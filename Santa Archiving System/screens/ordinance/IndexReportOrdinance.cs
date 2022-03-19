using DGVPrinterHelper;
using Santa_Archiving_System.services.controls;
using Santa_Archiving_System.services.ordinance;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Santa_Archiving_System.screens.ordinance
{
    public partial class IndexReportOrdinance : Form
    {
        public IndexReportOrdinance()
        {
            InitializeComponent();
        }
        private async Task LoadDataTable()
        {
            guna2DataGridView1.DataSource = await Ordinances.getPrintData();
        }

        private async Task LoadDataTableOnline()
        {
            guna2DataGridView1.DataSource = await Ordinances.getPrintDataOnline();
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Create Index Report?", "Index Report", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //do something
                DGVPrinter printer = new DGVPrinter();
                printer.Title = "Reports for Ordinace Data";
                printer.SubTitle = string.Format("Date: {0}", DateTime.Now.Date.ToString("MM/dd/yyyy"));
                printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                printer.PageNumbers = true;
                printer.PageNumberInHeader = false;
                printer.HeaderCellAlignment = StringAlignment.Near;
                printer.Footer = "Ordinace Data";
                printer.FooterSpacing = 15;
                printer.printDocument.DefaultPageSettings.Landscape = true;
                printer.PrintDataGridView(guna2DataGridView1);
            }
        }

        private async void IndexReportOrdinance_Load(object sender, EventArgs e)
        {
            if (ControlsServices.CheckIfOnline())
            {
                loading1.Visible = true;
                await LoadDataTableOnline();
                loading1.Visible = false;
            }
            else
            {
                loading1.Visible = true;
                await LoadDataTable();
                loading1.Visible = false;
            }
        }
    }
}
