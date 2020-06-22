using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApplicationWPF
{
    public static class DepartmentDatabaseHandler
    {
        public static void InsertToDB(Department department)
        {
            if (!IsUniqueDepartment(department.Name)) throw new ArgumentException("Department name is taken!");

            using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
            {
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand($"INSERT INTO department (departmentID, name, address) VALUES (@departmentID, @name, @address)", conn))
                    {
                        cmd.Parameters.AddWithValue("@departmentID", department.DepartmentId);
                        cmd.Parameters.AddWithValue("@name", department.Name);
                        cmd.Parameters.AddWithValue("@address", department.Address);
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                finally { conn.Close(); }
            }
        }

        public static bool IsUniqueDepartment(string name)
        {
            bool result = true;
            using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
            {
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand($"SELECT name FROM department WHERE name=@name", conn))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        MySqlDataReader dataReader = cmd.ExecuteReader();
                        if (dataReader.Read()) result = false;
                        dataReader.Close();
                        cmd.Dispose();
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                finally { conn.Close(); }
            }
            return result;
        }

        public static string GenerateUniqueID()
        {
            string depId = null;
            using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
            {
                try
                {
                    MySqlCommand cmd;
                    MySqlDataReader dataReader;

                    //Checking if auto-generated depId already exists in database
                    do
                    {
                        depId = GenerateDepartmentID();
                        cmd = new MySqlCommand($"SELECT departmentID FROM department WHERE departmentID=@departmentID", conn);
                        cmd.Parameters.AddWithValue("@departmentID", depId);
                        dataReader = cmd.ExecuteReader();
                    }
                    while (dataReader.Read());
                    dataReader.Close();
                    cmd.Dispose();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                finally { conn.Close(); }
            }
            return depId;
        }

        private static string GenerateDepartmentID()
        {
            Guid key = Guid.NewGuid();
            string GuidString = Convert.ToBase64String(key.ToByteArray());
            GuidString = GuidString.Replace("=", "");
            GuidString = GuidString.Replace("+", "");
            GuidString = GuidString.Replace("/", "");

            return GuidString;
        }

        public static Department GetDepartment(string DepartmentId)
        {
            Department newDep = null;
            using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
            {
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand($"SELECT name, address FROM department WHERE departmentID=@departmentID", conn))
                    {
                        cmd.Parameters.AddWithValue("@departmentID", DepartmentId);
                        MySqlDataReader dataReader = cmd.ExecuteReader();

                        if (dataReader.Read())
                        {
                            string name = dataReader.GetString(0);
                            string address = dataReader.GetString(1);
                            newDep = new Department(name, address, DepartmentId);
                        }
                        dataReader.Close();
                        cmd.Dispose();
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                finally { conn.Close(); }
            }
            return newDep;
        }

        public static Department GetUsersForDepartment(Department dep)
        {
            using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
            {
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand($"SELECT userID FROM users WHERE departmentID=@departmentID", conn))
                    {
                        cmd.Parameters.AddWithValue("@departmentID", dep.DepartmentId);
                        MySqlDataReader dataReader = cmd.ExecuteReader();

                        while (dataReader.Read())
                        {
                            Employee newEmp = EmployeeDatabaseHandler.GetEmployee(dataReader.GetString(0), true);
                            dep.Employees.Add(newEmp);
                        }
                        dataReader.Close();
                        cmd.Dispose();
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                finally { conn.Close(); }
            }
            return dep;
        }

        public static List<Employee> GetEmployeesFromDepartmentID(string depID)
        {
            List<Employee> employeesToSend = new List<Employee>();
            using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
            {
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand($"SELECT u.userID, d.name FROM users as u INNER JOIN department as d ON u.departmentID = d.departmentID WHERE d.departmentID=@departmentID", conn))
                    {
                        cmd.Parameters.AddWithValue("@departmentID", depID);
                        MySqlDataReader dataReader = cmd.ExecuteReader();
                        employeesToSend = new List<Employee>();

                        while (dataReader.Read())
                        {
                            Employee newEmp = EmployeeDatabaseHandler.GetEmployee(dataReader.GetString(0), true);
                            employeesToSend.Add(newEmp);
                        }
                        dataReader.Close();
                        cmd.Dispose();
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                finally { conn.Close(); }
            }
            return employeesToSend;
        }

        public static void RemoveStockOfDepartment(string departmentID)
        {
            using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
            {
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand($"DELETE FROM stock WHERE departmentID=@departmentID", conn))
                    {
                        cmd.Parameters.AddWithValue("@departmentID", departmentID);
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                finally { conn.Close(); }
            }
        }

        public static void RemoveDepartment(string departmentID)
        {
            using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
            {
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand($"DELETE FROM department WHERE departmentID=@departmentID", conn))
                    {
                        cmd.Parameters.AddWithValue("@departmentID", departmentID);
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                finally { conn.Close(); }
            }
        }

        public static List<Department> GetAllDepartments()
        {
            List<Department> allDepartments = new List<Department>();
            using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
            {
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand($"SELECT departmentID FROM department", conn))
                    {
                        MySqlDataReader dataReader = cmd.ExecuteReader();
                        while (dataReader.Read())
                        {
                            allDepartments.Add(DepartmentManager.GetDepartment(dataReader.GetString(0), true));
                        }
                        dataReader.Close();
                        cmd.Dispose();
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                finally { conn.Close(); }
            }
            return allDepartments;
        }

        public static List<Department> GetAllDepartmentsMinimalInformation()
        {
            List<Department> allDepartments = new List<Department>();
            using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
            {
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand($"SELECT name, address, departmentID FROM department", conn))
                    {
                        MySqlDataReader dataReader = cmd.ExecuteReader();
                        while (dataReader.Read())
                        {
                            allDepartments.Add(new Department(dataReader.GetString(0), dataReader.GetString(1), dataReader.GetString(2)));
                        }
                        dataReader.Close();
                        cmd.Dispose();       
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                finally { conn.Close(); }
            }
            return allDepartments;
        }

        public static void UpdateDepartmentData(string departmentID, string newName, string newAddress)
        {
            using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
            {
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand($"UPDATE department SET name=@name, address=@address WHERE departmentID=@departmentID", conn))
                    {
                        cmd.Parameters.AddWithValue("@name", newName);
                        cmd.Parameters.AddWithValue("@address", newAddress);
                        cmd.Parameters.AddWithValue("@departmentId", departmentID);
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
