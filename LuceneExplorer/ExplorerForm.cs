using LuceneExplorer.database;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LuceneExplorer
{
    public partial class ExplorerForm : System.Windows.Forms.Form
    {
        DirectoryInfo currentDirectory; // Biến toàn cục cho thư chọn hiện tại 
        FileInfo currentFileInfo; // Biến toàn cục cho file chọn hiện tại
        public ExplorerForm()
        {
            InitializeComponent();
            PopulateTreeView();

            Load_ImagesList();
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

            listView.SmallImageList.Images.Add(new Icon(@"..\..\resources\icons\folder_close.ico"));
            listView.SmallImageList.Images.Add(new Icon(@"..\..\resources\icons\document.ico"));
        }

        private void PopulateTreeView()
        {
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

        private void toolStripTextBox_Search_Click(object sender, EventArgs e)
        {
            toolStripTextBox_Search.Clear();

            toolStripTextBox_Search.ForeColor = Color.Black;
        }

        private void toolStripTextBox_Search_Leave(object sender, EventArgs e)
        {
            if (toolStripTextBox_Search.Text.Equals(String.Empty))
            {
                toolStripTextBox_Search.Text = "Search...";

                toolStripTextBox_Search.ForeColor = SystemColors.InactiveCaption;
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
                // FileInfo
                currentFileInfo = (FileInfo)listView.SelectedItems[0].Tag;

                Microsoft.Office.Interop.Word.Application ap = new Microsoft.Office.Interop.Word.Application();
                Document document = ap.Documents.Open(currentFileInfo.FullName);
                ap.Visible = true;
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
    }
}

