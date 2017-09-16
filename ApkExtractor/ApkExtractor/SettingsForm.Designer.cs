namespace ApkExtractor
{
    partial class SettingsForm
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
            this.AdbLocationTextBox = new System.Windows.Forms.TextBox();
            this.SelectFileButton = new System.Windows.Forms.Button();
            this.ConfirmSelectionButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AdbLocationTextBox
            // 
            this.AdbLocationTextBox.Location = new System.Drawing.Point(12, 12);
            this.AdbLocationTextBox.Name = "AdbLocationTextBox";
            this.AdbLocationTextBox.Size = new System.Drawing.Size(369, 20);
            this.AdbLocationTextBox.TabIndex = 0;
            this.AdbLocationTextBox.Text = "No File Selected";
            // 
            // SelectFileButton
            // 
            this.SelectFileButton.Location = new System.Drawing.Point(387, 10);
            this.SelectFileButton.Name = "SelectFileButton";
            this.SelectFileButton.Size = new System.Drawing.Size(75, 23);
            this.SelectFileButton.TabIndex = 1;
            this.SelectFileButton.Text = "Browse...";
            this.SelectFileButton.UseVisualStyleBackColor = true;
            this.SelectFileButton.Click += new System.EventHandler(this.SelectFileButton_Click);
            // 
            // ConfirmSelectionButton
            // 
            this.ConfirmSelectionButton.Location = new System.Drawing.Point(468, 10);
            this.ConfirmSelectionButton.Name = "ConfirmSelectionButton";
            this.ConfirmSelectionButton.Size = new System.Drawing.Size(75, 23);
            this.ConfirmSelectionButton.TabIndex = 2;
            this.ConfirmSelectionButton.Text = "Confirm";
            this.ConfirmSelectionButton.UseVisualStyleBackColor = true;
            this.ConfirmSelectionButton.Click += new System.EventHandler(this.ConfirmSelectionButton_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 45);
            this.Controls.Add(this.ConfirmSelectionButton);
            this.Controls.Add(this.SelectFileButton);
            this.Controls.Add(this.AdbLocationTextBox);
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox AdbLocationTextBox;
        private System.Windows.Forms.Button SelectFileButton;
        private System.Windows.Forms.Button ConfirmSelectionButton;
    }
}