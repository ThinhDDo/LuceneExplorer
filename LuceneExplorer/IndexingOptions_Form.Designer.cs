﻿namespace LuceneExplorer
{
    partial class IndexingOptions_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IndexingOptions_Form));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tab_index = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lbl_done = new System.Windows.Forms.Label();
            this.progressBar_Rebuild = new System.Windows.Forms.ProgressBar();
            this.btn_rebuild = new System.Windows.Forms.Button();
            this.btn_openIndexDialog = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txt_searchType = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_type = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.btn_addType = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.clb_types = new System.Windows.Forms.CheckedListBox();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.listViewLocations = new System.Windows.Forms.ListView();
            this.IncludedLocations = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LocationsPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lbl_indexSavePath = new System.Windows.Forms.Label();
            this.btn_OpenIndex = new System.Windows.Forms.Button();
            this.btn_deleteIndex = new System.Windows.Forms.Button();
            this.btn_addIndex = new System.Windows.Forms.Button();
            this.btn_stop = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.tab_index.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tab_index);
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(399, 447);
            this.panel1.TabIndex = 2;
            // 
            // tab_index
            // 
            this.tab_index.Controls.Add(this.tabPage1);
            this.tab_index.Controls.Add(this.tabPage2);
            this.tab_index.Location = new System.Drawing.Point(4, 4);
            this.tab_index.Name = "tab_index";
            this.tab_index.SelectedIndex = 0;
            this.tab_index.Size = new System.Drawing.Size(392, 440);
            this.tab_index.TabIndex = 0;
            this.tab_index.Tag = "";
            this.tab_index.Selected += new System.Windows.Forms.TabControlEventHandler(this.tab_index_Selected);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btn_deleteIndex);
            this.tabPage1.Controls.Add(this.btn_addIndex);
            this.tabPage1.Controls.Add(this.btn_stop);
            this.tabPage1.Controls.Add(this.btn_OpenIndex);
            this.tabPage1.Controls.Add(this.lbl_indexSavePath);
            this.tabPage1.Controls.Add(this.lbl_done);
            this.tabPage1.Controls.Add(this.progressBar_Rebuild);
            this.tabPage1.Controls.Add(this.btn_rebuild);
            this.tabPage1.Controls.Add(this.btn_openIndexDialog);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(384, 414);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Index";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lbl_done
            // 
            this.lbl_done.AutoSize = true;
            this.lbl_done.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_done.Location = new System.Drawing.Point(159, 390);
            this.lbl_done.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_done.Name = "lbl_done";
            this.lbl_done.Size = new System.Drawing.Size(63, 16);
            this.lbl_done.TabIndex = 3;
            this.lbl_done.Text = "DONE!!!";
            this.lbl_done.Visible = false;
            // 
            // progressBar_Rebuild
            // 
            this.progressBar_Rebuild.Location = new System.Drawing.Point(7, 385);
            this.progressBar_Rebuild.Margin = new System.Windows.Forms.Padding(2);
            this.progressBar_Rebuild.MarqueeAnimationSpeed = 200;
            this.progressBar_Rebuild.Name = "progressBar_Rebuild";
            this.progressBar_Rebuild.Size = new System.Drawing.Size(336, 26);
            this.progressBar_Rebuild.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar_Rebuild.TabIndex = 2;
            this.progressBar_Rebuild.Visible = false;
            // 
            // btn_rebuild
            // 
            this.btn_rebuild.Location = new System.Drawing.Point(206, 344);
            this.btn_rebuild.Name = "btn_rebuild";
            this.btn_rebuild.Size = new System.Drawing.Size(86, 36);
            this.btn_rebuild.TabIndex = 1;
            this.btn_rebuild.Text = "Rebuild chỉ mục";
            this.btn_rebuild.UseVisualStyleBackColor = true;
            this.btn_rebuild.Click += new System.EventHandler(this.btn_rebuild_Click);
            // 
            // btn_openIndexDialog
            // 
            this.btn_openIndexDialog.Location = new System.Drawing.Point(98, 344);
            this.btn_openIndexDialog.Name = "btn_openIndexDialog";
            this.btn_openIndexDialog.Size = new System.Drawing.Size(102, 36);
            this.btn_openIndexDialog.TabIndex = 1;
            this.btn_openIndexDialog.Text = "Thay đổi Index Path";
            this.btn_openIndexDialog.UseVisualStyleBackColor = true;
            this.btn_openIndexDialog.Click += new System.EventHandler(this.btn_openIndexDialog_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listViewLocations);
            this.groupBox1.Location = new System.Drawing.Point(7, 7);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox1.Size = new System.Drawing.Size(371, 334);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách chỉ mục";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txt_searchType);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.txt_type);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.btn_Delete);
            this.tabPage2.Controls.Add(this.btn_addType);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(384, 414);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "File Types";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txt_searchType
            // 
            this.txt_searchType.Location = new System.Drawing.Point(271, 360);
            this.txt_searchType.Name = "txt_searchType";
            this.txt_searchType.Size = new System.Drawing.Size(101, 20);
            this.txt_searchType.TabIndex = 5;
            this.txt_searchType.TextChanged += new System.EventHandler(this.txt_searchType_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(268, 343);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tìm extension:";
            // 
            // txt_type
            // 
            this.txt_type.Location = new System.Drawing.Point(12, 360);
            this.txt_type.Name = "txt_type";
            this.txt_type.Size = new System.Drawing.Size(101, 20);
            this.txt_type.TabIndex = 3;
            this.txt_type.TextChanged += new System.EventHandler(this.txt_type_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 343);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Thêm extension mới:";
            // 
            // btn_Delete
            // 
            this.btn_Delete.Location = new System.Drawing.Point(176, 358);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(51, 23);
            this.btn_Delete.TabIndex = 1;
            this.btn_Delete.Text = "Xoá";
            this.btn_Delete.UseVisualStyleBackColor = true;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // btn_addType
            // 
            this.btn_addType.Location = new System.Drawing.Point(119, 358);
            this.btn_addType.Name = "btn_addType";
            this.btn_addType.Size = new System.Drawing.Size(51, 23);
            this.btn_addType.TabIndex = 1;
            this.btn_addType.Text = "Thêm";
            this.btn_addType.UseVisualStyleBackColor = true;
            this.btn_addType.Click += new System.EventHandler(this.btn_addType_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.clb_types);
            this.groupBox2.Location = new System.Drawing.Point(7, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(371, 330);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách Extensions";
            // 
            // clb_types
            // 
            this.clb_types.FormattingEnabled = true;
            this.clb_types.Location = new System.Drawing.Point(6, 19);
            this.clb_types.Name = "clb_types";
            this.clb_types.Size = new System.Drawing.Size(359, 289);
            this.clb_types.TabIndex = 0;
            this.clb_types.Click += new System.EventHandler(this.clb_types_Click);
            this.clb_types.SelectedIndexChanged += new System.EventHandler(this.clb_types_SelectedIndexChanged);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // listViewLocations
            // 
            this.listViewLocations.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.IncludedLocations,
            this.LocationsPath});
            this.listViewLocations.HideSelection = false;
            this.listViewLocations.Location = new System.Drawing.Point(0, 16);
            this.listViewLocations.Name = "listViewLocations";
            this.listViewLocations.Size = new System.Drawing.Size(370, 318);
            this.listViewLocations.TabIndex = 0;
            this.listViewLocations.UseCompatibleStateImageBehavior = false;
            this.listViewLocations.View = System.Windows.Forms.View.Details;
            // 
            // IncludedLocations
            // 
            this.IncludedLocations.Text = "Nơi đánh chỉ mục";
            this.IncludedLocations.Width = 100;
            // 
            // LocationsPath
            // 
            this.LocationsPath.Text = "Đường dẫn chỉ mục";
            this.LocationsPath.Width = 250;
            // 
            // lbl_indexSavePath
            // 
            this.lbl_indexSavePath.AutoSize = true;
            this.lbl_indexSavePath.Location = new System.Drawing.Point(16, 361);
            this.lbl_indexSavePath.Name = "lbl_indexSavePath";
            this.lbl_indexSavePath.Size = new System.Drawing.Size(0, 13);
            this.lbl_indexSavePath.TabIndex = 4;
            // 
            // btn_OpenIndex
            // 
            this.btn_OpenIndex.Location = new System.Drawing.Point(6, 344);
            this.btn_OpenIndex.Name = "btn_OpenIndex";
            this.btn_OpenIndex.Size = new System.Drawing.Size(86, 36);
            this.btn_OpenIndex.TabIndex = 5;
            this.btn_OpenIndex.Text = "Mở thư mục Index";
            this.btn_OpenIndex.UseVisualStyleBackColor = true;
            this.btn_OpenIndex.Click += new System.EventHandler(this.btn_OpenIndex_Click);
            // 
            // btn_deleteIndex
            // 
            this.btn_deleteIndex.BackgroundImage = global::LuceneExplorer.Properties.Resources.delete;
            this.btn_deleteIndex.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_deleteIndex.Location = new System.Drawing.Point(298, 344);
            this.btn_deleteIndex.Name = "btn_deleteIndex";
            this.btn_deleteIndex.Size = new System.Drawing.Size(36, 36);
            this.btn_deleteIndex.TabIndex = 8;
            this.btn_deleteIndex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_deleteIndex.UseVisualStyleBackColor = true;
            // 
            // btn_addIndex
            // 
            this.btn_addIndex.BackgroundImage = global::LuceneExplorer.Properties.Resources.add;
            this.btn_addIndex.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_addIndex.Location = new System.Drawing.Point(342, 344);
            this.btn_addIndex.Name = "btn_addIndex";
            this.btn_addIndex.Size = new System.Drawing.Size(36, 36);
            this.btn_addIndex.TabIndex = 8;
            this.btn_addIndex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_addIndex.UseVisualStyleBackColor = true;
            this.btn_addIndex.Click += new System.EventHandler(this.btn_addIndex_Click);
            // 
            // btn_stop
            // 
            this.btn_stop.BackgroundImage = global::LuceneExplorer.Properties.Resources.stop;
            this.btn_stop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_stop.Location = new System.Drawing.Point(348, 385);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(30, 26);
            this.btn_stop.TabIndex = 6;
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Visible = false;
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
            // 
            // IndexingOptions_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 453);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IndexingOptions_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Indexing Options";
            this.panel1.ResumeLayout(false);
            this.tab_index.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tab_index;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_rebuild;
        private System.Windows.Forms.Button btn_openIndexDialog;
        private System.Windows.Forms.TextBox txt_type;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_addType;
        private System.Windows.Forms.CheckedListBox clb_types;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.TextBox txt_searchType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar progressBar_Rebuild;
        private System.Windows.Forms.Label lbl_done;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Button btn_OpenIndex;
        private System.Windows.Forms.Label lbl_indexSavePath;
        private System.Windows.Forms.ListView listViewLocations;
        private System.Windows.Forms.ColumnHeader IncludedLocations;
        private System.Windows.Forms.ColumnHeader LocationsPath;
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.Button btn_addIndex;
        private System.Windows.Forms.Button btn_deleteIndex;
    }
}