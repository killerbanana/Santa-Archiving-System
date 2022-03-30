using DGVPrinterHelper;
using Santa_Archiving_System.services.appropriation;
using Santa_Archiving_System.services.controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Santa_Archiving_System.screens.appropriation
{
    public partial class IndexReportAppropriation : Form
    {
        public IndexReportAppropriation()
        {
            InitializeComponent();
        }

        private async Task LoadDataTable()
        {
            guna2DataGridView1.DataSource = await Appropriations.getPrintData();
        }

        private async Task LoadDataTableOnline()
        {
            guna2DataGridView1.DataSource = await Appropriations.getPrintDataOnline();
        }

        private async void IndexReportAppropriation_Load(object sender, EventArgs e)
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

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(guna2TextBox1.Text))
            {


            }
            else
            {
                (guna2DataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("[AppropriationNo] LIKE '%{0}%' OR [Series] LIKE '%{0}%'  OR [Date] LIKE '%{0}%' OR  [Title] LIKE '%{0}%' OR  [Author] LIKE '%{0}%'", guna2TextBox1.Text);
            }
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Create Index Report?", "Index Report", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //do something
                DGVPrinter printer = new DGVPrinter();
                printer.Title = "Reports for Resolution Data";
                printer.SubTitle = string.Format("Date: {0}", DateTime.Now.Date.ToString("MM/dd/yyyy"));
                printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                printer.PageNumbers = true;
                printer.PageNumberInHeader = false;
                printer.HeaderCellAlignment = StringAlignment.Near;
                printer.Footer = "Appropriations Data";
                printer.FooterSpacing = 15;
                printer.printDocument.DefaultPageSettings.Landscape = true;
                printer.PrintDataGridView(guna2DataGridView1);
            }
        }
    }
}
