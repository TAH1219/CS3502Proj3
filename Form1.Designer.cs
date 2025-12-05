namespace CS3502Proj3
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            toolStrip1 = new ToolStrip();
            toolStripBack = new ToolStripButton();
            toolStripUp = new ToolStripButton();
            toolStripRefresh = new ToolStripButton();
            toolStripPath = new ToolStripTextBox();
            statusStrip1 = new StatusStrip();
            statusLabel = new ToolStripStatusLabel();
            splitMain = new SplitContainer();
            treeFolders = new TreeView();
            splitRight = new SplitContainer();
            listFiles = new ListView();
            columnFileName = new ColumnHeader();
            columnFileType = new ColumnHeader();
            columnFileSize = new ColumnHeader();
            textContent = new TextBox();
            fileToolStripMenuItem = new ToolStripMenuItem();
            menuNewFile = new ToolStripMenuItem();
            newFolderToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            deleteToolStripMenuItem = new ToolStripMenuItem();
            renameToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            toolStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitMain).BeginInit();
            splitMain.Panel1.SuspendLayout();
            splitMain.Panel2.SuspendLayout();
            splitMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitRight).BeginInit();
            splitRight.Panel1.SuspendLayout();
            splitRight.Panel2.SuspendLayout();
            splitRight.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripBack, toolStripUp, toolStripRefresh, toolStripPath });
            toolStrip1.Location = new Point(0, 24);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(800, 25);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripBack
            // 
            toolStripBack.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripBack.Image = Properties.Resources.Back;
            toolStripBack.ImageTransparentColor = Color.Magenta;
            toolStripBack.Name = "toolStripBack";
            toolStripBack.Size = new Size(23, 22);
            toolStripBack.Text = "Back";
            // 
            // toolStripUp
            // 
            toolStripUp.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripUp.Image = Properties.Resources.Up;
            toolStripUp.ImageTransparentColor = Color.Magenta;
            toolStripUp.Name = "toolStripUp";
            toolStripUp.Size = new Size(23, 22);
            toolStripUp.Text = "Up";
            // 
            // toolStripRefresh
            // 
            toolStripRefresh.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripRefresh.Image = Properties.Resources.Refresh;
            toolStripRefresh.ImageTransparentColor = Color.Magenta;
            toolStripRefresh.Name = "toolStripRefresh";
            toolStripRefresh.Size = new Size(23, 22);
            toolStripRefresh.Text = "Refresh";
            // 
            // toolStripPath
            // 
            toolStripPath.Name = "toolStripPath";
            toolStripPath.ReadOnly = true;
            toolStripPath.Size = new Size(100, 25);
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { statusLabel });
            statusStrip1.Location = new Point(0, 428);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 22);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(39, 17);
            statusLabel.Text = "Ready";
            // 
            // splitMain
            // 
            splitMain.Dock = DockStyle.Fill;
            splitMain.Location = new Point(0, 49);
            splitMain.Name = "splitMain";
            // 
            // splitMain.Panel1
            // 
            splitMain.Panel1.Controls.Add(treeFolders);
            // 
            // splitMain.Panel2
            // 
            splitMain.Panel2.Controls.Add(splitRight);
            splitMain.Panel2.Paint += splitContainer1_Panel2_Paint;
            splitMain.Size = new Size(800, 379);
            splitMain.SplitterDistance = 266;
            splitMain.TabIndex = 3;
            // 
            // treeFolders
            // 
            treeFolders.Dock = DockStyle.Fill;
            treeFolders.Location = new Point(0, 0);
            treeFolders.Name = "treeFolders";
            treeFolders.Size = new Size(266, 379);
            treeFolders.TabIndex = 0;
            // 
            // splitRight
            // 
            splitRight.Dock = DockStyle.Fill;
            splitRight.Location = new Point(0, 0);
            splitRight.Name = "splitRight";
            splitRight.Orientation = Orientation.Horizontal;
            // 
            // splitRight.Panel1
            // 
            splitRight.Panel1.Controls.Add(listFiles);
            // 
            // splitRight.Panel2
            // 
            splitRight.Panel2.Controls.Add(textContent);
            splitRight.Size = new Size(530, 379);
            splitRight.SplitterDistance = 176;
            splitRight.TabIndex = 0;
            // 
            // listFiles
            // 
            listFiles.Columns.AddRange(new ColumnHeader[] { columnFileName, columnFileType, columnFileSize });
            listFiles.Dock = DockStyle.Fill;
            listFiles.FullRowSelect = true;
            listFiles.Location = new Point(0, 0);
            listFiles.Name = "listFiles";
            listFiles.Size = new Size(530, 176);
            listFiles.TabIndex = 0;
            listFiles.UseCompatibleStateImageBehavior = false;
            listFiles.View = View.Details;
            listFiles.SelectedIndexChanged += listFiles_SelectedIndexChanged;
            // 
            // columnFileName
            // 
            columnFileName.Text = "File Name";
            columnFileName.Width = 150;
            // 
            // columnFileType
            // 
            columnFileType.Text = "File Type";
            columnFileType.Width = 100;
            // 
            // columnFileSize
            // 
            columnFileSize.Text = "File Size";
            columnFileSize.Width = 120;
            // 
            // textContent
            // 
            textContent.Dock = DockStyle.Fill;
            textContent.Location = new Point(0, 0);
            textContent.Multiline = true;
            textContent.Name = "textContent";
            textContent.ScrollBars = ScrollBars.Both;
            textContent.Size = new Size(530, 199);
            textContent.TabIndex = 0;
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { menuNewFile, newFolderToolStripMenuItem, saveToolStripMenuItem, deleteToolStripMenuItem, renameToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // menuNewFile
            // 
            menuNewFile.Name = "menuNewFile";
            menuNewFile.Size = new Size(180, 22);
            menuNewFile.Text = "New File";
            // 
            // newFolderToolStripMenuItem
            // 
            newFolderToolStripMenuItem.Name = "newFolderToolStripMenuItem";
            newFolderToolStripMenuItem.Size = new Size(180, 22);
            newFolderToolStripMenuItem.Text = "New Folder";
            newFolderToolStripMenuItem.Click += newFolderToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(180, 22);
            saveToolStripMenuItem.Text = "Save";
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(180, 22);
            deleteToolStripMenuItem.Text = "Delete";
            // 
            // renameToolStripMenuItem
            // 
            renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            renameToolStripMenuItem.Size = new Size(180, 22);
            renameToolStripMenuItem.Text = "Rename";
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitMain);
            Controls.Add(statusStrip1);
            Controls.Add(toolStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Main";
            Text = "File Manager";
            Load += Main_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            splitMain.Panel1.ResumeLayout(false);
            splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitMain).EndInit();
            splitMain.ResumeLayout(false);
            splitRight.Panel1.ResumeLayout(false);
            splitRight.Panel2.ResumeLayout(false);
            splitRight.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitRight).EndInit();
            splitRight.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripBack;
        private ToolStripButton toolStripUp;
        private ToolStripButton toolStripRefresh;
        private ToolStripTextBox toolStripPath;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel statusLabel;
        private SplitContainer splitMain;
        private TreeView treeFolders;
        private SplitContainer splitRight;
        private ListView listFiles;
        private ColumnHeader columnFileName;
        private ColumnHeader columnFileType;
        private ColumnHeader columnFileSize;
        private TextBox textContent;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem menuNewFile;
        private ToolStripMenuItem newFolderToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ToolStripMenuItem renameToolStripMenuItem;
    }
}
