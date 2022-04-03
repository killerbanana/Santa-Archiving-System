using Santa_Archiving_System.services.controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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
        string path = "";
        string data = "";

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            switch (guna2ComboBox1.SelectedIndex)
            {
                case 0:
                    path = ControlsServices.OpenFileDialogDocx();
                    fileName.Text = path;
                    break;
                case 1:
                    path = ControlsServices.OpenFileDialogPDF();
                    fileName.Text = path;
                    break;
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btn_convert_Click(object sender, EventArgs e)
        {
            switch (guna2ComboBox1.SelectedIndex)
            {
                case 0:
                    if (path == string.Empty || path == "")
                    {
                        MessageBox.Show("Please select a file to convert.");
                        return;
                    }
                    loading1.Visible = true;
                    await convert();
                    loading1.Visible = false;
                    MessageBox.Show("Successfully Converted");
                    break;
                case 1:
                    if (path == string.Empty || path == "")
                    {
                        MessageBox.Show("Please select a file to convert.");
                        return;
                    }
                    loading1.Visible = true;
                    await convertPDF();
                    loading1.Visible = false;
                    MessageBox.Show("Successfully Converted");
                    break;
            }
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

        public async Task convertPDF()
        {
            await Task.Run(() =>
            {
                SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();
                f.OpenPdf(path);
                if (f.PageCount > 0)
                    f.WordOptions.Format = SautinSoft.PdfFocus.CWordOptions.eWordDocument.Docx;
                    f.ToWord(path + ".docx");
            });
        }

        private void WordToPdf_Load(object sender, EventArgs e)
        {
            guna2ComboBox1.SelectedIndex = 0;
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            path = "";
            fileName.Text = path;
        }
    }
}
