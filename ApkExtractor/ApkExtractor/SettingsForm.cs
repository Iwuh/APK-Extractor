using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApkExtractor
{
    public partial class SettingsForm : Form
    {
        private const string SETTINGS_FILE = @".\ApkExtractorSettings.txt";

        private readonly SettingsManager _settings;

        public SettingsForm(SettingsManager settings)
        {
            InitializeComponent();

            _settings = settings;
            if (_settings.TryGetPath(out string path))
            {
                AdbLocationTextBox.Text = path;
            }
        }

        private void SelectFileButton_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                // Display a dialog box prompting the user to select a file.
                var result = dialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    // Update the text box.
                    AdbLocationTextBox.Text = dialog.FileName;
                }
            }
        }

        private void ConfirmSelectionButton_Click(object sender, EventArgs e)
        {
            // Save the selected path.
            _settings.SetPath(AdbLocationTextBox.Text);
            Close();
        }
    }
}
