using MySql.Data.MySqlClient;
using Santa_Archiving_System.common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
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

        //READING OFFLINE
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

        //READING ONLINE
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

        public static async Task<DataTable> getPdf(string type)
        {
            DataTable dt = new DataTable();
            await Task.Run(() =>
            {
                using (SqlConnection con = new SqlConnection(Constants.connectionStringOffline))
                {

                    using (SqlCommand cmd = new SqlCommand("SELECT ID, [Ordinance No], Series, Title, Author, Date, Time, Type, Tag, Size, Reading FROM Ordinance WHERE Type ='" + type + "'", con))
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

        public static async Task<DataTable> getPdfOnline(string type)
        {
            DataTable dt = new DataTable();
            await Task.Run(() =>
            {
                using (MySqlConnection con = new MySqlConnection(Constants.connectionStringOnline))
                {

                    using (MySqlCommand cmd = new MySqlCommand("SELECT ID, OrdinanceNo, Series, Title, Author, Date, Time, Type, Tag, Size, Reading FROM Ordinance WHERE Type ='" + type + "'", con))
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
                                                        String query1 = "INSERT INTO Ordinance(OrdinanceNo, Series, Date, Title, Author , Files, Time, Type, Size, Tag, Reading) VALUES(@Ordinance,@Series, @Date, @Title, @Author, @Files, @Time, @Type, @Size, @Tag, @Reading)";
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

        //SAVE OFFLINE
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

        //SAVE ONLINE
        public static async Task SaveOrdinanceDataOnline(
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
            String query = "INSERT INTO Ordinance(OrdinanceNo, Series, Date, Title, Author , Files, Time, Type, Size, Tag, Reading) VALUES(@Ordinance,@Series, @Date, @Title, @Author, @Files, @Time, @Type, @Size, @Tag, @Reading)";

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


                using (MySqlConnection con = new MySqlConnection(Constants.connectionStringOnline))
                {
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.Add(new MySqlParameter("@Ordinance", ordinanceNo));
                    cmd.Parameters.Add(new MySqlParameter("@Series", series));
                    cmd.Parameters.Add(new MySqlParameter("@Date", date));
                    cmd.Parameters.Add(new MySqlParameter("@Title", title));
                    cmd.Parameters.Add(new MySqlParameter("@Author", author));
                    cmd.Parameters.Add(new MySqlParameter("@Files",  buffer));
                    cmd.Parameters.Add(new MySqlParameter("@Time",  time + " " + ampm));
                    cmd.Parameters.Add(new MySqlParameter("@Type", Constants.ext));
                    cmd.Parameters.Add(new MySqlParameter("@Size", resultSize));
                    cmd.Parameters.Add(new MySqlParameter("@Tag",  tag));
                    cmd.Parameters.Add(new MySqlParameter("@Reading", reading));

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

        //CREATING FILE OFFLINE
        public static async Task<string> CreateNewFile(
            string Id,
            string fileType)
        {
            string path = "";
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            byte[] dbbyte = null;
            await Task.Run(() =>
            {
                if (fileType == ".docx")
                {
                    using (SqlConnection con = new SqlConnection(Constants.connectionStringOffline))
                    {
                        FileStream FS = null;

                        using (SqlCommand cmd = new SqlCommand("SELECT Files FROM Ordinance where Id ='" + int.Parse(Id) + "'", con))
                        {
                            con.Open();

                            da = new SqlDataAdapter(cmd);
                            dt = new DataTable();
                            da.Fill(dt);

                            dbbyte = (byte[])dt.Rows[0]["files"];

                            //store file Temporarily 
                            string filepath = "C:\\1.docx";

                            //Assign File path create file
                            FS = new FileStream(filepath, System.IO.FileMode.Create);

                            //Write bytes to create file
                            FS.Write(dbbyte, 0, dbbyte.Length);

                            //Close FileStream instance
                            FS.Close();

                        }

                    }
                    path = "C:\\New folder\\1.docx";
                }
                if (fileType == ".pdf")
                {
                    using (SqlConnection con = new SqlConnection(Constants.connectionStringOffline))
                    {

                        FileStream FS = null;

                        using (SqlCommand cmd = new SqlCommand("SELECT Files FROM Ordinance where Id ='" + int.Parse(Id) + "'", con))
                        {
                            con.Open();

                            da = new SqlDataAdapter(cmd);
                            dt = new DataTable();
                            da.Fill(dt);

                            dbbyte = (byte[])dt.Rows[0]["files"];

                            //store file Temporarily 
                            string filepath = "C:\\2.pdf";

                            //Assign File path create file
                            FS = new FileStream(filepath, System.IO.FileMode.Create);

                            //Write bytes to create file
                            FS.Write(dbbyte, 0, dbbyte.Length);

                            //Close FileStream instance
                            FS.Close();
                        }

                    }
                    path = "C:\\New folder\\2.pdf";
                }
            });
            return path;
        }

        //CREATING TEMP FILE ONLINE
        public static async Task<string> CreateNewFileOnline(
            string Id,
            string fileType)
        {
            string path = "";
            MySqlDataAdapter da = new MySqlDataAdapter();
            DataTable dt = new DataTable();
            byte[] dbbyte = null;
            await Task.Run(() =>
            {
                if (fileType == ".docx")
                {
                    using (MySqlConnection con = new MySqlConnection(Constants.connectionStringOnline))
                    {
                        FileStream FS = null;

                        using (MySqlCommand cmd = new MySqlCommand("SELECT Files FROM Ordinance where Id ='" + int.Parse(Id) + "'", con))
                        {
                            con.Open();

                            da = new MySqlDataAdapter(cmd);
                            dt = new DataTable();
                            da.Fill(dt);

                            dbbyte = (byte[])dt.Rows[0]["files"];

                            //store file Temporarily 
                            string filepath = "C:\\New folder\\1.docx";

                            //Assign File path create file
                            FS = new FileStream(filepath, System.IO.FileMode.Create);

                            //Write bytes to create file
                            FS.Write(dbbyte, 0, dbbyte.Length);

                            //Close FileStream instance
                            FS.Close();

                        }

                    }
                    path = "C:\\New folder\\1.docx";
                }
                if (fileType == ".pdf")
                {
                    using (MySqlConnection con = new MySqlConnection(Constants.connectionStringOnline))
                    {

                        FileStream FS = null;

                        using (MySqlCommand cmd = new MySqlCommand("SELECT Files FROM Ordinance where Id ='" + int.Parse(Id) + "'", con))
                        {
                            con.Open();

                            da = new MySqlDataAdapter(cmd);
                            dt = new DataTable();
                            da.Fill(dt);

                            dbbyte = (byte[])dt.Rows[0]["files"];

                            //store file Temporarily 
                            string filepath = "C:\\New folder\\2.pdf";

                            //Assign File path create file
                            FS = new FileStream(filepath, System.IO.FileMode.Create);

                            //Write bytes to create file
                            FS.Write(dbbyte, 0, dbbyte.Length);

                            //Close FileStream instance
                            FS.Close();
                        }

                    }
                    path = "C:\\New folder\\2.pdf";
                }
            });
            return path;
        }

        //UPDATE OFFLINE
        public static async Task UpdateOrdinance(
            string Id,
            string OrdinanceNo,
            string series,
            string date,
            string title,
            string author,
            string time,
            string ampm,
            string tag,
            string reading,
            string path)
        {
            await Task.Run(() =>
            {
                using (Stream stream = File.OpenRead(path))
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

                    string resultSize = String.Format("{0:0.##} {1}", len, sizes[order]);

                    using (SqlConnection con = new SqlConnection(Constants.connectionStringOffline))
                    {
                        using (SqlCommand cmd = new SqlCommand("Update Ordinance set [Ordinance No]=@Ordinance, Series=@Series, Date=@Date, Title=@Title, Author=@Author, " +
                            "Time=@Time , Tag=@Tag, Reading=@Reading, Files=@Files, Size=@Size where [Ordinance No]=@Ordinance AND Series=@Series", con))
                        {
                            con.Open();
                            cmd.Parameters.AddWithValue("@Id", Id);
                            cmd.Parameters.AddWithValue("@Ordinance", SqlDbType.VarChar).Value = OrdinanceNo;
                            cmd.Parameters.AddWithValue("@Series", SqlDbType.VarChar).Value = series;
                            cmd.Parameters.AddWithValue("@Date", SqlDbType.VarChar).Value = date;
                            cmd.Parameters.AddWithValue("@Title", SqlDbType.VarChar).Value = title;
                            cmd.Parameters.AddWithValue("@Files", SqlDbType.VarBinary).Value = buffer;
                            cmd.Parameters.AddWithValue("@Size", SqlDbType.VarChar).Value = resultSize;
                            cmd.Parameters.AddWithValue("@Author", SqlDbType.VarChar).Value = author;
                            cmd.Parameters.AddWithValue("@Time", SqlDbType.VarChar).Value = time + " " + ampm;
                            cmd.Parameters.AddWithValue("@Tag", SqlDbType.VarChar).Value = tag;
                            cmd.Parameters.AddWithValue("@Reading", SqlDbType.VarChar).Value = reading;
                            cmd.ExecuteNonQuery();

                            con.Close();
                        }

                    }
                }
            });
        }

        //UPDATE ONLINE
        public static async Task UpdateOrdinanceOnline(
            string Id,
            string OrdinanceNo,
            string series,
            string date,
            string title,
            string author,
            string time,
            string ampm,
            string tag,
            string reading,
            string path)
        {
            await Task.Run(() =>
            {
                using (Stream stream = File.OpenRead(path))
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

                    string resultSize = String.Format("{0:0.##} {1}", len, sizes[order]);

                    using (MySqlConnection con = new MySqlConnection(Constants.connectionStringOnline))
                    {
                        using (MySqlCommand cmd = new MySqlCommand("Update Ordinance set OrdinanceNo=@Ordinance, Series=@Series, Date=@Date, Title=@Title, " +
                            "Author=@Author, Time=@Time , Tag=@Tag, Reading=@Reading, Files=@Files, Size=@Size where Id=@Id", con))
                        {
                            con.Open();
                            cmd.Parameters.Add(new MySqlParameter("@Id", Id));
                            cmd.Parameters.Add(new MySqlParameter("@Ordinance", OrdinanceNo));
                            cmd.Parameters.Add(new MySqlParameter("@Series", series));
                            cmd.Parameters.Add(new MySqlParameter("@Date", date));
                            cmd.Parameters.Add(new MySqlParameter("@Title", title));
                            cmd.Parameters.Add(new MySqlParameter("@Author", author));
                            cmd.Parameters.Add(new MySqlParameter("@Files", buffer));
                            cmd.Parameters.Add(new MySqlParameter("@Time", time + " " + ampm));
                            cmd.Parameters.Add(new MySqlParameter("@Type", Constants.ext));
                            cmd.Parameters.Add(new MySqlParameter("@Size", resultSize));
                            cmd.Parameters.Add(new MySqlParameter("@Tag", tag));
                            cmd.Parameters.Add(new MySqlParameter("@Reading", reading));
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }

                    }
                }
            });
        }

        //DELETE OFFLINE
        public static async Task DeleteOrdinance(
            string Id,
            string OrdinanceNo,
            string series
            )
        {
            await Task.Run(() =>
            {
                using (SqlConnection con = new SqlConnection(Constants.connectionStringOffline))
                {
                    SqlCommand cmd = new SqlCommand("delete from [Ordinance] where Series=@Series and [Ordinance No]=@OrdinanceNo", con);
                    cmd.Parameters.AddWithValue("@Series", series);
                    cmd.Parameters.AddWithValue("@OrdinanceNo", OrdinanceNo);
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

        //DELETE ONLINE
        public static async Task DeleteOrdinanceOnline(
            string Id
            )
        {
            await Task.Run(() =>
            {
                using (MySqlConnection con = new MySqlConnection(Constants.connectionStringOnline))
                {
                    MySqlCommand cmd = new MySqlCommand("Delete from Ordinance where Id = @Id", con);
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

        //PRINTABLE DATA OFFLINE
        public static async Task<DataTable> getPrintData()
        {
            DataTable dt = new DataTable();
            await Task.Run(() =>
            {
                using (SqlConnection con = new SqlConnection(Constants.connectionStringOffline))
                {

                    using (SqlCommand cmd = new SqlCommand("SELECT [Ordinance No], Series, Title, Author, Date, Time FROM Ordinance", con))
                    {
                        con.Open();
                        IAsyncResult result = cmd.BeginExecuteReader();

                        while (!result.IsCompleted)
                        {
                            System.Threading.Thread.Sleep(100);
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

        //PRINTABLE DATA ONLINE
        public static async Task<DataTable> getPrintDataOnline()
        {
            DataTable dt = new DataTable();
            await Task.Run(() =>
            {
                using (MySqlConnection con = new MySqlConnection(Constants.connectionStringOnline))
                {

                    using (MySqlCommand cmd = new MySqlCommand("SELECT OrdinanceNo, Series, Title, Author, Date, Time FROM Ordinance", con))
                    {
                        con.Open();
                        IAsyncResult result = cmd.BeginExecuteReader();

                        while (!result.IsCompleted)
                        {
                            System.Threading.Thread.Sleep(100);
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

        public static async Task OpenFile(String FileType, String Id)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            await Task.Run(() =>
            {
                if (FileType == ".docx")
                {
                    using (SqlConnection con = new SqlConnection(Constants.connectionStringOffline))
                    {

                        FileStream FS = null;
                        byte[] dbbyte;

                        using (SqlCommand cmd = new SqlCommand("SELECT Files FROM Resolution where Id ='" + int.Parse(Id) + "'", con))
                        {
                            con.Open();

                            da = new SqlDataAdapter(cmd);
                            dt = new DataTable();
                            da.Fill(dt);

                            dbbyte = (byte[])dt.Rows[0]["files"];

                            //store file Temporarily 
                            string filepath = "C:\\New folder\\1.docx";

                            //Assign File path create file
                            FS = new FileStream(filepath, System.IO.FileMode.Create);

                            //Write bytes to create file
                            FS.Write(dbbyte, 0, dbbyte.Length);

                            //Close FileStream instance
                            FS.Close();

                            // Open fila after write 

                            //Create instance for process class
                            Process Proc = new Process();

                            //assign file path for process
                            Proc.StartInfo.FileName = filepath;
                            Proc.Start();

                        }

                    }
                }
                if (FileType == ".pdf")
                {
                    using (SqlConnection con = new SqlConnection(Constants.connectionStringOffline))
                    {

                        FileStream FS = null;
                        byte[] dbbyte;

                        using (SqlCommand cmd = new SqlCommand("SELECT Files FROM Resolution where Id ='" + int.Parse(Id) + "'", con))
                        {
                            con.Open();
                            da = new SqlDataAdapter(cmd);
                            dt = new DataTable();
                            da.Fill(dt);

                            dbbyte = (byte[])dt.Rows[0]["files"];

                            //store file Temporarily 
                            string filepath = "C:\\New folder\\2.pdf";

                            //Assign File path create file
                            FS = new FileStream(filepath, System.IO.FileMode.Create);

                            //Write bytes to create file
                            FS.Write(dbbyte, 0, dbbyte.Length);

                            //Close FileStream instance
                            FS.Close();

                            // Open fila after write 

                            //Create instance for process class
                            Process Proc = new Process();

                            //assign file path for process
                            Proc.StartInfo.FileName = filepath;
                            Proc.Start();

                        }

                    }
                }
            });
        }

        public static async Task OpenFileOnline(String FileType, String Id)
        {
            MySqlDataAdapter da = new MySqlDataAdapter();
            DataTable dt = new DataTable();
            await Task.Run(() =>
            {
                if (FileType == ".docx")
                {
                    using (MySqlConnection con = new MySqlConnection(Constants.connectionStringOnline))
                    {

                        FileStream FS = null;
                        byte[] dbbyte;

                        using (MySqlCommand cmd = new MySqlCommand("SELECT Files FROM Ordinance where Id ='" + int.Parse(Id) + "'", con))
                        {
                            con.Open();

                            da = new MySqlDataAdapter(cmd);
                            dt = new DataTable();
                            da.Fill(dt);

                            dbbyte = (byte[])dt.Rows[0]["files"];

                            //store file Temporarily 
                            string filepath = "C:\\New folder\\1.docx";

                            //Assign File path create file
                            FS = new FileStream(filepath, System.IO.FileMode.Create);

                            //Write bytes to create file
                            FS.Write(dbbyte, 0, dbbyte.Length);

                            //Close FileStream instance
                            FS.Close();

                            // Open fila after write 

                            //Create instance for process class
                            Process Proc = new Process();

                            //assign file path for process
                            Proc.StartInfo.FileName = filepath;
                            Proc.Start();

                        }

                    }
                }
                if (FileType == ".pdf")
                {
                    using (MySqlConnection con = new MySqlConnection(Constants.connectionStringOnline))
                    {

                        FileStream FS = null;
                        byte[] dbbyte;

                        using (MySqlCommand cmd = new MySqlCommand("SELECT Files FROM Ordinance where Id ='" + int.Parse(Id) + "'", con))
                        {
                            con.Open();
                            da = new MySqlDataAdapter(cmd);
                            dt = new DataTable();
                            da.Fill(dt);

                            dbbyte = (byte[])dt.Rows[0]["Files"];

                            //store file Temporarily 
                            string filepath = "C:\\New folder\\2.pdf";

                            //Assign File path create file
                            FS = new FileStream(filepath, System.IO.FileMode.Create);

                            //Write bytes to create file
                            FS.Write(dbbyte, 0, dbbyte.Length);

                            //Close FileStream instance
                            FS.Close();

                            // Open fila after write 

                            //Create instance for process class
                            Process Proc = new Process();

                            //assign file path for process
                            Proc.StartInfo.FileName = filepath;
                            Proc.Start();

                        }

                    }
                }
            });
        }
    }
}
