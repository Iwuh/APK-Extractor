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
    public partial class Form1 : Form
    {
        private AdbClient _client;

        public Form1()
        {
            InitializeComponent();
            _client = new AdbClient().StartAdbServer(@"C:\Program Files (x86)\Android\android-sdk\platform-tools\adb.exe");
        }

        private void DeviceButton_Click(object sender, EventArgs e)
        {
            using (var form = new SelectDeviceForm(_client))
            {
                form.ShowDialog();
            }
        }
    }
}
