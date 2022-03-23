using MySql.Data.MySqlClient;
using Santa_Archiving_System.common;
using Santa_Archiving_System.models;
using Santa_Archiving_System.screens.sbOfficial;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Santa_Archiving_System.services.Officials
{
    public class Officials
    {
        public static List<String> terms = new List<string>();
        public static List<String> position = new List<string>();
        public static List<String> title = new List<string>();
        public static List<String> firstName = new List<string>();
        public static List<String> middleName = new List<string>();
        public static List<String> lastName = new List<string>();
        public static List<String> suffix = new List<string>();
        public static List<String> rank = new List<string>();
        public static List<MemoryStream> image = new List<MemoryStream>();


        //save 
        public static async Task SaveOfficialsOffline
        (
            string firstName,
            string middleName,
            string lastName,
            string suffix,
             string title,
            string position,
            string gender,
            string birthday,
            string address,
            string contactNo,
            string terms,
            string image,
            string rank
        )
        {
            try
            {
                string FileName = image;
                byte[] ImageData;
                FileStream fs;
                BinaryReader br;
                fs = new FileStream(FileName, FileMode.Open, FileAccess.Read);
                br = new BinaryReader(fs);
                ImageData = br.ReadBytes((int)fs.Length);
                br.Close();
                fs.Close();
                String query = "INSERT INTO Officials(FirstName, MiddleName, LastName, Suffix, Title, Position, Gender, Birthday, Address, ContactNo, Terms, Image, RankNo) VALUES(@FirstName,@MiddleName, @LastName, @Suffix, @Title, @Position, @Gender, @Birthday, @Address, @ContactNo, @Terms, @Image, @RankNo)";

                using (SqlConnection con = new SqlConnection(Constants.connectionStringOffline))
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                   
                    cmd.Parameters.AddWithValue("@FirstName", SqlDbType.VarChar).Value = firstName;
                    cmd.Parameters.AddWithValue("@MiddleName", SqlDbType.VarChar).Value = middleName;
                    cmd.Parameters.AddWithValue("@LastName", SqlDbType.VarChar).Value = lastName;
                    cmd.Parameters.AddWithValue("@Suffix", SqlDbType.VarChar).Value = suffix;
                    cmd.Parameters.AddWithValue("@Title", SqlDbType.VarChar).Value = title;
                    cmd.Parameters.AddWithValue("@Position", SqlDbType.VarChar).Value = position;
                    cmd.Parameters.AddWithValue("@Gender", SqlDbType.VarChar).Value = gender;
                    cmd.Parameters.AddWithValue("@Birthday", SqlDbType.VarChar).Value = birthday;
                    cmd.Parameters.AddWithValue("@Address", SqlDbType.VarChar).Value = address;
                    cmd.Parameters.AddWithValue("@ContactNo", SqlDbType.VarChar).Value = contactNo;
                    cmd.Parameters.AddWithValue("@Terms", SqlDbType.VarChar).Value = terms;
                    cmd.Parameters.AddWithValue("@RankNo", SqlDbType.VarChar).Value = rank;
                    cmd.Parameters.AddWithValue("@Image", SqlDbType.VarBinary).Value = ImageData;
                    
                    con.Open();

                    IAsyncResult result = cmd.BeginExecuteNonQuery();

                    while (!result.IsCompleted)
                    {

                    }

                    await Task.Run(() =>
                    {
                        cmd.EndExecuteNonQuery(result);
                    });

                    con.Close();


                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        public static async Task SaveOfficialsOnline
       (
           string firstName,
           string middleName,
           string lastName,
           string suffix,
           string title,
           string position,
           string gender,
           string birthday,
           string address,
           string contactNo,
           string terms,
           string image,
           string rank
       )
        {
            try
            {
                string FileName = image;
                byte[] ImageData;
                FileStream fs;
                BinaryReader br;
                fs = new FileStream(FileName, FileMode.Open, FileAccess.Read);
                br = new BinaryReader(fs);
                ImageData = br.ReadBytes((int)fs.Length);
                br.Close();
                fs.Close();
                String query = "INSERT INTO Officials(FirstName, MiddleName, LastName, Suffix, Title, Position, Gender, Birthday, Address, ContactNo, Terms, Image, RankNo) VALUES(@FirstName, @MiddleName, @LastName, @Suffix, @Title, @Position, @Gender, @Birthday, @Address, @ContactNo, @Terms, @Image, @RankNo)";

                using (MySqlConnection con = new MySqlConnection(Constants.connectionStringOnline))
                {
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.Add(new MySqlParameter("@FirstName", firstName));
                    cmd.Parameters.Add(new MySqlParameter("@MiddleName", middleName));
                    cmd.Parameters.Add(new MySqlParameter("@LastName", lastName));
                    cmd.Parameters.Add(new MySqlParameter("@Suffix", suffix));
                    cmd.Parameters.Add(new MySqlParameter("@Title", title));
                    cmd.Parameters.Add(new MySqlParameter("@Position", position));
                    cmd.Parameters.Add(new MySqlParameter("@Gender", gender));
                    cmd.Parameters.Add(new MySqlParameter("@Birthday", birthday));
                    cmd.Parameters.Add(new MySqlParameter("@Address", address));
                    cmd.Parameters.Add(new MySqlParameter("@ContactNo", contactNo));
                    cmd.Parameters.Add(new MySqlParameter("@Terms", terms));
                    cmd.Parameters.Add(new MySqlParameter("@RankNo", rank));
                    cmd.Parameters.Add(new MySqlParameter("@Image", ImageData));
                    
                    con.Open();

                    IAsyncResult result = cmd.BeginExecuteNonQuery();

                    while (!result.IsCompleted)
                    {

                    }

                    await Task.Run(() =>
                    {
                        cmd.EndExecuteNonQuery(result);
                    });

                    con.Close();


                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        // retrieve list 
        public static async Task<DataTable> getOfficialsListOnline(string batch)
        {

            try
            {
                DataTable dt = new DataTable();

                await Task.Run(() =>
                {
                    using (MySqlConnection con = new MySqlConnection(Constants.connectionStringOnline))
                    {

                        using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM Officials  WHERE Terms='" + batch + "'", con))
                        {
                            con.Open();
                           

                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                               
                                dt.Load(reader);
                            }
                            con.Close();

                        }

                    }
                });
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<DataTable> getOfficialsListOffline(string batch)
        {
            try
            {
                DataTable dt = new DataTable();

                await Task.Run(() =>
                {
                    using (SqlConnection con = new SqlConnection(Constants.connectionStringOffline))
                    {

                        using (SqlCommand cmd = new SqlCommand("SELECT * FROM Officials  WHERE Terms='" + batch + "'", con))
                        {
                            con.Open();
                           
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                
                                dt.Load(reader);
                            }
                        
                        }

                    }
                });
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //retrieve all batch where official is not null
        public static async Task getTermsOnline()
        {
            try
            {
                terms.Clear();


                await Task.Run(() =>
                {
                    using (MySqlConnection con = new MySqlConnection(Constants.connectionStringOnline))
                    {

                        using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM Officials", con))
                        {
                            con.Open();
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {

                                while (reader.Read())
                                {
                                    terms.Add(reader.GetString(reader.GetOrdinal("Terms")));
                                }
                            }

                            con.Close();
                        }

                    }
                });

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task getTermsOffline()
        {
            try
            {
                terms.Clear();


                await Task.Run(() =>
                {
                    using (SqlConnection con = new SqlConnection(Constants.connectionStringOffline))
                    {

                        using (SqlCommand cmd = new SqlCommand("SELECT * FROM Officials", con))
                        {
                            con.Open();
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {

                                while (reader.Read())
                                {
                                    terms.Add(reader.GetString(reader.GetOrdinal("Terms")));
                                }
                            }

                            con.Close();
                        }

                    }
                });

            }
            catch (Exception)
            {
                throw;
            }
        }

        //officials chart
        public static async Task getOfficialsChartOffline(string terms)
        {

            try
            {
                position.Clear();
                title.Clear();
                firstName.Clear();
                middleName.Clear();
                lastName.Clear();
                suffix.Clear();
                rank.Clear();
                image.Clear();
                await Task.Run(() =>
                {
                    using (SqlConnection con = new SqlConnection(Constants.connectionStringOffline))
                    {
                        using (SqlCommand cmd = new SqlCommand("SELECT * FROM Officials  WHERE Terms='" + terms + "'", con))
                        {
                            con.Open();

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    position.Add(reader.GetString(reader.GetOrdinal("Position")));
                                    title.Add(reader.GetString(reader.GetOrdinal("Title")));
                                    firstName.Add(reader.GetString(reader.GetOrdinal("FirstName")));
                                    middleName.Add(reader.GetString(reader.GetOrdinal("MiddleName")));
                                    lastName.Add(reader.GetString(reader.GetOrdinal("LastName")));
                                    suffix.Add(reader.GetString(reader.GetOrdinal("Suffix")));
                                    rank.Add(reader.GetString(reader.GetOrdinal("RankNo")));
                                    byte[] img = (byte[])(reader["Image"]);
                                    MemoryStream mstream = new MemoryStream(img);
                                    image.Add(mstream);
                                }
     
                            }
                            con.Close();
                        }
                    }
                });
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static async Task getOfficialsChartOnline(string terms)
        {
           
            try
            {
                position.Clear();
                title.Clear();
                firstName.Clear();
                middleName.Clear();
                lastName.Clear();
                suffix.Clear();
                rank.Clear();
                image.Clear();

                await Task.Run(() =>
                {
                    using (MySqlConnection con = new MySqlConnection(Constants.connectionStringOnline))
                    {

                        using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM Officials  WHERE Terms='" + terms + "'", con))
                        {
                            con.Open();
                           
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {

                                while (reader.Read())
                                {
                                    position.Add(reader.GetString(reader.GetOrdinal("Position")));
                                    title.Add(reader.GetString(reader.GetOrdinal("Title")));
                                    firstName.Add(reader.GetString(reader.GetOrdinal("FirstName")));
                                    middleName.Add(reader.GetString(reader.GetOrdinal("MiddleName")));
                                    lastName.Add(reader.GetString(reader.GetOrdinal("LastName")));
                                    suffix.Add(reader.GetString(reader.GetOrdinal("Suffix")));
                                    rank.Add(reader.GetString(reader.GetOrdinal("RankNo")));
                                    byte[] img = (byte[])(reader["Image"]);
                                    MemoryStream mstream = new MemoryStream(img);
                                    image.Add(mstream);
                                }
                            }
                            con.Close();
                        }

                    }
                });
               
            }
            catch (Exception)
            {
                throw;
            }
        }

        //update
        public static async Task UpdateOfficialsOnline
          (
           string firstName,
           string middleName,
           string lastName,
           string suffix,
           string title,
           string position,
           string gender,
           string birthday,
           string address,
           string contactNo,
           List<String> committee,
           string terms,
           string rank,
           string Id
          )
        {
            try
            {
              
                await Task.Run(() =>
                {

                    using (MySqlConnection con = new MySqlConnection(Constants.connectionStringOnline))
                    {
                        using (MySqlCommand cmd = new MySqlCommand("Update Officials set FirstName=@FirstName, MiddleName=@MiddleName, LastName=@LastName, Suffix=@Suffix, Title=@Title, Position=@Position, Gender=@Gender, Birthday=@Birthday, Address=@Address, ContactNo=@ContactNo, Committee=@Committee, Terms=@Terms, RankNo=@RankNo where Id=@Id and Position=@Position and RankNo=@RankNo", con))
                        {
                            con.Open();
                            cmd.Parameters.Add(new MySqlParameter("@FirstName", firstName));
                            cmd.Parameters.Add(new MySqlParameter("@MiddleName", middleName));
                            cmd.Parameters.Add(new MySqlParameter("@LastName", lastName));
                            cmd.Parameters.Add(new MySqlParameter("@Suffix", suffix));
                            cmd.Parameters.Add(new MySqlParameter("@Title", title));
                            cmd.Parameters.Add(new MySqlParameter("@Position", position));
                            cmd.Parameters.Add(new MySqlParameter("@Gender", gender));
                            cmd.Parameters.Add(new MySqlParameter("@Birthday", birthday));
                            cmd.Parameters.Add(new MySqlParameter("@Address", address));
                            cmd.Parameters.Add(new MySqlParameter("@ContactNo", contactNo));
                            cmd.Parameters.Add(new MySqlParameter("@Committee", string.Join(",", committee)));
                            cmd.Parameters.Add(new MySqlParameter("@Terms", terms));
                            cmd.Parameters.Add(new MySqlParameter("@RankNo", rank));
                            cmd.Parameters.Add(new MySqlParameter("@Id", Id));
                            cmd.ExecuteNonQuery();
                            con.Close();

                        }

                    }

                });

            }
            catch (Exception)
            {
                throw;
            }

        }

        public static async Task UpdateOfficialsOffline
         (
          string firstName,
          string middleName,
          string lastName,
          string suffix,
          string title,
          string position,
          string gender,
          string birthday,
          string address,
          string contactNo,
          List<String> committee,
          string terms,
          string rank,
          string Id
         )
        {
            try
            {
             
                await Task.Run(() =>
                {

                    using (SqlConnection con = new SqlConnection(Constants.connectionStringOffline))
                    {
                        using (SqlCommand cmd = new SqlCommand("Update Officials set FirstName=@FirstName, MiddleName=@MiddleName, LastName=@LastName, Suffix=@Suffix, Title=@Title, Position=@Position, Gender=@Gender, Birthday=@Birthday, Address=@Address, ContactNo=@ContactNo, Committee=@Committee, Terms=@Terms, RankNo=@RankNo where Id=@Id", con))
                        {
                            con.Open();
                            cmd.Parameters.AddWithValue("@FirstName", SqlDbType.VarChar).Value = firstName;
                            cmd.Parameters.AddWithValue("@MiddleName", SqlDbType.VarChar).Value = middleName;
                            cmd.Parameters.AddWithValue("@LastName", SqlDbType.VarChar).Value = lastName;
                            cmd.Parameters.AddWithValue("@Suffix", SqlDbType.VarChar).Value = suffix;
                            cmd.Parameters.AddWithValue("@Title", SqlDbType.VarChar).Value = title;
                            cmd.Parameters.AddWithValue("@Position", SqlDbType.VarChar).Value = position;
                            cmd.Parameters.AddWithValue("@Gender", SqlDbType.VarChar).Value = gender;
                            cmd.Parameters.AddWithValue("@Birthday", SqlDbType.VarChar).Value = birthday;
                            cmd.Parameters.AddWithValue("@Address", SqlDbType.VarChar).Value = address;
                            cmd.Parameters.AddWithValue("@ContactNo", SqlDbType.VarChar).Value = contactNo;
                            cmd.Parameters.AddWithValue("@Committee", SqlDbType.VarChar).Value = string.Join(",", committee);
                            cmd.Parameters.AddWithValue("@Terms", SqlDbType.VarChar).Value = terms;
                            cmd.Parameters.AddWithValue("@RankNo", SqlDbType.VarChar).Value = rank;
                            cmd.Parameters.AddWithValue("@Id", SqlDbType.VarChar).Value = Id;
                            cmd.ExecuteNonQuery();
                            con.Close();

                        }

                    }

                });

            }
            catch (Exception)
            {
                throw;
            }

        }

        //delete
        public static async Task DeleteOfficialsOnline(string position, string Id)
        {
            try
            {
                await Task.Run(() =>
                {
                    using (MySqlConnection con = new MySqlConnection(Constants.connectionStringOnline))
                    {
                        MySqlCommand cmd = new MySqlCommand("Delete from Officials where Position=@Position and Id=@Id and RankNo=@RankNo", con);
                        cmd.Parameters.Add(new MySqlParameter("@Position", position));
                        cmd.Parameters.Add(new MySqlParameter("@Id", Id));
                        con.Open();

                        IAsyncResult result = cmd.BeginExecuteNonQuery();

                        while (!result.IsCompleted)
                        {

                        }
                        cmd.EndExecuteNonQuery(result);
                        con.Close();
                    }
                });
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task DeleteOfficialsOffline(string position, string Id)
        {
            try
            {
                await Task.Run(() =>
                {
                    using (SqlConnection con = new SqlConnection(Constants.connectionStringOffline))
                    {
                        SqlCommand cmd = new SqlCommand("Delete from Committee where Position=@Position and  and Id=@Id", con);
                        cmd.Parameters.AddWithValue("@Position", SqlDbType.VarChar).Value = position;
                        cmd.Parameters.AddWithValue("@Id", SqlDbType.VarChar).Value = Id;
                        con.Open();

                        IAsyncResult result = cmd.BeginExecuteNonQuery();

                        while (!result.IsCompleted)
                        {

                        }
                        cmd.EndExecuteNonQuery(result);
                        con.Close();
                    }
                });
            }
            catch (Exception)
            {
                throw;
            }
        }


        //export
        public static async Task ExportData()
        {
            try
            {
                await Task.Run(() =>
                {
                    using (SqlConnection con = new SqlConnection(Constants.connectionStringOffline))
                    {
                        using (SqlCommand cmd = new SqlCommand("SELECT * FROM Officials", con))
                        {
                            con.Open();

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    while (reader.Read())
                                    {
                                        using (MySqlConnection connect = new MySqlConnection(Constants.connectionStringOnline))
                                        {
                                            using (MySqlCommand command = new MySqlCommand("SELECT * FROM Officials where Position ='" + reader[6].ToString() + "'AND Terms ='" + reader[12].ToString() + "'", connect))
                                            {
                                                connect.Open();

                                                using (MySqlDataReader reader1 = command.ExecuteReader())
                                                {

                                                    if (reader1.HasRows)
                                                    {

                                                        String query1 = "Update Officials set FirstName = @FirstName, " +
                                                        "MiddleName = @MiddleName, " +
                                                        "LastName = @LastName," +
                                                        "Suffix = @LastName," +
                                                        "Title = @LastName," +
                                                        "Position = @LastName," +
                                                        "Gender = @LastName," +
                                                        "Birthday = @LastName," +
                                                        "Address = @LastName," +
                                                        "ContactNo = @LastName," +
                                                        "Committee = @LastName," +
                                                        "Terms = @LastName," +
                                                        "RankNo = @RankNo," +
                                                        "Image = @Image where Position ='" + reader[6].ToString() + "'AND Terms ='" + reader[12].ToString() + "'AND FirstName ='" + reader[1].ToString() + "'AND RankNo ='" + reader[13].ToString() + "'";


                                                        using (MySqlConnection connection3 = new MySqlConnection(Constants.connectionStringOnline))
                                                        {
                                                            MySqlCommand command3 = new MySqlCommand(query1, connection3);
                                                            command3.Parameters.Add(new MySqlParameter("@FirstName", reader[1].ToString()));
                                                            command3.Parameters.Add(new MySqlParameter("@MiddleName", reader[2].ToString()));
                                                            command3.Parameters.Add(new MySqlParameter("@LastName", reader[3].ToString()));
                                                            command3.Parameters.Add(new MySqlParameter("@Suffix", reader[4].ToString()));
                                                            command3.Parameters.Add(new MySqlParameter("@Title", reader[5].ToString()));
                                                            command3.Parameters.Add(new MySqlParameter("@Position", reader[6].ToString()));
                                                            command3.Parameters.Add(new MySqlParameter("@Gender", reader[7].ToString()));
                                                            command3.Parameters.Add(new MySqlParameter("@Birthday", reader[8].ToString()));
                                                            command3.Parameters.Add(new MySqlParameter("@Address", reader[9].ToString()));
                                                            command3.Parameters.Add(new MySqlParameter("@ContactNo", reader[10].ToString()));
                                                            command3.Parameters.Add(new MySqlParameter("@Committee", reader[11].ToString()));
                                                            command3.Parameters.Add(new MySqlParameter("@Terms", reader[12].ToString()));
                                                            command3.Parameters.Add(new MySqlParameter("@RankNo", reader[13].ToString()));
                                                            command3.Parameters.Add(new MySqlParameter("@Image", reader[14].ToString()));

                                                            connection3.Open();

                                                            command3.ExecuteNonQuery();
                                                            connection3.Close();
                                                        }
                                                    }
                                                    else
                                                    {

                                                        String query1 = "INSERT INTO Committee(FirstName, MiddleName, LastName, Suffix, Title, Position, Gender, Birthday, Address, ContactNo, Committee, Terms, RankNo, Image) VALUES(@FirstName, @MiddleName, @LastName, @Suffix, @Title, @Position, @Gender, @Birthday, @Address, @ContactNo, @Committee, @Terms, @RankNo, @Image)";
                                                        using (MySqlConnection connection3 = new MySqlConnection(Constants.connectionStringOnline))
                                                        {
                                                            MySqlCommand command3 = new MySqlCommand(query1, connection3);
                                                            command3.Parameters.Add(new MySqlParameter("@FirstName", reader[1].ToString()));
                                                            command3.Parameters.Add(new MySqlParameter("@MiddleName", reader[2].ToString()));
                                                            command3.Parameters.Add(new MySqlParameter("@LastName", reader[3].ToString()));
                                                            command3.Parameters.Add(new MySqlParameter("@Suffix", reader[4].ToString()));
                                                            command3.Parameters.Add(new MySqlParameter("@Title", reader[5].ToString()));
                                                            command3.Parameters.Add(new MySqlParameter("@Position", reader[6].ToString()));
                                                            command3.Parameters.Add(new MySqlParameter("@Gender", reader[7].ToString()));
                                                            command3.Parameters.Add(new MySqlParameter("@Birthday", reader[8].ToString()));
                                                            command3.Parameters.Add(new MySqlParameter("@Address", reader[9].ToString()));
                                                            command3.Parameters.Add(new MySqlParameter("@ContactNo", reader[10].ToString()));
                                                            command3.Parameters.Add(new MySqlParameter("@Committee", reader[11].ToString()));
                                                            command3.Parameters.Add(new MySqlParameter("@Terms", reader[12].ToString()));
                                                            command3.Parameters.Add(new MySqlParameter("@RankNo", reader[13].ToString()));
                                                            command3.Parameters.Add(new MySqlParameter("@Image", reader[14].ToString()));

                                                            connection3.Open();

                                                            command3.ExecuteNonQuery();
                                                            connection3.Close();
                                                        }
                                                    }
                                                }
                                                connect.Close();
                                            }
                                        }
                                    }
                                }
                            }
                            con.Close();
                        }
                    }
                });
            }
            catch (Exception)
            {
                throw;
            }
        }

        //import
        public static async Task ImportOfficials()
        {
            try
            {
                await Task.Run(() =>
                {
                    using (MySqlConnection con = new MySqlConnection(Constants.connectionStringOnline))
                    {
                        using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM Officials", con))
                        {
                            con.Open();

                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    while (reader.Read())
                                    {
                                        string res = reader[1].ToString();
                                        string series = reader[2].ToString();

                                        using (SqlConnection connect = new SqlConnection(Constants.connectionStringOffline))
                                        {
                                            using (SqlCommand command = new SqlCommand("SELECT * FROM Officials where Position ='" + reader[6].ToString() + "'AND Terms ='" + reader[12].ToString() + "'", connect))
                                            {
                                                connect.Open();

                                                using (SqlDataReader reader1 = command.ExecuteReader())
                                                {
                                                    if (reader1.HasRows)
                                                    {
                                                    }
                                                    else
                                                    {

                                                        String query1 = "INSERT INTO Committee(FirstName, MiddleName, LastName, Suffix, Title, Position, Gender, Birthday, Address, ContactNo, Committee, Terms, RankNo, Image) VALUES(@FirstName, @MiddleName, @LastName, @Suffix, @Title, @Position, @Gender, @Birthday, @Address, @ContactNo, @Committee, @Terms, @RankNo, @Image)";
                                                        using (SqlConnection connection3 = new SqlConnection(Constants.connectionStringOffline))
                                                        {
                                                            SqlCommand command3 = new SqlCommand(query1, connection3);
                                                         
                                                            command3.Parameters.AddWithValue("@FirstName", SqlDbType.VarChar).Value = reader[1].ToString();
                                                            command3.Parameters.AddWithValue("@MiddleName", SqlDbType.VarChar).Value = reader[2].ToString();
                                                            command3.Parameters.AddWithValue("@LastName", SqlDbType.VarChar).Value = reader[3].ToString();
                                                            command3.Parameters.AddWithValue("@Suffix", SqlDbType.VarChar).Value = reader[4].ToString();
                                                            command3.Parameters.AddWithValue("@Title", SqlDbType.VarChar).Value = reader[5].ToString();
                                                            command3.Parameters.AddWithValue("@Position", SqlDbType.VarChar).Value = reader[6].ToString();
                                                            command3.Parameters.AddWithValue("@Gender", SqlDbType.VarChar).Value = reader[7].ToString();
                                                            command3.Parameters.AddWithValue("@Birthday", SqlDbType.VarChar).Value = reader[8].ToString();
                                                            command3.Parameters.AddWithValue("@Address", SqlDbType.VarChar).Value = reader[9].ToString();
                                                            command3.Parameters.AddWithValue("@ContactNo", SqlDbType.VarChar).Value = reader[10].ToString();
                                                            command3.Parameters.AddWithValue("@Committee", SqlDbType.VarChar).Value = reader[11].ToString();
                                                            command3.Parameters.AddWithValue("@Terms", SqlDbType.VarChar).Value = reader[12].ToString();
                                                            command3.Parameters.AddWithValue("@RankNo", SqlDbType.VarChar).Value = reader[13].ToString();
                                                            command3.Parameters.AddWithValue("@Image", SqlDbType.VarBinary).Value = reader[14].ToString();
                                                            connection3.Open();

                                                            command3.ExecuteNonQuery();
                                                            connection3.Close();
                                                        }
                                                    }
                                                }
                                                connect.Close();
                                            }
                                        }
                                    }
                                }
                            }
                            con.Close();
                        }
                    }
                });
            }
            catch (Exception)
            {

                throw;
            }
        }

        //updatepic
        public static async Task UpdateProfilePicOnline
          (

          string Id,
          string firstName,
          string position,
          string rank,
          string image

          )
        {
            try
            {
                await Task.Run(() =>
                {

                    string FileName = image;
                    byte[] ImageData;
                    FileStream fs;
                    BinaryReader br;
                    fs = new FileStream(FileName, FileMode.Open, FileAccess.Read);
                    br = new BinaryReader(fs);
                    ImageData = br.ReadBytes((int)fs.Length);
                    br.Close();
                    fs.Close();
                 
                    using (MySqlConnection con = new MySqlConnection(Constants.connectionStringOnline))
                    {
                        using (MySqlCommand cmd = new MySqlCommand("Update Officials set Image=@Image where FirstName=@FirstName and Position=@Position and RankNo=@RankNo and Id=@Id", con))
                        {
                            con.Open();
                            cmd.Parameters.Add(new MySqlParameter("@Id", Id));
                            cmd.Parameters.Add(new MySqlParameter("@FirstName", firstName));
                            cmd.Parameters.Add(new MySqlParameter("@Position", position));
                            cmd.Parameters.Add(new MySqlParameter("@RankNo", rank));   
                            cmd.Parameters.Add(new MySqlParameter("@Image", ImageData));
                            cmd.ExecuteNonQuery();
                            con.Close();



                        }

                    }

                });
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static async Task UpdateProfilePicOffline
           (

          string Id,
          string firstName,
          string position,
          string rank,
          string image
           )
        {
            try
            {
                await Task.Run(() =>
                {

                    string FileName = image;
                    byte[] ImageData;
                    FileStream fs;
                    BinaryReader br;
                    fs = new FileStream(FileName, FileMode.Open, FileAccess.Read);
                    br = new BinaryReader(fs);
                    ImageData = br.ReadBytes((int)fs.Length);
                    br.Close();
                    fs.Close();

                    using (SqlConnection con = new SqlConnection(Constants.connectionStringOffline))
                    {
                        using (SqlCommand cmd = new SqlCommand("Update Officials set Image=@Image where FirstName=@FirstName and Position=@Position and RankNo=@RankNo and Id=@Id", con))
                        {
                            con.Open();
                            cmd.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = Id;
                            cmd.Parameters.AddWithValue("@FirstName", SqlDbType.VarChar).Value = firstName;
                            cmd.Parameters.AddWithValue("@Position", SqlDbType.VarChar).Value = position;
                            cmd.Parameters.AddWithValue("@RankNo", SqlDbType.VarChar).Value = rank;
                            cmd.Parameters.AddWithValue("@Image", SqlDbType.VarBinary).Value = ImageData;

                            cmd.ExecuteNonQuery();
                            con.Close();



                        }

                    }

                });
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
