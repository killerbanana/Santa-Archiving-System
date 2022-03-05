using Santa_Archiving_System.common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Santa_Archiving_System.services.controls
{
    class ControlsServices
    {
        public static string OpenFileDialog() {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "PDF Files|*.pdf| .docs|*.doc| .docx|*.docx"; ;
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    Constants.filePath = openFileDialog.FileName;

                    Constants.ext = Path.GetExtension(Constants.filePath);

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        Constants.fileContent = reader.ReadToEnd();
                    }
                }
            }
            return  Constants.filePath;
        }
    }
}
