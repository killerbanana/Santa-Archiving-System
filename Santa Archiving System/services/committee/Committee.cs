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

namespace Santa_Archiving_System.services.committee
{
    public class Committee
    {
        public static List<String> committeeMembers = new List<string>();
        public static List<String> terms = new List<string>();
        public static List<String> committeeList = new List<string>();
        private static string membersName;
        private static string committeName;


        public static async Task<DataTable> getCommitteeListOnline(string batch)

        {
            try
            {
                DataTable dt = new DataTable();
                await Task.Run(() =>
                {
                    using (MySqlConnection con = new MySqlConnection(Constants.connectionStringOnline))
                    {

                        using (MySqlCommand cmd = new MySqlCommand("SELECT Id, Title, Description, Chairman, ViceChairman, Members, Terms FROM Committee  WHERE Terms='" + batch + "'", con))
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

        public static async Task<DataTable> getCommitteeListOffline(string batch)
        {
            try
            {
                DataTable dt = new DataTable();
                await Task.Run(() =>
                {
                    using (SqlConnection con = new SqlConnection(Constants.connectionStringOffline))
                    {

                        using (SqlCommand cmd = new SqlCommand("SELECT Id, Title, Description, Chairman, ViceChairman, Members, Terms FROM Committee  WHERE Terms='" + batch + "'", con))
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

                        using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM Committee", con))
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

                        using (SqlCommand cmd = new SqlCommand("SELECT * FROM Committee", con))
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
        public static async Task getMembersOnline(string term)
        {
            try
            {
                committeeMembers.Clear();
                membersName = string.Empty;

                await Task.Run(() =>
                {
                    using (MySqlConnection con = new MySqlConnection(Constants.connectionStringOnline))
                    {

                        using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM Officials WHERE Terms='" + term + "'", con))
                        {
                            con.Open();

                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {

                                while (reader.Read())
                                {
                                   
                                    switch (reader[6].ToString())
                                    {
                                        case "Vice Mayor":
                                            membersName = "VM" + " " + reader[5].ToString() + " " + reader[1].ToString() + " " + reader[2].ToString() + " " + reader[3].ToString() + " " + reader[4].ToString();
                                            break;
                                        case "SBM":
                                            membersName = reader[6].ToString() + " " + reader[5].ToString() + " " + reader[1].ToString() + " " + reader[2].ToString() + " " + reader[3].ToString() + " " + reader[4].ToString();
                                            break;
                                        case "ABC Pres":
                                            membersName = reader[6].ToString() + " " + reader[5].ToString() + " " + reader[1].ToString() + " " + reader[2].ToString() + " " + reader[3].ToString() + " " + reader[4].ToString();
                                            break;
                                        case "PPSK Pres":
                                            membersName = reader[6].ToString() + " " + reader[5].ToString() + " " + reader[1].ToString() + " " + reader[2].ToString() + " " + reader[3].ToString() + " " + reader[4].ToString();
                                            break;
                                    }
                                   
                                    committeeMembers.Add(membersName);
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

        public static async Task getMembersOffline(string term)
        {
            try
            {
                committeeMembers.Clear();
                membersName = string.Empty;

                await Task.Run(() =>
                {
                    using (SqlConnection con = new SqlConnection(Constants.connectionStringOffline))
                    {

                        using (SqlCommand cmd = new SqlCommand("SELECT * FROM Officials WHERE Terms='" + term + "'", con))
                        {
                            con.Open();

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {

                                while (reader.Read())
                                {
                                    switch (reader[6].ToString())
                                    {
                                        case "Vice Mayor":
                                            membersName = "VM" + " " + reader[5].ToString() + " " + reader[1].ToString() + " " + reader[2].ToString() + " " + reader[3].ToString() + " " + reader[4].ToString();
                                            break;
                                        case "SBM":
                                            membersName = reader[6].ToString() + " " + reader[5].ToString() + " " + reader[1].ToString() + " " + reader[2].ToString() + " " + reader[3].ToString() + " " + reader[4].ToString();
                                            break;
                                        case "ABC Pres":
                                            membersName = reader[6].ToString() + " " + reader[5].ToString() + " " + reader[1].ToString() + " " + reader[2].ToString() + " " + reader[3].ToString() + " " + reader[4].ToString();
                                            break;
                                        case "PPSK Pres":
                                            membersName = reader[6].ToString() + " " + reader[5].ToString() + " " + reader[1].ToString() + " " + reader[2].ToString() + " " + reader[3].ToString() + " " + reader[4].ToString();
                                            break;
                                    }

                                    committeeMembers.Add(membersName);
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

        public static async Task SaveMembersOffline
      (
      string title,
      string description,
      string chairman,
      string viceChairman,
      List<String> members,
      string terms

      )
        {
            try
            {

                String query = "INSERT INTO Committee(Title, Description, Chairman, ViceChairman, Members, Terms) VALUES(@Title,@Description, @Chairman, @ViceChairman, @Members, @Terms)";

                using (SqlConnection con = new SqlConnection(Constants.connectionStringOffline))
                {
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@Title", SqlDbType.VarChar).Value = title;
                    cmd.Parameters.AddWithValue("@Description", SqlDbType.VarChar).Value = description;
                    cmd.Parameters.AddWithValue("@Chairman", SqlDbType.VarChar).Value = chairman;
                    cmd.Parameters.AddWithValue("@ViceChairman", SqlDbType.VarChar).Value = viceChairman;
                    cmd.Parameters.AddWithValue("@Members", SqlDbType.VarChar).Value = string.Join(",", members);
                    cmd.Parameters.AddWithValue("@Terms", SqlDbType.VarChar).Value = terms;

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


        public static async Task SaveMembersOnline
            (
             string title,
             string description,
             string chairman,
             string viceChairman,
             List<String> members,
             string terms
            )
        {
            try
            {

                String query = "INSERT INTO Committee(Title, Description, Chairman, ViceChairman, Members, Terms) VALUES(@Title,@Description, @Chairman, @ViceChairman, @Members, @Terms)";


                using (MySqlConnection con = new MySqlConnection(Constants.connectionStringOnline))
                {
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.Add(new MySqlParameter("@Title", title));
                    cmd.Parameters.Add(new MySqlParameter("@Description", description));
                    cmd.Parameters.Add(new MySqlParameter("@Chairman", chairman));
                    cmd.Parameters.Add(new MySqlParameter("@ViceChairman", viceChairman));
                    cmd.Parameters.Add(new MySqlParameter("@Members", string.Join(",", members)));
                    cmd.Parameters.Add(new MySqlParameter("@Terms", terms));

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

        public static async Task UpdateMembersOnline
           (
            string title,
            string description,
            string chairman,
            string viceChairman,
            List<String> members,
            string terms,
            string Id
           )
        {
            try
            {
                await Task.Run(() =>
                {

                    using (MySqlConnection con = new MySqlConnection(Constants.connectionStringOnline))
                    {
                        using (MySqlCommand cmd = new MySqlCommand("Update Committee set Title=@Title, Description=@Description, Chairman=@Chairman, ViceChairman=@ViceChairman, Members=@Members, Terms=@Terms where Id=@Id and Title=@Title", con))
                        {
                            con.Open();
                            cmd.Parameters.Add(new MySqlParameter("@Title", title));
                            cmd.Parameters.Add(new MySqlParameter("@Description", description));
                            cmd.Parameters.Add(new MySqlParameter("@Chairman", chairman));
                            cmd.Parameters.Add(new MySqlParameter("@ViceChairman", viceChairman));
                            cmd.Parameters.Add(new MySqlParameter("@Members", string.Join(",", members)));
                            cmd.Parameters.Add(new MySqlParameter("@Terms", terms));
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

        public static async Task UpdateMembersOffline
       (
        string title,
        string description,
        string chairman,
        string viceChairman,
        List<String> members,
        string terms,
        string Id
       )
        {
            try
            {
                await Task.Run(() =>
                {

                    using (SqlConnection con = new SqlConnection(Constants.connectionStringOffline))
                    {
                        using (SqlCommand cmd = new SqlCommand("Update Committee set Title=@Title, Description=@Description, Chairman=@Chairman, ViceChairman=@ViceChairman, Members=@Members, Terms=@Terms where Id=@Id and Title=@Title", con))
                        {
                            con.Open();
                            cmd.Parameters.AddWithValue("@Title", SqlDbType.VarChar).Value = title;
                            cmd.Parameters.AddWithValue("@Description", SqlDbType.VarChar).Value = description;
                            cmd.Parameters.AddWithValue("@Chairman", SqlDbType.VarChar).Value = chairman;
                            cmd.Parameters.AddWithValue("@ViceChairman", SqlDbType.VarChar).Value = viceChairman;
                            cmd.Parameters.AddWithValue("@Members", SqlDbType.VarChar).Value = string.Join(",", members);
                            cmd.Parameters.AddWithValue("@Terms", SqlDbType.VarChar).Value = terms;
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


        //export
        public static async Task ExportData()
        {
            try
            {
                await Task.Run(() =>
                {
                    using (SqlConnection con = new SqlConnection(Constants.connectionStringOffline))
                    {
                        using (SqlCommand cmd = new SqlCommand("SELECT * FROM Committee", con))
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
                                            using (MySqlCommand command = new MySqlCommand("SELECT * FROM Committee where Title ='" + reader[1].ToString() + "'AND Terms ='" + reader[6].ToString() + "'", connect))
                                            {
                                                connect.Open();

                                                using (MySqlDataReader reader1 = command.ExecuteReader())
                                                {

                                                    if (reader1.HasRows)
                                                    {

                                                        String query1 = "Update Committee set Description = @Description, " +
                                                        "Chairman = @Chairman, " +
                                                        "ViceChairman = @ViceChairman," +
                                                        "Members = @Members where Title ='" + reader[1].ToString() + "'AND Terms ='" + reader[6].ToString() + "'";


                                                        using (MySqlConnection connection3 = new MySqlConnection(Constants.connectionStringOnline))
                                                        {
                                                            MySqlCommand command3 = new MySqlCommand(query1, connection3);
                                                            command3.Parameters.Add(new MySqlParameter("@Title", reader[1].ToString()));
                                                            command3.Parameters.Add(new MySqlParameter("@Description", reader[2].ToString()));
                                                            command3.Parameters.Add(new MySqlParameter("@Chairman", reader[3].ToString()));
                                                            command3.Parameters.Add(new MySqlParameter("@ViceChairman", reader[4].ToString()));
                                                            command3.Parameters.Add(new MySqlParameter("@Members", reader[5].ToString()));
                                                            command3.Parameters.Add(new MySqlParameter("@Terms", reader[6].ToString()));


                                                            connection3.Open();

                                                            command3.ExecuteNonQuery();
                                                            connection3.Close();
                                                        }
                                                    }
                                                    else
                                                    {

                                                        String query1 = "INSERT INTO Committee(Title, Description, Chairman, ViceChairman, Members , Terms) VALUES(@Title,@Description, @Chairman, @ViceChairman, @Members, @Terms)";
                                                        using (MySqlConnection connection3 = new MySqlConnection(Constants.connectionStringOnline))
                                                        {
                                                            MySqlCommand command3 = new MySqlCommand(query1, connection3);
                                                            command3.Parameters.Add(new MySqlParameter("@Title", reader[1].ToString()));
                                                            command3.Parameters.Add(new MySqlParameter("@Description", reader[2].ToString()));
                                                            command3.Parameters.Add(new MySqlParameter("@Chairman", reader[3].ToString()));
                                                            command3.Parameters.Add(new MySqlParameter("@ViceChairman", reader[4].ToString()));
                                                            command3.Parameters.Add(new MySqlParameter("@Members", reader[5].ToString()));
                                                            command3.Parameters.Add(new MySqlParameter("@Terms", reader[6].ToString()));

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

        public static async Task ImportCommittee()
        {
            try
            {
                await Task.Run(() =>
                {
                    using (MySqlConnection con = new MySqlConnection(Constants.connectionStringOnline))
                    {
                        using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM Committee", con))
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
                                            using (SqlCommand command = new SqlCommand("SELECT * FROM Committee where Title ='" + reader[1].ToString() + "'AND Terms ='" + reader[6].ToString() + "'", connect))
                                            {
                                                connect.Open();

                                                using (SqlDataReader reader1 = command.ExecuteReader())
                                                {
                                                    if (reader1.HasRows)
                                                    {
                                                    }
                                                    else
                                                    {

                                                        String query1 = "INSERT INTO Committee(Title, Description, Chairman, ViceChairman, Members , Terms) VALUES(@Title,@Description, @Chairman, @ViceChairman, @Members, @Terms)";
                                                        using (SqlConnection connection3 = new SqlConnection(Constants.connectionStringOffline))
                                                        {
                                                            SqlCommand command3 = new SqlCommand(query1, connection3);
                                                            command3.Parameters.AddWithValue("@Title", SqlDbType.VarChar).Value = reader[1].ToString();
                                                            command3.Parameters.AddWithValue("@Description", SqlDbType.VarChar).Value = reader[2].ToString();
                                                            command3.Parameters.AddWithValue("@Chairman", SqlDbType.VarChar).Value = reader[3].ToString();
                                                            command3.Parameters.AddWithValue("@ViceChairman", SqlDbType.VarChar).Value = reader[4].ToString();
                                                            command3.Parameters.AddWithValue("@Members", SqlDbType.VarChar).Value = reader[5].ToString();
                                                            command3.Parameters.AddWithValue("@Terms", SqlDbType.VarChar).Value = reader[6].ToString();
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

        //delete
        public static async Task DeleteCommitteeOnline(string title, string Id)
        {
            try
            {
                await Task.Run(() =>
                {
                    using (MySqlConnection con = new MySqlConnection(Constants.connectionStringOnline))
                    {
                        MySqlCommand cmd = new MySqlCommand("Delete from Committee where Title=@Title and Id=@Id", con);
                        cmd.Parameters.Add(new MySqlParameter("@Title", title));
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

        public static async Task DeleteCommitteeOffline(string title, string Id)
        {
            try
            {
                await Task.Run(() =>
                {
                    using (SqlConnection con = new SqlConnection(Constants.connectionStringOffline))
                    {
                        SqlCommand cmd = new SqlCommand("Delete from Committee where Title=@Title and Id=@Id", con);
                        cmd.Parameters.AddWithValue("@Title", SqlDbType.VarChar).Value = title;
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


        //listCommitee
        public static async Task getCommitteeOnline(string term)
        {
            committeeList.Clear();
            try
            {
                committeeMembers.Clear();
                committeName = string.Empty;

                await Task.Run(() =>
                {
                    using (MySqlConnection con = new MySqlConnection(Constants.connectionStringOnline))
                    {

                        using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM Committee WHERE Terms='" + term + "'", con))
                        {
                            con.Open();

                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {

                                while (reader.Read())
                                {
                                    committeName = reader[1].ToString();
                                    committeeList.Add(committeName);
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

        public static async Task getCommitteeOffline(string term)
        {
            committeeList.Clear();
            try
            {
                committeeMembers.Clear();
                committeName = string.Empty;

                await Task.Run(() =>
                {
                    using (SqlConnection con = new SqlConnection(Constants.connectionStringOnline))
                    {

                        using (SqlCommand cmd = new SqlCommand("SELECT * FROM Committee WHERE Terms='" + term + "'", con))
                        {
                            con.Open();

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {

                                while (reader.Read())
                                {
                                    committeName = reader[1].ToString();
                                    committeeList.Add(committeName);
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
