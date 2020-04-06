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
        public static List<WorkshiftUC> GetEmployees(DateTime date)
        {
            List<WorkshiftUC> items = new List<WorkshiftUC>();
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
                            int index = items.FindIndex(item => item.Employee.UserID == dataReader.GetString(0));
                            if(index == -1)
                            {
                                WorkshiftUC newUnit = new WorkshiftUC(new Employee(dataReader.GetString(0)));
                                newUnit.SetStatus(dataReader.GetInt16(2), dataReader.GetInt16(1));
                                items.Add(newUnit);
                            }
                            else items[index].SetStatus(dataReader.GetInt16(2), dataReader.GetInt16(1));
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
