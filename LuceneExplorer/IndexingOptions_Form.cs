using LuceneExplorer.config;
using LuceneExplorer.database;
using LuceneExplorer.models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace LuceneExplorer
{
    public partial class IndexingOptions_Form : Form
    {
        DirectoryInfo currentDirectory; // Biến toàn cục cho thư chọn hiện tại
        List<TreeNode> locationsIndex = null;
        static List<FileType> types = null;
        bool rebuilt = false;
        ArrayList locations = new ArrayList();
        Thread progressThread;
        List<Location> locationsForIndex;

        public IndexingOptions_Form()
        {
            InitializeComponent();

            lbl_done.Visible = false;

            LoadComponents();

            GetListTypes();

            if (types == null)
            {
                SaveListTypes();
                GetListTypes();
            }

            // Danh sách các Locations Index 
            locations.Add(@"C:\Users\doduy\Downloads\Compressed");
            // locations.Add(@"D:\");
            locationsIndex = new List<TreeNode>();
            // Mở các thư mục đang được đánh chỉ mục
            OpenLocations();
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
            if(!DbAccess.GetLocationByName("Index").Path.Equals(String.Empty))
            {
                progressBar_Rebuild.Visible = true;
                btn_stop.Visible = true;
                progressThread = new Thread(new ThreadStart(Build_Index));
                progressThread.Start();
            }else
            {
                MessageBox.Show("Bạn chưa chọn nơi lưu trữ Index");
            }
            
        }

        private void Build_Index()
        {
            rebuilt = LuceneAccess.Initiate();
            if(rebuilt)
            {
                this.progressBar_Rebuild.Invoke(new MethodInvoker(delegate
                {
                    progressBar_Rebuild.Visible = false;
                }));
                this.btn_stop.Invoke(new MethodInvoker(delegate
                {
                    btn_stop.Visible = false;
                }));
            }
        }

        private void treeView_IncludedIndex_AfterCheck(object sender, TreeViewEventArgs e)
        {
            /*DirectoryInfo currentDirectoryInfo = (DirectoryInfo)e.Node.Tag;
            Console.WriteLine(currentDirectoryInfo.FullName, "Node selected");
            Console.WriteLine("Its child nodes: ");*/
            if(e.Node != null)
            {
                if (e.Node.Checked)
                {
                    locationsIndex.Add(e.Node);
                    Console.WriteLine("Node Added");
                    foreach (TreeNode node in e.Node.Nodes)
                    {
                        node.Checked = e.Node.Checked;
                    }
                }
                if (!e.Node.Checked && locationsIndex.Contains(e.Node))
                {
                    locationsIndex.Remove(e.Node);
                    Console.WriteLine("Node Removed");
                }
            }
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            progressThread.Abort();
            progressBar_Rebuild.Visible = false;
            btn_stop.Visible = false;
        }

        private void btn_openIndexDialog_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog indexDialog = new FolderBrowserDialog();

            if (indexDialog.ShowDialog() == DialogResult.OK)
            {
                if(!indexDialog.SelectedPath.Equals(String.Empty))
                {
                    DbAccess.UpdateLocation(new Location { Name = "Index", Path = indexDialog.SelectedPath });
                }
            }
        }

        private void btn_OpenIndex_Click(object sender, EventArgs e)
        {
            Location location = DbAccess.GetLocationByName("Index");
            if(!location.Path.Equals(String.Empty))
            {
                if(Directory.Exists(location.Path))
                {
                    Process.Start("explorer.exe", location.Path);
                } else
                {
                    MessageBox.Show("Thư mục không tồn tại");
                }
            } else
            {
                MessageBox.Show("Bạn chưa chọn thư mục Index");
            }
        }

        private void btn_addIndex_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog newLocationDialog = new FolderBrowserDialog();
            if (newLocationDialog.ShowDialog() == DialogResult.OK)
            {
                if (!newLocationDialog.SelectedPath.Equals(String.Empty))
                {
                    string newLocationPath = newLocationDialog.SelectedPath;
                    if(Directory.Exists(newLocationPath))
                    {
                        Location newLocation = new Location { Name = Path.GetFileName(newLocationPath), Path = newLocationPath };
                        DbAccess.SetLocation(newLocation);
                    }
                }
            }
            OpenLocations();
        }

        private void OpenLocations()
        {
            listViewLocations.Items.Clear();
            locationsForIndex = DbAccess.GetLocations();
            foreach (Location location in locationsForIndex)
            {
                Console.WriteLine("Path: {0}", location.Path);
                ListViewItem item = listViewLocations.Items.Add(location.Name);
                item.SubItems.Add(location.Path);
            }
        }
    }
}
