using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WIA;
namespace Santa_Archiving_System.screens.resolution
{
    public partial class ResolutionScanner : Form
    {

       
        public ResolutionScanner()
        {
            InitializeComponent();
        }

        public static List<string> GetDevicesId()
        {
            List<string> devices = new List<string>();
            WIA.DeviceManager manager = new WIA.DeviceManager();
            foreach (WIA.DeviceInfo info in manager.DeviceInfos)
            {
                devices.Add(info.DeviceID);
            }
            return devices;
        }
        private void ResolutionScanner_Load(object sender, EventArgs e)
        {
            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                MessageBox.Show(printer);
                
            }


        }

        private void btn_scan_Click(object sender, EventArgs e)
        {
            
        }
    }
}
