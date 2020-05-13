using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem2IntroProjectWaterfall0._1
{
    public class Department : IComparable<Department>
    {
		#region variables + properties

		private string departmentId;
		private string name;
		private string address;
		List<Employee> employees;
        public Inventory inventory;
		public List<Employee> Employees
		{
			get { return this.employees; }
		}
		public string Address
		{
			get { return address; }
			set {
                using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand($"UPDATE department SET address = @address WHERE departmentID=@departmentId", conn))
                    {
                        cmd.Parameters.AddWithValue("@address", value);
                        cmd.Parameters.AddWithValue("@departmentId", this.DepartmentId);
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                    conn.Close();
                    address = value;
                }
            }
		}

		public string Name
		{
			get { return name; }
			set
            {
                using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand($"UPDATE department SET name = @name WHERE departmentID=@departmentId", conn))
                    {
                        cmd.Parameters.AddWithValue("@name", value);
                        cmd.Parameters.AddWithValue("@departmentId", this.DepartmentId);
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                    conn.Close();
                    name = value;
                }
            }
		}

		public string DepartmentId
		{
			get { return departmentId; }
			set { departmentId = value; }
		}

        #endregion
        #region Constructors

        public Department(string name, string address)
        {
            if (name.Length > 0 && address.Length > 0)
            {
                this.name = name;
                this.address = address;
                employees = new List<Employee>();
                inventory = new Inventory(this.departmentId);

                using (MySqlConnection con = SqlConnectionHandler.GetSqlConnection())
                {
                    MySqlCommand cmd;
                    MySqlDataReader dataReader;

                    cmd = new MySqlCommand($"SELECT name FROM department WHERE name=@name", con);
                    cmd.Parameters.AddWithValue("@name", name);
                    dataReader = cmd.ExecuteReader();

                    if (dataReader.Read())
                    {
                        cmd.Dispose();
                        dataReader.Close();
                        throw new NameTakenException("Department name taken!");
                    }
                    else
                    {
                        cmd.Dispose();
                        dataReader.Close();
                        do
                        {
                            this.DepartmentId = GenerateDepartmentID();
                            cmd = new MySqlCommand($"SELECT departmentID FROM department WHERE departmentID=@departmentID", con);
                            cmd.Parameters.AddWithValue("@departmentID", this.DepartmentId);
                            dataReader = cmd.ExecuteReader();
                        }
                        while (dataReader.Read());
                        cmd.Dispose();
                        dataReader.Close();
                        //Making sure that the ID is unique

                        using (cmd = new MySqlCommand($"INSERT INTO department (departmentID, name, address) VALUES (@departmentID, @name, @address)", con))
                        {
                            cmd.Parameters.AddWithValue("@departmentID", this.DepartmentId);
                            cmd.Parameters.AddWithValue("@name", this.Name);
                            cmd.Parameters.AddWithValue("@address", this.Address);
                            cmd.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                    }
                    con.Close();
                }
            }
            else throw new InvalidEntryException("Please provide the needed details!");
        }
        public Department(string departmentId, bool withEmployeeList)
        {
            if (withEmployeeList)
            {
                inventory = new Inventory(this.departmentId);

                this.DepartmentId = departmentId;
                using (MySqlConnection con = SqlConnectionHandler.GetSqlConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand($"SELECT name, address FROM department WHERE departmentID=@departmentID", con))
                    {
                        cmd.Parameters.AddWithValue("@departmentID", DepartmentId);
                        MySqlDataReader dataReader = cmd.ExecuteReader();

                        if (dataReader.Read())
                        {
                            this.name = dataReader.GetString(0);
                            this.address = dataReader.GetString(1);
                        }
                        cmd.Dispose();
                        dataReader.Close();
                    }
                    //Get all other properties from department table

                    using (MySqlCommand cmd = new MySqlCommand($"SELECT userID FROM users WHERE departmentID=@departmentID", con))
                    {
                        cmd.Parameters.AddWithValue("@departmentID", this.DepartmentId);
                        MySqlDataReader dataReader = cmd.ExecuteReader();
                        this.employees = new List<Employee>();

                        while (dataReader.Read())
                        {
                            Employee newEmp = new Employee(dataReader.GetString(0), true);
                            if (newEmp.FirstName != null && newEmp.FirstName.Length > 0) newEmp.MainDetails = $"{newEmp.FirstName} {newEmp.LastName} ({this.Name})";
                            else newEmp.MainDetails = $"{newEmp.Username} ({this.Name})";
                            employees.Add(newEmp);
                        }
                        cmd.Dispose();
                        dataReader.Close();
                    }
                    con.Close();
                }
            }
            else
            {
                using (MySqlConnection con = SqlConnectionHandler.GetSqlConnection())
                {
                    MySqlCommand cmd;
                    MySqlDataReader dataReader;
                        using (cmd = new MySqlCommand($"SELECT name, address FROM department WHERE departmentID=@departmentID", con))
                        {
                            cmd.Parameters.AddWithValue("@departmentID", DepartmentId);
                            dataReader = cmd.ExecuteReader();

                            if (dataReader.Read())
                            {
                                this.name = dataReader.GetString(0);
                                this.address = dataReader.GetString(1);
                            }
                        }
                        cmd.Dispose();
                        dataReader.Close();
                        con.Close();
                }
            }
        }

        #endregion
        #region Methods

        private string GenerateDepartmentID()
        {
            Guid key = Guid.NewGuid();
            string GuidString = Convert.ToBase64String(key.ToByteArray());
            GuidString = GuidString.Replace("=", "");
            GuidString = GuidString.Replace("+", "");
            GuidString = GuidString.Replace("/", "");

            return GuidString;
        }

        public override string ToString()
        {
            return $"Department {this.Name} on {this.Address} - {this.employees.Count} Workers.";
        }

        public List<Employee> GetAllEmployees()
        {
            List<Employee> employeesToSend;
            using (MySqlConnection con = SqlConnectionHandler.GetSqlConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand($"SELECT userID FROM users WHERE departmentID=@departmentID", con))
                {
                    cmd.Parameters.AddWithValue("@departmentID", this.DepartmentId);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    employeesToSend = new List<Employee>();

                    while (dataReader.Read())
                    {
                        Employee newEmp = new Employee(dataReader.GetString(0), true);
                        if (newEmp.FirstName != null && newEmp.FirstName.Length > 0) newEmp.MainDetails = $"{newEmp.FirstName} {newEmp.LastName} ({this.Name})";
                        else newEmp.MainDetails = $"{newEmp.Username} ({this.Name})";
                        employeesToSend.Add(newEmp);
                    }
                    cmd.Dispose();
                    dataReader.Close();
                }
                con.Close();
            }
            return employeesToSend;
        }

        public Employee GetEmployee(string userID)
        {
            foreach(Employee employee in Employees)
            {
                if (employee.UserID == userID) return employee;
            }
            return null;
        }

        public static List<Employee> GetEmployeesFromDepartmentID(string depID)
        {
            List<Employee> employeesToSend;
            using (MySqlConnection con = SqlConnectionHandler.GetSqlConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand($"SELECT u.userID, d.name FROM users as u INNER JOIN department as d ON u.departmentID = d.departmentID WHERE d.departmentID=@departmentID", con))
                {
                    cmd.Parameters.AddWithValue("@departmentID", depID);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    employeesToSend = new List<Employee>();

                    while (dataReader.Read())
                    {
                        Employee newEmp = new Employee(dataReader.GetString(0), true);
                        if (newEmp.FirstName != null && newEmp.FirstName.Length > 0) newEmp.MainDetails = $"{newEmp.FirstName} {newEmp.LastName} ({dataReader.GetString(1)})";
                        else newEmp.MainDetails = $"{newEmp.Username} ({dataReader.GetString(1)})";
                        employeesToSend.Add(newEmp);
                    }
                    cmd.Dispose();
                    dataReader.Close();
                }
                con.Close();
            }
            return employeesToSend;
        }

        public void RemoveEmployee(string userID)
        {
            bool atleastOneWorking = (employees.Count > 1) ? true : false;

            if (atleastOneWorking)
            {
                foreach (Employee e in employees)
                    if (e.UserID == userID)
                    {
                        e.RemoveFromDatabase();
                        employees.Remove(e);
                        break;
                    }
            } else {
                throw new MinimalEmployeesException("You must always have one employee in a department!"); }
        }

        public void RemoveFromDatabase()
        {
            if (employees.Count == 0) 
            {
                using (MySqlConnection con = SqlConnectionHandler.GetSqlConnection())
                {

                    //First we clear the employees in the department that were not previously moved, then we delete the actual department

                    using (MySqlCommand cmd = new MySqlCommand($"DELETE FROM stock WHERE departmentID=@departmentID", con))
                    {
                        cmd.Parameters.AddWithValue("@departmentID", this.DepartmentId);
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                    //Then we delete all stocks of the current department
                    using (MySqlCommand cmd = new MySqlCommand($"DELETE FROM department WHERE departmentID=@departmentID", con))
                    {
                        cmd.Parameters.AddWithValue("@departmentID", this.DepartmentId);
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                    con.Close();
                }
            }
            else throw new MinimalEmployeesException("You still have employees in this department!");
        }
        
        public static List<Department> GetAllDepartments()
        {
            List<Department> allDepartments = new List<Department>();
            using (MySqlConnection con = SqlConnectionHandler.GetSqlConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand($"SELECT departmentID FROM department", con))
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        allDepartments.Add(new Department(dataReader.GetString(0),true));
                    }
                    cmd.Dispose();
                    dataReader.Close();
                }
                con.Close();
            }
            return allDepartments;
        }

        public void AssignEmployeeTo(string userID, string newDepartmentId)
        {
            foreach (Employee e in Employee.GetAllEmployees(true))
                if (e.UserID == userID)
                    e.DepartmentID = newDepartmentId;
        }

        public int CompareTo(Department other)
        {
            if (String.Compare(this.Name, other.Name) < 0) return -1;
            else if (String.Compare(this.Name, other.Name) > 0) return 1;
            return 0;
        }
    }
    #endregion
}
