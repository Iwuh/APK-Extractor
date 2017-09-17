using ApkExtractor.Adb;
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
    public partial class Form1 : Form
    {
        private AdbClient _client;
        private SettingsManager _settings;
        private bool _serverRunning;
        private Device _currentDevice;

        public Form1()
        {
            InitializeComponent();
            _client = new AdbClient();

            _settings = new SettingsManager();
        }

        /// <summary>
        /// Attempts to start the ADB server if it's not already running. Will notify the user if the server does not successfully start.
        /// </summary>
        /// <returns>Whether or not the server started successfully.</returns>
        private bool TryStartServer()
        {
            // Return true if the server is already running.
            if (_serverRunning) return true;

            // If a path is already set, attempt to start the server using it.
            if (_settings.TryGetPath(out string path))
            {
                try
                {
                    _client.StartAdbServer(path);
                    // If no exception is thrown, the server should be running.
                    _serverRunning = true;
                    return true;
                }
                catch (ArgumentException e) // The user-supplied path is not valid.
                {
                    MessageBox.Show(e.Message,
                                    "Invalid Path",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
            else // No path is set.
            {
                MessageBox.Show("A path to the ADB executable must be set before use.",
                                "No Path Specified",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
            return false;
        }

        private void DeviceButton_Click(object sender, EventArgs e)
        {
            // If the server isn't running and the server start fails, return.
            if (!_serverRunning && !TryStartServer()) return;

            using (var form = new SelectDeviceForm(_client))
            {
                form.ShowDialog();
                _currentDevice = form.SelectedDevice;
                if (_currentDevice != null)
                {
                    CurrentDeviceLabel.Text = _currentDevice.ToString();
                }
            }
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            using (var form = new SettingsForm(_settings))
            {
                form.ShowDialog();

                if (!_serverRunning)
                {
                    TryStartServer();
                }
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            _serverRunning = TryStartServer();
        }
    }
}
