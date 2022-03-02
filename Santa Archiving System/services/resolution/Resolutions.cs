using MySql.Data.MySqlClient;
using Santa_Archiving_System.common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Santa_Archiving_System.services.resolution
{
    class Resolutions
    {
        public static async Task<DataTable> getList()
        {

            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(Constants.connectionStringOffline))
            {

                using (SqlCommand cmd = new SqlCommand("SELECT ID, [Resolution No], Series, Title, Author, Date, Time, Type, Tag, Size, Reading FROM Resolution", con))
                {
                    con.Open();
                    IAsyncResult result = cmd.BeginExecuteReader();

                    while (!result.IsCompleted)
                    {

                        // Wait for 1/10 second, so the counter
                        // does not consume all available resources 
                        //System.Threading.Thread.Sleep(100);
                        // on the main thread.
                    }

                    using (SqlDataReader reader = cmd.EndExecuteReader(result))
                    {
                        await Task.Run(() =>
                        {
                            dt.Load(reader);
                        });
                    }

                }

            }
            return dt;
        }

        public static async 
        Task
ImportResolutions()
        {
            try
            {
                await Task.Run(() =>
                {
                    using (MySqlConnection con = new MySqlConnection(Constants.connectionStringOnline))
                    {
                        using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM Resolution", con))
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
                                            using (SqlCommand command = new SqlCommand("SELECT * FROM Resolution where [Resolution No] ='" + res + "'AND Series ='" + series + "'", connect))
                                            {
                                                connect.Open();

                                                using (SqlDataReader reader1 = command.ExecuteReader())
                                                {
                                                    if (reader1.HasRows)
                                                    {
                                                    }
                                                    else
                                                    {
                                                        byte[] dbbyte;
                                                        dbbyte = (byte[])reader["Files"];

                                                        String query1 = "INSERT INTO Resolution([Resolution No], Series, Date, Title, Author , Files, Time, Type, Size, Tag, Reading) VALUES(@Resolution,@Series, @Date, @Title, @Author, @Files, @Time, @Type, @Size, @Tag, @Reading)";
                                                        using (SqlConnection connection3 = new SqlConnection(Constants.connectionStringOffline))
                                                        {
                                                            SqlCommand command3 = new SqlCommand(query1, connection3);
                                                            command3.Parameters.AddWithValue("@Resolution", SqlDbType.VarChar).Value = reader[1].ToString();
                                                            command3.Parameters.AddWithValue("@Series", SqlDbType.VarChar).Value = reader[2].ToString();
                                                            command3.Parameters.AddWithValue("@Date", SqlDbType.VarChar).Value = reader[3].ToString();
                                                            command3.Parameters.AddWithValue("@Title", SqlDbType.VarChar).Value = reader[4].ToString();
                                                            command3.Parameters.AddWithValue("@Author", SqlDbType.VarChar).Value = reader[5].ToString();
                                                            command3.Parameters.AddWithValue("@Files", SqlDbType.VarBinary).Value = dbbyte;
                                                            command3.Parameters.AddWithValue("@Time", SqlDbType.VarChar).Value = reader[7].ToString();
                                                            command3.Parameters.AddWithValue("@Type", SqlDbType.VarChar).Value = reader[8].ToString();
                                                            command3.Parameters.AddWithValue("@Size", SqlDbType.VarChar).Value = reader[9].ToString();
                                                            command3.Parameters.AddWithValue("@Tag", SqlDbType.VarChar).Value = reader[10].ToString();
                                                            command3.Parameters.AddWithValue("@Reading", SqlDbType.VarChar).Value = reader[11].ToString();
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
    }
}
