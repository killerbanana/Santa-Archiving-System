using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Santa_Archiving_System.screens.sbOfficial
{
    public partial class SbOfficialEncode : Form
    {
        public SbOfficialEncode()
        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            SbAddOfficials sbAddOfficials = new SbAddOfficials();
            sbAddOfficials.ShowDialog();
        }
    }
}
