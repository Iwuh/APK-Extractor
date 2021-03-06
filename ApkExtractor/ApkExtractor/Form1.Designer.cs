﻿namespace ApkExtractor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.PackageListBox = new System.Windows.Forms.ListBox();
            this.RefreshDeviceButton = new System.Windows.Forms.Button();
            this.TransferButton = new System.Windows.Forms.Button();
            this.CancelTransferButton = new System.Windows.Forms.Button();
            this.TransferProgressLabel = new System.Windows.Forms.Label();
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
            this.RefreshDeviceButton.Location = new System.Drawing.Point(12, 7);
            this.RefreshDeviceButton.Name = "RefreshDeviceButton";
            this.RefreshDeviceButton.Size = new System.Drawing.Size(105, 23);
            this.RefreshDeviceButton.TabIndex = 1;
            this.RefreshDeviceButton.Text = "Refresh devices";
            this.RefreshDeviceButton.UseVisualStyleBackColor = true;
            this.RefreshDeviceButton.Click += new System.EventHandler(this.RefreshDeviceButton_Click);
            // 
            // TransferButton
            // 
            this.TransferButton.Location = new System.Drawing.Point(12, 419);
            this.TransferButton.Name = "TransferButton";
            this.TransferButton.Size = new System.Drawing.Size(70, 30);
            this.TransferButton.TabIndex = 3;
            this.TransferButton.Text = "Transfer";
            this.TransferButton.UseVisualStyleBackColor = true;
            this.TransferButton.Click += new System.EventHandler(this.TransferButton_Click);
            // 
            // CancelTransferButton
            // 
            this.CancelTransferButton.Location = new System.Drawing.Point(88, 419);
            this.CancelTransferButton.Name = "CancelTransferButton";
            this.CancelTransferButton.Size = new System.Drawing.Size(70, 30);
            this.CancelTransferButton.TabIndex = 4;
            this.CancelTransferButton.Text = "Cancel";
            this.CancelTransferButton.UseVisualStyleBackColor = true;
            this.CancelTransferButton.Click += new System.EventHandler(this.CancelTransferButton_Click);
            // 
            // TransferProgressLabel
            // 
            this.TransferProgressLabel.AutoSize = true;
            this.TransferProgressLabel.BackColor = System.Drawing.Color.White;
            this.TransferProgressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TransferProgressLabel.Location = new System.Drawing.Point(175, 420);
            this.TransferProgressLabel.MinimumSize = new System.Drawing.Size(294, 25);
            this.TransferProgressLabel.Name = "TransferProgressLabel";
            this.TransferProgressLabel.Size = new System.Drawing.Size(294, 25);
            this.TransferProgressLabel.TabIndex = 5;
            this.TransferProgressLabel.Text = "No Transfer In Progress";
            this.TransferProgressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SettingsButton
            // 
            this.SettingsButton.Location = new System.Drawing.Point(234, 7);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(58, 23);
            this.SettingsButton.TabIndex = 6;
            this.SettingsButton.Text = "Settings";
            this.SettingsButton.UseVisualStyleBackColor = true;
            this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // DeviceComboBox
            // 
            this.DeviceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DeviceComboBox.FormattingEnabled = true;
            this.DeviceComboBox.Location = new System.Drawing.Point(12, 36);
            this.DeviceComboBox.Name = "DeviceComboBox";
            this.DeviceComboBox.Size = new System.Drawing.Size(460, 21);
            this.DeviceComboBox.TabIndex = 7;
            // 
            // RefreshPackageButton
            // 
            this.RefreshPackageButton.Location = new System.Drawing.Point(123, 7);
            this.RefreshPackageButton.Name = "RefreshPackageButton";
            this.RefreshPackageButton.Size = new System.Drawing.Size(105, 23);
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
            this.Controls.Add(this.TransferProgressLabel);
            this.Controls.Add(this.CancelTransferButton);
            this.Controls.Add(this.TransferButton);
            this.Controls.Add(this.RefreshDeviceButton);
            this.Controls.Add(this.PackageListBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "APK Extractor";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox PackageListBox;
        private System.Windows.Forms.Button RefreshDeviceButton;
        private System.Windows.Forms.Button TransferButton;
        private System.Windows.Forms.Button CancelTransferButton;
        private System.Windows.Forms.Label TransferProgressLabel;
        private System.Windows.Forms.Button SettingsButton;
        private System.Windows.Forms.ComboBox DeviceComboBox;
        private System.Windows.Forms.Button RefreshPackageButton;
    }
}

