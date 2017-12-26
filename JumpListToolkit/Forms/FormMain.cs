using Plarform.Support.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Pictograms;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Forms.Pictograms;
using Toolkit.Models;

namespace Toolkit.Forms
{
    public partial class FormMain : Form
    {
        public string Source { get; set; } = string.Empty;
        public List<Link> Model { get; set; } = new List<Link>();

        public FormMain()
        {
            InitializeComponent();

            Icon = Icon.ExtractAssociatedIcon(Program.Assembly.Location);

            // Icons
            toolStripButtonFile.SetImage(MaterialDesign.Instance, Program.Icon, 48, SystemColors.Control);

            newToolStripMenuItem.SetImage(MaterialDesign.Instance, MaterialDesign.IconType.insert_drive_file, 48, toolStripMenu.BackColor);
            openToolStripMenuItem.SetImage(MaterialDesign.Instance, MaterialDesign.IconType.folder_open, 48, toolStripMenu.BackColor);
            saveToolStripMenuItem.SetImage(MaterialDesign.Instance, MaterialDesign.IconType.save, 48, toolStripMenu.BackColor);
            saveAsToolStripMenuItem.SetImage(MaterialDesign.Instance, MaterialDesign.IconType.save, 48, toolStripMenu.BackColor);

            toolStripButtonAdd.SetImage(MaterialDesign.Instance, MaterialDesign.IconType.add, 48, SystemColors.Control);
            toolStripButtonEdit.SetImage(MaterialDesign.Instance, MaterialDesign.IconType.edit, 48, SystemColors.Control);
            toolStripButtonDelete.SetImage(MaterialDesign.Instance, MaterialDesign.IconType.delete, 48, SystemColors.Control);

            toolStripButtonUpdates.SetImage(MaterialDesign.Instance, MaterialDesign.IconType.system_update_alt, 48, SystemColors.Control);

            toolStripButtonAction.SetImage(MaterialDesign.Instance, MaterialDesign.IconType.code, 48, SystemColors.Control);
            toolStripButtonApply.SetImage(MaterialDesign.Instance, MaterialDesign.IconType.check, 48, SystemColors.Control);

#if DEBUG
            FormHelper.ExtractResources(toolStripMenu);
#endif
        }

        private void RenderContent()
        {
            listViewTasks.Groups.Clear();
            listViewTasks.Items.Clear();

            if (Model != null)
            {
                var collection = from item in Model
                                 group item by item.Category.Trim() into g
                                 select new { g.Key, Value = g.ToList() };

                listViewTasks.Groups.AddRange(collection.Select(m => new ListViewGroup(m.Key, m.Key)).ToArray());

                foreach (var group in collection)
                    foreach (var item in group.Value)
                    {
                        Icon icon = null;
                        if (!string.IsNullOrEmpty(item.IconLocation))
                            icon = Icon.ExtractAssociatedIcon(item.IconLocation);
                        if (File.Exists(item.Path) || icon == null)
                            icon = Icon.ExtractAssociatedIcon(item.Path);
                        imageListIcons.Images.Add(item.Title, icon.ToBitmap());

                        listViewTasks.Items.Add(new ListViewItem(item.Title)
                        {
                            Tag = item,
                            SubItems = { item.Path, item.Arguments },
                            ImageKey = item.Title,
                            Group = listViewTasks.Groups[group.Key]
                        });
                    }
            }
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            RenderContent();
        }

        #region Drag & Drop

        private void FormMain_DragDrop(object sender, DragEventArgs e)
        {
            bufferedPanelPreview.Visible = false;
            e.Effect = DragDropEffects.None;

            if ((e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy)
            {
                if (((IDataObject)e.Data).GetData("FileName") is Array data && ((data.Length == 1) && (data.GetValue(0) is string)))
                {
                    var filename = ((string[])data)[0];
                    if (!string.IsNullOrEmpty(filename))
                        LoadFile(filename);
                }
            }
        }

        private void FormMain_DragEnter(object sender, DragEventArgs e)
        {
            bufferedPanelPreview.Visible = true;
            e.Effect = DragDropEffects.Copy;
        }

        private void FormMain_DragLeave(object sender, EventArgs e)
        {
            bufferedPanelPreview.Visible = false;
        }

        #endregion Drag & Drop

        private void LoadFile(string item)
        {
            var fi = new FileInfo(item.ToString());
            Model.Add(new Link(fi.FullName, Path.GetFileNameWithoutExtension(fi.Name)));
            RenderContent();
        }

        #region MainActions

        private void ToolStripButtonNew_Click(object sender, EventArgs e)
        {
            Source = string.Empty;
            Model = new List<Link>();
            RenderContent();
        }

        private void ToolStripButtonOpen_Click(object sender, EventArgs e)
        {
            openFileDialogSettings.ShowDialog();
        }

        private void OpenFileDialogSettings_FileOk(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(openFileDialogSettings.FileName) && File.Exists(openFileDialogSettings.FileName))
            {
                Source = openFileDialogSettings.FileName;
                try
                {
                    Model = Program.LoadFromFile(Source);
                    RenderContent();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Source = string.Empty;
                }
            }
        }

        private void ToolStripButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Source) || !File.Exists(Path.ChangeExtension(Source, "lnk")))
            {
                saveFileDialogSettings.FileName = Path.ChangeExtension(Program.Assembly.Location, "json");
                saveFileDialogSettings.ShowDialog();
            }
            else
            {
                saveFileDialogSettings.FileName = Source;
                SaveFileDialogSettings_FileOk(sender, new CancelEventArgs(false));
            }
        }

        private void ToolStripMenuItemSaveAs_Click(object sender, EventArgs e)
        {
            saveFileDialogSettings.ShowDialog();
        }

        private void SaveFileDialogSettings_FileOk(object sender, CancelEventArgs e)
        {
            if (Path.GetExtension(saveFileDialogSettings.FileName).ToLower() == ".lnk")
            {
                var file = saveFileDialogSettings.FileName;
                var settings = Path.ChangeExtension(file, "json");
                ShortcutHelper.CreateShortcut(Program.Assembly.Location, Path.GetDirectoryName(file), Path.GetFileNameWithoutExtension(file), null, $"/settings {settings}", Path.GetDirectoryName(Program.Assembly.Location));
                Program.SaveToFile(settings, Model);
            }
            else
                Program.SaveToFile(saveFileDialogSettings.FileName, Model);
        }

        #endregion MainActions

        #region ItemActions

        private void ToolStripButtonAdd_Click(object sender, EventArgs e)
        {
            var child = new FormEditor(new Link()) { StartPosition = FormStartPosition.CenterParent, Icon = this.Icon };
            if (child.ShowDialog() == DialogResult.OK)
            {
                Model.Add(child.Model);
                RenderContent();
            }
        }

        private void ToolStripButtonEdit_Click(object sender, EventArgs e)
        {
            if (listViewTasks.SelectedItems != null && listViewTasks.SelectedItems.OfType<ListViewItem>().Any())
            {
                var item = listViewTasks.SelectedItems.OfType<ListViewItem>().FirstOrDefault();
                if (item != null)
                {
                    var link = (item.Tag as Link);
                    var index = Model.IndexOf(link);
                    if (index >= 0)
                    {
                        var child = new FormEditor(link.Clone()) { StartPosition = FormStartPosition.CenterParent, Icon = this.Icon };

                        if (child.ShowDialog() == DialogResult.OK)
                        {
                            Model[index] = child.Model;
                            RenderContent();
                        }
                    }
                }
            }
        }

        private void ToolStripButtonDelete_Click(object sender, EventArgs e)
        {
            if (listViewTasks.SelectedItems != null && listViewTasks.SelectedItems.OfType<ListViewItem>().Any())
                foreach (var item in listViewTasks.SelectedItems.OfType<ListViewItem>())
                {
                    Model.Remove((item.Tag as Link));
                    RenderContent();
                }
        }

        private void ListViewTasks_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ToolStripMenuItemLaunch_Click(sender, e);
        }

        #endregion ItemActions

        private void ToolStripButtonApply_Click(object sender, EventArgs e)
        {
            if (Model != null)
                Program.RegisterTaskBarActions(Model);
        }

        private void ToolStripButtonAbout_Click(object sender, EventArgs e)
        {
            var child = new FormAbout();
            child.ShowDialog();
        }

        private void ToolStripButtonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void FormMain_Load(object sender, EventArgs e)
        {
            toolStripButtonUpdates.Checked = Properties.Settings.Default.CheckForUpdates;

            if (Properties.Settings.Default.CheckForUpdates)
                await GitHubInfo.CheckForUpdateAsync();
        }

        private void ToolStripMenuItemDefault_Click(object sender, EventArgs e)
        {
        }

        private void ListViewTasks_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            toolStripButtonEdit.Visible = e.IsSelected;
            toolStripButtonDelete.Visible = e.IsSelected;
            editToolStripMenuItem.Enabled = e.IsSelected;
            deleteToolStripMenuItem.Enabled = e.IsSelected;
            defaultToolStripMenuItem.Enabled = e.IsSelected;
            launchToolStripMenuItem.Enabled = e.IsSelected;
        }

        private void ToolStripMenuItemLaunch_Click(object sender, EventArgs e)
        {
            if (listViewTasks.SelectedItems != null && listViewTasks.SelectedItems.OfType<ListViewItem>().Any())
            {
                var link = (listViewTasks.SelectedItems.OfType<ListViewItem>().FirstOrDefault().Tag as Link);
                if (link != null)
                    Process.Start(new ProcessStartInfo()
                    {
                        FileName = link.Path,
                        Arguments = link.Path,
                        WorkingDirectory = link.WorkingDirectory
                    });
            }
        }

        private void ToolStripButtonAction_Click(object sender, EventArgs e)
        {
        }

        private void ToolStripButtonUpdates_Click(object sender, EventArgs e)
        {
            var checkForUpdates = !toolStripButtonUpdates.Checked;
            toolStripButtonUpdates.Checked = checkForUpdates;
            Properties.Settings.Default.CheckForUpdates = checkForUpdates;
            Properties.Settings.Default.Save();
        }
    }
}