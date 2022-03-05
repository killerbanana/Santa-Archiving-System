using Santa_Archiving_System.common;
using Santa_Archiving_System.models;
using Santa_Archiving_System.services.controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Santa_Archiving_System.screens.resolution
{
    public partial class AddResolution : Form
    {
        Ordinance ord;
        public AddResolution(Ordinance data)
        {
            this.ord = data;
            InitializeComponent();
        }
    
        

        private async void guna2Button3_Click(object sender, EventArgs e)
        {
            if (Constants.filePath == string.Empty)
            {
                MessageBox.Show("File can't be empty!");
                return;
            }

            String query = "INSERT INTO Resolution([Resolution No], Series, Date, Title, Author , Files, Time, Type, Size, Tag, Reading) VALUES(@Resolution,@Series, @Date, @Title, @Author, @Files, @Time, @Type, @Size, @Tag, @Reading)";

            using (Stream stream = File.OpenRead(Constants.filePath))
            {
                byte[] buffer = new byte[stream.Length];
                stream.Read(buffer, 0, buffer.Length);

                string[] sizes = { "B", "KB", "MB", "GB", "TB" };
                double len = new FileInfo(Constants.filePath).Length;
                int order = 0;
                while (len >= 1024 && order < sizes.Length - 1)
                {
                    order++;
                    len = len / 1024;
                }

                // Adjust the format string to your preferences. For example "{0:0.#}{1}" would
                // show a single decimal place, and no space.
                string resultSize = String.Format("{0:0.##} {1}", len, sizes[order]);


                using (SqlConnection con = new SqlConnection(Constants.connectionStringOffline))
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Resolution", SqlDbType.VarChar).Value = resolutionNumber.Text;
                    cmd.Parameters.AddWithValue("@Series", SqlDbType.VarChar).Value = series.Text;
                    cmd.Parameters.AddWithValue("@Date", SqlDbType.VarChar).Value = date.Text;
                    cmd.Parameters.AddWithValue("@Title", SqlDbType.VarChar).Value = title.Text;
                    cmd.Parameters.AddWithValue("@Author", SqlDbType.VarChar).Value = author.Text;
                    cmd.Parameters.AddWithValue("@Files", SqlDbType.VarBinary).Value = buffer;
                    cmd.Parameters.AddWithValue("@Time", SqlDbType.VarChar).Value = time.Text + " " + ampm.Text;
                    cmd.Parameters.AddWithValue("@Type", SqlDbType.VarChar).Value = Constants.ext;
                    cmd.Parameters.AddWithValue("@Size", SqlDbType.VarChar).Value = resultSize;
                    cmd.Parameters.AddWithValue("@Tag", SqlDbType.VarBinary).Value = tag.Text;
                    cmd.Parameters.AddWithValue("@Reading", SqlDbType.VarBinary).Value = reading_cb.Text;

                    con.Open();

                    loading1.Visible = true;

                    IAsyncResult result = cmd.BeginExecuteNonQuery();

                    while (!result.IsCompleted)
                    {

                    }



                    await Task.Run(() => {
                        cmd.EndExecuteNonQuery(result);
                    });

                    con.Close();
                    loading1.Visible = false;
                    

                    switch (ord.Reading)
                    {
                        case "Encode":
                            this.Close();
                            break;
                        case "First Reading":
                            this.Close();
                            break;
                        case "Second Reading":
                            this.Close();
                            break;
                        case "Third Reading":
                            this.Close();
                            break;
                    }

                }
            }
        }

        private void AddResolution_Load(object sender, EventArgs e)
        {
            
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            var filename = ControlsServices.OpenFileDialog();
            fileName.Text = filename;
        }
    }
}
