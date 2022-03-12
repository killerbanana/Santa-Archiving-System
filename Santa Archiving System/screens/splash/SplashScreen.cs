using Santa_Archiving_System.screens.auth;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Santa_Archiving_System.screens.splash
{
    public partial class SplashScreen : Form
    {
        int counter = 0;
        Thread th;
        public SplashScreen()
        {
            InitializeComponent();
        }
        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;    // Remove Form Flicker
                return cp;
            }
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {
            this.UseWaitCursor = true;
            progressBar.Value = 0;
            timer1.Start();
        }

        private void opennewform(object obj)
        {
            Application.Run(new Login());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            counter++;
            progressBar.Increment(1);
            lbl_percent.Text = progressBar.ProgressPercentText;
            if (counter == 100)
            {
                this.UseWaitCursor = false;
                timer1.Stop();
                lbl_pressToContinue.Visible = true;
                panel_loading.Visible = false;
            }
           
        }

        private void SplashScreen_KeyDown(object sender, KeyEventArgs e)
        {
            if (lbl_pressToContinue.Visible == true)
            {

                if (e.KeyCode == Keys.Enter)
                {
                    this.Close();
                    th = new Thread(opennewform);
                    th.SetApartmentState(ApartmentState.STA);
                    th.Start();
                    
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    this.Close();
                }

            }
        }

       
    }
}
