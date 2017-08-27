namespace ApkExtractor
{
    partial class SelectDeviceForm
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
            this.DeviceListBox = new System.Windows.Forms.ListBox();
            this.ConfirmDeviceButton = new System.Windows.Forms.Button();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DeviceListBox
            // 
            this.DeviceListBox.FormattingEnabled = true;
            this.DeviceListBox.Location = new System.Drawing.Point(12, 12);
            this.DeviceListBox.Name = "DeviceListBox";
            this.DeviceListBox.Size = new System.Drawing.Size(260, 212);
            this.DeviceListBox.TabIndex = 0;
            // 
            // ConfirmDeviceButton
            // 
            this.ConfirmDeviceButton.Location = new System.Drawing.Point(197, 230);
            this.ConfirmDeviceButton.Name = "ConfirmDeviceButton";
            this.ConfirmDeviceButton.Size = new System.Drawing.Size(75, 23);
            this.ConfirmDeviceButton.TabIndex = 1;
            this.ConfirmDeviceButton.Text = "Select";
            this.ConfirmDeviceButton.UseVisualStyleBackColor = true;
            this.ConfirmDeviceButton.Click += new System.EventHandler(this.ConfirmDeviceButton_Click);
            // 
            // RefreshButton
            // 
            this.RefreshButton.Location = new System.Drawing.Point(12, 230);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(75, 23);
            this.RefreshButton.TabIndex = 2;
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // SelectDeviceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.ConfirmDeviceButton);
            this.Controls.Add(this.DeviceListBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectDeviceForm";
            this.Text = "SelectDeviceForm";
            this.Load += new System.EventHandler(this.SelectDeviceForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox DeviceListBox;
        private System.Windows.Forms.Button ConfirmDeviceButton;
        private System.Windows.Forms.Button RefreshButton;
    }
}