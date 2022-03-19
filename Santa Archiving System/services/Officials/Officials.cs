using MySql.Data.MySqlClient;
using Santa_Archiving_System.common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Santa_Archiving_System.services.Officials
{
    public class Officials
    {
        public static List<String> terms = new List<string>();
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
            List<String> committees,
            string terms,
            string image
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
                String query = "INSERT INTO Officials(FirstName, MiddleName, LastName, Suffix, Title, Position, Gender, Birthday, Address, ContactNo, Committees, Terms, Image) VALUES(@FirstName,@MiddleName, @LastName, @Suffix, @Title, @Position, @Gender, @Birthday, @Address, @ContactNo, @Committees, @Terms, @Image)";

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
                    cmd.Parameters.AddWithValue("@Committees", SqlDbType.VarChar).Value = string.Join(",", committees);
                    cmd.Parameters.AddWithValue("@Terms", SqlDbType.VarChar).Value = terms;
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
           List<String> committees,
           string terms,
           string image
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
                String query = "INSERT INTO Officials(FirstName, MiddleName, LastName, Suffix, Title, Position, Gender, Birthday, Address, ContactNo, Committees, Terms, Image) VALUES(@FirstName,@MiddleName, @LastName, @Suffix, @Title, @Position, @Gender, @Birthday, @Address, @ContactNo, @Committees, @Terms, @Image)";

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
                    cmd.Parameters.Add(new MySqlParameter("@Committees", committees));
                    cmd.Parameters.Add(new MySqlParameter("@Terms", terms));
                    cmd.Parameters.Add(new MySqlParameter("@Image", image));
                   
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
                            IAsyncResult result = cmd.BeginExecuteReader();

                            while (!result.IsCompleted)
                            {
                            }

                            using (MySqlDataReader reader = cmd.EndExecuteReader(result))
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
                            IAsyncResult result = cmd.BeginExecuteReader();

                            while (!result.IsCompleted)
                            {
                            }

                            using (SqlDataReader reader = cmd.EndExecuteReader(result))
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
    }
}
