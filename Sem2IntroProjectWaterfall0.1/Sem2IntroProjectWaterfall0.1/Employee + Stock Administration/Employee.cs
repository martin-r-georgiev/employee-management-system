using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Sem2IntroProjectWaterfall0._1
{
    public class Employee : IComparable<Employee>
    {
        #region Instance Variables

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
        private string mainDetails;
        private int workHours;
        private double attendance;

        

        #endregion

        #region Properties
        //Properties


        public int WorkHours
        {
            get { return workHours; }
            set {
                if (value % 4 == 0)
                {
                    using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
                    {
                        using (MySqlCommand cmd = new MySqlCommand($"UPDATE employees SET workHours=@workHours WHERE userID=@userID", conn))
                        {
                            cmd.Parameters.AddWithValue("@workHours", value);
                            cmd.Parameters.AddWithValue("@userID", this.userID);
                            cmd.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        conn.Close();
                        this.workHours = value;
                    }
                }
            }
        }

        public string UserID
        {
            get { return this.userID; }
        }

        public string Username
        {
            get { return this.username; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
                    {
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
        }

        public string Password
        {
            get { return this.password; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
                    {
                        using (MySqlCommand cmd = new MySqlCommand($"UPDATE users SET password=@password WHERE userID=@userID", conn))
                        {
                            string hashValue = HashManager.GetSha256(value);
                            cmd.Parameters.AddWithValue("@password", hashValue);
                            cmd.Parameters.AddWithValue("@userID", this.userID);
                            cmd.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        conn.Close();
                        this.password = value;
                    }
                    
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

                using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
                {
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
        }

        public Role Role
        {
            get { return this.role; }
            private set
            {
                using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
                {
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
        }

        public string DepartmentID
        {
            get { return this.departmentID; }
            set
            {
                using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
                {
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
        }

        public string Name
        {
            get
            {
                if (!string.IsNullOrEmpty(this.firstName) || !string.IsNullOrEmpty(this.lastName)) return $"{this.firstName} {this.lastName} ({this.Username})";
                else return this.Username;
            }
        }

        public string FirstName
        {
            get {return this.firstName; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
                    {
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
        }

        public string LastName
        {
            get { return this.lastName; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
                    {
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
        }

        public string Nationality
        {
            get {
                 return this.nationality; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
                    {
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
        }

        public string Address
        {
            get {
                return this.address; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
                    {
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
        }

        public string Email
        {
            get {
                return this.email; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
                    {
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
        }

        public string PhoneNumber
        {
            get {
                return this.phoneNumber; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
                    {
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
        }

        public DateTime DateOfBirth
        {
            get {
                return this.dateofBirth; 
            }
            set
            {
                using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand($"UPDATE employees SET dateOfBirth=@dateOfBirth WHERE userID=@userID", conn))
                    {
                        cmd.Parameters.AddWithValue("@dateOfBirth", value);
                        cmd.Parameters.AddWithValue("@userID", this.userID);
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                    conn.Close();
                    this.dateofBirth = value;
                }
                this.dateofBirth = value;
            }
        }

        public bool Sex
        {
            //Binary: 0 = Male, 1 = Female
            get { return this.sex; }
            private set
            {
                using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
                    {
                        using (MySqlCommand cmd = new MySqlCommand($"UPDATE employees SET sex=@sex WHERE userID=@userID", conn))
                        {
                            cmd.Parameters.AddWithValue("@sex", value);
                            cmd.Parameters.AddWithValue("@userID", this.userID);
                            cmd.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        conn.Close();
                        this.sex = value;
                }
                this.sex = value; }
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
        public string MainDetails
        {
            get { return mainDetails; }
            set { mainDetails = value; }
        }
        public double Attendance
        {
            get { return attendance; }
            set
            {
                using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand($"UPDATE employees SET attendance=@attendance WHERE userID=@userID", conn))
                    {
                        cmd.Parameters.AddWithValue("@attendance", value);
                        cmd.Parameters.AddWithValue("@userID", this.userID);
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                    conn.Close();
                }
                this.attendance = value;
            }
        }
        #endregion

        #region Constructors
        //Constructors

        public Employee(string newUsername, string newPassword, decimal newSalaryRate, Role newRole, string newDepID, int workHours)
        {
            this.username = newUsername;
            this.password = HashManager.GetSha256(newPassword);
            this.salaryHourlyRate = newSalaryRate;
            this.role = newRole;
            this.departmentID = newDepID;
            this.workHours = workHours;
            this.StartDate = DateTime.Today;
  
            using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
            {
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
                using (cmd = new MySqlCommand($"INSERT INTO employees(userID,startDate, workHours, attendance) VALUES (@userID, @startDate, @workHours, @attendance)", conn))
                {
                    cmd.Parameters.AddWithValue("@userID", this.userID);
                    cmd.Parameters.AddWithValue("@startDate", this.StartDate);
                    cmd.Parameters.AddWithValue("@workHours", this.workHours);
                    cmd.Parameters.AddWithValue("@attendance", "0.0");
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                conn.Close();
            }
        }
        public Employee(string userIdentifier, bool needFullDetails)
        {
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
                            this.userID = userIdentifier;
                            this.username = dataReader.GetString(1);
                            this.password = dataReader.GetString(2);
                            this.salaryHourlyRate = dataReader.GetDecimal(3);
                            this.role = (Role)dataReader.GetInt32(4);
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
                            this.workHours = dataReader.GetInt32(16);
                            if (!dataReader.IsDBNull(17)) this.attendance = Convert.ToDouble(dataReader.GetDecimal(17));

                        }
                        cmd.Dispose();
                        dataReader.Close();
                    }
                    conn.Close();
                }
            } else
            {
                using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand($"SELECT username,departmentID,firstName,lastName,role FROM users as u LEFT OUTER JOIN employees as e ON u.userID = e.userID WHERE u.userID=@userID", conn))
                    {
                        cmd.Parameters.AddWithValue("@userID", userIdentifier);
                        MySqlDataReader dataReader = cmd.ExecuteReader();

                        if (dataReader.Read())
                        {
                            this.userID = userIdentifier;
                            this.username = dataReader.GetString(0);
                            this.departmentID = dataReader.GetString(1);
                            this.firstName = (dataReader.IsDBNull(2)) ? null : dataReader.GetString(2);
                            this.lastName = (dataReader.IsDBNull(3)) ? null : dataReader.GetString(3);
                            this.role = (Role)dataReader.GetInt32(4);
                        }
                        cmd.Dispose();
                        dataReader.Close();
                    }
                    conn.Close();
                }
            }
        }
        #endregion

        #region Class methods
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
            using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand($"REPLACE INTO employees (userID, firstName, lastName, dateOfBirth, sex) VALUES (@userID, @fName, @lName, @birthDate, @sex)", conn))
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
        }

        public void SetPersonalInfo(string fName, string lName, string nationality, string address, string email, string phoneNum, DateTime dateOfBirth, bool sex)
        {
            using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand($"UPDATE employees " +
                    $"SET userID=@userID, firstName=@fName, " +
                    $"lastName=@lName, nationality=@nat, address=@address, email=@email, " +
                    $"phoneNumber=@pNum, dateOfBirth=@birthDate, sex=@sex " +
                    $"WHERE userID =@userID", conn))
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

        public void RemoveFromDatabase()
        {
            using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
            {
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

        public static List<Employee> GetAllEmployees(bool needFullDetails)
        {
            if (needFullDetails)
            {
                List<Employee> allEmployees = new List<Employee>();
                using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand($"SELECT userID FROM users", conn))
                    {
                        MySqlDataReader dataReader = cmd.ExecuteReader();
                        while (dataReader.Read())
                        {
                            Employee newEmp = new Employee(dataReader.GetString(0), true);
                            Department empDepartment = new Department(newEmp.DepartmentID, true);
                            if (newEmp.FirstName != null && newEmp.FirstName.Length > 0) newEmp.MainDetails = $"{newEmp.FirstName} {newEmp.LastName} ({empDepartment.Name})";
                            else newEmp.MainDetails = $"{newEmp.Username} ({empDepartment.Name})";
                            allEmployees.Add(newEmp);
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
                    using (MySqlCommand cmd = new MySqlCommand($"SELECT userID FROM users", conn))
                    {
                        MySqlDataReader dataReader = cmd.ExecuteReader();
                        while (dataReader.Read())
                        {
                            Employee newEmp = new Employee(dataReader.GetString(0),false);
                            allEmployees.Add(newEmp);
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
                return result;
            }
        }
        public static string CalculateWorkingSince(Employee selectedEmployee) //Used for the employee listing label
        {
            string s = "";
            if (selectedEmployee.StartDate.HasValue)
            {
                int workingSince = DateTime.Today.Year - selectedEmployee.StartDate.Value.Year;
                if (workingSince > 0)
                {
                    s = $"Working since: {workingSince} years";
                    if (workingSince == 1) s.Replace("years", "year");
                }
                else
                {
                    workingSince = DateTime.Today.Month - selectedEmployee.StartDate.Value.Month;
                    if (workingSince > 0)
                    {
                        s = $"Working since: {workingSince} months";
                        if (workingSince == 1) s.Replace("months", "month");
                    }
                    else
                    {
                        workingSince = DateTime.Today.Day - selectedEmployee.StartDate.Value.Day;
                        s = $"Working since: {workingSince} days";
                        if (workingSince == 1) s.Replace("days", "day");
                    }
                }
            }
            else s = $"Working since: Unknown";
            return s;
        }

        public int CompareTo(Employee other)
        {
            if (String.Compare(this.Name, other.Name) < 0) return -1;
            else if (String.Compare(this.Name, other.Name) > 0) return 1;
            return 0;
        }

        #endregion
    }
}
