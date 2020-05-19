using LuceneExplorer.database;
using LuceneExplorer.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LuceneExplorer
{
    public partial class IndexingOptions_Form : Form
    {
        DirectoryInfo currentDirectory; // Biến toàn cục cho thư chọn hiện tại
        private static List<FileType> types = null;

        public IndexingOptions_Form()
        {
            InitializeComponent();
            PopulateTreeView();

            LoadComponents();
            if(types == null)
            {
                SaveListTypes();
            }
        }

        private void SaveListTypes()
        {
            if(File.Exists(@"..\..\resources\filetypes\file_01.txt"))
            {
                string[] lines = File.ReadAllLines(@"..\..\resources\filetypes\file_01.txt");
                try
                {
                    DbAccess.setTypes(lines);
                    Console.WriteLine("Lưu danh sách Type thành công");
                }
                catch (SqlException sqle)
                {
                    Console.WriteLine("Lưu type thất bại");
                }
            }
            try
            {
                types = DbAccess.GetTypes();
                Console.WriteLine("Load danh sách Type thành công");
            }
            catch (SqlException sqle)
            {
                Console.WriteLine("Load type thất bại");
            }
        }

        private void LoadComponents()
        {
            if(txt_type.Text.Equals(String.Empty))
            {
                btn_addType.Enabled = false;
            }
        }

        private void PopulateTreeView()
        {
            // Lấy các ổ đĩa trong máy tính - đưa vào trong root node (This PC)
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if(drive.Name.Equals(@"C:\"))
                {
                    TreeNode driveNode = new TreeNode("Local Disk " + drive.Name); // Tạo node với drive.Name là tên ổ đĩa (vd: C:/)
                    driveNode.Tag = drive.RootDirectory; // Trả về Thư mục gốc (C:\\ và D:\\)
                    driveNode.ImageIndex = 1;
                    driveNode.SelectedImageIndex = 1;
                    treeView_IncludedIndex.Nodes.Add(driveNode);
                }
                else
                {
                    TreeNode driveNode = new TreeNode(drive.VolumeLabel + " " + drive.Name); // Tạo node với drive.Name là tên ổ đĩa (vd: C:/)
                    driveNode.Tag = drive.RootDirectory; // Trả về Thư mục gốc (C:\\ và D:\\)
                    driveNode.ImageIndex = 1;
                    driveNode.SelectedImageIndex = 1;
                    treeView_IncludedIndex.Nodes.Add(driveNode);
                }
            }
        }

        private void treeView_IncludedIndex_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode selectedNode = treeView_IncludedIndex.SelectedNode;
            if (selectedNode.Tag.GetType() == typeof(DirectoryInfo)) // Kiểm tra Node hiện tại có phải là Thư mục hay không
            {
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

        private void btn_addType_Click(object sender, EventArgs e)
        {
            if(!txt_type.Text.Equals(String.Empty))
            {
                clb_types.Items.Add(txt_type.Text.Trim(), false);
                txt_type.Clear();
            }
        }

        private void clb_types_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (clb_types.SelectedIndex > -1)
            {
                txt_type.Text = clb_types.Items[clb_types.SelectedIndex] + "";
            }
        }

        private void txt_type_TextChanged(object sender, EventArgs e)
        {
            if (txt_type.Text.Equals(String.Empty))
            {
                btn_addType.Enabled = false;
            }
            else
            {
                btn_addType.Enabled = true;
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            clb_types.Items.RemoveAt(clb_types.SelectedIndex);
            txt_type.Clear();
        }

        private void txt_searchType_TextChanged(object sender, EventArgs e)
        {
            if(!txt_searchType.Text.Equals(String.Empty))
            {
                int foundType = clb_types.FindStringExact(txt_searchType.Text.Trim());
                if(foundType > -1)
                {
                    clb_types.SetSelected(foundType, true);
                }
            }
        }

        private void tab_index_Selected(object sender, TabControlEventArgs e)
        {
            if(types != null)
            {
                foreach (FileType type in types)
                {
                    if (!type.Equals(String.Empty))
                    {
                        clb_types.Items.Add(type.TenType);
                        clb_types.SetItemChecked(clb_types.Items.IndexOf(type.TenType), type.IsUse);
                    }
                }
            } else
            {
                MessageBox.Show("Chưa có dữ liệu các Extension");
            }
           
        }

        private void clb_types_Click(object sender, EventArgs e)
        {
            int selectedIdx = clb_types.SelectedIndex;
            if (selectedIdx > -1)
            {
                txt_type.Text = clb_types.Items[selectedIdx] + "";
                if(clb_types.GetItemChecked(selectedIdx))
                {
                    DbAccess.UpdateType(txt_type.Text.Trim(), 0);

                    clb_types.SetItemChecked(selectedIdx, true);

                    updateList(new FileType(txt_type.Text, true));
                }
                else
                {
                    DbAccess.UpdateType(txt_type.Text.Trim(), 1);

                    clb_types.SetItemChecked(selectedIdx, true);

                    updateList(new FileType(txt_type.Text, false));
                }
            }
        }

        private void updateList(FileType type)
        {
            int idx = types.IndexOf(type);
            if(idx > -1)
            {
                types[idx].IsUse = (!type.IsUse);
            }
        }
    }
}
