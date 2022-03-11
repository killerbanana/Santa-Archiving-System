﻿using MySql.Data.MySqlClient;
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

namespace Santa_Archiving_System.services.account
{

    public class Account
    {
        public static bool checkedUsername;
        public static bool checkedLoginOnline;
        public static bool checkedLoginOffline;
        public static string firstName, middleName, lastName, accountRole, username, password;
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
                                            byte[] img = (byte[])(reader["Image"]);
                                            MemoryStream mstream = new MemoryStream(img);
                                            image = mstream;
                                            accountRole = reader[9].ToString();
                                            privilege.Add(reader.GetString(reader.GetOrdinal("Privilege")));
                                            username = reader[11].ToString();
                                            password = reader[12].ToString();
                                            status = Convert.ToBoolean(reader[13]); 
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
                                        byte[] img = (byte[])(reader["Image"]);
                                        MemoryStream mstream = new MemoryStream(img);
                                        image = mstream;
                                        accountRole = reader[9].ToString();
                                        privilege.Add(reader.GetString(reader.GetOrdinal("Privilege")));
                                        username = reader[11].ToString();
                                        password = reader[12].ToString();
                                        status = Convert.ToBoolean(reader[13]);
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

            string FileName = image;
            byte[] ImageData;
            FileStream fs;
            BinaryReader br;
            fs = new FileStream(FileName, FileMode.Open, FileAccess.Read);
            br = new BinaryReader(fs);
            ImageData = br.ReadBytes((int)fs.Length);
            br.Close();
            fs.Close();
            String query = "INSERT INTO Registration(FirstName, MiddleName, LastName, Gender, Birthday , Address, ContactNo, AccountRole, Privilege, Username, Password, Image, Status) VALUES(@FirstName,@MiddleName, @LastName, @Gender, @Birthday, @Address, @ContactNo, @Role, @Privilege, @Username, @Password, @Image, @Status)";

            using (SqlConnection con = new SqlConnection(Constants.connectionStringOffline))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                //SQL kasta kuys
                cmd.Parameters.AddWithValue("@FirstName", SqlDbType.VarChar).Value = firstName;
                cmd.Parameters.AddWithValue("@MiddleName", SqlDbType.VarChar).Value = middleName;
                cmd.Parameters.AddWithValue("@LastName", SqlDbType.VarChar).Value = lastName;
                cmd.Parameters.AddWithValue("@Gender", SqlDbType.VarChar).Value = gender;
                cmd.Parameters.AddWithValue("@Birthday", SqlDbType.VarChar).Value = birthday;
                cmd.Parameters.AddWithValue("@Address", SqlDbType.VarChar).Value = address;
                cmd.Parameters.AddWithValue("@ContactNo", SqlDbType.VarChar).Value = contactNo;
                cmd.Parameters.AddWithValue("@Role", SqlDbType.VarChar).Value = accountRole;
                cmd.Parameters.AddWithValue("@Privilege", SqlDbType.VarChar).Value = string.Join(",", privilege);
                cmd.Parameters.AddWithValue("@Username", SqlDbType.VarChar).Value = username;
                cmd.Parameters.AddWithValue("@Password", SqlDbType.VarChar).Value = password;
                cmd.Parameters.AddWithValue("@Image", SqlDbType.VarChar).Value = ImageData;
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
            List<String> privilege,
            string username,
            string password,
            string image,
            bool status
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
            String query = "INSERT INTO Registration(FirstName, MiddleName, LastName, Gender, Birthday , Address, ContactNo, AccountRole, Privilege, Username, Password, Image, Status) VALUES(@FirstName,@MiddleName, @LastName, @Gender, @Birthday, @Address, @ContactNo, @Role, @Privilege, @Username, @Password, @Image, @Status)";

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

    }
}