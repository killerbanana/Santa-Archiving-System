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

namespace Santa_Archiving_System.services.ordinance
{
    class Ordinances
    {
        public static async Task<DataTable> getListOrdinance()
        {

            DataTable dt = new DataTable();
            await Task.Run(() =>
            {
                using (SqlConnection con = new SqlConnection(Constants.connectionStringOffline))
                {

                    using (SqlCommand cmd = new SqlCommand("SELECT ID, [Ordinance No], Series, Title, Author, Date, Time, Type, Tag, Size, Reading FROM Ordinance", con))
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

        public static async Task<DataTable> getListOrdinanceOnline()
        {

            DataTable dt = new DataTable();
            await Task.Run(() =>
            {
                using (MySqlConnection con = new MySqlConnection(Constants.connectionStringOnline))
                {

                    using (MySqlCommand cmd = new MySqlCommand("SELECT ID, OrdinanceNo, Series, Title, Author, Date, Time, Type, Tag, Size, Reading FROM Ordinance", con))
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

        public static async Task<DataTable> getReading(string reading)
        {
            DataTable dt = new DataTable();
            await Task.Run(() =>
            {
                using (SqlConnection con = new SqlConnection(Constants.connectionStringOffline))
                {

                    using (SqlCommand cmd = new SqlCommand("SELECT ID, [Ordinance No], Series, Title, Author, Date, Time, Type, Tag, Size, Reading FROM Ordinance WHERE Reading ='" + reading + "'", con))
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

        public static async Task<DataTable> getReadingOnline (string reading)
        {
            DataTable dt = new DataTable();
            await Task.Run(() =>
            {
                using (MySqlConnection con = new MySqlConnection(Constants.connectionStringOnline))
                {

                    using (MySqlCommand cmd = new MySqlCommand("SELECT ID, OrdinanceNo, Series, Title, Author, Date, Time, Type, Tag, Size, Reading FROM Ordinance WHERE Reading ='" + reading + "'", con))
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

        public static async Task ImportOrdinances()
        {
            try
            {
                await Task.Run(() =>
                {
                    using (MySqlConnection con = new MySqlConnection(Constants.connectionStringOnline))
                    {
                        using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM Ordinance", con))
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
                                            using (SqlCommand command = new SqlCommand("SELECT * FROM Ordinance where [Ordinance No] ='" + res + "'AND Series ='" + series + "'", connect))
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

                                                        String query1 = "INSERT INTO Ordinance([Ordinance No], Series, Date, Title, Author , Files, Time, Type, Size, Tag, Reading) VALUES(@Ordinance,@Series, @Date, @Title, @Author, @Files, @Time, @Type, @Size, @Tag, @Reading)";
                                                        using (SqlConnection connection3 = new SqlConnection(Constants.connectionStringOffline))
                                                        {
                                                            SqlCommand command3 = new SqlCommand(query1, connection3);
                                                            command3.Parameters.AddWithValue("@Ordinance", SqlDbType.VarChar).Value = reader[1].ToString();
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

        public static async Task ExportOrdinances()
        {
            try
            {
                await Task.Run(() =>
                {
                    using (SqlConnection con = new SqlConnection(Constants.connectionStringOffline))
                    {
                        using (SqlCommand cmd = new SqlCommand("SELECT * FROM Ordinance", con))
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
                                            using (MySqlCommand command = new MySqlCommand("SELECT * FROM Ordinance where OrdinanceNo ='" + reader[1].ToString() + "'AND Series ='" + reader[2].ToString() + "'", connect))
                                            {
                                                connect.Open();

                                                using (MySqlDataReader reader1 = command.ExecuteReader())
                                                {

                                                    if (reader1.HasRows)
                                                    {
                                                        byte[] dbbyte;
                                                        dbbyte = (byte[])reader["Files"];

                                                        String query1 = "Update Ordinance set OrinanceNo = @Ordinance, " +
                                                        "Series= @Series, " +
                                                        "Date = @Date, " +
                                                        "Title = @Title," +
                                                        "Author = @Author, " +
                                                        "Files = @Files, " +
                                                        "Time = @Time, " +
                                                        "Type = @Type, " +
                                                        "Size = @Size, " +
                                                        "Tag = @Tag, " +
                                                        "Reading = @Reading where OrdinanceNo ='" + reader[1].ToString() +
                                                        "'AND Series ='" + reader[2].ToString() + "'";

                                                        using (MySqlConnection connection3 = new MySqlConnection(Constants.connectionStringOnline))
                                                        {
                                                            MySqlCommand command3 = new MySqlCommand(query1, connection3);
                                                            command3.Parameters.Add(new MySqlParameter("@Ordinance", reader[1].ToString()));
                                                            command3.Parameters.Add(new MySqlParameter("@Series", reader[2].ToString()));
                                                            command3.Parameters.Add(new MySqlParameter("@Date", reader[3].ToString()));
                                                            command3.Parameters.Add(new MySqlParameter("@Title", reader[4].ToString()));
                                                            command3.Parameters.Add(new MySqlParameter("@Author", reader[5].ToString()));
                                                            command3.Parameters.Add(new MySqlParameter("@Files", dbbyte));
                                                            command3.Parameters.Add(new MySqlParameter("@Time", reader[7].ToString()));
                                                            command3.Parameters.Add(new MySqlParameter("@Type", reader[8].ToString()));
                                                            command3.Parameters.Add(new MySqlParameter("@Size", reader[9].ToString()));
                                                            command3.Parameters.Add(new MySqlParameter("@Tag", reader[10].ToString()));
                                                            command3.Parameters.Add(new MySqlParameter("@Reading", reader[11].ToString()));

                                                            connection3.Open();

                                                            command3.ExecuteNonQuery();
                                                            connection3.Close();
                                                        }
                                                    }
                                                    else
                                                    {
                                                        byte[] dbbyte;
                                                        dbbyte = (byte[])reader["Files"];
                                                        String query1 = "INSERT INTO Resolution(OrdinanceNo, Series, Date, Title, Author , Files, Time, Type, Size, Tag, Reading) VALUES(@Ordinance,@Series, @Date, @Title, @Author, @Files, @Time, @Type, @Size, @Tag, @Reading)";
                                                        using (MySqlConnection connection3 = new MySqlConnection(Constants.connectionStringOnline))
                                                        {
                                                            MySqlCommand command3 = new MySqlCommand(query1, connection3);
                                                            command3.Parameters.Add(new MySqlParameter("@Ordinance", reader[1].ToString()));
                                                            command3.Parameters.Add(new MySqlParameter("@Series", reader[2].ToString()));
                                                            command3.Parameters.Add(new MySqlParameter("@Date", reader[3].ToString()));
                                                            command3.Parameters.Add(new MySqlParameter("@Title", reader[4].ToString()));
                                                            command3.Parameters.Add(new MySqlParameter("@Author", reader[5].ToString()));
                                                            command3.Parameters.Add(new MySqlParameter("@Files", dbbyte));
                                                            command3.Parameters.Add(new MySqlParameter("@Time", reader[7].ToString()));
                                                            command3.Parameters.Add(new MySqlParameter("@Type", reader[8].ToString()));
                                                            command3.Parameters.Add(new MySqlParameter("@Size", reader[9].ToString()));
                                                            command3.Parameters.Add(new MySqlParameter("@Tag", reader[10].ToString()));
                                                            command3.Parameters.Add(new MySqlParameter("@Reading", reader[11].ToString()));
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

        public static async Task SaveOrdinanceData(
           string ordinanceNo,
           string series,
           string date,
           string title,
           string author,
           string time,
           string ampm,
           string tag,
           string reading
           )
        {
            String query = "INSERT INTO Ordinance([Ordinance No], Series, Date, Title, Author , Files, Time, Type, Size, Tag, Reading) VALUES(@Ordinance,@Series, @Date, @Title, @Author, @Files, @Time, @Type, @Size, @Tag, @Reading)";

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
                    cmd.Parameters.AddWithValue("@Ordinance", SqlDbType.VarChar).Value = ordinanceNo;
                    cmd.Parameters.AddWithValue("@Series", SqlDbType.VarChar).Value = series;
                    cmd.Parameters.AddWithValue("@Date", SqlDbType.VarChar).Value = date;
                    cmd.Parameters.AddWithValue("@Title", SqlDbType.VarChar).Value = title;
                    cmd.Parameters.AddWithValue("@Author", SqlDbType.VarChar).Value = author;
                    cmd.Parameters.AddWithValue("@Files", SqlDbType.VarBinary).Value = buffer;
                    cmd.Parameters.AddWithValue("@Time", SqlDbType.VarChar).Value = time + " " + ampm;
                    cmd.Parameters.AddWithValue("@Type", SqlDbType.VarChar).Value = Constants.ext;
                    cmd.Parameters.AddWithValue("@Size", SqlDbType.VarChar).Value = resultSize;
                    cmd.Parameters.AddWithValue("@Tag", SqlDbType.VarChar).Value = tag;
                    cmd.Parameters.AddWithValue("@Reading", SqlDbType.VarChar).Value = reading;

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
}
