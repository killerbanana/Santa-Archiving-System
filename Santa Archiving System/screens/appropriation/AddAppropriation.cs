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
    public partial class AddAppropriation : Form
    {
        public AddAppropriation()
        {
            InitializeComponent();
        }

        private void btn_browse_Click(object sender, EventArgs e)
        {
            var filename = ControlsServices.OpenFileDialog();
            fileName.Text = filename;
        }
    }
}
