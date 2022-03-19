using MySql.Data.MySqlClient;
using Santa_Archiving_System.common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Santa_Archiving_System.services.tricycle
{
    class Tricycles
    {
        public static async Task<DataTable> GetTricycleData()
        {

            DataTable dt = new DataTable();
            await Task.Run(() =>
            {
                using (SqlConnection con = new SqlConnection(Constants.connectionStringOffline))
                {

                    using (SqlCommand cmd = new SqlCommand("SELECT ID, Name, Barangay, [Civil Status], Reason, Make, [Motor No], [Chassis No], [Plate No], [No of units], [Franchise No], [Tax certificate No], [OR No], [Date of Franchise], Status FROM [Tricycle Franchise]", con))
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
                            dt.Load(reader);
                        }

                    }

                }
            });
                
            return dt;
        }

        public static async Task<DataTable> GetTricycleDataOnline()
        {

            DataTable dt = new DataTable();
            await Task.Run(() =>
            {
                using (MySqlConnection con = new MySqlConnection(Constants.connectionStringOnline))
                {

                    using (MySqlCommand cmd = new MySqlCommand("SELECT ID, Name, Barangay, CivilStatus, Reason, Make, MotorNo, ChassisNo, PlateNo, Noofunits, FranchiseNo, TaxcertificateNo, ORNo, DateofFranchise, Status FROM TricycleFranchise", con))
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

                        using (MySqlDataReader reader = cmd.EndExecuteReader(result))
                        {
                            dt.Load(reader);
                        }

                    }

                }
            });

            return dt;
        }

        public static async Task ImportTricyData()
        {
            try
            {
                await Task.Run(() =>
                {
                    using (MySqlConnection con = new MySqlConnection(Constants.connectionStringOnline))
                    {
                        using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM TricycleFranchise", con))
                        {
                            con.Open();

                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    while (reader.Read())
                                    {
                                        using (SqlConnection connect = new SqlConnection(Constants.connectionStringOffline))
                                        {
                                            using (SqlCommand command = new SqlCommand("SELECT * FROM [Tricycle Franchise] where [Id] ='" + reader[0].ToString() + "'AND [Motor No] ='" + reader[6].ToString() + "'", connect))
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
                                                        dbbyte = (byte[])reader["File2"];

                                                        String query1 = "INSERT INTO [Tricycle Franchise](" +
                                                        "[Name] , " +
                                                        "Barangay, " +
                                                        "[Civil Status], " +
                                                        "Reason," +
                                                        " Make , " +
                                                        "[Motor No], " +
                                                        "[File2], " +
                                                        "[Chassis No], " +
                                                        "[Plate No], " +
                                                        "[No of units], " +
                                                        "[Franchise No]," +
                                                        "[Tax Certificate No] ," +
                                                        "[OR No] ," +
                                                        "[Date of Franchise]," +
                                                        "[Year]," +
                                                        "Status) VALUES(@Name,@Barangay, @CStatus, @Reason, @Make, @Motor, @File2, @Chassis, @Plate, @Units, @Franchise, @TaxCert,@OR, @Date, @Year, @Status )";


                                                        using (SqlConnection connection3 = new SqlConnection(Constants.connectionStringOffline))
                                                        {
                                                            SqlCommand command3 = new SqlCommand(query1, connection3);
                                                            command3.Parameters.AddWithValue("@Name", SqlDbType.VarChar).Value = reader[1].ToString();
                                                            command3.Parameters.AddWithValue("@Barangay", SqlDbType.VarChar).Value = reader[2].ToString();
                                                            command3.Parameters.AddWithValue("@CStatus", SqlDbType.VarChar).Value = reader[3].ToString();
                                                            command3.Parameters.AddWithValue("@Reason", SqlDbType.VarChar).Value = reader[4].ToString();
                                                            command3.Parameters.AddWithValue("@Make", SqlDbType.VarChar).Value = reader[5].ToString();
                                                            command3.Parameters.AddWithValue("@Motor", SqlDbType.VarBinary).Value = reader[6].ToString();
                                                            command3.Parameters.AddWithValue("@File2", SqlDbType.VarChar).Value = dbbyte;
                                                            command3.Parameters.AddWithValue("@Chassis", SqlDbType.VarChar).Value = reader[8].ToString();
                                                            command3.Parameters.AddWithValue("@Plate", SqlDbType.VarChar).Value = reader[9].ToString();
                                                            command3.Parameters.AddWithValue("@Units", SqlDbType.VarChar).Value = reader[10].ToString();
                                                            command3.Parameters.AddWithValue("@Franchise", SqlDbType.VarChar).Value = reader[11].ToString();
                                                            command3.Parameters.AddWithValue("@TaxCert", SqlDbType.VarChar).Value = reader[12].ToString();
                                                            command3.Parameters.AddWithValue("@OR", SqlDbType.VarChar).Value = reader[13].ToString();
                                                            command3.Parameters.AddWithValue("@Date", SqlDbType.VarChar).Value = reader[14].ToString();
                                                            command3.Parameters.AddWithValue("@Year", SqlDbType.VarChar).Value = reader[15].ToString();
                                                            command3.Parameters.AddWithValue("@Status", SqlDbType.VarChar).Value = reader[16].ToString();

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

        public static async Task ExportTricyData()
        {
            try
            {
                await Task.Run(() =>
                {
                    using (SqlConnection con = new SqlConnection(Constants.connectionStringOffline))
                    {
                        using (SqlCommand cmd = new SqlCommand("SELECT * FROM [Tricycle Franchise]", con))
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
                                            using (MySqlCommand command = new MySqlCommand("SELECT * FROM TricycleFranchise where FranchiseNo ='" + reader[11].ToString() + "'AND MotorNo ='" + reader[6].ToString() + "'AND Year ='" + reader[15].ToString() + "'", connect))
                                            {
                                                connect.Open();

                                                using (MySqlDataReader reader1 = command.ExecuteReader())
                                                {

                                                    if (reader1.HasRows)
                                                    {
                                                        byte[] dbbyte;
                                                        dbbyte = (byte[])reader["File2"];

                                                        String query1 = "Update TricycleFranchise set " +
                                                        "Name = @Name," +
                                                        "Barangay= @Barangay, " +
                                                        "CivilStatus = @CStatus, " +
                                                        "Reason = @Reason, " +
                                                        "Make = @Make, " +
                                                        "MotorNo = @Motor, " +
                                                        "File2 = @File2, " +
                                                        "ChassisNo = @Chassis, " +
                                                        "PlateNo = @Plate , " +
                                                        "Noofunits = @Units, " +
                                                        "FranchiseNo = @Franchise , " +
                                                        "TaxCertificateNo = @TaxCert , " +
                                                        "ORNo = @OR, " +
                                                        "DateofFranchise = @Date , " +
                                                        "Year = @Year," +
                                                        "Status = @Status where " +
                                                        "Id ='" + reader[0].ToString() + "'AND Name ='" + reader[1].ToString() + "'";
                                                        using (MySqlConnection connection3 = new MySqlConnection(Constants.connectionStringOnline))
                                                        {
                                                            MySqlCommand command3 = new MySqlCommand(query1, connection3);
                                                            command3.Parameters.Add(new MySqlParameter("@Name", reader[1].ToString()));
                                                            command3.Parameters.Add(new MySqlParameter("@Barangay", reader[2].ToString()));
                                                            command3.Parameters.Add(new MySqlParameter("@CStatus", reader[3].ToString()));
                                                            command3.Parameters.Add(new MySqlParameter("@Reason", reader[4].ToString()));
                                                            command3.Parameters.Add(new MySqlParameter("@Make", reader[5].ToString()));
                                                            command3.Parameters.Add(new MySqlParameter("@Motor", reader[6].ToString()));
                                                            command3.Parameters.Add(new MySqlParameter("@File2", dbbyte));
                                                            command3.Parameters.Add(new MySqlParameter("@Chassis", reader[8].ToString()));
                                                            command3.Parameters.Add(new MySqlParameter("@Plate", reader[9].ToString()));
                                                            command3.Parameters.Add(new MySqlParameter("@Units", reader[10].ToString()));
                                                            command3.Parameters.Add(new MySqlParameter("@Franchise", reader[11].ToString()));
                                                            command3.Parameters.Add(new MySqlParameter("@TaxCert", reader[12].ToString()));
                                                            command3.Parameters.Add(new MySqlParameter("@OR", reader[13].ToString()));
                                                            command3.Parameters.Add(new MySqlParameter("@Date", reader[14].ToString()));
                                                            command3.Parameters.Add(new MySqlParameter("@Year", reader[15].ToString()));
                                                            command3.Parameters.Add(new MySqlParameter("@Status", reader[16].ToString()));

                                                            connection3.Open();

                                                            command3.ExecuteNonQuery();
                                                            connection3.Close();
                                                        }
                                                    }
                                                    else
                                                    {
                                                        byte[] dbbyte;
                                                        dbbyte = (byte[])reader["File2"];

                                                        String query1 = "INSERT INTO TricycleFranchise(" +
                                                        "Name , " +
                                                        "Barangay, " +
                                                        "CivilStatus, " +
                                                        "Reason," +
                                                        "Make , " +
                                                        "MotorNo, " +
                                                        "File2, " +
                                                        "ChassisNo, " +
                                                        "PlateNo, " +
                                                        "Noofunits, " +
                                                        "FranchiseNo," +
                                                        "TaxCertificateNo," +
                                                        "ORNo ," +
                                                        "DateofFranchise," +
                                                        "Year," +
                                                        "Status) VALUES(@Name,@Barangay, @CStatus, @Reason, @Make, @Motor, @File2, @Chassis, @Plate, @Units, @Franchise, @TaxCert,@OR, @Date, @Year, @Status )";


                                                        using (MySqlConnection connection3 = new MySqlConnection(Constants.connectionStringOnline))
                                                        {
                                                            MySqlCommand command3 = new MySqlCommand(query1, connection3);
                                                            command3.Parameters.Add(new MySqlParameter("@Name", reader[1].ToString()));
                                                            command3.Parameters.Add(new MySqlParameter("@Barangay", reader[2].ToString()));
                                                            command3.Parameters.Add(new MySqlParameter("@CStatus", reader[3].ToString()));
                                                            command3.Parameters.Add(new MySqlParameter("@Reason", reader[4].ToString()));
                                                            command3.Parameters.Add(new MySqlParameter("@Make", reader[5].ToString()));
                                                            command3.Parameters.Add(new MySqlParameter("@Motor", reader[6].ToString()));
                                                            command3.Parameters.Add(new MySqlParameter("@File2", dbbyte));
                                                            command3.Parameters.Add(new MySqlParameter("@Chassis", reader[8].ToString()));
                                                            command3.Parameters.Add(new MySqlParameter("@Plate", reader[9].ToString()));
                                                            command3.Parameters.Add(new MySqlParameter("@Units", reader[10].ToString()));
                                                            command3.Parameters.Add(new MySqlParameter("@Franchise", reader[11].ToString()));
                                                            command3.Parameters.Add(new MySqlParameter("@TaxCert", reader[12].ToString()));
                                                            command3.Parameters.Add(new MySqlParameter("@OR", reader[13].ToString()));
                                                            command3.Parameters.Add(new MySqlParameter("@Date", reader[14].ToString()));
                                                            command3.Parameters.Add(new MySqlParameter("@Year", reader[15].ToString()));
                                                            command3.Parameters.Add(new MySqlParameter("@Status", reader[16].ToString()));
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
