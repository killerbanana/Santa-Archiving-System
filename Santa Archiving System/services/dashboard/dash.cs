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

                        using (MySqlCommand cmd = new MySqlCommand("SELECT Title, Agenda, Date, Time, Venue FROM Activities", con))
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
    }
}
