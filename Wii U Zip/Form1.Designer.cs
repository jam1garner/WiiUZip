namespace Wii_U_Zip
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.extractAll = new System.Windows.Forms.Button();
            this.extract = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sARCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yAZ0SARCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yAZ0FileszsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paddedYAZ0SARCszsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setupFiletypeAssociationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bigEndianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.LabelEdit = true;
            this.treeView1.Location = new System.Drawing.Point(0, 24);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(495, 405);
            this.treeView1.TabIndex = 0;
            // 
            // extractAll
            // 
            this.extractAll.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.extractAll.Location = new System.Drawing.Point(0, 521);
            this.extractAll.Name = "extractAll";
            this.extractAll.Size = new System.Drawing.Size(495, 23);
            this.extractAll.TabIndex = 1;
            this.extractAll.Text = "Extract All";
            this.extractAll.UseVisualStyleBackColor = true;
            this.extractAll.Click += new System.EventHandler(this.extractAll_Click);
            // 
            // extract
            // 
            this.extract.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.extract.Location = new System.Drawing.Point(0, 498);
            this.extract.Name = "extract";
            this.extract.Size = new System.Drawing.Size(495, 23);
            this.extract.TabIndex = 2;
            this.extract.Text = "Extract";
            this.extract.UseVisualStyleBackColor = true;
            this.extract.Click += new System.EventHandler(this.extract_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(495, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.openToolStripMenuItem,
            this.setupFiletypeAssociationToolStripMenuItem,
            this.bigEndianToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sARCToolStripMenuItem,
            this.yAZ0SARCToolStripMenuItem,
            this.yAZ0FileszsToolStripMenuItem,
            this.paddedYAZ0SARCszsToolStripMenuItem});
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // sARCToolStripMenuItem
            // 
            this.sARCToolStripMenuItem.Name = "sARCToolStripMenuItem";
            this.sARCToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.sARCToolStripMenuItem.Text = "SARC";
            this.sARCToolStripMenuItem.Click += new System.EventHandler(this.sARCToolStripMenuItem_Click);
            // 
            // yAZ0SARCToolStripMenuItem
            // 
            this.yAZ0SARCToolStripMenuItem.Name = "yAZ0SARCToolStripMenuItem";
            this.yAZ0SARCToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.yAZ0SARCToolStripMenuItem.Text = "YAZ0 SARC (.szs)";
            this.yAZ0SARCToolStripMenuItem.Click += new System.EventHandler(this.yAZ0SARCToolStripMenuItem_Click);
            // 
            // yAZ0FileszsToolStripMenuItem
            // 
            this.yAZ0FileszsToolStripMenuItem.Name = "yAZ0FileszsToolStripMenuItem";
            this.yAZ0FileszsToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.yAZ0FileszsToolStripMenuItem.Text = "YAZ0 File (.szs)";
            this.yAZ0FileszsToolStripMenuItem.Click += new System.EventHandler(this.yAZ0FileszsToolStripMenuItem_Click);
            // 
            // paddedYAZ0SARCszsToolStripMenuItem
            // 
            this.paddedYAZ0SARCszsToolStripMenuItem.Name = "paddedYAZ0SARCszsToolStripMenuItem";
            this.paddedYAZ0SARCszsToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.paddedYAZ0SARCszsToolStripMenuItem.Text = "Custom YAZ0 SARC (.szs)";
            this.paddedYAZ0SARCszsToolStripMenuItem.Click += new System.EventHandler(this.paddedYAZ0SARCszsToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // setupFiletypeAssociationToolStripMenuItem
            // 
            this.setupFiletypeAssociationToolStripMenuItem.Name = "setupFiletypeAssociationToolStripMenuItem";
            this.setupFiletypeAssociationToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.setupFiletypeAssociationToolStripMenuItem.Text = "Setup Filetype Association";
            this.setupFiletypeAssociationToolStripMenuItem.Click += new System.EventHandler(this.setupFiletypeAssociationToolStripMenuItem_Click);
            // 
            // bigEndianToolStripMenuItem
            // 
            this.bigEndianToolStripMenuItem.Checked = true;
            this.bigEndianToolStripMenuItem.CheckOnClick = true;
            this.bigEndianToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.bigEndianToolStripMenuItem.Name = "bigEndianToolStripMenuItem";
            this.bigEndianToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.bigEndianToolStripMenuItem.Text = "Big Endian";
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button1.Location = new System.Drawing.Point(0, 475);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(495, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Replace File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button3.Location = new System.Drawing.Point(0, 452);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(495, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "Delete File";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button2.Location = new System.Drawing.Point(0, 429);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(495, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Add File";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 544);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.extract);
            this.Controls.Add(this.extractAll);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Wii U Zip";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop_1);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter_1);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button extractAll;
        private System.Windows.Forms.Button extract;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sARCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yAZ0SARCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yAZ0FileszsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setupFiletypeAssociationToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolStripMenuItem bigEndianToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paddedYAZ0SARCszsToolStripMenuItem;
    }
}

