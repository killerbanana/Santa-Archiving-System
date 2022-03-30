using Santa_Archiving_System.common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WordToPDF;

namespace Santa_Archiving_System.screens.tricycle
{
    public partial class AddFranchise : Form
    {
        public AddFranchise()
        {
            InitializeComponent();
        }

        public static string name, barangay, civil, reason, make, motor, chassis, plate, units, franchise, tax, orno, status, date, fee;

  

        SqlDataAdapter da = new SqlDataAdapter();

        DataTable dt = new DataTable();

        private async void AddFranchise_Load(object sender, EventArgs e)
        {
            dateTime.Value = DateTime.Now;
            String query = "INSERT INTO Retrieve(Files) VALUES(@Files)";

            using (Stream stream = File.OpenRead(Constants.filename1))
            {
                byte[] buffer = new byte[stream.Length];
                stream.Read(buffer, 0, buffer.Length);

                string[] sizes = { "B", "KB", "MB", "GB", "TB" };
                double len = new FileInfo(Constants.filename1).Length;
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

                    cmd.Parameters.AddWithValue("@Files", SqlDbType.VarBinary).Value = buffer;

                    con.Open();
                    IAsyncResult result = cmd.BeginExecuteNonQuery();

                    while (!result.IsCompleted)
                    {

                    }
                    
                    await Task.Run(() => {
                        cmd.EndExecuteNonQuery(result);
                    });

                    con.Close();
                }
            }

            using (SqlConnection con = new SqlConnection(Constants.connectionStringOffline))
            {

                FileStream FS = null;
                byte[] dbbyte;

                using (SqlCommand cmd = new SqlCommand("SELECT Files FROM Retrieve", con))
                {
                    con.Open();

                    da = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    da.Fill(dt);

                    dbbyte = (byte[])dt.Rows[0]["Files"];

                    //store file Temporarily 
                    string filepath = "C:\\New folder\\tricy1.docx";

                    //Assign File path create file
                    FS = new FileStream(filepath, System.IO.FileMode.Create);

                    //Write bytes to create file
                    FS.Write(dbbyte, 0, dbbyte.Length);

                    //Close FileStream instance
                    FS.Close();
                }

            }
        }

        private async void guna2Button3_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                CreateWordDocument(Constants.filename2, @"C:\\New folder\\tricy4.docx");
                name = tb_name.Text;
                barangay = tb_barangay.Text;
                civil = tb_civil.Text;
                reason = tb_reason.Text;
                make = tb_make.Text;
                motor = tb_motor.Text;
                chassis = tb_chasis.Text;
                plate = tb_plate.Text;
                units = tb_units.Text;
                franchise = tb_franchise.Text;
                tax = tb_certNo.Text;
                orno = tb_orNo.Text;
                status = tb_status.Text;
                date = dateTime.Text;
                fee = tb_certFee.Text;
                Word2Pdf word2Pdf = new Word2Pdf();
                word2Pdf.InputLocation = @"C:\\New folder\\tricy4.docx";
                word2Pdf.OutputLocation = @"C:\\New Folder(2)\file.pdf";
                word2Pdf.Word2PdfCOnversion();

                databaseFilePut(@"C:\\New Folder\\tricy4.docx");
            });
            MessageBox.Show("Success Registration");
            loading.Visible = false;

            Process Proc = new Process();

            //assign file path for process
            Proc.StartInfo.FileName = @"C:\\New Folder(2)\\file.pdf";
            Proc.Start();
            
            this.Close();
        }

        string fullMonthName = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).ToString("MMMM", CultureInfo.CreateSpecificCulture("en"));
        public static byte[] file1;

        private void FindAndReplace(Microsoft.Office.Interop.Word.Application application, object findText, object replaceWithText)
        {

            object matchCase = true;
            object matchWholeWord = true;
            object matchWildCards = false;
            object matchSoundLike = false;
            object nmatchAllForms = false;
            object forward = true;
            object format = false;
            object matchKashida = false;
            object matchDiactitics = false;
            object matchAlefHamza = false;
            object matchControl = false;
            object read_only = false;
            object visible = true;
            object replace = 2;
            object wrap = 1;

            application.Selection.Find.Execute(ref findText,
                ref matchCase, ref matchWholeWord,
                ref matchWildCards, ref matchSoundLike,
                ref nmatchAllForms, ref forward,
                ref wrap, ref format, ref replaceWithText,
                ref replace, ref matchKashida,
                ref matchDiactitics, ref matchAlefHamza,
                ref matchControl);

        }

        private void CreateWordDocument(object filename, object savaAs)
        {
            object missing = Missing.Value;

            Microsoft.Office.Interop.Word.Application application = new Microsoft.Office.Interop.Word.Application();

            Microsoft.Office.Interop.Word.Document aDoc = null;

            if (File.Exists((string)filename))
            {
                DateTime dateTime = DateTime.Now;

                object readOnly = false;
                object isVisible = false;

                application.Visible = false;

                aDoc = application.Documents.Open(
                   ref filename, ref missing, ref readOnly,
                   ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing, ref missing);

                aDoc.Activate();

                this.FindAndReplace(application, "<Name>", tb_name.Text);
                this.FindAndReplace(application, "<FRANCHISE NO>", tb_franchise.Text);
                this.FindAndReplace(application, "<Operate>", tb_reason.Text);
                this.FindAndReplace(application, "<Barangay>", tb_barangay.Text);
                this.FindAndReplace(application, "<Duration>", fullMonthName + " " + DateTime.Now.Day + "," + DateTime.Now.Year + " to " + "December 31, " + DateTime.Now.Year);
                this.FindAndReplace(application, "<ISSUED Date>", DateTime.Now.ToLongDateString());
                this.FindAndReplace(application, "<Date>", DateTime.Now.ToLongDateString());
                this.FindAndReplace(application, "<day>", DateTime.Now.Day.ToString());
                this.FindAndReplace(application, "<month>", fullMonthName);
                this.FindAndReplace(application, "<year>", DateTime.Now.Year.ToString());
                this.FindAndReplace(application, "<tax>", tb_certNo.Text);
                this.FindAndReplace(application, "<Valid>", "December 31, " + DateTime.Now.Year.ToString());
                this.FindAndReplace(application, "<no. of units>", tb_units.Text);
                this.FindAndReplace(application, "<Make>", tb_make.Text);
                this.FindAndReplace(application, "<Motor No.>", tb_motor.Text);
                this.FindAndReplace(application, "<Chasis No.>", tb_chasis.Text);
                this.FindAndReplace(application, "<Plate No.>", tb_plate.Text);
                this.FindAndReplace(application, "<Cert Fee>", tb_certFee.Text);
                this.FindAndReplace(application, "<Status>", tb_civil.Text);
                this.FindAndReplace(application, "<OR no.>", tb_orNo.Text);

            }
            else
            {
                return;
            }

            aDoc.SaveAs2(ref savaAs, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing);

            aDoc.Close(ref missing, ref missing, ref missing);

            application.Quit();
        }

        public static void databaseFilePut(string varFilePath)
        {
            using (var stream = new FileStream(varFilePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = new BinaryReader(stream))
                {
                    file1 = reader.ReadBytes((int)stream.Length);
                }
            }

            using (var conn = new SqlConnection(Constants.connectionStringOffline))
            {

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT Into [dbo].[Tricycle Franchise] (Name, Barangay, [Civil Status], Reason, Make, [Motor No], File2, [Chassis No], [Plate No] , [No of units], [Franchise No], [Tax Certificate No], [OR No], [Date of Franchise], [Year], Status, Fee) Values 
                    (@Name, @Barangay, @Civil, @Reason, @Make, @Motor, @File2, @Chassis, @Plate, @Units, @Franchise, @Tax, @ORno, @Date, @Year, @Status, @Fee)";

                    conn.Open();

                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Barangay", barangay);
                    cmd.Parameters.AddWithValue("@Civil", civil);
                    cmd.Parameters.AddWithValue("@Reason", reason);
                    cmd.Parameters.AddWithValue("@Make", make);
                    cmd.Parameters.AddWithValue("@Motor", motor);
                    cmd.Parameters.Add("@File2", SqlDbType.VarBinary, file1.Length).Value = file1;
                    cmd.Parameters.AddWithValue("@Chassis", chassis);
                    cmd.Parameters.AddWithValue("@Plate", plate);
                    cmd.Parameters.AddWithValue("@Units", units);
                    cmd.Parameters.AddWithValue("@Franchise", franchise);
                    cmd.Parameters.AddWithValue("@Tax", tax);
                    cmd.Parameters.AddWithValue("@ORno", orno);
                    cmd.Parameters.AddWithValue("@Date", date);
                    cmd.Parameters.AddWithValue("@Year", DateTime.Now.Year);
                    cmd.Parameters.AddWithValue("@Status", status);
                    cmd.Parameters.AddWithValue("@Fee", fee);
                    cmd.ExecuteNonQuery();

                    conn.Close();
                }
            }
        }
    }
}
