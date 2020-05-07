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
        public static List<WorkshiftUC> GetEmployees(DateTime date, string departmentID)
        {
            List<WorkshiftUC> items = new List<WorkshiftUC>();
            using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
            {
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand($"SELECT w.userID, w.workshift, w.status FROM workshifts as w INNER JOIN users as u ON w.userID = u.userID WHERE date=@date AND u.departmentID = @department", conn))
                    {
                        cmd.Parameters.AddWithValue("@date", date.Date);
                        cmd.Parameters.AddWithValue("@department", departmentID);
                        MySqlDataReader dataReader = cmd.ExecuteReader();
                        while (dataReader.Read())
                        {
                            int index = items.FindIndex(item => item.Employee.UserID == dataReader.GetString(0));
                            if(index == -1)
                            {
                                bool addEmployee = true;
                                Employee newEmployee = new Employee(dataReader.GetString(0), false);
                                switch (newEmployee.Role)
                                {
                                    case Role.Worker: if (!WorkshiftFilters.ShowWorkers) addEmployee = false; break;
                                    case Role.Manager: if (!WorkshiftFilters.ShowManagers) addEmployee = false; break;
                                    case Role.Admin: if (!WorkshiftFilters.ShowAdmins) addEmployee = false; break;
                                }

                                if(addEmployee)
                                {
                                    WorkshiftUC newUnit = new WorkshiftUC(newEmployee, date);
                                    newUnit.SetStatus(dataReader.GetInt16(2), dataReader.GetInt16(1));
                                    items.Add(newUnit);
                                }
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

        public static List<WorkshiftWeeklyUC> GetWeeklyEmployees(DateTime date, string departmentID)
        {
            List<WorkshiftWeeklyUC> items = new List<WorkshiftWeeklyUC>();
            using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
            {
                try
                {
                    DateTime startDate = DateTimeControls.StartOfWeek(date, DayOfWeek.Monday);
                    DateTime endDate = startDate.AddDays(6);
                    using (MySqlCommand cmd = new MySqlCommand($"SELECT w.userID, w.workshift, w.status, w.date FROM workshifts as w INNER JOIN users as u ON w.userID = u.userID WHERE w.date >= @start AND w.date <= @end AND u.departmentID = @department", conn))
                    {
                        cmd.Parameters.AddWithValue("@start", startDate);
                        cmd.Parameters.AddWithValue("@end", endDate);
                        cmd.Parameters.AddWithValue("@department", departmentID);
                        MySqlDataReader dataReader = cmd.ExecuteReader();
                        while (dataReader.Read())
                        {
                            int index = items.FindIndex(item => item.Employee.UserID == dataReader.GetString(0));
                            if (index == -1)
                            {
                                bool addEmployee = true;
                                Employee newEmployee = new Employee(dataReader.GetString(0), false);
                                switch(newEmployee.Role)
                                {
                                    case Role.Worker: if (!WorkshiftFilters.ShowWorkers) addEmployee = false; break;
                                    case Role.Manager: if (!WorkshiftFilters.ShowManagers) addEmployee = false; break;
                                    case Role.Admin: if (!WorkshiftFilters.ShowAdmins) addEmployee = false; break;
                                }

                                if (addEmployee)
                                {
                                    WorkshiftWeeklyUC newUnit = new WorkshiftWeeklyUC(newEmployee, startDate, endDate);
                                    newUnit.SetStatus(dataReader.GetDateTime(3).DayOfWeek, dataReader.GetInt16(2), dataReader.GetInt16(1));
                                    items.Add(newUnit);
                                }
                            }
                            else items[index].SetStatus(dataReader.GetDateTime(3).DayOfWeek, dataReader.GetInt16(2), dataReader.GetInt16(1));
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
