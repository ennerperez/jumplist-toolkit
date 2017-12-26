using System;
using System.Drawing;
using System.Windows.Forms;
using Toolkit.Models;

namespace Toolkit.Forms
{
    public partial class FormEditor : Form
    {
        public Link Model { get; set; }

        private void InitializeBinding()
        {
            textBoxTitle.DataBindings.Add("Text", Model, "Title", false, DataSourceUpdateMode.OnPropertyChanged);
            textBoxDescription.DataBindings.Add("Text", Model, "Description", false, DataSourceUpdateMode.OnPropertyChanged);
            textBoxFilePath.DataBindings.Add("Text", Model, "Path", false, DataSourceUpdateMode.OnPropertyChanged);
            textBoxWorkdir.DataBindings.Add("Text", Model, "WorkingDirectory", false, DataSourceUpdateMode.OnPropertyChanged);
            textBoxArguments.DataBindings.Add("Text", Model, "Arguments", false, DataSourceUpdateMode.OnPropertyChanged);
            textBoxIconLocation.DataBindings.Add("Text", Model, "IconLocation", false, DataSourceUpdateMode.OnPropertyChanged);
            numericUpDownIconIndex.DataBindings.Add("Value", Model, "IconIndex", false, DataSourceUpdateMode.OnPropertyChanged);
            textBoxCategory.DataBindings.Add("Text", Model, "Category", false, DataSourceUpdateMode.OnPropertyChanged);
        }

        public FormEditor(Link model)
        {
            InitializeComponent();

            Model = model;
            InitializeBinding();
        }

        private void ButtonFilePathExamine_Click(object sender, EventArgs e)
        {
            if (openFileDialogFile.ShowDialog() == DialogResult.OK)
                textBoxFilePath.Text = openFileDialogFile.FileName;

            if (string.IsNullOrEmpty(textBoxTitle.Text))
                textBoxTitle.Text = System.IO.Path.GetFileNameWithoutExtension(textBoxFilePath.Text);
        }

        private void ButtonWorkdirExamine_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialogWorkdir.ShowDialog() == DialogResult.OK)
                textBoxWorkdir.Text = folderBrowserDialogWorkdir.SelectedPath;
        }

        private void ButtonIconLocationExamine_Click(object sender, EventArgs e)
        {
            if (openFileDialogFile.ShowDialog() == DialogResult.OK)
            {
                textBoxIconLocation.Text = openFileDialogFile.FileName;
                PreviewIcon();
            }
        }

        private void NumericUpDownIconIndex_ValueChanged(object sender, EventArgs e)
        {
            PreviewIcon();
        }

        private void PreviewIcon()
        {
            try
            {
                var icon = Icon.ExtractAssociatedIcon(Model.IconLocation);
                pictureBoxIconPreview.Image = icon.ToBitmap();
            }
            catch (Exception)
            {
                pictureBoxIconPreview.Image = null;
            }
        }

        private void ButtonOk_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Model.Title) && !string.IsNullOrEmpty(Model.Path) && System.IO.File.Exists(Model.Path))
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}