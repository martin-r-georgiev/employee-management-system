using MediaBazaarApplicationWPF.UserControls;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApplicationWPF
{
    public abstract class WorkshiftDatabaseHandler
    {
        public static void CheckMissedWorkshifts(DateTime date, string departmentID)
        {
            using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
            {
                try
                {
                    List<int> missedWorkshiftIds = new List<int>();
                    DateTime startDate = DateTimeControls.StartOfWeek(date, DayOfWeek.Monday);
                    DateTime endDate = (startDate.AddDays(6) <= DateTime.Today) ? startDate.AddDays(6) : DateTime.Today;

                    List<string> checkinUsers = new List<string>();
                    List<DateTime> checkinsList = new List<DateTime>();
                    List<DateTime> checkoutsList = new List<DateTime>();

                    using (MySqlCommand cmd = new MySqlCommand($"SELECT DISTINCT c.userID, MIN(c.checkin), MAX(c.checkout) FROM checkins as c INNER JOIN users as u ON c.userID=u.userID WHERE c.checkin >= @start AND c.checkout <= @end AND u.departmentID = @department GROUP BY c.userID, CAST(c.checkin as DATE)", conn))
                    {
                        cmd.Parameters.AddWithValue("@start", startDate);
                        cmd.Parameters.AddWithValue("@end", endDate);
                        cmd.Parameters.AddWithValue("@department", departmentID);
                        MySqlDataReader dataReader = cmd.ExecuteReader();
                        while (dataReader.Read())
                        {
                            DateTime checkOut = (!dataReader.IsDBNull(2)) ? dataReader.GetDateTime(2) : dataReader.GetDateTime(1).Date.AddDays(1).AddSeconds(-1);
                            checkinUsers.Add(dataReader.GetString(0));
                            checkinsList.Add(dataReader.GetDateTime(1));
                            checkoutsList.Add(checkOut);
                        }
                        dataReader.Dispose();
                        cmd.Dispose();
                    }

                    using (MySqlCommand cmd = new MySqlCommand($"SELECT w.userID, w.date, MIN(w.workshift), MAX(w.workshift), GROUP_CONCAT(w.id ORDER BY w.workshift) FROM workshifts as w INNER JOIN users as u ON w.userID=u.userID WHERE w.date >= @start AND w.date < @end AND u.departmentID = @department GROUP BY w.userID, w.date", conn))
                    {
                        cmd.Parameters.AddWithValue("@start", startDate);
                        cmd.Parameters.AddWithValue("@end", endDate);
                        cmd.Parameters.AddWithValue("@department", departmentID);

                        MySqlDataReader dataReader = cmd.ExecuteReader();
                        while (dataReader.Read())
                        {
                            string userID = dataReader.GetString(0);
                            DateTime timestamp = dataReader.GetDateTime(1);
                            int workshiftMinIndex = dataReader.GetInt16(2);
                            int workshiftMaxIndex = dataReader.GetInt16(3);
                            string rowIDRaw = dataReader.GetString(4);
                            rowIDRaw = rowIDRaw.Replace("(", string.Empty).Replace(")", string.Empty);
                            int[] rowIDs = Array.ConvertAll(rowIDRaw.Split(',').ToArray(), int.Parse);

                            int index = checkinUsers.FindIndex(item => item == userID);
                            if (index != -1 && checkinsList[index].Date == timestamp.Date)
                            {
                                int workshiftIndex = workshiftMinIndex;
                                int counter = 0;

                                while (workshiftIndex <= workshiftMaxIndex)
                                {
                                    if (checkinsList[index] > timestamp.AddHours(9 + workshiftIndex * 4).AddMinutes(15))
                                    {
                                        missedWorkshiftIds.Add(rowIDs[counter]);
                                        counter++;
                                    }
                                    workshiftIndex++;
                                }
                                if (checkoutsList[index].Date == checkinsList[index].Date && checkoutsList[index] < timestamp.AddHours(13 + workshiftMaxIndex * 4).AddMinutes(-15))
                                {
                                    missedWorkshiftIds.Add(rowIDs[rowIDs.Length - 1]);
                                }
                                checkinUsers.RemoveAt(index);
                                checkinsList.RemoveAt(index);
                                checkoutsList.RemoveAt(index);
                            }
                            else foreach (int rowID in rowIDs) missedWorkshiftIds.Add(rowID);
                        }
                        dataReader.Dispose();
                        cmd.Dispose();
                    }

                    missedWorkshiftIds = missedWorkshiftIds.Distinct().ToList();

                    foreach (int rowID in missedWorkshiftIds)
                    {
                        using (MySqlCommand cmd = new MySqlCommand($"UPDATE workshifts SET status = @newStatus WHERE id = @rowID AND status IN (@available, @pending)", conn))
                        {
                            cmd.Parameters.AddWithValue("@newStatus", (int)WorkshiftStatus.Missed);
                            cmd.Parameters.AddWithValue("@rowID", rowID);
                            cmd.Parameters.AddWithValue("@available", (int)WorkshiftStatus.Available);
                            cmd.Parameters.AddWithValue("@pending", (int)WorkshiftStatus.Pending);
                            cmd.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                finally { conn.Close(); }
            }
        }

        public static ObservableCollection<DailyWorkshift> GetEmployees(DateTime date, string departmentID, WorkshiftFilter filter)
        {
            ObservableCollection<DailyWorkshift> items = new ObservableCollection<DailyWorkshift>();
            using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
            {
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand($"SELECT w.userID, w.workshift, w.status FROM workshifts as w INNER JOIN users as u ON w.userID = u.userID WHERE w.date=@date AND u.departmentID = @department", conn))
                    {
                        cmd.Parameters.AddWithValue("@date", date.Date);
                        cmd.Parameters.AddWithValue("@department", departmentID);
                        MySqlDataReader dataReader = cmd.ExecuteReader();
                        while (dataReader.Read())
                        {
                            int index = items.IndexOf(items.Where(item => item.Employee.UserID == dataReader.GetString(0)).FirstOrDefault());
                            if (index == -1)
                            {
                                Employee newEmployee = EmployeeDatabaseHandler.GetEmployee(dataReader.GetString(0), false);

                                if (filter.GetValue(newEmployee.Role) == true)
                                {
                                    DailyWorkshift newUnit = new DailyWorkshift(newEmployee, date);
                                    newUnit.SetStatus(dataReader.GetInt16(2), dataReader.GetInt16(1));
                                    items.Add(newUnit);
                                }
                            }
                            else items[index].SetStatus(dataReader.GetInt16(2), dataReader.GetInt16(1));
                        }
                        dataReader.Dispose();
                        cmd.Dispose();
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                finally { conn.Close(); }
            }
            return items;
        }

        public static ObservableCollection<WeeklyWorkshift> GetWeeklyEmployees(DateTime date, string departmentID, WorkshiftFilter filter)
        {
            ObservableCollection<WeeklyWorkshift> items = new ObservableCollection<WeeklyWorkshift>();
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
                            int index = items.IndexOf(items.Where(item => item.Employee.UserID == dataReader.GetString(0)).FirstOrDefault());
                            if (index == -1)
                            {
                                Employee newEmployee = EmployeeDatabaseHandler.GetEmployee(dataReader.GetString(0), false);

                                if (filter.GetValue(newEmployee.Role) == true)
                                {
                                    WeeklyWorkshift newUnit = new WeeklyWorkshift(newEmployee, startDate, endDate);
                                    newUnit.SetStatus(dataReader.GetDateTime(3).DayOfWeek, dataReader.GetInt16(2), dataReader.GetInt16(1));
                                    items.Add(newUnit);
                                }
                            }
                            else items[index].SetStatus(dataReader.GetDateTime(3).DayOfWeek, dataReader.GetInt16(2), dataReader.GetInt16(1));
                        }
                        dataReader.Dispose();
                        cmd.Dispose();
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                finally { conn.Close(); }
            }
            return items;
        }

        public static void ChangeWorkshiftStatus(Employee employee, DateTime date, int status, int workshiftIndex)
        {
            using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
            {
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand($"DELETE FROM workshifts WHERE userID=@userid AND date = @date AND workshift = @workshift", conn))
                    {
                        cmd.Parameters.AddWithValue("@userid", employee.UserID);
                        cmd.Parameters.AddWithValue("@date", date.Date);
                        cmd.Parameters.AddWithValue("@workshift", workshiftIndex);
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }

                    using (MySqlCommand cmd = new MySqlCommand($"INSERT IGNORE INTO workshifts (userID, date, workshift, status) VALUES (@userid, @date, @workshift, @status)", conn))
                    {
                        cmd.Parameters.AddWithValue("@userid", employee.UserID);
                        cmd.Parameters.AddWithValue("@date", date.Date);
                        cmd.Parameters.AddWithValue("@workshift", workshiftIndex);
                        cmd.Parameters.AddWithValue("@status", status);
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                finally { conn.Close(); }
            }
        }

        public static void DeleteWorkshift(Employee employee, DateTime date, int workshiftIndex)
        {
            using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
            {
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand($"DELETE FROM workshifts WHERE userID=@userid AND date = @date AND workshift = @workshift", conn))
                    {
                        cmd.Parameters.AddWithValue("@userid", employee.UserID);
                        cmd.Parameters.AddWithValue("@date", date.Date);
                        cmd.Parameters.AddWithValue("@workshift", workshiftIndex);
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                finally { conn.Close(); }
            }
        }
    }
}
