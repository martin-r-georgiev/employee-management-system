using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Sem2IntroProjectWaterfall0._1
{
    public abstract class WorkshiftDatabaseHandler
    {
        public static List<WorkshiftUnit> GetEmployees(DateTime date)
        {
            List<WorkshiftUnit> items = new List<WorkshiftUnit>();
            using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
            {
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand($"SELECT userID, workshift, status FROM workshifts WHERE date=@date", conn))
                    {
                        cmd.Parameters.AddWithValue("@date", date.Date);
                        MySqlDataReader dataReader = cmd.ExecuteReader();
                        while (dataReader.Read())
                        {
                            items.Add(new WorkshiftUnit(new Employee(dataReader.GetString(0)), dataReader.GetInt16(1), dataReader.GetInt16(2)));
                        }
                        dataReader.Dispose();
                        cmd.Dispose();
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    LoginScreen.logger.Log($"[WorkshiftDatabaseHandler] The application encountered an issue when trying to get data from database:\n{ex.Message}", LoggingLevels.ERROR);
                    conn.Close();
                }     
            }
            return items;
        }
    }
}
