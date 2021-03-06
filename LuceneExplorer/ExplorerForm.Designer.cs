﻿namespace LuceneExplorer
{
    partial class ExplorerForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExplorerForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.indexingOptions_ToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btn_back = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_newFolder = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton9 = new System.Windows.Forms.ToolStripButton();
            this.txt_search = new System.Windows.Forms.ToolStripTextBox();
            this.btn_refresh = new System.Windows.Forms.ToolStripButton();
            this.toolStrip_Address = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel_Address = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.txt_Address = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButton_Go = new System.Windows.Forms.ToolStripButton();
            this.panel_Footer = new System.Windows.Forms.Panel();
            this.treeView = new System.Windows.Forms.TreeView();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.listView = new System.Windows.Forms.ListView();
            this.Names = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Modified = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Size = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Paths = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Contents = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.contextmenu_listview_options = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cb_searchOptions = new System.Windows.Forms.ToolStripComboBox();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.toolStrip_Address.SuspendLayout();
            this.contextmenu_listview_options.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(800, 30);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 26);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(49, 26);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(55, 26);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.indexingOptions_ToolStrip});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(58, 26);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // indexingOptions_ToolStrip
            // 
            this.indexingOptions_ToolStrip.Name = "indexingOptions_ToolStrip";
            this.indexingOptions_ToolStrip.Size = new System.Drawing.Size(214, 26);
            this.indexingOptions_ToolStrip.Text = "Indexing Options...";
            this.indexingOptions_ToolStrip.Click += new System.EventHandler(this.indexingOptions_ToolStrip_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(55, 26);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_back,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripSeparator1,
            this.btn_newFolder,
            this.toolStripSeparator2,
            this.toolStripButton5,
            this.toolStripButton6,
            this.toolStripButton7,
            this.toolStripButton8,
            this.toolStripButton9,
            this.txt_search,
            this.btn_refresh,
            this.cb_searchOptions});
            this.toolStrip1.Location = new System.Drawing.Point(0, 30);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(1);
            this.toolStrip1.Size = new System.Drawing.Size(800, 33);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btn_back
            // 
            this.btn_back.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_back.Image = ((System.Drawing.Image)(resources.GetObject("btn_back.Image")));
            this.btn_back.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(29, 28);
            this.btn_back.Text = "toolStripButton1";
            this.btn_back.Click += new System.EventHandler(this.backButton_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(29, 28);
            this.toolStripButton2.Text = "toolStripButton2";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(29, 28);
            this.toolStripButton3.Text = "toolStripButton3";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // btn_newFolder
            // 
            this.btn_newFolder.Image = ((System.Drawing.Image)(resources.GetObject("btn_newFolder.Image")));
            this.btn_newFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_newFolder.Name = "btn_newFolder";
            this.btn_newFolder.Size = new System.Drawing.Size(79, 28);
            this.btn_newFolder.Text = "Folder";
            this.btn_newFolder.Click += new System.EventHandler(this.btn_newFolder_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(29, 28);
            this.toolStripButton5.Text = "toolStripButton5";
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(29, 28);
            this.toolStripButton6.Text = "toolStripButton6";
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton7.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton7.Image")));
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(29, 28);
            this.toolStripButton7.Text = "toolStripButton7";
            // 
            // toolStripButton8
            // 
            this.toolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton8.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton8.Image")));
            this.toolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton8.Name = "toolStripButton8";
            this.toolStripButton8.Size = new System.Drawing.Size(29, 28);
            this.toolStripButton8.Text = "toolStripButton8";
            // 
            // toolStripButton9
            // 
            this.toolStripButton9.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton9.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton9.Image")));
            this.toolStripButton9.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton9.Name = "toolStripButton9";
            this.toolStripButton9.Size = new System.Drawing.Size(29, 28);
            this.toolStripButton9.Text = "toolStripButton9";
            // 
            // txt_search
            // 
            this.txt_search.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.txt_search.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_search.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_search.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.txt_search.Name = "txt_search";
            this.txt_search.Size = new System.Drawing.Size(150, 31);
            this.txt_search.Text = "Search...";
            this.txt_search.Leave += new System.EventHandler(this.toolStripTextBox_Search_Leave);
            this.txt_search.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolStripTextBox_Search_KeyDown);
            this.txt_search.Click += new System.EventHandler(this.txt_search_Click);
            this.txt_search.TextChanged += new System.EventHandler(this.txt_search_TextChanged);
            // 
            // btn_refresh
            // 
            this.btn_refresh.Image = global::LuceneExplorer.Properties.Resources.refresh_btn;
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(29, 28);
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // toolStrip_Address
            // 
            this.toolStrip_Address.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip_Address.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel_Address,
            this.toolStripSeparator3,
            this.txt_Address,
            this.toolStripButton_Go});
            this.toolStrip_Address.Location = new System.Drawing.Point(0, 63);
            this.toolStrip_Address.Name = "toolStrip_Address";
            this.toolStrip_Address.Padding = new System.Windows.Forms.Padding(1);
            this.toolStrip_Address.Size = new System.Drawing.Size(800, 31);
            this.toolStrip_Address.TabIndex = 2;
            this.toolStrip_Address.Text = "toolStrip2";
            this.toolStrip_Address.Resize += new System.EventHandler(this.toolStrip_Address_Resize);
            // 
            // toolStripLabel_Address
            // 
            this.toolStripLabel_Address.Name = "toolStripLabel_Address";
            this.toolStripLabel_Address.Size = new System.Drawing.Size(62, 26);
            this.toolStripLabel_Address.Text = "Address";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 29);
            // 
            // txt_Address
            // 
            this.txt_Address.AutoSize = false;
            this.txt_Address.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Address.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_Address.Name = "txt_Address";
            this.txt_Address.Size = new System.Drawing.Size(101, 27);
            // 
            // toolStripButton_Go
            // 
            this.toolStripButton_Go.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton_Go.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Go.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Go.Image")));
            this.toolStripButton_Go.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Go.Name = "toolStripButton_Go";
            this.toolStripButton_Go.Size = new System.Drawing.Size(29, 26);
            this.toolStripButton_Go.Text = "toolStripButton10";
            // 
            // panel_Footer
            // 
            this.panel_Footer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel_Footer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_Footer.ForeColor = System.Drawing.SystemColors.Control;
            this.panel_Footer.Location = new System.Drawing.Point(0, 416);
            this.panel_Footer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel_Footer.Name = "panel_Footer";
            this.panel_Footer.Size = new System.Drawing.Size(800, 34);
            this.panel_Footer.TabIndex = 3;
            // 
            // treeView
            // 
            this.treeView.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView.Location = new System.Drawing.Point(0, 94);
            this.treeView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(300, 322);
            this.treeView.TabIndex = 4;
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(300, 94);
            this.splitter1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 322);
            this.splitter1.TabIndex = 5;
            this.splitter1.TabStop = false;
            // 
            // listView
            // 
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Names,
            this.Modified,
            this.Type,
            this.Size,
            this.Paths,
            this.Contents});
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(303, 94);
            this.listView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(497, 322);
            this.listView.SmallImageList = this.imageList;
            this.listView.TabIndex = 6;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.SelectedIndexChanged += new System.EventHandler(this.listView_SelectedIndexChanged);
            this.listView.DoubleClick += new System.EventHandler(this.listView_DoubleClick_1);
            this.listView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView_MouseClick_1);
            // 
            // Names
            // 
            this.Names.Text = "Name";
            // 
            // Modified
            // 
            this.Modified.Text = "Modified";
            // 
            // Type
            // 
            this.Type.Text = "Type";
            // 
            // Size
            // 
            this.Size.Text = "Size";
            // 
            // Paths
            // 
            this.Paths.Text = "Path";
            this.Paths.Width = 100;
            // 
            // Contents
            // 
            this.Contents.Text = "Content";
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // contextmenu_listview_options
            // 
            this.contextmenu_listview_options.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextmenu_listview_options.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.cutToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.renameToolStripMenuItem});
            this.contextmenu_listview_options.Name = "contextmenu_listview_options";
            this.contextmenu_listview_options.Size = new System.Drawing.Size(133, 124);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(132, 24);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(132, 24);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(132, 24);
            this.cutToolStripMenuItem.Text = "Cut";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.CutToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(132, 24);
            this.pasteToolStripMenuItem.Text = "Paste";
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(132, 24);
            this.renameToolStripMenuItem.Text = "Rename";
            // 
            // cb_searchOptions
            // 
            this.cb_searchOptions.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.cb_searchOptions.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cb_searchOptions.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cb_searchOptions.Name = "cb_searchOptions";
            this.cb_searchOptions.Size = new System.Drawing.Size(121, 31);
            this.cb_searchOptions.Click += new System.EventHandler(this.cb_searchOptions_Click);
            // 
            // ExplorerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.treeView);
            this.Controls.Add(this.panel_Footer);
            this.Controls.Add(this.toolStrip_Address);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ExplorerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lucene Explorer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip_Address.ResumeLayout(false);
            this.toolStrip_Address.PerformLayout();
            this.contextmenu_listview_options.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btn_back;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btn_newFolder;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private System.Windows.Forms.ToolStripButton toolStripButton8;
        private System.Windows.Forms.ToolStripButton toolStripButton9;
        private System.Windows.Forms.ToolStrip toolStrip_Address;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_Address;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripTextBox txt_Address;
        private System.Windows.Forms.ToolStripButton toolStripButton_Go;
        private System.Windows.Forms.Panel panel_Footer;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ToolStripTextBox txt_search;
        private System.Windows.Forms.ColumnHeader Names;
        private System.Windows.Forms.ColumnHeader Type;
        private System.Windows.Forms.ColumnHeader Modified;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ColumnHeader Size;
        private System.Windows.Forms.ContextMenuStrip contextmenu_listview_options;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem indexingOptions_ToolStrip;
        private System.Windows.Forms.ToolStripButton btn_refresh;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader Paths;
        private System.Windows.Forms.ColumnHeader Contents;
        private System.Windows.Forms.ToolStripComboBox cb_searchOptions;
    }
}

