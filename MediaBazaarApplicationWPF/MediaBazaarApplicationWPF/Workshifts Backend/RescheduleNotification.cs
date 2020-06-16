using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApplicationWPF
{
    public class RescheduleNotification
    {
        private string userID;
        private DateTime date;
        private int workshiftIndex;

        public int WorkshiftIndex
        {
            get { return workshiftIndex; }
            set { workshiftIndex = value; }
        }

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public string UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        public RescheduleNotification(string employeeId, DateTime date, int workshiftIndex)
        {

            if (CheckIfExists(employeeId, date, workshiftIndex))
            {
                this.UserID = employeeId;
                this.Date = date;
                this.WorkshiftIndex = workshiftIndex;
            }
        }
        public static bool CheckIfExists(string employeeId, DateTime date, int workshiftIndex)
        {
            using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand($"SELECT id FROM notifications WHERE employeeId=@employeeID AND date=@date AND workshift=@workshift", conn))
                {
                    cmd.Parameters.AddWithValue("@employeeID", employeeId);
                    cmd.Parameters.AddWithValue("@date", date);
                    cmd.Parameters.AddWithValue("@workshift", workshiftIndex);
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    if (dataReader.Read())
                    {
                        return true;
                    }
                    cmd.Dispose();
                    dataReader.Close();
                }
                conn.Close();
                return false;
            }
        }
        public void RemoveNotification()
        {
            if (this.UserID == null || this.UserID == "")
                return;

            using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand($"DELETE FROM notifications WHERE employeeID=@employeeID AND date=@date AND workshift=@workshift", conn))
                {
                    cmd.Parameters.AddWithValue("@employeeID", this.userID);
                    cmd.Parameters.AddWithValue("@date", this.date);
                    cmd.Parameters.AddWithValue("@workshift", this.workshiftIndex);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                conn.Close();
            }
        }
        public static void AddNotification(string employeeId, DateTime date, int workshiftIndex)
        {
            using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand($"INSERT INTO notifications (employeeID, date, workshift) VALUES (@employeeID, @date, @workshift)", conn))
                {
                    cmd.Parameters.AddWithValue("@employeeID", employeeId);
                    cmd.Parameters.AddWithValue("@date", date);
                    cmd.Parameters.AddWithValue("@workshift", workshiftIndex);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                conn.Close();
            }

        }
        public void UpdateWorkshift(int status)
        {
            using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand($"DELETE FROM workshifts WHERE userID=@userid AND date = @date AND workshift = @workshift", conn))
                {
                    cmd.Parameters.AddWithValue("@userid", this.UserID);
                    cmd.Parameters.AddWithValue("@date", this.Date.Date);
                    cmd.Parameters.AddWithValue("@workshift", this.WorkshiftIndex);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                conn.Close();
            }

            using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand($"INSERT IGNORE INTO workshifts (userID, date, workshift, status) VALUES (@userid, @date, @workshift, @status)", conn))
                {
                    cmd.Parameters.AddWithValue("@userid", this.UserID);
                    cmd.Parameters.AddWithValue("@date", this.Date.Date);
                    cmd.Parameters.AddWithValue("@workshift", this.WorkshiftIndex);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                conn.Close();
            }
        }
        public static List<RescheduleNotification> GetAllNotifications()
        {
            List<RescheduleNotification> notifications = new List<RescheduleNotification>();
            using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand($"SELECT employeeId, date, workshift FROM notifications", conn))
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        string employeeId = dataReader.GetString(0);
                        DateTime date = dataReader.GetDateTime(1);
                        int workshiftIndex = dataReader.GetInt16(2);
                        notifications.Add(new RescheduleNotification(employeeId, date, workshiftIndex));
                    }
                    cmd.Dispose();
                    dataReader.Close();
                }
                conn.Close();

            }
            return notifications;
        }

        public static List<RescheduleNotification> GetAllNotifications(string departmentID)
        {
            Department selectedDepartment = DepartmentManager.GetDepartment(departmentID, true);
            List<RescheduleNotification> notifications = new List<RescheduleNotification>();
            foreach (Employee e in selectedDepartment.Employees)
            {
                using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand($"SELECT employeeId, date, workshift FROM notifications WHERE employeeID=@employeeID", conn))
                    {
                        cmd.Parameters.AddWithValue("@employeeId", e.UserID);
                        MySqlDataReader dataReader = cmd.ExecuteReader();

                        while (dataReader.Read())
                        {
                            string employeeId = dataReader.GetString(0);
                            DateTime date = dataReader.GetDateTime(1);
                            int workshiftIndex = dataReader.GetInt16(2);
                            notifications.Add(new RescheduleNotification(employeeId, date, workshiftIndex));
                        }
                        cmd.Dispose();
                        dataReader.Close();
                    }
                    conn.Close();

                }
            }
            return notifications;
        }
    }
}
