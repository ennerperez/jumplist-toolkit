namespace Toolkit.Forms
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonFile = new System.Windows.Forms.ToolStripDropDownButton();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonClose = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonAbout = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonAction = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonApply = new System.Windows.Forms.ToolStripButton();
            this.listViewTasks = new System.Windows.Forms.ListView();
            this.contextMenuStripItemActions = new System.Windows.Forms.ContextMenuStrip();
            this.launchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.defaultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageListIcons = new System.Windows.Forms.ImageList();
            this.openFileDialogSettings = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialogSettings = new System.Windows.Forms.SaveFileDialog();
            this.helpProviderMain = new System.Windows.Forms.HelpProvider();
            this.bufferedPanelPreview = new System.Windows.Forms.BufferedPanel();
            this.labelPreview = new System.Windows.Forms.Label();
            this.toolStripButtonUpdates = new System.Windows.Forms.ToolStripButton();
            this.toolStripMenu.SuspendLayout();
            this.contextMenuStripItemActions.SuspendLayout();
            this.bufferedPanelPreview.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMenu
            // 
            resources.ApplyResources(this.toolStripMenu, "toolStripMenu");
            this.toolStripMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.toolStripMenu.CanOverflow = false;
            this.toolStripMenu.GripMargin = new System.Windows.Forms.Padding(0);
            this.toolStripMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripMenu.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonFile,
            this.toolStripSeparator1,
            this.toolStripButtonAdd,
            this.toolStripButtonEdit,
            this.toolStripButtonDelete,
            this.toolStripButtonClose,
            this.toolStripButtonAbout,
            this.toolStripSeparator8,
            this.toolStripButtonAction,
            this.toolStripButtonApply,
            this.toolStripButtonUpdates});
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.helpProviderMain.SetShowHelp(this.toolStripMenu, ((bool)(resources.GetObject("toolStripMenu.ShowHelp"))));
            // 
            // toolStripButtonFile
            // 
            resources.ApplyResources(this.toolStripButtonFile, "toolStripButtonFile");
            this.toolStripButtonFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripSeparator3,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem});
            this.toolStripButtonFile.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripButtonFile.Name = "toolStripButtonFile";
            this.toolStripButtonFile.ShowDropDownArrow = false;
            // 
            // newToolStripMenuItem
            // 
            resources.ApplyResources(this.newToolStripMenuItem, "newToolStripMenuItem");
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.ToolStripButtonNew_Click);
            // 
            // openToolStripMenuItem
            // 
            resources.ApplyResources(this.openToolStripMenuItem, "openToolStripMenuItem");
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.ToolStripButtonOpen_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // saveToolStripMenuItem
            // 
            resources.ApplyResources(this.saveToolStripMenuItem, "saveToolStripMenuItem");
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.ToolStripButtonSave_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            resources.ApplyResources(this.saveAsToolStripMenuItem, "saveAsToolStripMenuItem");
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItemSaveAs_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // toolStripButtonAdd
            // 
            resources.ApplyResources(this.toolStripButtonAdd, "toolStripButtonAdd");
            this.toolStripButtonAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAdd.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripButtonAdd.Name = "toolStripButtonAdd";
            this.toolStripButtonAdd.Click += new System.EventHandler(this.ToolStripButtonAdd_Click);
            // 
            // toolStripButtonEdit
            // 
            resources.ApplyResources(this.toolStripButtonEdit, "toolStripButtonEdit");
            this.toolStripButtonEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonEdit.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripButtonEdit.Name = "toolStripButtonEdit";
            this.toolStripButtonEdit.Click += new System.EventHandler(this.ToolStripButtonEdit_Click);
            // 
            // toolStripButtonDelete
            // 
            resources.ApplyResources(this.toolStripButtonDelete, "toolStripButtonDelete");
            this.toolStripButtonDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDelete.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripButtonDelete.Name = "toolStripButtonDelete";
            this.toolStripButtonDelete.Click += new System.EventHandler(this.ToolStripButtonDelete_Click);
            // 
            // toolStripButtonClose
            // 
            this.toolStripButtonClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            resources.ApplyResources(this.toolStripButtonClose, "toolStripButtonClose");
            this.toolStripButtonClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonClose.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripButtonClose.Name = "toolStripButtonClose";
            this.toolStripButtonClose.Click += new System.EventHandler(this.ToolStripButtonExit_Click);
            // 
            // toolStripButtonAbout
            // 
            this.toolStripButtonAbout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            resources.ApplyResources(this.toolStripButtonAbout, "toolStripButtonAbout");
            this.toolStripButtonAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAbout.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripButtonAbout.Name = "toolStripButtonAbout";
            this.toolStripButtonAbout.Click += new System.EventHandler(this.ToolStripButtonAbout_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            resources.ApplyResources(this.toolStripSeparator8, "toolStripSeparator8");
            // 
            // toolStripButtonAction
            // 
            resources.ApplyResources(this.toolStripButtonAction, "toolStripButtonAction");
            this.toolStripButtonAction.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAction.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripButtonAction.Name = "toolStripButtonAction";
            this.toolStripButtonAction.Click += new System.EventHandler(this.ToolStripButtonAction_Click);
            // 
            // toolStripButtonApply
            // 
            resources.ApplyResources(this.toolStripButtonApply, "toolStripButtonApply");
            this.toolStripButtonApply.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonApply.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripButtonApply.Name = "toolStripButtonApply";
            this.toolStripButtonApply.Click += new System.EventHandler(this.ToolStripButtonApply_Click);
            // 
            // listViewTasks
            // 
            resources.ApplyResources(this.listViewTasks, "listViewTasks");
            this.listViewTasks.BackColor = System.Drawing.SystemColors.Control;
            this.listViewTasks.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewTasks.ContextMenuStrip = this.contextMenuStripItemActions;
            this.listViewTasks.LargeImageList = this.imageListIcons;
            this.listViewTasks.Name = "listViewTasks";
            this.helpProviderMain.SetShowHelp(this.listViewTasks, ((bool)(resources.GetObject("listViewTasks.ShowHelp"))));
            this.listViewTasks.SmallImageList = this.imageListIcons;
            this.listViewTasks.UseCompatibleStateImageBehavior = false;
            this.listViewTasks.View = System.Windows.Forms.View.Tile;
            this.listViewTasks.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.ListViewTasks_ItemSelectionChanged);
            this.listViewTasks.DragDrop += new System.Windows.Forms.DragEventHandler(this.FormMain_DragDrop);
            this.listViewTasks.DragEnter += new System.Windows.Forms.DragEventHandler(this.FormMain_DragEnter);
            this.listViewTasks.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListViewTasks_MouseDoubleClick);
            // 
            // contextMenuStripItemActions
            // 
            this.contextMenuStripItemActions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.launchToolStripMenuItem,
            this.toolStripSeparator4,
            this.addToolStripMenuItem,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.toolStripSeparator2,
            this.defaultToolStripMenuItem});
            this.contextMenuStripItemActions.Name = "contextMenuStripItemActions";
            this.helpProviderMain.SetShowHelp(this.contextMenuStripItemActions, ((bool)(resources.GetObject("contextMenuStripItemActions.ShowHelp"))));
            resources.ApplyResources(this.contextMenuStripItemActions, "contextMenuStripItemActions");
            // 
            // launchToolStripMenuItem
            // 
            resources.ApplyResources(this.launchToolStripMenuItem, "launchToolStripMenuItem");
            this.launchToolStripMenuItem.Name = "launchToolStripMenuItem";
            this.launchToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItemLaunch_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            resources.ApplyResources(this.addToolStripMenuItem, "addToolStripMenuItem");
            this.addToolStripMenuItem.Click += new System.EventHandler(this.ToolStripButtonAdd_Click);
            // 
            // editToolStripMenuItem
            // 
            resources.ApplyResources(this.editToolStripMenuItem, "editToolStripMenuItem");
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.ToolStripButtonEdit_Click);
            // 
            // deleteToolStripMenuItem
            // 
            resources.ApplyResources(this.deleteToolStripMenuItem, "deleteToolStripMenuItem");
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.ToolStripButtonDelete_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // defaultToolStripMenuItem
            // 
            resources.ApplyResources(this.defaultToolStripMenuItem, "defaultToolStripMenuItem");
            this.defaultToolStripMenuItem.Name = "defaultToolStripMenuItem";
            this.defaultToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItemDefault_Click);
            // 
            // imageListIcons
            // 
            this.imageListIcons.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            resources.ApplyResources(this.imageListIcons, "imageListIcons");
            this.imageListIcons.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // openFileDialogSettings
            // 
            this.openFileDialogSettings.DefaultExt = "json";
            resources.ApplyResources(this.openFileDialogSettings, "openFileDialogSettings");
            this.openFileDialogSettings.FileOk += new System.ComponentModel.CancelEventHandler(this.OpenFileDialogSettings_FileOk);
            // 
            // saveFileDialogSettings
            // 
            this.saveFileDialogSettings.DefaultExt = "json";
            resources.ApplyResources(this.saveFileDialogSettings, "saveFileDialogSettings");
            this.saveFileDialogSettings.FileOk += new System.ComponentModel.CancelEventHandler(this.SaveFileDialogSettings_FileOk);
            // 
            // bufferedPanelPreview
            // 
            this.bufferedPanelPreview.AllowDrop = true;
            resources.ApplyResources(this.bufferedPanelPreview, "bufferedPanelPreview");
            this.bufferedPanelPreview.Controls.Add(this.labelPreview);
            this.bufferedPanelPreview.Name = "bufferedPanelPreview";
            this.helpProviderMain.SetShowHelp(this.bufferedPanelPreview, ((bool)(resources.GetObject("bufferedPanelPreview.ShowHelp"))));
            // 
            // labelPreview
            // 
            this.labelPreview.AllowDrop = true;
            this.labelPreview.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.labelPreview, "labelPreview");
            this.labelPreview.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelPreview.Name = "labelPreview";
            this.helpProviderMain.SetShowHelp(this.labelPreview, ((bool)(resources.GetObject("labelPreview.ShowHelp"))));
            this.labelPreview.DragDrop += new System.Windows.Forms.DragEventHandler(this.FormMain_DragDrop);
            this.labelPreview.DragEnter += new System.Windows.Forms.DragEventHandler(this.FormMain_DragEnter);
            this.labelPreview.DragLeave += new System.EventHandler(this.FormMain_DragLeave);
            // 
            // toolStripButtonUpdates
            // 
            this.toolStripButtonUpdates.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            resources.ApplyResources(this.toolStripButtonUpdates, "toolStripButtonUpdates");
            this.toolStripButtonUpdates.Checked = global::Toolkit.Properties.Settings.Default.CheckForUpdates;
            this.toolStripButtonUpdates.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripButtonUpdates.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonUpdates.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripButtonUpdates.Name = "toolStripButtonUpdates";
            this.toolStripButtonUpdates.Click += new System.EventHandler(this.ToolStripButtonUpdates_Click);
            // 
            // FormMain
            // 
            this.AllowDrop = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bufferedPanelPreview);
            this.Controls.Add(this.listViewTasks);
            this.Controls.Add(this.toolStripMenu);
            this.Name = "FormMain";
            this.helpProviderMain.SetShowHelp(this, ((bool)(resources.GetObject("$this.ShowHelp"))));
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.Shown += new System.EventHandler(this.FormMain_Shown);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FormMain_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FormMain_DragEnter);
            this.DragLeave += new System.EventHandler(this.FormMain_DragLeave);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            this.contextMenuStripItemActions.ResumeLayout(false);
            this.bufferedPanelPreview.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton toolStripButtonEdit;
        private System.Windows.Forms.ToolStripButton toolStripButtonClose;
        private System.Windows.Forms.ToolStripButton toolStripButtonAbout;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton toolStripButtonApply;
        private System.Windows.Forms.ListView listViewTasks;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripItemActions;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ImageList imageListIcons;
        private System.Windows.Forms.OpenFileDialog openFileDialogSettings;
        private System.Windows.Forms.SaveFileDialog saveFileDialogSettings;
        private System.Windows.Forms.ToolStripButton toolStripButtonAdd;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem defaultToolStripMenuItem;
        private System.Windows.Forms.HelpProvider helpProviderMain;
        private System.Windows.Forms.BufferedPanel bufferedPanelPreview;
        private System.Windows.Forms.Label labelPreview;
        private System.Windows.Forms.ToolStripDropDownButton toolStripButtonFile;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem launchToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolStripButtonAction;
        private System.Windows.Forms.ToolStripButton toolStripButtonUpdates;
    }
}

