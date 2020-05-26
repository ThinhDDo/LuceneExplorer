using LuceneExplorer.config;
using LuceneExplorer.database;
using LuceneExplorer.models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace LuceneExplorer
{
    public partial class IndexingOptions_Form : Form
    {
        DirectoryInfo currentDirectory; // Biến toàn cục cho thư chọn hiện tại
        TreeNodeCollection locationsIndex = null;
        static List<FileType> types = null;

        ArrayList locations = new ArrayList();

        public IndexingOptions_Form()
        {
            InitializeComponent();

            lbl_done.Visible = false;

            PopulateTreeView();

            LoadComponents();

            GetListTypes();

            if (types == null)
            {
                SaveListTypes();
                GetListTypes();
            }

            // Danh sách các Locations Index 
            locations.Add(@"C:\Users\doduy\Downloads");
            // locations.Add(@"D:\");
        }

        /*
         * Hiển thị danh sách các node được check
         * Default: Truyền tham số là Node chứa thông tin ổ đĩa (vd: C:\, D:\)
         */
        private void scanLocationsIndex()
        {
            // Hiển thị danh sách Index Locations
            // Quét ổ đĩa gốc
            foreach (TreeNode parentNode in treeView_IncludedIndex.Nodes)
            {
                GetCheckedNodes(parentNode);
                if(locationsIndex != null)
                {
                    Console.WriteLine("Parent Node: " + parentNode.Name);
                    foreach (TreeNode node in locationsIndex)
                    {
                        Console.WriteLine("\tChild Node: " + node.Name);
                    }
                }
                else
                {
                    Console.WriteLine("Chưa có Locations nào được chọn");
                }
            }
        }

        /*
         * Sử dụng đệ quy quét các Child Node của TreeView
         * @Param node: Node parent
         */
        private void GetCheckedNodes(TreeNode node)
        {
            if(node.Checked)
            {
                locationsIndex.Add(node);
            }
            else
            {
                foreach (TreeNode subNode in node.Nodes)
                {
                    GetCheckedNodes(subNode);
                }
            }
        }

        private void GetListTypes()
        {
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

        private void SaveListTypes()
        {
            if (File.Exists(@"..\..\resources\filetypes\file_types.txt"))
            {
                string[] lines = File.ReadAllLines(@"..\..\resources\filetypess\file_types.txt");
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
            /*if (clb_types.SelectedIndex > -1)
            {
                txt_type.Text = clb_types.Items[clb_types.SelectedIndex] + "";
            }*/
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
                Console.Write("Item Check: " + clb_types.Items[selectedIdx].ToString() + "\t");
                Console.WriteLine("Current Check: " + clb_types.GetItemChecked(selectedIdx));
                Console.WriteLine("Changed Check: " + !clb_types.GetItemChecked(selectedIdx));
                Console.WriteLine("Item Check: " + clb_types.Items[selectedIdx].ToString());
                DbAccess.UpdateType(clb_types.Items[selectedIdx].ToString(), !clb_types.GetItemChecked(selectedIdx));

                clb_types.SetItemChecked(selectedIdx, !clb_types.GetItemChecked(selectedIdx));
            }
        }

        private void btn_rebuild_Click(object sender, EventArgs e)
        {
            Thread progressThread = new Thread(() =>
            {
                showProgress();
            });
            progressThread.Start();
            LuceneAccess.Initiate(locations);
            progressBar_Rebuild.Visible = false;
            lbl_done.Visible = true;
        }

        private void showProgress()
        {
            progressBar_Rebuild.Visible = true;
        }

        private void treeView_IncludedIndex_AfterCheck(object sender, TreeViewEventArgs e)
        {
            /*DirectoryInfo currentDirectoryInfo = (DirectoryInfo)e.Node.Tag;
            Console.WriteLine(currentDirectoryInfo.FullName, "Node selected");
            Console.WriteLine("Its child nodes: ");*/
            if(e.Node.Checked)
            {
                locationsIndex.Add(e.Node);
                foreach (TreeNode node in e.Node.Nodes)
                {
                    node.Checked = e.Node.Checked;
                }
            }
            if(!e.Node.Checked && locationsIndex.Contains(e.Node))
            {
                locationsIndex.Remove(e.Node);
            }
        }

        private void btn_addIndex_Click(object sender, EventArgs e)
        {
            
        }
    }
}
