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

        private async void RefreshDeviceButton_Click(object sender, EventArgs e)
        {
            // If the server isn't running and the server start fails, return.
            if (!_serverRunning && !TryStartServer()) return;

            try
            {
                // Get a list of all devices currently connected.
                var devices = await _client.GetDevicesAsync();

                // Pause drawing to the ComboBox while we add items.
                DeviceComboBox.BeginUpdate();
                DeviceComboBox.Items.Clear();
                foreach (Device d in devices)
                {
                    DeviceComboBox.Items.Add(d);
                }
                // Resume drawing.
                DeviceComboBox.EndUpdate();
            }
            catch (AdbException ex)
            {
                MessageBox.Show(ex.Message,
                                "ADB Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
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

        private async void RefreshPackageButton_Click(object sender, EventArgs e)
        {
            const string prefix = "package:";

            // If the server isn't running and the server start fails, return.
            if (!_serverRunning && !TryStartServer()) return;

            if (DeviceComboBox.SelectedItem == null)
            {
                MessageBox.Show("A device must be selected before the package list can be retrieved.",
                                "No Device",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                return;
            }

            try
            {
                // Get a list of all packages in a single string.
                string response = await _client.ExecuteShellCommandAsync(DeviceComboBox.SelectedItem as Device, "pm list packages");
                // Split the string into several lines.
                var split = response.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                // Remove the package: prefix from each line.
                var packages = split.Select(s => s.Substring(prefix.Length));

                // Pause drawing of the list box while items are added.
                PackageListBox.BeginUpdate();
                PackageListBox.Items.Clear();
                foreach (string package in packages)
                {
                    PackageListBox.Items.Add(package);
                }
                // Resume drawing of the list box.
                PackageListBox.EndUpdate();
            }
            catch (AdbException ex)
            {
                MessageBox.Show(ex.Message,
                                "ADB Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
    }
}
