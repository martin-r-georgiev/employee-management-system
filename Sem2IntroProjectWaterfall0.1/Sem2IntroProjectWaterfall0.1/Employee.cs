using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Sem2IntroProjectWaterfall0._1
{
    public class Employee
    {
        private string userID;
        private string username;
        private string password;
        private decimal salaryHourlyRate;
        private Role role;
        private string departmentID;
        private string firstName;
        private string lastName;
        private string nationality;
        private string address;
        private string email;
        private string phoneNumber;
        private DateTime dateofBirth;
        private bool sex;
        private Nullable<DateTime> startDate;
        private Nullable<DateTime> endDate;

        //Properties

        public string UserID
        {
            get { return this.userID; }
        }

        public string Username
        {
            get { return this.username; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    MySqlConnection conn = SqlConnectionHandler.GetSqlConnection();
                    using (MySqlCommand cmd = new MySqlCommand($"UPDATE users SET username=@username WHERE userID=@userID", conn))
                    {
                        cmd.Parameters.AddWithValue("@username", value);
                        cmd.Parameters.AddWithValue("@userID", this.userID);
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                    conn.Close();

                    this.username = value;
                }
            }
        }

        public string Password
        {
            get { return this.password; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    MySqlConnection conn = SqlConnectionHandler.GetSqlConnection();
                    using (MySqlCommand cmd = new MySqlCommand($"UPDATE users SET password=@password WHERE userID=@userID", conn))
                    {
                        cmd.Parameters.AddWithValue("@password", value);
                        cmd.Parameters.AddWithValue("@userID", this.userID);
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                    conn.Close();

                    this.password = value;
                }
            }
        }

        public decimal SalaryHourlyRate
        {
            get { return this.salaryHourlyRate; }
            set
            {
                if (this.salaryHourlyRate >= 0) this.salaryHourlyRate = value;
                else this.salaryHourlyRate = 0;

                MySqlConnection conn = SqlConnectionHandler.GetSqlConnection();
                using (MySqlCommand cmd = new MySqlCommand($"UPDATE users SET salary=@salary WHERE userID=@userID", conn))
                {
                    cmd.Parameters.AddWithValue("@salary", this.salaryHourlyRate);
                    cmd.Parameters.AddWithValue("@userID", this.userID);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                conn.Close();
            }
        }

        public Role Role
        {
            get { return this.role; }
            private set
            {
                MySqlConnection conn = SqlConnectionHandler.GetSqlConnection();
                using (MySqlCommand cmd = new MySqlCommand($"UPDATE users SET role=@role WHERE userID=@userID", conn))
                {
                    cmd.Parameters.AddWithValue("@role", value);
                    cmd.Parameters.AddWithValue("@userID", this.userID);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                conn.Close();

                this.role = value;
            }
        }

        public string DepartmentID
        {
            get { return this.departmentID; }
            set
            {
                MySqlConnection conn = SqlConnectionHandler.GetSqlConnection();
                using (MySqlCommand cmd = new MySqlCommand($"UPDATE users SET departmentID=@depID WHERE userID=@userID", conn))
                {
                    cmd.Parameters.AddWithValue("@depID", value);
                    cmd.Parameters.AddWithValue("@userID", this.userID);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                conn.Close();

                this.departmentID = value;
            }
        }

        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    MySqlConnection conn = SqlConnectionHandler.GetSqlConnection();
                    using (MySqlCommand cmd = new MySqlCommand($"UPDATE employees SET firstName=@firstName WHERE userID=@userID", conn))
                    {
                        cmd.Parameters.AddWithValue("@firstName", value);
                        cmd.Parameters.AddWithValue("@userID", this.userID);
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                    conn.Close();

                    this.firstName = value;
                }
            }
        }

        public string LastName
        {
            get { return this.lastName; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    MySqlConnection conn = SqlConnectionHandler.GetSqlConnection();
                    using (MySqlCommand cmd = new MySqlCommand($"UPDATE employees SET lastName=@lastName WHERE userID=@userID", conn))
                    {
                        cmd.Parameters.AddWithValue("@lastName", value);
                        cmd.Parameters.AddWithValue("@userID", this.userID);
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                    conn.Close();

                    this.lastName = value;
                }
            }
        }

        public string Nationality
        {
            get { return this.nationality; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    MySqlConnection conn = SqlConnectionHandler.GetSqlConnection();
                    using (MySqlCommand cmd = new MySqlCommand($"UPDATE employees SET nationality=@nationality WHERE userID=@userID", conn))
                    {
                        cmd.Parameters.AddWithValue("@nationality", value);
                        cmd.Parameters.AddWithValue("@userID", this.userID);
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                    conn.Close();

                    this.nationality = value;
                }
            }
        }

        public string Address
        {
            get { return this.address; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    MySqlConnection conn = SqlConnectionHandler.GetSqlConnection();
                    using (MySqlCommand cmd = new MySqlCommand($"UPDATE employees SET address=@address WHERE userID=@userID", conn))
                    {
                        cmd.Parameters.AddWithValue("@address", value);
                        cmd.Parameters.AddWithValue("@userID", this.userID);
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                    conn.Close();

                    this.address = value;
                }
            }
        }

        public string Email
        {
            get { return this.email; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    MySqlConnection conn = SqlConnectionHandler.GetSqlConnection();
                    using (MySqlCommand cmd = new MySqlCommand($"UPDATE employees SET email=@email WHERE userID=@userID", conn))
                    {
                        cmd.Parameters.AddWithValue("@email", value);
                        cmd.Parameters.AddWithValue("@userID", this.userID);
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                    conn.Close();

                    this.email = value;
                }
            }
        }

        public string PhoneNumber
        {
            get { return this.phoneNumber; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    MySqlConnection conn = SqlConnectionHandler.GetSqlConnection();
                    using (MySqlCommand cmd = new MySqlCommand($"UPDATE employees SET phoneNumber=@phoneNumber WHERE userID=@userID", conn))
                    {
                        cmd.Parameters.AddWithValue("@phoneNumber", value);
                        cmd.Parameters.AddWithValue("@userID", this.userID);
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                    conn.Close();

                    this.phoneNumber = value;
                }
            }
        }

        public DateTime DateOfBirth
        {
            get { return this.dateofBirth; }
        }

        public bool Sex
        {
            //Binary: 0 = Male, 1 = Female
            get { return this.sex; }
            private set { this.sex = value; }
        }

        public Nullable<DateTime> StartDate
        {
            get { return this.startDate; }
            set { this.startDate = value; }
        }

        public Nullable<DateTime> EndDate
        {
            get { return this.endDate; }
            set { this.endDate = value; }
        }

        //Constructors

        public Employee(string newUsername, string newPassword, decimal newSalaryRate, Role newRole, string newDepID)
        {
            this.username = newUsername;
            this.password = newPassword;
            this.salaryHourlyRate = newSalaryRate;
            this.role = newRole;
            this.departmentID = newDepID;

            MySqlConnection conn = SqlConnectionHandler.GetSqlConnection();
            MySqlCommand cmd;
            MySqlDataReader dataReader;

            //Checking if auto-generated userID already exists in database
            do
            {
                this.userID = GenerateUserID();
                cmd = new MySqlCommand($"SELECT userID FROM users WHERE userID=@userID", conn);
                cmd.Parameters.AddWithValue("@userID", this.userID);
                dataReader = cmd.ExecuteReader();
            }
            while (dataReader.Read());

            cmd.Dispose();
            dataReader.Close();

            using (cmd = new MySqlCommand($"INSERT INTO users (userID, username, password, salary, role, departmentID) VALUES (@userID, @username, @password, @salary, @role, @depID)", conn))
            {
                cmd.Parameters.AddWithValue("@userID", this.userID);
                cmd.Parameters.AddWithValue("@username", this.username);
                cmd.Parameters.AddWithValue("@password", this.password);
                cmd.Parameters.AddWithValue("@salary", this.salaryHourlyRate);
                cmd.Parameters.AddWithValue("@role", this.role);
                cmd.Parameters.AddWithValue("@depID", this.departmentID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            conn.Close();
        }

        public Employee(string userIdentifier)
        {
            MySqlConnection conn = SqlConnectionHandler.GetSqlConnection();

            string sql_statement = $"SELECT * FROM users as u LEFT OUTER JOIN employees as e ON u.userID = e.userID WHERE u.userID=@userID";

            using (MySqlCommand cmd = new MySqlCommand(sql_statement, conn))
            {
                cmd.Parameters.AddWithValue("@userID", userIdentifier);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.Read())
                {
                    this.userID = userIdentifier;
                    this.username = dataReader.GetString(1);
                    this.password = dataReader.GetString(2);
                    this.salaryHourlyRate = dataReader.GetDecimal(3);
                    this.role = (Role) dataReader.GetInt32(4);
                    this.departmentID = dataReader.GetString(5);
                    this.firstName = (dataReader.IsDBNull(7)) ? null : dataReader.GetString(7);
                    this.lastName = (dataReader.IsDBNull(8)) ? null : dataReader.GetString(8);
                    this.nationality = (dataReader.IsDBNull(9)) ? null : dataReader.GetString(9);
                    this.address = (dataReader.IsDBNull(10)) ? null : dataReader.GetString(10);
                    this.email = (dataReader.IsDBNull(11)) ? null : dataReader.GetString(11);
                    this.phoneNumber = (dataReader.IsDBNull(12)) ? null : dataReader.GetString(12);
                    if (!dataReader.IsDBNull(13)) this.dateofBirth = dataReader.GetDateTime(13);
                    if (!dataReader.IsDBNull(14)) this.sex = dataReader.GetBoolean(14);
                    if (!dataReader.IsDBNull(15)) this.startDate = dataReader.GetDateTime(15);
                    if (!dataReader.IsDBNull(16)) this.endDate = dataReader.GetDateTime(16);
                }
                cmd.Dispose();
                dataReader.Close();
            }
            conn.Close();
        }

        //Methods
        private string GenerateUserID()
        {
            Guid key = Guid.NewGuid();
            string GuidString = Convert.ToBase64String(key.ToByteArray());
            GuidString = GuidString.Replace("=", "");
            GuidString = GuidString.Replace("+", "");
            GuidString = GuidString.Replace("/", "");

            return GuidString;
        }

        public void SetPersonalInfo(string fName, string lName, DateTime dateOfBirth, bool sex)
        {
            MySqlConnection conn = SqlConnectionHandler.GetSqlConnection();

            using (MySqlCommand cmd = new MySqlCommand($"INSERT IGNORE employees (userID, firstName, lastName, dateOfBirth, sex) VALUES (@userID, @fName, @lName, @birthDate, @sex)", conn))
            {
                cmd.Parameters.AddWithValue("@userID", this.userID);
                cmd.Parameters.AddWithValue("@fName", fName);
                cmd.Parameters.AddWithValue("@lName", lName);
                cmd.Parameters.AddWithValue("@birthDate", dateOfBirth);
                cmd.Parameters.AddWithValue("@sex", sex);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            conn.Close();
        }

        public void SetPersonalInfo(string fName, string lName, string nationality, string address, string email, string phoneNum, DateTime dateOfBirth, bool sex)
        {
            MySqlConnection conn = SqlConnectionHandler.GetSqlConnection();

            using (MySqlCommand cmd = new MySqlCommand($"INSERT IGNORE INTO employees (userID, firstName, lastName, nationality, address, email, phoneNumber, dateOfBirth, sex) VALUES (@userID, @fName, @lName, @nat, @address, @email, @pNum, @birthDate, @sex)", conn))
            {
                cmd.Parameters.AddWithValue("@userID", this.userID);
                cmd.Parameters.AddWithValue("@fName", fName);
                cmd.Parameters.AddWithValue("@lName", lName);
                cmd.Parameters.AddWithValue("@nat", nationality);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@pNum", phoneNum);
                cmd.Parameters.AddWithValue("@birthDate", dateOfBirth);
                cmd.Parameters.AddWithValue("@sex", sex);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            conn.Close();
        }

        public Employee GetEmployee(string userIdentifier)
        {
            return new Employee(userIdentifier);
        }

        public static void RemoveFromDatabase(string userIdentifier)
        {
            MySqlConnection conn = SqlConnectionHandler.GetSqlConnection();

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

            conn.Close();
        }

        public void RemoveFromDatabase()
        {
            MySqlConnection conn = SqlConnectionHandler.GetSqlConnection();

            using (MySqlCommand cmd = new MySqlCommand($"DELETE FROM employees WHERE userID=@userID", conn))
            {
                cmd.Parameters.AddWithValue("@userid", this.userID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            using (MySqlCommand cmd = new MySqlCommand($"DELETE FROM users WHERE userID=@userID", conn))
            {
                cmd.Parameters.AddWithValue("@userid", this.userID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            conn.Close();
        }
    }
}
