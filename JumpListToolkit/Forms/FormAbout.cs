using System;
using System.Drawing;
using System.Windows.Forms;

namespace Toolkit.Forms
{
    public partial class FormAbout : Form
    {
        public FormAbout()
        {
            InitializeComponent();

            Icon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetEntryAssembly().Location);

            labelAbout.Text = string.Format(labelAbout.Text,
                ApplicationInfo.Description,
                ApplicationInfo.Version.ToString(),
                ApplicationInfo.CopyrightHolder);

            richTextBoxChangeLog.Text = System.Text.Encoding.UTF8.GetString(Properties.Resources.CHANGELOG);
            richTextBoxLicense.Text = System.Text.Encoding.UTF8.GetString(Properties.Resources.LICENSE);

            pictureBoxIcon.Image = Icon.ToBitmap();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabelWeb_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start((sender as LinkLabel).Text);
        }
    }
}