using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApplicationWPF
{
    public class HistoryLog
    {
        public static void AddToHistoryLog(Employee ToAdd) // adding an employee with his basic details when registering
        {
            using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
            {
                MySqlCommand cmd;

                using (cmd = new MySqlCommand($"INSERT INTO historylog(userID,username,firstName,lastName,phoneNumber,startDate,dateOfBirth,workHours, attendance,salary,role) VALUES (@userID,@username,@firstName,@lastName,@phoneNumber,@startDate,@dateOfBirth,@workHours,@attendance,@salary,@role)", conn))
                {
                    cmd.Parameters.AddWithValue("@userID", ToAdd.UserID);
                    cmd.Parameters.AddWithValue("@username", ToAdd.Username);
                    cmd.Parameters.AddWithValue("@firstName", ToAdd.FirstName);
                    cmd.Parameters.AddWithValue("@lastName", ToAdd.LastName);
                    cmd.Parameters.AddWithValue("@phoneNumber", ToAdd.PhoneNumber);
                    cmd.Parameters.AddWithValue("@startDate", ToAdd.StartDate);
                    cmd.Parameters.AddWithValue("@dateOfBirth", ToAdd.PhoneNumber);
                    cmd.Parameters.AddWithValue("@workHours", ToAdd.WorkHours);
                    cmd.Parameters.AddWithValue("@attendance", ToAdd.Attendance);
                    cmd.Parameters.AddWithValue("@salary", ToAdd.SalaryHourlyRate);
                    cmd.Parameters.AddWithValue("@role", ToAdd.Role);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                conn.Close();
            }

        }

        public static void UpdateHistoryLog(Employee ToAdd) // updating him based on the details that could've been changed 
        {
            using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
            {
                MySqlCommand cmd;
                using (cmd = new MySqlCommand($"UPDATE historylog SET firstName = @firstName,email=@email,address=@address,nationality=@nationality,lastName = @lastName,phoneNumber = @phoneNumber,startDate = @startDate,dateOfBirth = @dateOfBirth,workHours = @workHours, attendance = @attendance, salary=@salary, role=@role WHERE userID = @userID", conn))
                {
                    cmd.Parameters.AddWithValue("@userID", ToAdd.UserID);
                    cmd.Parameters.AddWithValue("@firstName", ToAdd.FirstName);
                    cmd.Parameters.AddWithValue("@lastName", ToAdd.LastName);
                    cmd.Parameters.AddWithValue("@phoneNumber", ToAdd.PhoneNumber);
                    cmd.Parameters.AddWithValue("@email", ToAdd.Email);
                    cmd.Parameters.AddWithValue("@address", ToAdd.Address);
                    cmd.Parameters.AddWithValue("@nationality", ToAdd.Nationality);
                    cmd.Parameters.AddWithValue("@startDate", ToAdd.StartDate);
                    cmd.Parameters.AddWithValue("@dateOfBirth", ToAdd.DateOfBirth);
                    cmd.Parameters.AddWithValue("@workHours", ToAdd.WorkHours);
                    cmd.Parameters.AddWithValue("@attendance", ToAdd.Attendance);
                    cmd.Parameters.AddWithValue("@salary", ToAdd.SalaryHourlyRate);
                    cmd.Parameters.AddWithValue("@role", ToAdd.Role);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                conn.Close();
            }

        }

        public static void UpdateHistoryLogDeleted(string userID) // updating him based on the details that could've been changed 
        {
            using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
            {
                MySqlCommand cmd;
                using (cmd = new MySqlCommand($"UPDATE historylog SET endDate = @endDate WHERE userID = @userID", conn))
                {
                    cmd.Parameters.AddWithValue("@userID", userID);
                    cmd.Parameters.AddWithValue("@endDate", System.DateTime.Today.ToString("yyyy-MM-dd"));         
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                conn.Close();
            }

        }

        public static List<string> ShowLog() // message with the employee history log
        {
            List<string> messages = new List<string>();

            using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand($"SELECT * FROM historylog ", conn))
                {

                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        string role = ReturnRole(dataReader["role"].ToString());
                        string username = dataReader["username"].ToString();

                        string firstName = dataReader["firstName"].ToString();
                        if (firstName == "") firstName = "UNKNOWN";

                        string lastName = dataReader["lastName"].ToString();
                        if (lastName == "") lastName = "UNKNOWN";


                        string phoneNumber = dataReader["phoneNumber"].ToString();
                        if (phoneNumber == "") phoneNumber = "UNKNOWN";

                        string email = dataReader["email"].ToString();
                        if (email == "") email = "UNKNOWN";

                        string nationality = dataReader["nationality"].ToString();
                        if (nationality == "") nationality = "UNKNOWN";

                        string address = dataReader["address"].ToString();
                        if (address == "") address = "UNKNOWN";

                        string dateOfBirth;
                        if (dataReader["dateOfBirth"].ToString() == "")
                            dateOfBirth = "UNKNOWN";
                        else
                            dateOfBirth = Convert.ToDateTime(dataReader["dateOfBirth"]).ToString("yyyy-MM-dd");

                        string startDate = Convert.ToDateTime(dataReader["startDate"]).ToString("yyyy-MM-dd");
                        string endDate;
                        if (dataReader["endDate"].ToString() == "")
                            endDate = "Now";
                        else
                            endDate = Convert.ToDateTime(dataReader["endDate"]).ToString("yyyy-MM-dd");

                        string workHours = dataReader["workHours"].ToString();
                        string salary = dataReader["salary"].ToString();
                        string attendance = dataReader["attendance"].ToString();
                        string m = $"{firstName} {lastName} ({username}) - {role} working {workHours} hours/week at {salary}$/hr. \n{nationality} born on {dateOfBirth}. \n E-mail: {email} \t Phone: {phoneNumber} \t Address: {address} \n Worked {startDate} - {endDate} with {attendance}% attendance";
                        messages.Add(m);
                    }
                    cmd.Dispose();
                    dataReader.Close();
                }
                conn.Close();
            }
            return messages;
        }

        public static void DeleteFromHistoryLog(string userID)
        {
            using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
            {
                MySqlCommand cmd;
                using (cmd = new MySqlCommand($"DELETE from historylog where userID=@userID ", conn))
                {
                    cmd.Parameters.AddWithValue("@userID", userID);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                conn.Close();
            }
        }

        public static bool CheckIfPersonExists(string userID)
        {
            bool exists = false;
            using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
            {
                MySqlCommand cmd;
                using (cmd = new MySqlCommand($"select * from historylog where userID=@userID ", conn))
                { 
                    cmd.Parameters.AddWithValue("@userID", userID);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.Read())
                        exists = true;
                    cmd.Dispose();
                    dataReader.Close();
                }
                conn.Close();
            }
            return exists;
        }


        public static string ReturnRole(string role)
        {
            switch (role)
            {
                case "0":
                    return "Worker";
                case "1":
                    return "Manager";
                case "2":
                    return "Administrator";
                case "3":
                    return "Owner";
                default:
                    return "ERROR";
            }
        }
    }
}
