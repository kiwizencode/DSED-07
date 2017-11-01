using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportMortalityReason
{
    public class Program
    {

        public static string ConnectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=IMSystem;Integrated Security=True";

        static void Main(string[] args)
        {
            string[] reasons = { "Filter issue", "Heating issue", "Unkown reason",
                                  "Beat up", "Tank leaking", "Stress of shipment",
                                  "Suspec Cyanide poisoning", "Ammoni/Nirate poisoning",
                                  "pH shock from shipping", "Bleeding/Progeny"};
            
            for (int i = 0; i < reasons.Length; i++)
            {
                Console.WriteLine(reasons[i]);
                updateTable(reasons[i]);
            }

            Console.ReadKey();
        }

        static private void updateTable(string selected_field)
        {
            /*
                CREATE TABLE [dbo].[MORTALITY] (
                    [ID_PK]   INT            IDENTITY (1, 1) NOT NULL,
                    [TEXT]    NVARCHAR (100) NULL,
                    PRIMARY KEY CLUSTERED ([ID_PK] ASC)
                );

             */
            SqlCommand command = new SqlCommand();
            //string selected_field = string.Empty;

            command.CommandText = "INSERT INTO [MORTALITY] ([TEXT]) VALUES(@FIELD_TEXT) ;";
            command.Parameters.AddWithValue("@FIELD_TEXT", selected_field);

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                command.Connection = connection;

                connection.Open();
                try
                {
                    int rowAffected = command.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    throw new Exception("ERROR : " + ex.Message);
                }
                finally
                {
                    if (connection.State == System.Data.ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }

            //Console.WriteLine("end of program");
            //Console.Read();
        }
    }
}
