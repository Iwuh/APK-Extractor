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
            this.DeviceButton = new System.Windows.Forms.Button();
            this.CurrentDeviceLabel = new System.Windows.Forms.Label();
            this.DownloadButton = new System.Windows.Forms.Button();
            this.CancelDownloadButton = new System.Windows.Forms.Button();
            this.DownloadProgressLabel = new System.Windows.Forms.Label();
            this.SettingsButton = new System.Windows.Forms.Button();
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
            // DeviceButton
            // 
            this.DeviceButton.Location = new System.Drawing.Point(12, 12);
            this.DeviceButton.Name = "DeviceButton";
            this.DeviceButton.Size = new System.Drawing.Size(70, 38);
            this.DeviceButton.TabIndex = 1;
            this.DeviceButton.Text = "Devices";
            this.DeviceButton.UseVisualStyleBackColor = true;
            // 
            // CurrentDeviceLabel
            // 
            this.CurrentDeviceLabel.AutoSize = true;
            this.CurrentDeviceLabel.BackColor = System.Drawing.Color.White;
            this.CurrentDeviceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentDeviceLabel.Location = new System.Drawing.Point(98, 12);
            this.CurrentDeviceLabel.MinimumSize = new System.Drawing.Size(310, 40);
            this.CurrentDeviceLabel.Name = "CurrentDeviceLabel";
            this.CurrentDeviceLabel.Size = new System.Drawing.Size(310, 40);
            this.CurrentDeviceLabel.TabIndex = 2;
            this.CurrentDeviceLabel.Text = "No Device Selected";
            this.CurrentDeviceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.SettingsButton);
            this.Controls.Add(this.DownloadProgressLabel);
            this.Controls.Add(this.CancelDownloadButton);
            this.Controls.Add(this.DownloadButton);
            this.Controls.Add(this.CurrentDeviceLabel);
            this.Controls.Add(this.DeviceButton);
            this.Controls.Add(this.PackageListBox);
            this.Name = "Form1";
            this.Text = "APK Extractor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox PackageListBox;
        private System.Windows.Forms.Button DeviceButton;
        private System.Windows.Forms.Label CurrentDeviceLabel;
        private System.Windows.Forms.Button DownloadButton;
        private System.Windows.Forms.Button CancelDownloadButton;
        private System.Windows.Forms.Label DownloadProgressLabel;
        private System.Windows.Forms.Button SettingsButton;
    }
}

