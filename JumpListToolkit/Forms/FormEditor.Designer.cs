namespace Toolkit.Forms
{
    partial class FormEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEditor));
            this.labelTitle = new System.Windows.Forms.Label();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.labelFilePath = new System.Windows.Forms.Label();
            this.textBoxFilePath = new System.Windows.Forms.TextBox();
            this.labelArguments = new System.Windows.Forms.Label();
            this.textBoxArguments = new System.Windows.Forms.TextBox();
            this.labelIconLocation = new System.Windows.Forms.Label();
            this.textBoxIconLocation = new System.Windows.Forms.TextBox();
            this.labelIconIndex = new System.Windows.Forms.Label();
            this.numericUpDownIconIndex = new System.Windows.Forms.NumericUpDown();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.checkBoxElevate = new System.Windows.Forms.CheckBox();
            this.buttonFilePathExamine = new System.Windows.Forms.Button();
            this.buttonIconLocationExamine = new System.Windows.Forms.Button();
            this.openFileDialogFile = new System.Windows.Forms.OpenFileDialog();
            this.labelWorkdir = new System.Windows.Forms.Label();
            this.textBoxWorkdir = new System.Windows.Forms.TextBox();
            this.buttonWorkdirExamine = new System.Windows.Forms.Button();
            this.folderBrowserDialogWorkdir = new System.Windows.Forms.FolderBrowserDialog();
            this.pictureBoxIconPreview = new System.Windows.Forms.PictureBox();
            this.labelCategory = new System.Windows.Forms.Label();
            this.textBoxCategory = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIconIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIconPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            resources.ApplyResources(this.labelTitle, "labelTitle");
            this.labelTitle.Name = "labelTitle";
            // 
            // textBoxTitle
            // 
            resources.ApplyResources(this.textBoxTitle, "textBoxTitle");
            this.textBoxTitle.Name = "textBoxTitle";
            // 
            // labelDescription
            // 
            resources.ApplyResources(this.labelDescription, "labelDescription");
            this.labelDescription.Name = "labelDescription";
            // 
            // textBoxDescription
            // 
            resources.ApplyResources(this.textBoxDescription, "textBoxDescription");
            this.textBoxDescription.Name = "textBoxDescription";
            // 
            // labelFilePath
            // 
            resources.ApplyResources(this.labelFilePath, "labelFilePath");
            this.labelFilePath.Name = "labelFilePath";
            // 
            // textBoxFilePath
            // 
            resources.ApplyResources(this.textBoxFilePath, "textBoxFilePath");
            this.textBoxFilePath.Name = "textBoxFilePath";
            // 
            // labelArguments
            // 
            resources.ApplyResources(this.labelArguments, "labelArguments");
            this.labelArguments.Name = "labelArguments";
            // 
            // textBoxArguments
            // 
            resources.ApplyResources(this.textBoxArguments, "textBoxArguments");
            this.textBoxArguments.Name = "textBoxArguments";
            // 
            // labelIconLocation
            // 
            resources.ApplyResources(this.labelIconLocation, "labelIconLocation");
            this.labelIconLocation.Name = "labelIconLocation";
            // 
            // textBoxIconLocation
            // 
            resources.ApplyResources(this.textBoxIconLocation, "textBoxIconLocation");
            this.textBoxIconLocation.Name = "textBoxIconLocation";
            // 
            // labelIconIndex
            // 
            resources.ApplyResources(this.labelIconIndex, "labelIconIndex");
            this.labelIconIndex.Name = "labelIconIndex";
            // 
            // numericUpDownIconIndex
            // 
            resources.ApplyResources(this.numericUpDownIconIndex, "numericUpDownIconIndex");
            this.numericUpDownIconIndex.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericUpDownIconIndex.Name = "numericUpDownIconIndex";
            this.numericUpDownIconIndex.ValueChanged += new System.EventHandler(this.NumericUpDownIconIndex_ValueChanged);
            // 
            // buttonOk
            // 
            resources.ApplyResources(this.buttonOk, "buttonOk");
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.ButtonOk_Click);
            // 
            // buttonCancel
            // 
            resources.ApplyResources(this.buttonCancel, "buttonCancel");
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // checkBoxElevate
            // 
            resources.ApplyResources(this.checkBoxElevate, "checkBoxElevate");
            this.checkBoxElevate.Name = "checkBoxElevate";
            this.checkBoxElevate.UseVisualStyleBackColor = true;
            // 
            // buttonFilePathExamine
            // 
            resources.ApplyResources(this.buttonFilePathExamine, "buttonFilePathExamine");
            this.buttonFilePathExamine.Name = "buttonFilePathExamine";
            this.buttonFilePathExamine.UseVisualStyleBackColor = true;
            this.buttonFilePathExamine.Click += new System.EventHandler(this.ButtonFilePathExamine_Click);
            // 
            // buttonIconLocationExamine
            // 
            resources.ApplyResources(this.buttonIconLocationExamine, "buttonIconLocationExamine");
            this.buttonIconLocationExamine.Name = "buttonIconLocationExamine";
            this.buttonIconLocationExamine.UseVisualStyleBackColor = true;
            this.buttonIconLocationExamine.Click += new System.EventHandler(this.ButtonIconLocationExamine_Click);
            // 
            // openFileDialogFile
            // 
            this.openFileDialogFile.DefaultExt = "*";
            resources.ApplyResources(this.openFileDialogFile, "openFileDialogFile");
            // 
            // labelWorkdir
            // 
            resources.ApplyResources(this.labelWorkdir, "labelWorkdir");
            this.labelWorkdir.Name = "labelWorkdir";
            // 
            // textBoxWorkdir
            // 
            resources.ApplyResources(this.textBoxWorkdir, "textBoxWorkdir");
            this.textBoxWorkdir.Name = "textBoxWorkdir";
            // 
            // buttonWorkdirExamine
            // 
            resources.ApplyResources(this.buttonWorkdirExamine, "buttonWorkdirExamine");
            this.buttonWorkdirExamine.Name = "buttonWorkdirExamine";
            this.buttonWorkdirExamine.UseVisualStyleBackColor = true;
            this.buttonWorkdirExamine.Click += new System.EventHandler(this.ButtonWorkdirExamine_Click);
            // 
            // pictureBoxIconPreview
            // 
            this.pictureBoxIconPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.pictureBoxIconPreview, "pictureBoxIconPreview");
            this.pictureBoxIconPreview.Name = "pictureBoxIconPreview";
            this.pictureBoxIconPreview.TabStop = false;
            // 
            // labelCategory
            // 
            resources.ApplyResources(this.labelCategory, "labelCategory");
            this.labelCategory.Name = "labelCategory";
            // 
            // textBoxCategory
            // 
            resources.ApplyResources(this.textBoxCategory, "textBoxCategory");
            this.textBoxCategory.Name = "textBoxCategory";
            // 
            // FormEditor
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBoxIconPreview);
            this.Controls.Add(this.checkBoxElevate);
            this.Controls.Add(this.buttonIconLocationExamine);
            this.Controls.Add(this.buttonWorkdirExamine);
            this.Controls.Add(this.buttonFilePathExamine);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.numericUpDownIconIndex);
            this.Controls.Add(this.textBoxIconLocation);
            this.Controls.Add(this.textBoxCategory);
            this.Controls.Add(this.textBoxArguments);
            this.Controls.Add(this.textBoxWorkdir);
            this.Controls.Add(this.textBoxFilePath);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.textBoxTitle);
            this.Controls.Add(this.labelIconIndex);
            this.Controls.Add(this.labelIconLocation);
            this.Controls.Add(this.labelCategory);
            this.Controls.Add(this.labelArguments);
            this.Controls.Add(this.labelWorkdir);
            this.Controls.Add(this.labelFilePath);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.labelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormEditor";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIconIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIconPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Label labelFilePath;
        private System.Windows.Forms.TextBox textBoxFilePath;
        private System.Windows.Forms.Label labelArguments;
        private System.Windows.Forms.TextBox textBoxArguments;
        private System.Windows.Forms.Label labelIconLocation;
        private System.Windows.Forms.TextBox textBoxIconLocation;
        private System.Windows.Forms.Label labelIconIndex;
        private System.Windows.Forms.NumericUpDown numericUpDownIconIndex;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.CheckBox checkBoxElevate;
        private System.Windows.Forms.Button buttonFilePathExamine;
        private System.Windows.Forms.Button buttonIconLocationExamine;
        private System.Windows.Forms.OpenFileDialog openFileDialogFile;
        private System.Windows.Forms.Label labelWorkdir;
        private System.Windows.Forms.TextBox textBoxWorkdir;
        private System.Windows.Forms.Button buttonWorkdirExamine;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogWorkdir;
        private System.Windows.Forms.PictureBox pictureBoxIconPreview;
        private System.Windows.Forms.Label labelCategory;
        private System.Windows.Forms.TextBox textBoxCategory;
    }
}