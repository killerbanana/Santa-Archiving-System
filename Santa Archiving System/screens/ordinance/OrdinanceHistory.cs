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
    public partial class OrdinanceHistory : Form
    {
        public OrdinanceHistory()
        {
            InitializeComponent();
        }

        private async void OrdinanceHistory_Load(object sender, EventArgs e)
        {
            loading1.Visible = true;
            guna2DataGridView1.DataSource = await Ordinances.getHistoryOnline();
            loading1.Visible = false;
        }
    }
}
