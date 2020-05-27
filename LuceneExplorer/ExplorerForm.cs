using LuceneExplorer.database;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Icon = System.Drawing.Icon;
using Color = System.Drawing.Color;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.Office.Interop.PowerPoint;
using Microsoft.Office.Core;
using LuceneExplorer.config;
using LuceneExplorer.models;

namespace LuceneExplorer
{
    public partial class ExplorerForm : System.Windows.Forms.Form
    {
        DirectoryInfo currentDirectory; // Biến toàn cục cho thư chọn hiện tại 
        FileInfo currentFileInfo; // Biến toàn cục cho file chọn hiện tại
        string userName = Path.GetFileName(System.Security.Principal.WindowsIdentity.GetCurrent().Name);

        public ExplorerForm()
        {
            InitializeComponent();
            PopulateTreeView();

            Load_ImagesList();

            Console.WriteLine(userName);
        }

        private void Load_ImagesList()
        {
            // Thêm danh sách các icon
            treeView.ImageList = new ImageList();
            treeView.ImageList.Images.Add(new Icon(@"..\..\resources\icons\mycomputer.ico"));
            treeView.ImageList.Images.Add(new Icon(@"..\..\resources\icons\drive.ico"));
            treeView.ImageList.Images.Add(new Icon(@"..\..\resources\icons\folder_close.ico"));
            treeView.ImageList.Images.Add(new Icon(@"..\..\resources\icons\folder_open.ico"));
            treeView.ImageList.Images.Add(new Icon(@"..\..\resources\icons\document.ico"));
            treeView.ImageList.Images.Add(new Icon(@"..\..\resources\icons\quickaccess.ico"));
            treeView.ImageList.Images.Add(new Icon(@"..\..\resources\icons\downloads.ico"));
            treeView.ImageList.Images.Add(new Icon(@"..\..\resources\icons\documents.ico"));

            listView.SmallImageList.Images.Add(new Icon(@"..\..\resources\icons\folder_close.ico"));
            listView.SmallImageList.Images.Add(new Icon(@"..\..\resources\icons\document.ico"));
        }

        private void PopulateTreeView()
        {
            // Tạo một node root là This PC - hiện các ổ đĩa trong máy tính
            TreeNode quickAccess = new TreeNode("Quick Access"); // Tạo root node
            quickAccess.Tag = "Quick Access"; // 
            quickAccess.ImageIndex = 5; // Chọn image trong image list để hiển thị
            quickAccess.SelectedImageIndex = 5; // Chọn image trong image list để hiển thị khi ĐƯỢC NHẤN VÀO
            treeView.Nodes.Add(quickAccess); // Thêm node vào treeview
    
            
            DirectoryInfo userInfo = new DirectoryInfo(@"C:\Users\"+userName);
            foreach (DirectoryInfo userDirectory in userInfo.GetDirectories())
            {
                switch(userDirectory.Name)
                {
                    case "Downloads":
                        TreeNode downloads = new TreeNode("Downloads"); // Tạo root node
                        downloads.Tag = userDirectory; // 
                        downloads.ImageIndex = 6; // Chọn image trong image list để hiển thị
                        downloads.SelectedImageIndex = 6; // Chọn image trong image list để hiển thị khi ĐƯỢC NHẤN VÀO
                        quickAccess.Nodes.Add(downloads); // Thêm node vào treeview
                        break;
                    case "Documents":
                        TreeNode documents = new TreeNode("Documents"); // Tạo root node
                        documents.Tag = userDirectory; // 
                        documents.ImageIndex = 7; // Chọn image trong image list để hiển thị
                        documents.SelectedImageIndex = 7; // Chọn image trong image list để hiển thị khi ĐƯỢC NHẤN VÀO
                        quickAccess.Nodes.Add(documents); // Thêm node vào treeview
                        break;
                    default:
                        break;
                }
            }

            // =============================================================================================
            // Tạo một node root là This PC - hiện các ổ đĩa trong máy tính
            TreeNode thisPCNode = new TreeNode("This PC"); // Tạo root node
            thisPCNode.Tag = "This PC"; // 
            thisPCNode.ImageIndex = 0; // Chọn image trong image list để hiển thị
            thisPCNode.SelectedImageIndex = 0; // Chọn image trong image list để hiển thị khi ĐƯỢC NHẤN VÀO
            treeView.Nodes.Add(thisPCNode); // Thêm node vào treeview

            // Lấy các ổ đĩa trong máy tính - đưa vào trong root node (This PC)
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                TreeNode driveNode = new TreeNode(drive.Name); // Tạo node với drive.Name là tên ổ đĩa (vd: C:/)
                driveNode.Tag = drive.RootDirectory; // Trả về Thư mục gốc (C:\\ và D:\\)
                driveNode.ImageIndex = 1;
                driveNode.SelectedImageIndex = 1;
                thisPCNode.Nodes.Add(driveNode);
            }
        }

        private void Form_Load(object sender, EventArgs e)
        {
            toolStrip_Address_Resize(this, e);
        }

        private void toolStrip_Address_Resize(object sender, EventArgs e)
        {
            txt_Address.Width = this.Width - toolStripLabel_Address.Bounds.Width - toolStripButton_Go.Bounds.Width - 35;
        }

        private void toolStripTextBox_Search_Leave(object sender, EventArgs e)
        {
            if (txt_search.Text.Equals(String.Empty))
            {
                txt_search.Text = "Search...";

                txt_search.ForeColor = SystemColors.InactiveCaption;
            }
        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode selectedNode = treeView.SelectedNode;
            if (selectedNode.Tag.GetType() == typeof(DirectoryInfo)) // Kiểm tra Node hiện tại có phải là Thư mục hay không
            {
                // Hiển thị địa chỉ lên Address Bar textbox
                txt_Address.Text = selectedNode.FullPath.Replace("This PC\\", "").Replace(@"\\", @"\");

                // Bỏ chọn node trước đó
                selectedNode.Nodes.Clear();
                
                // Thêm các node vào thư mục con
                DirectoryInfo dir = (DirectoryInfo)selectedNode.Tag;

                // Lấy tất cả các thư mục, files bằng method: GetDirectories()
                // Thêm node con vào node hiện tại đang chọn, 
                // nhấp vào dấu cộng để hiển thị các node con
                try
                {
                    foreach (DirectoryInfo subDirectory in dir.GetDirectories())
                    {
                        TreeNode subNode = new TreeNode(subDirectory.Name);
                        subNode.Tag = subDirectory; // Chứa dữ liệu của treenode
                        subNode.ImageIndex = 2;
                        subNode.SelectedImageIndex = 3;
                        selectedNode.Nodes.Add(subNode);
                    }

                    // Hiển thị bên list view
                    // Đưa dữ liệu của node đang chọn vào biến toàn cục
                    currentDirectory = dir;

                    // Hiển thị dữ liệu (thư mục, files) bên Listview
                    OpenDirectory();
                }
                catch (UnauthorizedAccessException uae)
                {
                    // Reset lại node đã có
                    //selectedNode.Nodes.Clear();
                    MessageBox.Show("Không có quyền truy cập", "Thông báo");
                }
            }
            else // Nếu không phải thư mục
            {
                ; // Do nothing
            }

            // Tự động mở rộng Node khi chọn
            selectedNode.Expand();
        }

        /*
         * Mở danh sách thư mục tương ứng qua ListView
         */
        private void OpenDirectory()
        {
            // Clear các item hiển thị trên listview trước đó
            listView.Items.Clear();

            if(currentDirectory != null)
            {
                // Hiển thị các THƯ MỤC trong ListView
                foreach (DirectoryInfo subDirectory in currentDirectory.GetDirectories())
                {
                    // Name - 1st Column
                    ListViewItem listViewItem = listView.Items.Add(subDirectory.Name);
                    listViewItem.Tag = subDirectory; // Đưa dữ liệu của subDirectory vào item
                    listViewItem.ImageIndex = 0; // chọn image của item (đã được lưu vào listView.SmallImageList)

                    // Date Modified - 2nd Column
                    listViewItem.SubItems.Add(subDirectory.LastWriteTime.ToString()); // Ngày sửa đổi gần nhất

                    // Type - 3rd Column
                    listViewItem.SubItems.Add("Folder"); // Loại tập tin

                    // Size - 4nd
                    listViewItem.SubItems.Add(""); // TO-DO: Kích thước tập tin
                }

                // Hiển thị các FILE trong ListView
                foreach (FileInfo file in currentDirectory.GetFiles())
                {
                    // Name - 1st Column
                    ListViewItem listViewItem = listView.Items.Add(file.Name);
                    listViewItem.Tag = file; // Lưu trữ data của File vào mỗi item
                    listViewItem.ImageIndex = 1; // chọn image của item (đã được lưu vào listView.SmallImageList)

                    // Date Modified - 2nd Column
                    listViewItem.SubItems.Add(file.LastWriteTime.ToString()); // Ngày sửa đổi gần nhất

                    // Type - 3rd Column
                    listViewItem.SubItems.Add("File"); // Loại tập tin

                    // Size - 4nd
                    listViewItem.SubItems.Add(file.Length.ToString()); // TO-DO: Kích thước tập tin
                }

            }
            
            // Tự động auto size cột listview
            listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        /*
         * Double Click để mở thư mục trong ListView
         */
        private void listView_DoubleClick_1(object sender, EventArgs e)
        {
            if (listView.SelectedItems[0].Tag.GetType() == typeof(DirectoryInfo)) {
                currentDirectory = (DirectoryInfo)listView.SelectedItems[0].Tag;
                OpenDirectory();
            } 
            else
            {
                // Current FileInfo Data 
                currentFileInfo = (FileInfo)listView.SelectedItems[0].Tag;
                if (currentFileInfo.Exists && (currentFileInfo.Extension.Equals(".docx") || currentFileInfo.Extension.Equals(".doc")))
                {

                    Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
                    Document document = word.Documents.Open(currentFileInfo.FullName);
                    word.Visible = true;
                }
                else if (currentFileInfo.Exists && (currentFileInfo.Extension.Equals(".xlsx") || currentFileInfo.Extension.Equals(".xls")))
                {
                    Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                    Workbook document = excel.Workbooks.Open(currentFileInfo.FullName);
                    excel.Visible = true;
                }
                else if (currentFileInfo.Exists && (currentFileInfo.Extension.Equals(".pptx") || currentFileInfo.Extension.Equals(".ppt")))
                {
                    Microsoft.Office.Interop.PowerPoint.Application pp = new Microsoft.Office.Interop.PowerPoint.Application();
                    Presentation document = pp.Presentations.Open(currentFileInfo.FullName, MsoTriState.msoFalse, MsoTriState.msoFalse, MsoTriState.msoTrue);
                    pp.Visible = MsoTriState.msoTrue;
                }
            }
            // OpenDirectory();
        }

        /*
         * Xử lý chức năng Delete folder hoặc file: Di chuyen vao Recycle Bin
         */
        private void deleteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            //currentDirectory = (DirectoryInfo)listView.SelectedItems[0].Tag;
            MessageBox.Show(currentDirectory.FullName);
        }

        /*
         * Xử lý Right Click trong ListView cho các chức năng phụ
         */
        private void listView_MouseClick_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (listView.FocusedItem.Bounds.Contains(e.Location))
                {
                    contextmenu_listview_options.Show(Cursor.Position);
                }
            }
        }

        /**
         * Hiển thị Menu Option để tuỳ chỉnh đánh chỉ mục
         * Default Index Folder: ....
         */
        private void indexingOptions_ToolStrip_Click(object sender, EventArgs e)
        {
            IndexingOptions_Form fIndexOption = new IndexingOptions_Form();
            fIndexOption.ShowDialog();
            this.Show();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            OpenDirectory();
        }

        private void toolStripTextBox_Search_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if(!txt_search.Text.Equals(String.Empty))
                {
                    List<Location> search_results = LuceneAccess.SearchQuery(txt_search.Text.Trim());

                    // Hiển thị lên listview
                    OpenLocations(search_results);
                }
            }
        }

        /*
         * Mở danh sách thư mục tương ứng qua ListView
         */
        private void OpenLocations(List<Location> locations)
        {
            // Clear các item hiển thị trên listview trước đó
            listView.Items.Clear();

            if(currentDirectory != null)
            {
                txt_Address.Text = "Search Results in " + currentDirectory.Name;
            }
            
            if(Directory.Exists(locations[0].Path))
            {
                DirectoryInfo locationInfo = new DirectoryInfo(locations[0].Path);
                listView.Columns.Add("Path", 200, HorizontalAlignment.Left);

                txt_Address.Text = "Search Results in " + locationInfo.Name;

                // Name - 1st Column
                ListViewItem listViewItem = listView.Items.Add(locationInfo.Name);
                listViewItem.Tag = locationInfo; // Đưa dữ liệu của subDirectory vào item
                listViewItem.ImageIndex = 0; // chọn image của item (đã được lưu vào listView.SmallImageList)

                // Date Modified - 2nd Column
                listViewItem.SubItems.Add(locationInfo.LastWriteTime.ToString()); // Ngày sửa đổi gần nhất

                // Type - 3rd Column
                listViewItem.SubItems.Add("Folder"); // Loại tập tin

                // Size - 4nd
                listViewItem.SubItems.Add(""); // TO-DO: Kích thước tập tin

                // Path - 5th
                listViewItem.SubItems.Add(locationInfo.FullName);
            }
            
            // Tự động auto size cột listview
            listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void txt_search_Click(object sender, EventArgs e)
        {
            txt_search.Clear();

            txt_search.ForeColor = Color.Black;
        }
    }
}

