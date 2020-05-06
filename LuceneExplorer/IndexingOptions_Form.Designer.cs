namespace LuceneExplorer
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
            this.btn_addIndex = new System.Windows.Forms.Button();
            this.btn_delIndex = new System.Windows.Forms.Button();
            this.btn_resetIndex = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tab_index = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lv_extensions = new System.Windows.Forms.ListView();
            this.lv_indexed = new System.Windows.Forms.ListView();
            this.panel1.SuspendLayout();
            this.tab_index.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_addIndex
            // 
            this.btn_addIndex.Location = new System.Drawing.Point(159, 385);
            this.btn_addIndex.Name = "btn_addIndex";
            this.btn_addIndex.Size = new System.Drawing.Size(75, 56);
            this.btn_addIndex.TabIndex = 1;
            this.btn_addIndex.Text = "Thêm chỉ mục";
            this.btn_addIndex.UseVisualStyleBackColor = true;
            // 
            // btn_delIndex
            // 
            this.btn_delIndex.Location = new System.Drawing.Point(240, 385);
            this.btn_delIndex.Name = "btn_delIndex";
            this.btn_delIndex.Size = new System.Drawing.Size(75, 56);
            this.btn_delIndex.TabIndex = 1;
            this.btn_delIndex.Text = "Xoá chỉ mục";
            this.btn_delIndex.UseVisualStyleBackColor = true;
            // 
            // btn_resetIndex
            // 
            this.btn_resetIndex.Location = new System.Drawing.Point(321, 385);
            this.btn_resetIndex.Name = "btn_resetIndex";
            this.btn_resetIndex.Size = new System.Drawing.Size(75, 56);
            this.btn_resetIndex.TabIndex = 1;
            this.btn_resetIndex.Text = "Reset chỉ mục";
            this.btn_resetIndex.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tab_index);
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(399, 375);
            this.panel1.TabIndex = 2;
            // 
            // tab_index
            // 
            this.tab_index.Controls.Add(this.tabPage1);
            this.tab_index.Controls.Add(this.tabPage2);
            this.tab_index.Location = new System.Drawing.Point(4, 4);
            this.tab_index.Name = "tab_index";
            this.tab_index.SelectedIndex = 0;
            this.tab_index.Size = new System.Drawing.Size(392, 368);
            this.tab_index.TabIndex = 0;
            this.tab_index.Tag = "";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(384, 342);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Index";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(384, 342);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "File Types";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lv_indexed);
            this.groupBox1.Location = new System.Drawing.Point(7, 7);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(371, 329);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách chỉ mục";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lv_extensions);
            this.groupBox2.Location = new System.Drawing.Point(7, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(371, 329);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách Extensions";
            // 
            // lv_extensions
            // 
            this.lv_extensions.HideSelection = false;
            this.lv_extensions.Location = new System.Drawing.Point(0, 19);
            this.lv_extensions.Name = "lv_extensions";
            this.lv_extensions.Size = new System.Drawing.Size(371, 310);
            this.lv_extensions.TabIndex = 0;
            this.lv_extensions.UseCompatibleStateImageBehavior = false;
            // 
            // lv_indexed
            // 
            this.lv_indexed.HideSelection = false;
            this.lv_indexed.Location = new System.Drawing.Point(0, 16);
            this.lv_indexed.Margin = new System.Windows.Forms.Padding(0);
            this.lv_indexed.Name = "lv_indexed";
            this.lv_indexed.Size = new System.Drawing.Size(371, 313);
            this.lv_indexed.TabIndex = 0;
            this.lv_indexed.UseCompatibleStateImageBehavior = false;
            // 
            // IndexingOptions_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 453);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_resetIndex);
            this.Controls.Add(this.btn_delIndex);
            this.Controls.Add(this.btn_addIndex);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "IndexingOptions_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Indexing Options";
            this.panel1.ResumeLayout(false);
            this.tab_index.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_addIndex;
        private System.Windows.Forms.Button btn_delIndex;
        private System.Windows.Forms.Button btn_resetIndex;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tab_index;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lv_indexed;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView lv_extensions;
    }
}