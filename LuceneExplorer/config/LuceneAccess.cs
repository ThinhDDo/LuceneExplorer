using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.Search;
using Lucene.Net.Store;
using LuceneExplorer.database;
using LuceneExplorer.models;
using Spire.Pdf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Version = Lucene.Net.Util.Version;

namespace LuceneExplorer.config
{
    public class LuceneAccess
    {
        // Path to store index folder
        static DirectoryInfo indexDirIndex = null;
        static List<string> file_types = new List<string>();
        static Location locationIndexSaving = null;
        /*
         * Khởi tạo các thành phần chính cho Bộ đánh chỉ mục:
         * 1.. Bộ phân tích
         * 2.. Thư mục chứa Index
         * 3.. Bộ ghi chỉ mục
         * Thực hiện thu thập dữ liệu: Quét toàn bộ ổ đĩa trên máy tính (exclude: Ổ CD/DVD, External Drives,...)
         */
        public static bool Initiate()
        {
            // Lấy nơi lưu trữ index
            locationIndexSaving = DbAccess.GetLocationByName("Index");
            indexDirIndex = new DirectoryInfo(locationIndexSaving.Path);

            // Xử lý stopword, indexing.
            using (var analyzer = new StandardAnalyzer(Version.LUCENE_29))
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
            return true;
        }

        /*
         * Được chạy khi chương trình khởi động
         * Lần thứ 2 chạy nếu thư mục Index đã có dữ liệu không cần chạy
         */
        public static void ScanLocationsForIndex(List<Location> locations, StandardAnalyzer analyzer, FSDirectory indexDir, IndexWriter indexWriter)
        {
            // TODO: Lấy danh sách các Locations được chọn để thực hiện Index
            /*foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (!drive.Name.Equals(@"C:\"))
                {
                    BuildIndexFolders(drive.Name, analyzer, indexDir, indexWriter);
                }
            }*/

            foreach (Location location in locations)
            {
                if (!location.Path.Contains(@"RECYCLE.BIN"))
                {
                    Console.WriteLine("location: " + location.Name);
                    BuildIndexFolders(location.Path, analyzer, indexDir, indexWriter);
                }
            }
        }

        /*
         * Phương thức đánh chỉ mục các THƯ MỤC
         * Đối với thư mục con sẽ dùng đệ quy để đánh chỉ mục
         */
        public static void BuildIndexFolders(string path, StandardAnalyzer analyzer, FSDirectory indexDir, IndexWriter indexWriter)
        {
            // TODO: Thực hiện đánh chỉ mục cho path hiện tại
            Document document = new Document();

            // TODO: Update index
            /**
             * Cập nhật Index bằng cách xoá index cũ và thêm index mới
             * Xoá index cũ: Dùng IndexReader để tìm path trong Index hiện tại. Nếu có: Xoá. Nếu không: Thêm
             */

            document.Add(new Field("Name", Path.GetFileName(path), Field.Store.YES, Field.Index.ANALYZED));
            document.Add(new Field("Type", "folder", Field.Store.YES, Field.Index.NO)); 
            document.Add(new Field("Path", path, Field.Store.YES, Field.Index.NO)); 
            
            indexWriter.AddDocument(document);

            indexWriter.Optimize();
            indexWriter.Flush(false, false, false);

            try
            {
                if (!path.Contains(@"RECYCLE.BIN"))
                {
                    foreach (string folder in System.IO.Directory.GetDirectories(path))
                    {
                        Console.WriteLine("Thư mục: {0}", Path.GetDirectoryName(folder));
                        BuildIndexFolders(folder, analyzer, indexDir, indexWriter);
                    }
                }

            }
            catch (UnauthorizedAccessException uae)
            {
                Console.WriteLine("Không có quyền truy cập: {0}", path);
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

            using (var analyzer = new StandardAnalyzer(Version.LUCENE_29))
            {
                Lucene.Net.Store.Directory indexStore = FSDirectory.Open(indexDirIndex.FullName);

                // Truyền query vào IndexSearcher
                Searcher search = new IndexSearcher(IndexReader.Open(indexStore, true));

                // Tạo truy vấn tìm kiếm
                Query query = new WildcardQuery(new Term("Filename", $"*{keyword.ToLower()}*"));

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
                    results.Add(new Location { Name = foundDoc.Get("Name"), Path = foundDoc.Get("Path") , Type = foundDoc.Get("Type")});
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
        private static void BuildIndexFiles(string file, StandardAnalyzer analyzer, FSDirectory indexDir, IndexWriter indexWriter)
        {
            string toText = "";
            Document document;

            switch (Path.GetExtension(file))
            {
                case ".docx":
                    toText = WordToText(file);
                    break;
                case ".pdf":
                    toText = PdfToText(file);
                    break;
                case ".txt":
                    toText = TxtToText(file);
                    break;
            }

            // File Indexing
            document = new Document();

            document.Add(new Field("Filename", Path.GetFileName(file), Field.Store.YES, Field.Index.NOT_ANALYZED));
            document.Add(new Field("Path", file, Field.Store.YES, Field.Index.NOT_ANALYZED));
            document.Add(new Field("Content", toText.ToString().Trim().ToLower(), Field.Store.YES, Field.Index.ANALYZED));
            indexWriter.AddDocument(document);

            indexWriter.Optimize();
            indexWriter.Flush(false, false, false);
        }

        private static string PdfToText(string fullName)
        {
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(fullName);

            // Initilize StringBuilder Instance
            StringBuilder toText = new StringBuilder();

            for (int page = 0; page < doc.Pages.Count; page++)
            {
                toText.Append(doc.Pages[page].ExtractText());
            }

            return toText.ToString();
        }

        private static string TxtToText(string fullName)
        {
            StringBuilder toText = new StringBuilder();
            foreach (string line in File.ReadAllLines(fullName))
            {
                toText.AppendLine(line);
            }
            return toText.ToString();
        }

        private static string WordToText(string fullName)
        {
            Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application(); // Word APplication
            Microsoft.Office.Interop.Word.Document doc = word.Documents.Open(fullName);
            word.Visible = false;

            // Initilize StringBuilder Instance
            StringBuilder toText = new StringBuilder();

            //Extract Text from Word and Save to StringBuilder Instance
            foreach (Microsoft.Office.Interop.Word.Section section in doc.Sections)
            {
                foreach (Microsoft.Office.Interop.Word.Paragraph paragraph in section.Range.Paragraphs)
                {
                    toText.AppendLine(paragraph.Range.Text);
                }
            }
            return toText.ToString();
        }
    }
}
