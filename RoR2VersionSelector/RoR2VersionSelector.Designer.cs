namespace RoR2VersionSelector
{
    partial class RoR2VersionSelector
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
            this.ButtonDownloadDepot = new System.Windows.Forms.Button();
            this.TextBoxDepotDownloaderResult = new System.Windows.Forms.TextBox();
            this.PanelMain = new System.Windows.Forms.Panel();
            this.GroupBoxMain = new System.Windows.Forms.GroupBox();
            this.CheckBoxDownloadOnlyDLLFiles = new System.Windows.Forms.CheckBox();
            this.ButtonCopyDownloadedVersionToSteamInstall = new System.Windows.Forms.Button();
            this.TextBoxUsername = new System.Windows.Forms.TextBox();
            this.LabelUsername = new System.Windows.Forms.Label();
            this.ComboBoxVersionSelector = new System.Windows.Forms.ComboBox();
            this.PanelMain.SuspendLayout();
            this.GroupBoxMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonDownloadDepot
            // 
            this.ButtonDownloadDepot.AutoSize = true;
            this.ButtonDownloadDepot.Dock = System.Windows.Forms.DockStyle.Top;
            this.ButtonDownloadDepot.Location = new System.Drawing.Point(3, 70);
            this.ButtonDownloadDepot.Name = "ButtonDownloadDepot";
            this.ButtonDownloadDepot.Size = new System.Drawing.Size(794, 23);
            this.ButtonDownloadDepot.TabIndex = 3;
            this.ButtonDownloadDepot.Text = "Download";
            this.ButtonDownloadDepot.UseVisualStyleBackColor = true;
            this.ButtonDownloadDepot.Click += new System.EventHandler(this.ButtonDownloadDepot_Click);
            // 
            // TextBoxDepotDownloaderResult
            // 
            this.TextBoxDepotDownloaderResult.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TextBoxDepotDownloaderResult.Location = new System.Drawing.Point(0, 198);
            this.TextBoxDepotDownloaderResult.Multiline = true;
            this.TextBoxDepotDownloaderResult.Name = "TextBoxDepotDownloaderResult";
            this.TextBoxDepotDownloaderResult.Size = new System.Drawing.Size(800, 252);
            this.TextBoxDepotDownloaderResult.TabIndex = 2;
            this.TextBoxDepotDownloaderResult.TabStop = false;
            // 
            // PanelMain
            // 
            this.PanelMain.Controls.Add(this.GroupBoxMain);
            this.PanelMain.Controls.Add(this.TextBoxDepotDownloaderResult);
            this.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelMain.Location = new System.Drawing.Point(0, 0);
            this.PanelMain.Name = "PanelMain";
            this.PanelMain.Size = new System.Drawing.Size(800, 450);
            this.PanelMain.TabIndex = 2;
            // 
            // GroupBoxMain
            // 
            this.GroupBoxMain.AutoSize = true;
            this.GroupBoxMain.Controls.Add(this.CheckBoxDownloadOnlyDLLFiles);
            this.GroupBoxMain.Controls.Add(this.ButtonCopyDownloadedVersionToSteamInstall);
            this.GroupBoxMain.Controls.Add(this.ButtonDownloadDepot);
            this.GroupBoxMain.Controls.Add(this.TextBoxUsername);
            this.GroupBoxMain.Controls.Add(this.LabelUsername);
            this.GroupBoxMain.Controls.Add(this.ComboBoxVersionSelector);
            this.GroupBoxMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.GroupBoxMain.Location = new System.Drawing.Point(0, 0);
            this.GroupBoxMain.Name = "GroupBoxMain";
            this.GroupBoxMain.Size = new System.Drawing.Size(800, 192);
            this.GroupBoxMain.TabIndex = 0;
            this.GroupBoxMain.TabStop = false;
            this.GroupBoxMain.Text = "Version Selection";
            // 
            // CheckBoxDownloadOnlyDLLFiles
            // 
            this.CheckBoxDownloadOnlyDLLFiles.Location = new System.Drawing.Point(316, 155);
            this.CheckBoxDownloadOnlyDLLFiles.Name = "CheckBoxDownloadOnlyDLLFiles";
            this.CheckBoxDownloadOnlyDLLFiles.Size = new System.Drawing.Size(161, 18);
            this.CheckBoxDownloadOnlyDLLFiles.TabIndex = 3;
            this.CheckBoxDownloadOnlyDLLFiles.Text = "Download Only DLL Files";
            this.CheckBoxDownloadOnlyDLLFiles.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBoxDownloadOnlyDLLFiles.UseVisualStyleBackColor = true;
            this.CheckBoxDownloadOnlyDLLFiles.CheckedChanged += new System.EventHandler(this.CheckBoxDownloadOnlyDLLFiles_CheckedChanged);
            // 
            // ButtonCopyDownloadedVersionToSteamInstall
            // 
            this.ButtonCopyDownloadedVersionToSteamInstall.AutoSize = true;
            this.ButtonCopyDownloadedVersionToSteamInstall.Dock = System.Windows.Forms.DockStyle.Top;
            this.ButtonCopyDownloadedVersionToSteamInstall.Location = new System.Drawing.Point(3, 93);
            this.ButtonCopyDownloadedVersionToSteamInstall.Name = "ButtonCopyDownloadedVersionToSteamInstall";
            this.ButtonCopyDownloadedVersionToSteamInstall.Size = new System.Drawing.Size(794, 23);
            this.ButtonCopyDownloadedVersionToSteamInstall.TabIndex = 4;
            this.ButtonCopyDownloadedVersionToSteamInstall.Text = "Copy Downloaded Version To Steam Install";
            this.ButtonCopyDownloadedVersionToSteamInstall.UseVisualStyleBackColor = true;
            this.ButtonCopyDownloadedVersionToSteamInstall.Click += new System.EventHandler(this.ButtonCopyDownloadedVersionToSteamInstall_Click);
            // 
            // TextBoxUsername
            // 
            this.TextBoxUsername.Dock = System.Windows.Forms.DockStyle.Top;
            this.TextBoxUsername.Location = new System.Drawing.Point(3, 50);
            this.TextBoxUsername.Name = "TextBoxUsername";
            this.TextBoxUsername.Size = new System.Drawing.Size(794, 20);
            this.TextBoxUsername.TabIndex = 1;
            this.TextBoxUsername.TextChanged += new System.EventHandler(this.TextBoxUsername_TextChanged);
            // 
            // LabelUsername
            // 
            this.LabelUsername.AutoSize = true;
            this.LabelUsername.Dock = System.Windows.Forms.DockStyle.Top;
            this.LabelUsername.Location = new System.Drawing.Point(3, 37);
            this.LabelUsername.Name = "LabelUsername";
            this.LabelUsername.Size = new System.Drawing.Size(55, 13);
            this.LabelUsername.TabIndex = 3;
            this.LabelUsername.Text = "Username";
            // 
            // ComboBoxVersionSelector
            // 
            this.ComboBoxVersionSelector.Dock = System.Windows.Forms.DockStyle.Top;
            this.ComboBoxVersionSelector.FormattingEnabled = true;
            this.ComboBoxVersionSelector.Location = new System.Drawing.Point(3, 16);
            this.ComboBoxVersionSelector.Name = "ComboBoxVersionSelector";
            this.ComboBoxVersionSelector.Size = new System.Drawing.Size(794, 21);
            this.ComboBoxVersionSelector.TabIndex = 0;
            this.ComboBoxVersionSelector.SelectedIndexChanged += new System.EventHandler(this.ComboBoxVersionSelector_SelectedIndexChanged);
            // 
            // RoR2VersionSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PanelMain);
            this.Name = "RoR2VersionSelector";
            this.Text = "RoR2 Version Selector";
            this.Load += new System.EventHandler(this.RoR2VersionSelector_Load);
            this.PanelMain.ResumeLayout(false);
            this.PanelMain.PerformLayout();
            this.GroupBoxMain.ResumeLayout(false);
            this.GroupBoxMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ButtonDownloadDepot;
        private System.Windows.Forms.TextBox TextBoxDepotDownloaderResult;
        private System.Windows.Forms.Panel PanelMain;
        private System.Windows.Forms.ComboBox ComboBoxVersionSelector;
        private System.Windows.Forms.GroupBox GroupBoxMain;
        private System.Windows.Forms.Label LabelUsername;
        private System.Windows.Forms.TextBox TextBoxUsername;
        private System.Windows.Forms.Button ButtonCopyDownloadedVersionToSteamInstall;
        private System.Windows.Forms.CheckBox CheckBoxDownloadOnlyDLLFiles;
    }
}

