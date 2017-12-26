using System;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace Toolkit.Forms
{
    public partial class FormAbout : Form
    {
        public FormAbout()
        {
            InitializeComponent();

            Icon = Icon.ExtractAssociatedIcon(Assembly.GetEntryAssembly().Location);

            labelAbout.Text = string.Format(labelAbout.Text,
                ApplicationInfo.Description,
                ApplicationInfo.Version.ToString(),
                ApplicationInfo.Copyright);

            richTextBoxChangeLog.Text = System.Text.Encoding.UTF8.GetString(Properties.Resources.CHANGELOG);
            richTextBoxLicense.Text = System.Text.Encoding.UTF8.GetString(Properties.Resources.LICENSE);

            linkLabelWeb.Text = GitHubInfo.Repo;
            buttonUpdate.Visible = (GitHubInfo.LatestRelease != null && (GitHubInfo.LatestRelease.GetVersion() > ApplicationInfo.Version));

            pictureBoxIcon.Image = Icon.ToBitmap();
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LinkLabelWeb_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start((sender as LinkLabel).Text);
        }

        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            Process.Start(GitHubInfo.Repo);
        }

        private async void FormAbout_Load(object sender, EventArgs e)
        {
            if (GitHubInfo.LatestRelease == null) await GitHubInfo.GetLatestReleaseAsync();
            buttonUpdate.Visible = (GitHubInfo.LatestRelease != null && (GitHubInfo.LatestRelease.GetVersion() > ApplicationInfo.Version));
        }
    }
}