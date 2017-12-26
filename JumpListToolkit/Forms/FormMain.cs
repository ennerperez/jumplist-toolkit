using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Pictograms;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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

            Icon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetEntryAssembly().Location);

            // Icons
            toolStripButtonNew.SetImage(MaterialDesign.Instance, MaterialDesign.IconType.insert_drive_file, 48, Color.White);
            toolStripButtonOpen.SetImage(MaterialDesign.Instance, MaterialDesign.IconType.folder_open, 48, Color.White);
            toolStripButtonSave.SetImage(MaterialDesign.Instance, MaterialDesign.IconType.save, 48, Color.White);

            toolStripButtonAdd.SetImage(MaterialDesign.Instance, MaterialDesign.IconType.add, 48, Color.White);
            toolStripButtonEdit.SetImage(MaterialDesign.Instance, MaterialDesign.IconType.edit, 48, Color.White);
            toolStripButtonDelete.SetImage(MaterialDesign.Instance, MaterialDesign.IconType.delete, 48, Color.White);

            toolStripButtonRefresh.SetImage(MaterialDesign.Instance, MaterialDesign.IconType.refresh, 48, Color.White);

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
                                 group item by item.Category into g
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

        #region MainActions

        private void toolStripButtonNew_Click(object sender, EventArgs e)
        {
            Source = string.Empty;
            Model = new List<Link>();
            RenderContent();
        }

        private void toolStripButtonOpen_Click(object sender, EventArgs e)
        {
            openFileDialogSettings.ShowDialog();
        }

        private void openFileDialogSettings_FileOk(object sender, CancelEventArgs e)
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

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Source) || !File.Exists(Path.ChangeExtension(Source, "lnk")))
            {
                saveFileDialogSettings.FileName = Path.ChangeExtension(Program.Assembly.Location, "json");
                saveFileDialogSettings.ShowDialog();
            }
            else
            {
                saveFileDialogSettings.FileName = Source;
                saveFileDialogSettings_FileOk(sender, new CancelEventArgs(false));
            }
        }

        private void saveFileDialogSettings_FileOk(object sender, CancelEventArgs e)
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

        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            var child = new FormEditor(new Link()) { StartPosition = FormStartPosition.CenterParent, Icon = this.Icon };
            if (child.ShowDialog() == DialogResult.OK)
            {
                Model.Add(child.Model);
                RenderContent();
            }
        }

        private void toolStripButtonEdit_Click(object sender, EventArgs e)
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

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            if (listViewTasks.SelectedItems != null && listViewTasks.SelectedItems.OfType<ListViewItem>().Any())
                foreach (var item in listViewTasks.SelectedItems.OfType<ListViewItem>())
                {
                    Model.Remove((item.Tag as Link));
                    RenderContent();
                }
        }

        private void listViewTasks_MouseDoubleClick(object sender, MouseEventArgs e)
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

        #endregion ItemActions

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            if (Model != null)
                Program.RegisterTaskBarActions(Model);
        }

        private void toolStripButtonAbout_Click(object sender, EventArgs e)
        {
            var child = new FormAbout();
            child.ShowDialog();
        }

        private void toolStripButtonExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}