using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace CS3502Proj3
{
    public partial class Main : Form
    {
        private readonly FileManager fileManager = new FileManager();
        private string currentDirectory = "";
        private string? previousDirectory;
        private string? currentFilePath;

        public Main()
        {
            InitializeComponent();
            HookUpEvents();
        }

        private void HookUpEvents()
        {
            Load += Main_Load;
            treeFolders.AfterSelect += treeFolders_AfterSelect;
            listFiles.ItemActivate += listFiles_ItemActivate;

            toolStripBack.Click += toolStripBack_Click;
            toolStripUp.Click += toolStripUp_Click;
            toolStripRefresh.Click += toolStripRefresh_Click;

            menuNewFile.Click += menuNewFile_Click;
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;
            renameToolStripMenuItem.Click += renameToolStripMenuItem_Click;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            currentDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (string.IsNullOrEmpty(currentDirectory))
                currentDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

            listFiles.FullRowSelect = true;
            listFiles.HideSelection = false;

            BuildFolderTree();
            ShowDirectory(currentDirectory);
        }

        private void BuildFolderTree()
        {
            treeFolders.Nodes.Clear();

            string root = Path.GetPathRoot(currentDirectory) ?? "C:\\";
            TreeNode rootNode = new TreeNode(root) { Tag = root };

            try
            {
                foreach (var dir in Directory.GetDirectories(root))
                {
                    string name = Path.GetFileName(dir);
                    if (!string.IsNullOrWhiteSpace(name))
                        rootNode.Nodes.Add(new TreeNode(name) { Tag = dir });
                }
            }
            catch
            {
            }

            TreeNode docsNode = new TreeNode("Documents") { Tag = currentDirectory };
            rootNode.Nodes.Add(docsNode);

            treeFolders.Nodes.Add(rootNode);
            rootNode.Expand();
        }

        private void ShowDirectory(string path)
        {
            try
            {
                if (!Directory.Exists(path))
                {
                    ShowError("Directory not found: " + path);
                    return;
                }

                listFiles.BeginUpdate();
                listFiles.Items.Clear();

                foreach (var entry in fileManager.GetEntries(path))
                {
                    var item = new ListViewItem(entry.Name) { Tag = entry.FullName };

                    if (entry is DirectoryInfo)
                    {
                        item.SubItems.Add("Folder");
                        item.SubItems.Add("");
                    }
                    else if (entry is FileInfo fi)
                    {
                        item.SubItems.Add("File");
                        item.SubItems.Add(fi.Length.ToString());
                    }

                    listFiles.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
                return;
            }
            finally
            {
                listFiles.EndUpdate();
            }

            previousDirectory = currentDirectory;
            currentDirectory = path;
            currentFilePath = null;
            toolStripPath.Text = currentDirectory;
            textContent.Clear();
            ShowStatus("Showing: " + currentDirectory);
        }

        private void treeFolders_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag is string path)
                ShowDirectory(path);
        }

        private void listFiles_ItemActivate(object sender, EventArgs e)
        {
            if (listFiles.SelectedItems.Count == 0) return;

            var item = listFiles.SelectedItems[0];
            string? path = item.Tag as string;
            if (string.IsNullOrEmpty(path)) return;

            if (Directory.Exists(path))
                ShowDirectory(path);
            else if (File.Exists(path))
                OpenFile(path);
        }

        private void OpenFile(string path)
        {
            try
            {
                string content = fileManager.Read(path);
                textContent.Text = content;
                currentFilePath = path;
                ShowStatus("Opened: " + path);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        private void toolStripBack_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(previousDirectory) && Directory.Exists(previousDirectory))
                ShowDirectory(previousDirectory);
        }

        private void toolStripUp_Click(object sender, EventArgs e)
        {
            string? parent = Path.GetDirectoryName(currentDirectory);
            if (!string.IsNullOrEmpty(parent))
                ShowDirectory(parent);
        }

        private void toolStripRefresh_Click(object sender, EventArgs e)
        {
            ShowDirectory(currentDirectory);
        }

        private void menuNewFile_Click(object sender, EventArgs e)
        {
            CreateNewFile();
        }

        private void newFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateNewFolder();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveCurrentFile();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteSelected();
        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RenameSelected();
        }

        private void CreateNewFile()
        {
            if (string.IsNullOrEmpty(currentDirectory)) return;

            string name = Interaction.InputBox("Enter file name:", "New File", "newfile.txt");
            if (string.IsNullOrWhiteSpace(name)) return;

            string path = Path.Combine(currentDirectory, name);
            string content = Interaction.InputBox("Initial content (optional):", "New File Content", "");

            try
            {
                fileManager.CreateFile(path, content);
                ShowDirectory(currentDirectory);
                ShowStatus("Created file: " + path);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        private void CreateNewFolder()
        {
            if (string.IsNullOrEmpty(currentDirectory)) return;

            string name = Interaction.InputBox("Enter folder name:", "New Folder", "NewFolder");
            if (string.IsNullOrWhiteSpace(name)) return;

            string path = Path.Combine(currentDirectory, name);

            try
            {
                fileManager.CreateDirectory(path);
                ShowDirectory(currentDirectory);
                ShowStatus("Created folder: " + path);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        private void SaveCurrentFile()
        {
            if (string.IsNullOrEmpty(currentFilePath))
            {
                ShowError("No file is open to save.");
                return;
            }

            try
            {
                fileManager.Update(currentFilePath, textContent.Text);
                ShowStatus("Saved: " + currentFilePath);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        private string? GetSelectedPath()
        {
            if (listFiles.SelectedItems.Count == 0) return null;
            return listFiles.SelectedItems[0].Tag as string;
        }

        private void DeleteSelected()
        {
            string? path = GetSelectedPath();
            if (string.IsNullOrWhiteSpace(path))
            {
                ShowError("Select a file or folder first.");
                return;
            }

            DialogResult result = MessageBox.Show(this, "Delete: " + path + " ?", "Confirm Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result != DialogResult.Yes) return;

            try
            {
                fileManager.Delete(path);
                ShowDirectory(currentDirectory);
                ShowStatus("Deleted: " + path);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        private void RenameSelected()
        {
            string? path = GetSelectedPath();
            if (string.IsNullOrWhiteSpace(path))
            {
                ShowError("Select a file or folder first.");
                return;
            }

            string newName = Interaction.InputBox("New name:", "Rename", Path.GetFileName(path));
            if (string.IsNullOrWhiteSpace(newName)) return;

            try
            {
                string newPath = fileManager.Rename(path, newName);
                ShowDirectory(currentDirectory);
                ShowStatus("Renamed to: " + newPath);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        private void ShowStatus(string text)
        {
            statusLabel.Text = text;
        }

        private void ShowError(string message)
        {
            MessageBox.Show(this, message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            ShowStatus(message);
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void listFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
