namespace ApkExtractor
{
    partial class Form1
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
            this.PackageListBox = new System.Windows.Forms.ListBox();
            this.RefreshDeviceButton = new System.Windows.Forms.Button();
            this.DownloadButton = new System.Windows.Forms.Button();
            this.CancelDownloadButton = new System.Windows.Forms.Button();
            this.DownloadProgressLabel = new System.Windows.Forms.Label();
            this.SettingsButton = new System.Windows.Forms.Button();
            this.DeviceComboBox = new System.Windows.Forms.ComboBox();
            this.RefreshPackageButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PackageListBox
            // 
            this.PackageListBox.FormattingEnabled = true;
            this.PackageListBox.Location = new System.Drawing.Point(12, 63);
            this.PackageListBox.Name = "PackageListBox";
            this.PackageListBox.Size = new System.Drawing.Size(460, 342);
            this.PackageListBox.TabIndex = 0;
            // 
            // RefreshDeviceButton
            // 
            this.RefreshDeviceButton.Location = new System.Drawing.Point(12, 12);
            this.RefreshDeviceButton.Name = "RefreshDeviceButton";
            this.RefreshDeviceButton.Size = new System.Drawing.Size(70, 38);
            this.RefreshDeviceButton.TabIndex = 1;
            this.RefreshDeviceButton.Text = "Refresh devices";
            this.RefreshDeviceButton.UseVisualStyleBackColor = true;
            this.RefreshDeviceButton.Click += new System.EventHandler(this.RefreshDeviceButton_Click);
            // 
            // DownloadButton
            // 
            this.DownloadButton.Location = new System.Drawing.Point(12, 419);
            this.DownloadButton.Name = "DownloadButton";
            this.DownloadButton.Size = new System.Drawing.Size(70, 30);
            this.DownloadButton.TabIndex = 3;
            this.DownloadButton.Text = "Download";
            this.DownloadButton.UseVisualStyleBackColor = true;
            // 
            // CancelDownloadButton
            // 
            this.CancelDownloadButton.Location = new System.Drawing.Point(88, 419);
            this.CancelDownloadButton.Name = "CancelDownloadButton";
            this.CancelDownloadButton.Size = new System.Drawing.Size(70, 30);
            this.CancelDownloadButton.TabIndex = 4;
            this.CancelDownloadButton.Text = "Cancel";
            this.CancelDownloadButton.UseVisualStyleBackColor = true;
            // 
            // DownloadProgressLabel
            // 
            this.DownloadProgressLabel.AutoSize = true;
            this.DownloadProgressLabel.BackColor = System.Drawing.Color.White;
            this.DownloadProgressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DownloadProgressLabel.Location = new System.Drawing.Point(175, 420);
            this.DownloadProgressLabel.MinimumSize = new System.Drawing.Size(294, 25);
            this.DownloadProgressLabel.Name = "DownloadProgressLabel";
            this.DownloadProgressLabel.Size = new System.Drawing.Size(294, 25);
            this.DownloadProgressLabel.TabIndex = 5;
            this.DownloadProgressLabel.Text = "No Download In Progress";
            this.DownloadProgressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SettingsButton
            // 
            this.SettingsButton.Location = new System.Drawing.Point(414, 12);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(58, 38);
            this.SettingsButton.TabIndex = 6;
            this.SettingsButton.Text = "Settings";
            this.SettingsButton.UseVisualStyleBackColor = true;
            this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // DeviceComboBox
            // 
            this.DeviceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DeviceComboBox.FormattingEnabled = true;
            this.DeviceComboBox.Location = new System.Drawing.Point(164, 12);
            this.DeviceComboBox.Name = "DeviceComboBox";
            this.DeviceComboBox.Size = new System.Drawing.Size(244, 21);
            this.DeviceComboBox.TabIndex = 7;
            // 
            // RefreshPackageButton
            // 
            this.RefreshPackageButton.Location = new System.Drawing.Point(88, 12);
            this.RefreshPackageButton.Name = "RefreshPackageButton";
            this.RefreshPackageButton.Size = new System.Drawing.Size(70, 38);
            this.RefreshPackageButton.TabIndex = 8;
            this.RefreshPackageButton.Text = "Refresh packages";
            this.RefreshPackageButton.UseVisualStyleBackColor = true;
            this.RefreshPackageButton.Click += new System.EventHandler(this.RefreshPackageButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.RefreshPackageButton);
            this.Controls.Add(this.DeviceComboBox);
            this.Controls.Add(this.SettingsButton);
            this.Controls.Add(this.DownloadProgressLabel);
            this.Controls.Add(this.CancelDownloadButton);
            this.Controls.Add(this.DownloadButton);
            this.Controls.Add(this.RefreshDeviceButton);
            this.Controls.Add(this.PackageListBox);
            this.Name = "Form1";
            this.Text = "APK Extractor";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox PackageListBox;
        private System.Windows.Forms.Button RefreshDeviceButton;
        private System.Windows.Forms.Button DownloadButton;
        private System.Windows.Forms.Button CancelDownloadButton;
        private System.Windows.Forms.Label DownloadProgressLabel;
        private System.Windows.Forms.Button SettingsButton;
        private System.Windows.Forms.ComboBox DeviceComboBox;
        private System.Windows.Forms.Button RefreshPackageButton;
    }
}

