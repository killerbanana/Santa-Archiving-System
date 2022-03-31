using MySql.Data.MySqlClient;
using Santa_Archiving_System.common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Santa_Archiving_System.services.dashboard
{
    public class dash
    {

        public static async Task<DataTable> getActivities()

        {
            try
            {
                DataTable dt = new DataTable();
                await Task.Run(() =>
                {
                    using (MySqlConnection con = new MySqlConnection(Constants.connectionStringOnline))
                    {

                        using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM Activities", con))
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
        //delete
        public static async Task DeleteActivities(string title, string agenda)
        {
            try
            {
                await Task.Run(() =>
                {
                    using (MySqlConnection con = new MySqlConnection(Constants.connectionStringOnline))
                    {
                        MySqlCommand cmd = new MySqlCommand("Delete from Activities where Title = @Title and Agenda = @Agenda", con);
                        cmd.Parameters.Add(new MySqlParameter("@Title", title));
                        cmd.Parameters.Add(new MySqlParameter("@Agenda", agenda));
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
        //insertActivities
        public static async Task SaveActivities
   (
   string title,
   string agenda,
   string date,
   string time,
    string venue
   )
        {
            try
            {

                String query = "INSERT INTO Activities(Title, Agenda, Date, Time, Venue) VALUES(@Title,@Agenda, @Date, @Time, @Venue)";

                using (MySqlConnection con = new MySqlConnection(Constants.connectionStringOnline))
                {
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.Add(new MySqlParameter("@Title", title));
                    cmd.Parameters.Add(new MySqlParameter("@Agenda", agenda));
                    cmd.Parameters.Add(new MySqlParameter("@Date", date));
                    cmd.Parameters.Add(new MySqlParameter("@Time", time));
                    cmd.Parameters.Add(new MySqlParameter("@Venue", venue));
             


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
    }
}
