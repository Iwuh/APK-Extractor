using ApkExtractor.Adb;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApkExtractor
{
    public partial class SelectDeviceForm : Form
    {
        private AdbClient _client;

        public SelectDeviceForm(AdbClient client)
        {
            InitializeComponent();
            _client = client;
        }

        /// <summary>
        /// The device selected by the user.
        /// </summary>
        public Device SelectedDevice { get; private set; }

        private async void SelectDeviceForm_Load(object sender, EventArgs e) => await ShowDevices();

        /// <summary>
        /// Gets a list of connected devices and updates the ListBox.
        /// </summary>
        /// <returns></returns>
        private async Task ShowDevices()
        {
            var devices = await _client.GetDevicesAsync();

            // Disable drawing while we update the control.
            DeviceListBox.BeginUpdate();
            // Clear all items from the ListBox.
            DeviceListBox.Items.Clear();

            // Add all devices to the ListBox and dictionary.
            foreach (Device d in devices)
            {
                DeviceListBox.Items.Add(d);
            }

            // End the update, allowing the control to draw its new contents.
            DeviceListBox.EndUpdate();
            DeviceListBox.ClearSelected();
        }

        private async void RefreshButton_Click(object sender, EventArgs e) => await ShowDevices();

        private void ConfirmDeviceButton_Click(object sender, EventArgs e)
        {
            SelectedDevice = (Device)DeviceListBox.SelectedItem;
        }
    }
}
