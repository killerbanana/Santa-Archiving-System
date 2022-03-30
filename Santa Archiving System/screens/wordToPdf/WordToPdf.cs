using Santa_Archiving_System.services.controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WordToPDF;

namespace Santa_Archiving_System.screens.wordToPdf
{
    public partial class WordToPdf : Form
    {
        public WordToPdf()
        {
            InitializeComponent();
        }
        String path = "";

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            path = ControlsServices.OpenFileDialog1();
            fileName.Text = path;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btn_convert_Click(object sender, EventArgs e)
        {
            loading1.Visible = true;
            await convert();
            loading1.Visible = false;
        }

        public async Task convert()
        {
            await Task.Run(() =>
            {
                Word2Pdf word2Pdf = new Word2Pdf();
                word2Pdf.InputLocation = @path;
                word2Pdf.OutputLocation = @"C:\\New Folder(2)\file.pdf";
                word2Pdf.Word2PdfCOnversion();

                Process Proc = new Process();

                //assign file path for process
                Proc.StartInfo.FileName = @"C:\\New Folder(2)\\file.pdf";
                Proc.Start();
            });
        }
    }
}
