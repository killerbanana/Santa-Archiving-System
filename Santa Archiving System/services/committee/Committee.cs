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
    class Committee
    {
        public static List<String> committeeMembers = new List<string>();
        public static List<String> terms = new List<string>();
        private static string membersName;


        public static async Task<DataTable> getCommitteeListOnline(string batch)
        {
            try
            {
                DataTable dt = new DataTable();
                await Task.Run(() =>
                {
                    using (MySqlConnection con = new MySqlConnection(Constants.connectionStringOnline))
                    {

                        using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM Committee  WHERE Terms='" + batch + "'", con))
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

                        using (SqlCommand cmd = new SqlCommand("SELECT * FROM Committee  WHERE Terms='" + batch + "'", con))
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
                                    membersName = reader[6].ToString() + " " + reader[5].ToString() + " " + reader[1].ToString() + " " + reader[2].ToString() + " " + reader[3].ToString() + " " + reader[4].ToString();
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

                        using (SqlCommand cmd = new SqlCommand("SELECT * FROM Officials WHERE Term='" + term + "'", con))
                        {
                            con.Open();

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {

                                while (reader.Read())
                                {
                                    membersName = reader[6].ToString() + " " + reader[5].ToString() + " " + reader[1].ToString() + " " + reader[2].ToString() + " " + reader[3].ToString() + " " + reader[4].ToString();
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
                        using (MySqlCommand cmd = new MySqlCommand("Update Committee set Title=@Title, Description=@Description, Chairman=@Chairman, ViceChairman=@ViceChairman, Members=@Members, Terms=@Terms where Id=@Id", con))
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
                        using (SqlCommand cmd = new SqlCommand("Update Committee set Title=@Title, Description=@Description, Chairman=@Chairman, ViceChairman=@ViceChairman, Members=@Members, Terms=@Terms where Id=@Id", con))
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

    }
}
