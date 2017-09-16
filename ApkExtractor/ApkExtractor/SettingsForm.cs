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
        }

        private void SelectFileButton_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                // Display a dialog box prompting the user to select a file.
                var result = dialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    // Set the currently selected path and update the text box.
                    _settings.SetPath(dialog.FileName);
                    AdbLocationTextBox.Text = dialog.FileName;
                }
            }
        }

        private void ConfirmSelectionButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
