using MySql.Data.MySqlClient;
using Santa_Archiving_System.common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Santa_Archiving_System.services.account
{
   
    public class Account
    {
        public static bool checkedUsername;
        
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
      
        public static async Task SaveAccountOnline
            (
            string firstName,
            string middleName,
            string lastName,
            string gender,
            string birthday,
            string address,
            string contactNo,
            string accountRole,
            string privilege,
            string username,
            string password,
            string image
            )
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
            String query = "INSERT INTO Registration(FirstName, MiddleName, LastName, Gender, Birthday , Address, ContactNo, AccountRole, Privilege, Username, Password, Image) VALUES(@FirstName,@MiddleName, @LastName, @Gender, @Birthday, @Address, @ContactNo, @Role, @Privilege, @Username, @Password, @Image)";

            using (MySqlConnection con = new MySqlConnection(Constants.connectionStringOnline))
            {
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.Add(new MySqlParameter("@FirstName", firstName));
                cmd.Parameters.Add(new MySqlParameter("@MiddleName", middleName));
                cmd.Parameters.Add(new MySqlParameter("@LastName", lastName));
                cmd.Parameters.Add(new MySqlParameter("@Gender", gender));
                cmd.Parameters.Add(new MySqlParameter("@Birthday", birthday));
                cmd.Parameters.Add(new MySqlParameter("@Address", address));
                cmd.Parameters.Add(new MySqlParameter("@ContactNo", contactNo));
                cmd.Parameters.Add(new MySqlParameter("@Role", accountRole));
                cmd.Parameters.Add(new MySqlParameter("@Privilege", privilege));
                cmd.Parameters.Add(new MySqlParameter("@Username", username));
                cmd.Parameters.Add(new MySqlParameter("@Password", password));
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

    }
}
