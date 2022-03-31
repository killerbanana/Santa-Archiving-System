using MySql.Data.MySqlClient;
using Santa_Archiving_System.common;
using Santa_Archiving_System.models;
using Santa_Archiving_System.services.controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Santa_Archiving_System.services.account
{

    public class Account
    {
        public static bool checkedUsername;
        public static bool checkedLoginOnline;
        public static bool checkedLoginOffline;
        public static string firstName, middleName, lastName, suffix, accountRole, gender, birthday, address, contactNo, userName, password;
        public static System.IO.MemoryStream image;
        public static bool status;
        public static List<String> privilege = new List<string>();

        public static async Task CheckLoginOffline(string username)
        {

            try
            {
                await Task.Run(() =>
                {
                    using (SqlConnection con = new SqlConnection(Constants.connectionStringOffline))
                    {
                        using (SqlCommand cmd = new SqlCommand("SELECT * FROM Registration  WHERE Username='" + username + "'", con))
                        {
                            con.Open();

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {


                                if (reader.HasRows)
                                {
                                    while (reader.Read())
                                    {
                                        checkedLoginOffline = true;
                                        firstName = reader[1].ToString();
                                        middleName = reader[2].ToString();
                                        lastName = reader[3].ToString();
                                        suffix = reader[4].ToString();
                                        gender = reader[6].ToString();
                                        birthday = reader[7].ToString();
                                        address = reader[6].ToString();
                                        contactNo = reader[9].ToString();
                                        byte[] img = (byte[])(reader["Image"]);
                                        MemoryStream mstream = new MemoryStream(img);
                                        image = mstream;
                                        accountRole = reader[10].ToString();
                                        privilege.Add(reader.GetString(reader.GetOrdinal("Privilege")));
                                        userName = reader[12].ToString();
                                        password = reader[13].ToString();
                                        status = Convert.ToBoolean(reader[14]);

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
        public static async Task CheckLoginOnline(string username)
        {

            try
            {
                await Task.Run(() =>
                {
                    using (MySqlConnection con = new MySqlConnection(Constants.connectionStringOnline))
                    {
                        using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM Registration  WHERE Username='" + username + "'", con))
                        {
                            con.Open();

                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {


                                if (reader.HasRows)
                                {
                                    while (reader.Read())
                                    {
                                        checkedLoginOnline = true;
                                        firstName = reader[1].ToString();
                                        middleName = reader[2].ToString();
                                        lastName = reader[3].ToString();
                                        suffix = reader[4].ToString();
                                        gender = reader[6].ToString();
                                        birthday = reader[7].ToString();
                                        address = reader[6].ToString();
                                        contactNo = reader[9].ToString();
                                        byte[] img = (byte[])(reader["Image"]);
                                        MemoryStream mstream = new MemoryStream(img);
                                        image = mstream;
                                        accountRole = reader[10].ToString();
                                        privilege.Add(reader.GetString(reader.GetOrdinal("Privilege")));
                                        userName = reader[12].ToString();
                                        password = reader[13].ToString();
                                        status = Convert.ToBoolean(reader[14]);
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
        public static async Task CheckUsername(string username)
        {

            try
            {
                await Task.Run(() =>
                {
                    using (MySqlConnection con = new MySqlConnection(Constants.connectionStringOnline))
                    {
                        using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM Registration  WHERE Username='" + username + "'", con))
                        {
                            con.Open();

                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {

                                while (reader.Read())
                                {
                                    if (reader.HasRows)
                                    {

                                        checkedUsername = true;

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
        public static async Task SaveAccountOffline
             (
             string firstName,
             string middleName,
             string lastName,
             string suffix,
             string gender,
             string birthday,
             string address,
             string contactNo,
             string accountRole,
             List<String> privilege,
             string username,
             string password,
             string image,
             bool status
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
                String query = "INSERT INTO Registration(FirstName, MiddleName, LastName, Suffix, Gender, Birthday , Address, ContactNo, AccountRole, Privilege, Username, Password, Image, Status) VALUES(@FirstName,@MiddleName, @LastName, @Suffix, @Gender, @Birthday, @Address, @ContactNo, @Role, @Privilege, @Username, @Password, @Image, @Status)";

                using (SqlConnection con = new SqlConnection(Constants.connectionStringOffline))
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    //SQL kasta kuys
                    cmd.Parameters.AddWithValue("@FirstName", SqlDbType.VarChar).Value = firstName;
                    cmd.Parameters.AddWithValue("@MiddleName", SqlDbType.VarChar).Value = middleName;
                    cmd.Parameters.AddWithValue("@LastName", SqlDbType.VarChar).Value = lastName;
                    cmd.Parameters.AddWithValue("@Suffix", SqlDbType.VarChar).Value = suffix;
                    cmd.Parameters.AddWithValue("@Gender", SqlDbType.VarChar).Value = gender;
                    cmd.Parameters.AddWithValue("@Birthday", SqlDbType.VarChar).Value = birthday;
                    cmd.Parameters.AddWithValue("@Address", SqlDbType.VarChar).Value = address;
                    cmd.Parameters.AddWithValue("@ContactNo", SqlDbType.VarChar).Value = contactNo;
                    cmd.Parameters.AddWithValue("@Role", SqlDbType.VarChar).Value = accountRole;
                    cmd.Parameters.AddWithValue("@Privilege", SqlDbType.VarChar).Value = string.Join(",", privilege);
                    cmd.Parameters.AddWithValue("@Username", SqlDbType.VarChar).Value = username;
                    cmd.Parameters.AddWithValue("@Password", SqlDbType.VarChar).Value = password;
                    cmd.Parameters.AddWithValue("@Image", SqlDbType.VarBinary).Value = ImageData;
                    cmd.Parameters.AddWithValue("@Status", SqlDbType.VarChar).Value = status;

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
        public static async Task SaveAccountOnline
            (
            string firstName,
            string middleName,
            string lastName,
            string suffix,
            string gender,
            string birthday,
            string address,
            string contactNo,
            string accountRole,
            List<String> privilege,
            string username,
            string password,
            string image,
            bool status
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
                String query = "INSERT INTO Registration(FirstName, MiddleName, LastName, Suffix, Gender, Birthday , Address, ContactNo, AccountRole, Privilege, Username, Password, Image, Status) VALUES(@FirstName,@MiddleName, @LastName, @Suffix, @Gender, @Birthday, @Address, @ContactNo, @Role, @Privilege, @Username, @Password, @Image, @Status)";

                using (MySqlConnection con = new MySqlConnection(Constants.connectionStringOnline))
                {
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.Add(new MySqlParameter("@FirstName", firstName));
                    cmd.Parameters.Add(new MySqlParameter("@MiddleName", middleName));
                    cmd.Parameters.Add(new MySqlParameter("@LastName", lastName));
                    cmd.Parameters.Add(new MySqlParameter("@Suffix", suffix));
                    cmd.Parameters.Add(new MySqlParameter("@Gender", gender));
                    cmd.Parameters.Add(new MySqlParameter("@Birthday", birthday));
                    cmd.Parameters.Add(new MySqlParameter("@Address", address));
                    cmd.Parameters.Add(new MySqlParameter("@ContactNo", contactNo));
                    cmd.Parameters.Add(new MySqlParameter("@Role", accountRole));
                    cmd.Parameters.Add(new MySqlParameter("@Privilege", string.Join(",", privilege)));
                    cmd.Parameters.Add(new MySqlParameter("@Username", username));
                    cmd.Parameters.Add(new MySqlParameter("@Password", password));
                    cmd.Parameters.Add(new MySqlParameter("@Image", ImageData));
                    cmd.Parameters.Add(new MySqlParameter("@Status", status));
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


        public static async Task UpdateProfileOnline
            (
            string firstName,
            string middleName,
            string lastName,
            string gender,
            string birthday,
            string address,
            string contactNo

            )
        {
            try
            {
                await Task.Run(() =>
                {

                    using (MySqlConnection con = new MySqlConnection(Constants.connectionStringOnline))
                    {
                        using (MySqlCommand cmd = new MySqlCommand("Update Registration set FirstName=@FirstName, MiddleName=@MiddleName, LastName=@LastName, Gender=@Gender, " +
                                "Birthday=@Birthday, Address=@Address , ContactNo=@ContactNo where Username=@Username", con))
                        {
                            con.Open();
                            cmd.Parameters.Add(new MySqlParameter("@Username", userName));
                            cmd.Parameters.Add(new MySqlParameter("@FirstName", firstName));
                            cmd.Parameters.Add(new MySqlParameter("@MiddleName", middleName));
                            cmd.Parameters.Add(new MySqlParameter("@LastName", lastName));
                            cmd.Parameters.Add(new MySqlParameter("@Gender", gender));
                            cmd.Parameters.Add(new MySqlParameter("@Birthday", birthday));
                            cmd.Parameters.Add(new MySqlParameter("@Address", address));
                            cmd.Parameters.Add(new MySqlParameter("@ContactNo", contactNo));

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

        public static async Task UpdateProfileOffline
          (
          string firstName,
          string middleName,
          string lastName,
          string gender,
          string birthday,
          string address,
          string contactNo

          )
        {
            try
            {
                await Task.Run(() =>
                {

                    using (SqlConnection con = new SqlConnection(Constants.connectionStringOffline))
                    {
                        using (SqlCommand cmd = new SqlCommand("Update Registration set FirstName=@FirstName, MiddleName=@MiddleName, LastName=@LastName, Gender=@Gender, " +
                                "Birthday=@Birthday, Address=@Address , ContactNo=@ContactNo where Username=@Username", con))
                        {
                            con.Open();
                            cmd.Parameters.AddWithValue("@Username", SqlDbType.VarChar).Value = userName;
                            cmd.Parameters.AddWithValue("@FirstName", SqlDbType.VarChar).Value = firstName;
                            cmd.Parameters.AddWithValue("@MiddleName", SqlDbType.VarChar).Value = middleName;
                            cmd.Parameters.AddWithValue("@LastName", SqlDbType.VarChar).Value = lastName;
                            cmd.Parameters.AddWithValue("@Gender", SqlDbType.VarChar).Value = gender;
                            cmd.Parameters.AddWithValue("@Birthday", SqlDbType.VarChar).Value = birthday;
                            cmd.Parameters.AddWithValue("@Address", SqlDbType.VarChar).Value = address;
                            cmd.Parameters.AddWithValue("@ContactNo", SqlDbType.VarChar).Value = contactNo;

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
        public static async Task UpdateProfilePicOnline
           (
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
                        using (MySqlCommand cmd = new MySqlCommand("Update Registration set Image=@Image where Username=@Username", con))
                        {
                            con.Open();
                            cmd.Parameters.Add(new MySqlParameter("@Username", userName));
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
                        using (SqlCommand cmd = new SqlCommand("Update Registration set Image=@Image where Username=@Username", con))
                        {
                            con.Open();
                            cmd.Parameters.AddWithValue("@Username", SqlDbType.VarChar).Value = userName;
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

        public static async Task UpdatePasswordOffline(string password)
        {
            try
            {
                await Task.Run(() =>
                {

                    using (SqlConnection con = new SqlConnection(Constants.connectionStringOffline))
                    {

                        using (SqlCommand cmd = new SqlCommand("Update Registration set Password=@Password where Username=@Username", con))
                        {
                            con.Open();
                            cmd.Parameters.AddWithValue("@Username", SqlDbType.VarChar).Value = userName;
                            cmd.Parameters.AddWithValue("@Password", SqlDbType.VarChar).Value = password;

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

        public static async Task UpdatePasswordOnline(string password)
        {
            try
            {
                await Task.Run(() =>
                {

                    using (MySqlConnection con = new MySqlConnection(Constants.connectionStringOnline))
                    {
                        using (MySqlCommand cmd = new MySqlCommand("Update Registration set Password=@Password where Username=@Username", con))
                        {
                            con.Open();
                            cmd.Parameters.Add(new MySqlParameter("@Username", userName));
                            cmd.Parameters.Add(new MySqlParameter("@Password", password));
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

        public static async Task<DataTable> getUsersListOnline()
        {
            try
            {
                DataTable dt = new DataTable();
                await Task.Run(() =>
                {
                    using (MySqlConnection con = new MySqlConnection(Constants.connectionStringOnline))
                    {

                        using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM Registration", con))
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
        //update user account
        public static async Task getUserToUpdateOnline
        (

            string accountRole,
            List<String> privilege,
            bool status,
            string username
        )
        {
            try
            {
                await Task.Run(() =>
                {

                    using (MySqlConnection con = new MySqlConnection(Constants.connectionStringOnline))
                    {
                        using (MySqlCommand cmd = new MySqlCommand("Update Registration set AccountRole=@AccountRole, Privilege=@Privilege, Status=@Status where Username=@Username", con))
                        {
                            con.Open();


                            cmd.Parameters.Add(new MySqlParameter("@AccountRole", accountRole));
                            cmd.Parameters.Add(new MySqlParameter("@Privilege", string.Join(",", privilege)));
                            cmd.Parameters.Add(new MySqlParameter("@Status", Convert.ToBoolean(status)));
                            cmd.Parameters.Add(new MySqlParameter("@Username", username));
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

        public static async Task getUserToUpdateOffline
        (

            string accountRole,
            List<String> privilege,
            bool status,
            string username
        )
        {
            try
            {
                await Task.Run(() =>
                {

                    using (SqlConnection con = new SqlConnection(Constants.connectionStringOffline))
                    {
                        using (SqlCommand cmd = new SqlCommand("Update Registration set AccountRole=@AccountRole, Privilege=@Privilege, Status=@Status where Username=@Username", con))
                        {
                            con.Open();

                            cmd.Parameters.AddWithValue("@AccountRole", SqlDbType.VarChar).Value = accountRole;
                            cmd.Parameters.AddWithValue("@Privilege", SqlDbType.VarChar).Value = string.Join(",", privilege);
                            cmd.Parameters.AddWithValue("@Status", SqlDbType.VarChar).Value = Convert.ToBoolean(status);
                            cmd.Parameters.AddWithValue("@Username", SqlDbType.VarChar).Value = username;

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


        //Delete
        public static async Task DeleteUserOnline(string username)
        {
            try
            {
                await Task.Run(() =>
                {
                    using (MySqlConnection con = new MySqlConnection(Constants.connectionStringOnline))
                    {
                        MySqlCommand cmd = new MySqlCommand("Delete from Registration where Username = @Username", con);
                        cmd.Parameters.Add(new MySqlParameter("@Username", username));
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

        public static async Task DeleteUserOffline(string username)
        {
            try
            {
                await Task.Run(() =>
                {
                    using (SqlConnection con = new SqlConnection(Constants.connectionStringOffline))
                    {
                        SqlCommand cmd = new SqlCommand("Delete from Registration where Username = @Username", con);
                        cmd.Parameters.AddWithValue("@Username", SqlDbType.VarChar).Value = username;
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

        public static async Task updateOnlineStatus
       (

        bool online,
        string username
       )
        {
            try
            {
                await Task.Run(() =>
                {

                    using (MySqlConnection con = new MySqlConnection(Constants.connectionStringOnline))
                    {
                        using (MySqlCommand cmd = new MySqlCommand("Update Registration set Online=@Online where Username=@Username", con))
                        {
                            con.Open();
                  
                            cmd.Parameters.Add(new MySqlParameter("@Online", Convert.ToBoolean(online)));
                            cmd.Parameters.Add(new MySqlParameter("@Username", username));
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


        //getonlineusers

        public static async Task<DataTable> getOnlineUsers()
        {
            try
            {
                DataTable dt = new DataTable();
                await Task.Run(() =>
                {
                    using (MySqlConnection con = new MySqlConnection(Constants.connectionStringOnline))
                    {

                        using (MySqlCommand cmd = new MySqlCommand("SELECT FirstName, Username FROM Registration WHERE Online='" + 1 + "'", con))
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

       
    }
}
