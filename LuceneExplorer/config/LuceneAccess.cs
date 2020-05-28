using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;
using Lucene.Net.Store;
using LuceneExplorer.database;
using LuceneExplorer.models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TikaOnDotNet.TextExtraction;
using Version = Lucene.Net.Util.Version;

namespace LuceneExplorer.config
{
    public class LuceneAccess
    {
        // Path to store index folder
        static List<FileType> file_types = DbAccess.GetTypes();
        static Location locationIndexSaving = DbAccess.GetLocationByName("Index");
        static DirectoryInfo indexDirIndex = new DirectoryInfo(locationIndexSaving.Path);
        static Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application(); // Word APplication
        /*
         * Khởi tạo các thành phần chính cho Bộ đánh chỉ mục:
         * 1.. Bộ phân tích
         * 2.. Thư mục chứa Index
         * 3.. Bộ ghi chỉ mục
         * Thực hiện thu thập dữ liệu: Quét toàn bộ ổ đĩa trên máy tính (exclude: Ổ CD/DVD, External Drives,...)
         */
        public static bool Initiate()
        {
            // Xử lý stopword, indexing.
            using (var analyzer = new StandardAnalyzer(Version.LUCENE_29, new FileInfo(@"..\..\resources\stopwords\stopwords.txt")))
            {
                // TODO: User có thể chọn nơi lưu trữ Index (Default: Ổ C)
                using (var indexDir = FSDirectory.Open(indexDirIndex.FullName))
                {
                    using (var indexWriter = new IndexWriter(indexDir, analyzer, IndexWriter.MaxFieldLength.UNLIMITED))
                    {
                        // TODO: Scan các thư mục được chọn để Index
                        List<Location> locations = DbAccess.GetLocations();
                        ScanLocationsForIndex(locations, analyzer, indexDir, indexWriter);
                    }
                }
            }
            
            return true; // Condidion Multithread stop.
        }

        /*
         * Được chạy khi chương trình khởi động
         * Lần thứ 2 chạy nếu thư mục Index đã có dữ liệu không cần chạy
         */
        public static void ScanLocationsForIndex(List<Location> locations, StandardAnalyzer analyzer, FSDirectory indexDir, IndexWriter indexWriter)
        {

            foreach (Location location in locations)
            {
                if (!location.Name.Contains(@"$RECYCLE.BIN"))
                {
                    location.Type = "folder";

                    Console.WriteLine("Root location: " + location.Name);
                    BuildIndexFolders(location, analyzer, indexDir, indexWriter, 0);
                }
            }
        }

        /*
         * Phương thức đánh chỉ mục các THƯ MỤC
         * Đối với thư mục con sẽ dùng đệ quy để đánh chỉ mục
         */
        public static void BuildIndexFolders(Location location, StandardAnalyzer analyzer, FSDirectory indexDir, IndexWriter indexWriter, int depth_folder)
        {
            if(depth_folder == 7)
            {
                return;
            }

            // TODO: Update index
            /**
             * Cập nhật Index bằng cách xoá index cũ và thêm index mới
             * Xoá index cũ: Dùng IndexReader để tìm path trong Index hiện tại. Nếu có: Xoá. Nếu không: Thêm
             */
            // TODO: Thực hiện đánh chỉ mục cho path hiện tại
            Document document = new Document();

            document.Add(new Field("Name", location.Name, Field.Store.YES, Field.Index.ANALYZED));
            document.Add(new Field("Type", location.Type, Field.Store.YES, Field.Index.NO));
            document.Add(new Field("Path", location.Path, Field.Store.YES, Field.Index.NO));

            indexWriter.UpdateDocument(new Term("Path", $"{location.Path}"), document);

            indexWriter.Optimize();
            indexWriter.Flush(false, false, false);

            try
            {
                if (!location.Name.Contains(@"$RECYCLE.BIN"))
                {
                    // Đánh chỉ mục tất cả các thư mục con trong thư mục cha
                    foreach (string folder in System.IO.Directory.GetDirectories(location.Path))
                    {
                        Console.WriteLine("Folder indexing: {0}", Path.GetDirectoryName(folder));
                        BuildIndexFolders(
                            new Location { Name = Path.GetFileName(folder), Path = folder, Type = "folder"}, 
                            analyzer, 
                            indexDir, 
                            indexWriter, 
                            depth_folder++);
                    }
                    // Đánh chỉ mục tất cả các file trong thư mục cha
                    foreach (string file in System.IO.Directory.GetFiles(location.Path))
                    {
                        Console.WriteLine("File indexing: {0}", Path.GetDirectoryName(file));
                        BuildIndexFiles(
                            new Location { Name = Path.GetFileName(file), Path = file, Type = Path.GetExtension(file) },
                            analyzer,
                            indexDir,
                            indexWriter);
                    }
                }

            }
            catch (UnauthorizedAccessException uae)
            {
                Console.WriteLine("Không có quyền truy cập: {0}", location.Path);
            }
            finally
            {
                ;
            }
        }

        /*
         * Phương thức tìm kiếm văn bản
         */
        public static List<Location> SearchQuery(string keyword)
        {
            // Biến toàn cục: Nơi lưu trữ các index
            Console.WriteLine("\n\n\n\n");
            Console.WriteLine("Keyword: " + keyword);
            using (var analyzer = new StandardAnalyzer(Version.LUCENE_29))
            {
                Lucene.Net.Store.Directory indexStore = FSDirectory.Open(indexDirIndex.FullName);
                if (indexStore.FileExists(IndexWriter.WRITE_LOCK_NAME))
                {
                    try
                    {
                        indexStore.ClearLock(IndexWriter.WRITE_LOCK_NAME);
                    }catch(IOException ioe)
                    {
                        Console.WriteLine("write.lock are being use by other process");
                    }
                    
                }

                // Truyền query vào IndexSearcher
                Searcher search = new IndexSearcher(IndexReader.Open(indexStore, true));

                var fields = new[] { "Name", "Type", "Content", "Path" };
                var queryParser = new MultiFieldQueryParser(Version.LUCENE_29, fields, analyzer);
                // Tạo truy vấn tìm kiếm
                var query = queryParser.Parse($"{keyword.ToLower()}*");

                /*Bắt đầu tìm kiếm. Có rất nhiều cách tìm kiếm @@
                Cách 1: Tìm dựa theo số lần xuất hiện*/
                TopScoreDocCollector cllctr = TopScoreDocCollector.Create(10, true); // true: bật sắp xếp theo thứ tự
                // Lấy các kết quả đạt yêu cầu query
                var hits = search.Search(query, 1000).ScoreDocs;
                // ScoreDoc[] hits = cllctr.TopDocs().ScoreDocs;

                // Vòng lặp lấy kết quả
                Console.WriteLine("Đã tìm thấy: {0} kết quả", hits.Length);

                List<Location> results = new List<Location>(hits.Length);
                foreach (var hit in hits)
                {
                    var foundDoc = search.Doc(hit.Doc);
                    Console.WriteLine("Folder: {0}, Path: {1}", foundDoc.Get("Name"), foundDoc.Get("Path"));
                    results.Add(new Location { Name = foundDoc.Get("Name"), Path = foundDoc.Get("Path"), Type = foundDoc.Get("Type") , Content = foundDoc.Get("Content")});
                }
                return results;
                /*for(int hit_idx=0; hit_idx < hits.Length; hit_idx++)
                {
                    if(hit_idx == 0)
                    {
                        var foundDoc = search.Doc(hits[hit_idx].Doc);
                        Console.WriteLine("Root folder: {0}, File name: {1}", foundDoc.Get("Path"), foundDoc.Get("Filename"));
                    } else
                    {
                        var foundDoc = search.Doc(hits[hit_idx].Doc);
                        Console.WriteLine("Folder name: {0}", foundDoc.Get("Path"));
                    }
                }*/
            }
        }

        /**
         * Đánh chỉ mục cho file:
         * Nội dung chỉ mục file bao gồm: Name, Path, Type, Content
         */
        private static void BuildIndexFiles(Location location, StandardAnalyzer analyzer, FSDirectory indexDir, IndexWriter indexWriter)
        {
            string toText = "";
            Document document;

            FileType temp = new FileType { TenType = location.Type.Replace(".", ""), IsUse = true };
            bool read = false;
            foreach(FileType type in file_types)
            {
                if(type.Equals(temp))
                {
                    read = true;
                }
            }
            if (read)
            {
                // Extract all text from document
                switch (location.Type)
                {
                    case ".docx":
                        toText = WordToText(location.Path);
                        break;
                    case ".pdf":
                        toText = PdfToText(location.Path);
                        break;
                    case ".txt":
                        toText = TxtToText(location.Path);
                        break;
                }
            }
            
            // File Indexing
            document = new Document();

            document.Add(new Field("Name", location.Name, Field.Store.YES, Field.Index.ANALYZED));
            document.Add(new Field("Type", "file", Field.Store.YES, Field.Index.NOT_ANALYZED));
            document.Add(new Field("Path", location.Path, Field.Store.YES, Field.Index.NOT_ANALYZED));
            document.Add(new Field("Content", toText.Trim().ToLower(), Field.Store.YES, Field.Index.ANALYZED));
            indexWriter.UpdateDocument(new Term("Path", $"{location.Path}"), document); 

            indexWriter.Optimize();
            indexWriter.Flush(false, false, false);
        }

        private static string PdfToText(string fullName)
        {
            /*PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(fullName);

            // Initilize StringBuilder Instance
            StringBuilder toText = new StringBuilder();

            for (int page = 0; page < doc.Pages.Count; page++)
            {
                toText.Append(doc.Pages[page].ExtractText());
            }
            */
            var text = new TextExtractor().Extract(fullName).Text;
            return text;
        }

        private static string TxtToText(string fullName)
        {
            /*StringBuilder toText = new StringBuilder();
            foreach (string line in File.ReadAllLines(fullName))
            {
                toText.AppendLine(line);
            }
            return toText.ToString();*/
            return new TextExtractor().Extract(fullName).Text;
        }

        private static string WordToText(string fullName)
        {
            /*word.Visible = false;
            Microsoft.Office.Interop.Word.Document doc;
            // Initilize StringBuilder Instance
            StringBuilder toText = new StringBuilder();
            
            try
            {
                if (!Path.GetFileName(fullName).StartsWith("~$"))
                {
                    doc = word.Documents.Open(fullName);
                    //Extract Text from Word and Save to StringBuilder Instance
                    foreach (Microsoft.Office.Interop.Word.Section section in doc.Sections)
                    {
                        foreach (Microsoft.Office.Interop.Word.Paragraph paragraph in section.Range.Paragraphs)
                        {
                            toText.AppendLine(paragraph.Range.Text);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Open file word failed");
            } finally
            {
                ;
            }
            return toText.ToString();*/
            return new TextExtractor().Extract(fullName).Text;
        }
    }
}
