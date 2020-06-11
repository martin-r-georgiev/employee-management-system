using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MediaBazaarApplicationWPF
{
    public abstract class EmployeeDatabaseHandler
    {
        public static void InsertToDatabase(Employee employee)
        {
            using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand($"INSERT IGNORE INTO users (userID, username, password, salary, role, departmentID) VALUES (@userID, @username, @password, @salary, @role, @depID)", conn))
                {
                    cmd.Parameters.AddWithValue("@userID", employee.UserID);
                    cmd.Parameters.AddWithValue("@username", employee.Username);
                    cmd.Parameters.AddWithValue("@password", employee.Password);
                    cmd.Parameters.AddWithValue("@salary", employee.SalaryHourlyRate);
                    cmd.Parameters.AddWithValue("@role", employee.Role);
                    cmd.Parameters.AddWithValue("@depID", employee.DepartmentID);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }

                using (MySqlCommand cmd = new MySqlCommand($"INSERT IGNORE INTO employees(userID, startDate, workHours, attendance) VALUES (@userID, @startDate, @workHours, @attendance)", conn))
                {
                    cmd.Parameters.AddWithValue("@userID", employee.UserID);
                    cmd.Parameters.AddWithValue("@startDate", employee.StartDate);
                    cmd.Parameters.AddWithValue("@workHours", employee.WorkHours);
                    cmd.Parameters.AddWithValue("@attendance", "0.0");
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                conn.Close();
            }
        }

        public static void UpdateDatabaseEntry(Employee employee)
        {
            using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(@"UPDATE users as u INNER JOIN employees as e ON u.userID = e.userID
                       SET u.username = @username, u.password = @password, u.salary = @salary, u.role = @role, u.departmentID = @depID,
                           e.firstName = @fName, e.lastName = @lName, e.address = @address, e.phoneNumber = @phone, e.workHours = @workHours, e.attendance = @attendance
                       WHERE u.userID = @userID", conn))
                {
                    cmd.Parameters.AddWithValue("@username", employee.Username);
                    cmd.Parameters.AddWithValue("@password", employee.Password);
                    cmd.Parameters.AddWithValue("@salary", employee.SalaryHourlyRate);
                    cmd.Parameters.AddWithValue("@role", (int)employee.Role);
                    cmd.Parameters.AddWithValue("@depID", employee.DepartmentID);
                    cmd.Parameters.AddWithValue("@fName", employee.FirstName);
                    cmd.Parameters.AddWithValue("@lName", employee.LastName);
                    cmd.Parameters.AddWithValue("@address", employee.Address);
                    cmd.Parameters.AddWithValue("@phone", employee.PhoneNumber);
                    cmd.Parameters.AddWithValue("@workHours", employee.WorkHours);
                    cmd.Parameters.AddWithValue("@attendance", employee.Attendance);
                    cmd.Parameters.AddWithValue("@userID", employee.UserID);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                conn.Close();
            }
        }


        public static void RemoveFromDatabase(string userIdentifier)
        {
            using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand($"DELETE FROM employees WHERE userID=@userID", conn))
                {
                    cmd.Parameters.AddWithValue("@userid", userIdentifier);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }

                using (MySqlCommand cmd = new MySqlCommand($"DELETE FROM users WHERE userID=@userID", conn))
                {
                    cmd.Parameters.AddWithValue("@userid", userIdentifier);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }


                using (MySqlCommand cmd = new MySqlCommand($"DELETE FROM preferences WHERE userID=@userID", conn))
                {
                    cmd.Parameters.AddWithValue("@userid", userIdentifier);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }


                using (MySqlCommand cmd = new MySqlCommand($"DELETE FROM workshifts WHERE userID=@userID", conn))
                {
                    cmd.Parameters.AddWithValue("@userid", userIdentifier);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                conn.Close();
            }
        }

        public static Employee GetEmployee(string userIdentifier, bool needFullDetails)
        {
            Employee employee = null;
            if (needFullDetails)
            {
                using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand($"SELECT * FROM users as u LEFT OUTER JOIN employees as e ON u.userID = e.userID WHERE u.userID=@userID", conn))
                    {
                        cmd.Parameters.AddWithValue("@userID", userIdentifier);
                        MySqlDataReader dataReader = cmd.ExecuteReader();

                        if (dataReader.Read())
                        {
                            employee = new Employee(userIdentifier, dataReader.GetString(1), dataReader.GetString(2), dataReader.GetDecimal(3), (EmployeeRole)dataReader.GetInt32(4), dataReader.GetString(5), dataReader.GetInt32(16), false);

                            if (!dataReader.IsDBNull(7)) employee.FirstName = dataReader.GetString(7);
                            if (!dataReader.IsDBNull(8)) employee.LastName = dataReader.GetString(8);
                            if (!dataReader.IsDBNull(9)) employee.Nationality = dataReader.GetString(9);
                            if (!dataReader.IsDBNull(10)) employee.Address = dataReader.GetString(10);
                            if (!dataReader.IsDBNull(11)) employee.Email = dataReader.GetString(11);
                            if (!dataReader.IsDBNull(12)) employee.PhoneNumber = dataReader.GetString(12);
                            if (!dataReader.IsDBNull(13)) employee.DateOfBirth = dataReader.GetDateTime(13);
                            if (!dataReader.IsDBNull(14)) employee.Sex = dataReader.GetBoolean(14);
                            if (!dataReader.IsDBNull(15)) employee.StartDate = dataReader.GetDateTime(15);
                            if (!dataReader.IsDBNull(17)) employee.Attendance = Convert.ToDouble(dataReader.GetDecimal(17));
                        }
                        cmd.Dispose();
                        dataReader.Close();
                    }
                    conn.Close();
                }
            }
            else
            {
                using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand($"SELECT u.username, u.password, u.salary, u.role, u.departmentID, e.workHours, e.firstName, e.lastName FROM users as u LEFT OUTER JOIN employees as e ON u.userID = e.userID WHERE u.userID=@userID", conn))
                    {
                        cmd.Parameters.AddWithValue("@userID", userIdentifier);
                        MySqlDataReader dataReader = cmd.ExecuteReader();

                        if (dataReader.Read())
                        {
                            employee = new Employee(userIdentifier, dataReader.GetString(0), dataReader.GetString(1), dataReader.GetDecimal(2), (EmployeeRole)dataReader.GetInt32(3), dataReader.GetString(4), dataReader.GetInt32(5), false);
                            if (!dataReader.IsDBNull(6)) employee.FirstName = dataReader.GetString(6);
                            if (!dataReader.IsDBNull(7)) employee.LastName = dataReader.GetString(7);
                        }
                        cmd.Dispose();
                        dataReader.Close();
                    }
                    conn.Close();
                }
            }
            return employee;
        }

        public static List<Employee> GetAllEmployees(bool needFullDetails)
        {
            if (needFullDetails)
            {
                List<Employee> allEmployees = new List<Employee>();
                using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand($"SELECT * FROM users as u LEFT OUTER JOIN employees as e ON u.userID = e.userID", conn))
                    {
                        MySqlDataReader dataReader = cmd.ExecuteReader();
                        while (dataReader.Read())
                        {
                            Employee employee = new Employee(dataReader.GetString(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetDecimal(3), (EmployeeRole)dataReader.GetInt32(4), dataReader.GetString(5), dataReader.GetInt32(16), false);
                            string firstName = (dataReader.IsDBNull(7)) ? null : dataReader.GetString(7);
                            string lastName = (dataReader.IsDBNull(8)) ? null : dataReader.GetString(8);
                            string nationality = (dataReader.IsDBNull(9)) ? null : dataReader.GetString(9);
                            string address = (dataReader.IsDBNull(10)) ? null : dataReader.GetString(10);
                            string email = (dataReader.IsDBNull(11)) ? null : dataReader.GetString(11);
                            string phoneNumber = (dataReader.IsDBNull(12)) ? null : dataReader.GetString(12);
                            DateTime? dateOfBirth = (dataReader.IsDBNull(13)) ? (DateTime?)null : dataReader.GetDateTime(13);
                            bool? sex = (dataReader.IsDBNull(14)) ? (bool?)null : dataReader.GetBoolean(14);

                            employee.SetPersonalInfo(firstName, lastName, nationality, address, email, phoneNumber, dateOfBirth, sex);

                            if (!dataReader.IsDBNull(15)) employee.StartDate = dataReader.GetDateTime(15);
                            if (!dataReader.IsDBNull(17)) employee.Attendance = Convert.ToDouble(dataReader.GetDecimal(17));

                            allEmployees.Add(employee);
                        }
                        cmd.Dispose();
                        dataReader.Close();
                    }
                    conn.Close();
                    return allEmployees;
                }
            }
            else
            {
                List<Employee> allEmployees = new List<Employee>();
                using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand($"SELECT u.userID, u.username, u.password, u.salary, u.role, u.departmentID, e.workHours, e.firstName, e.lastName, FROM users as u LEFT OUTER JOIN employees as e ON u.userID = e.userID", conn))
                    {
                        MySqlDataReader dataReader = cmd.ExecuteReader();
                        while (dataReader.Read())
                        {
                            Employee employee = new Employee(dataReader.GetString(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetDecimal(3), (EmployeeRole)dataReader.GetInt32(4), dataReader.GetString(5), dataReader.GetInt32(6), false);
                            employee.FirstName = dataReader.GetString(7);
                            employee.LastName = dataReader.GetString(8);
                            allEmployees.Add(employee);
                        }
                        cmd.Dispose();
                        dataReader.Close();
                    }
                    conn.Close();
                    return allEmployees;
                }
            }
        }

        public static bool IsUniqueUsername(string targetUsername)
        {
            bool result = true;
            using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand($"SELECT username FROM users WHERE username=@username", conn))
                {
                    cmd.Parameters.AddWithValue("@username", targetUsername);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.Read()) result = false;
                    dataReader.Dispose();
                    cmd.Dispose();
                }
                conn.Close();
            }
            return result;
        }

        public static string GenerateUniqueUserID()
        {
            string userID;
            using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
            {
                MySqlCommand cmd;
                MySqlDataReader dataReader;

                //Checking if auto-generated userID already exists in database
                do
                {
                    userID = GenerateUserID();
                    cmd = new MySqlCommand($"SELECT userID FROM users WHERE userID=@userID", conn);
                    cmd.Parameters.AddWithValue("@userID", userID);
                    dataReader = cmd.ExecuteReader();
                }
                while (dataReader.Read());

                cmd.Dispose();
                dataReader.Close();
                conn.Close();
            }
            return userID;
        }

        public static string GetPictureURL(string userIdentifier)
        {
            string picture = "http://placehold.it/150";
            using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand($"SELECT picture FROM employees WHERE userID=@userID", conn))
                {
                    cmd.Parameters.AddWithValue("@userID", userIdentifier);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read()) { picture = dataReader.GetString(0); }
                    cmd.Dispose();
                    dataReader.Close();
                }
                conn.Close();
            }
            return picture;
        }

        private static string GenerateUserID()
        {
            Guid key = Guid.NewGuid();
            string GuidString = Convert.ToBase64String(key.ToByteArray());
            GuidString = GuidString.Replace("=", "");
            GuidString = GuidString.Replace("+", "");
            GuidString = GuidString.Replace("/", "");

            return GuidString;
        }
    }
}
