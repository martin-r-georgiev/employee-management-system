using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data.MySqlClient;
using Sem2IntroProjectWaterfall0._1;

namespace ProjectWaterfallUnitTests
{
    [TestClass]
    public class EmployeeTesting
    {
        private string username = "test";
        private string password = "test";
        private string userID = "";
        private decimal salaryHourlyRate = 10;
        private Role role = Role.Worker;
        private string firstName = "test";
        private string lastName = "test";
        private string nationality = "test";
        private string address = "test" ;
        private string email = "test@abv.bg";
        private string phoneNumber = "123456789";
        private int workHours = 40;
        private DateTime dateofBirth = new DateTime(2000,1,1);
        private bool sex = true;
        private string depID = "cOAyYEYI90OPfEfVhXAHVA";
        private decimal salary = 4;

        void DeleteTestEmployee(string testUserId)
        {
            using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand($"DELETE FROM employees WHERE userID=@userID", conn))
                {
                    cmd.Parameters.AddWithValue("@userID", testUserId);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }

                using (MySqlCommand cmd = new MySqlCommand($"DELETE FROM users WHERE userID=@userID", conn))
                {
                    cmd.Parameters.AddWithValue("@userID", testUserId);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                conn.Close();
            }
        }
        [TestMethod]
        public void CreateEmployeeTest()
        {
            Employee testEmployee = new Employee(username, password, salaryHourlyRate, role, depID, workHours);

            Assert.AreEqual(username, testEmployee.Username);
            Assert.AreEqual(salaryHourlyRate, testEmployee.SalaryHourlyRate);
            Assert.AreEqual(role, testEmployee.Role);
            Assert.AreEqual(depID, testEmployee.DepartmentID);
            Assert.AreEqual(workHours, testEmployee.WorkHours);
            Assert.AreEqual(DateTime.Now.Date, testEmployee.StartDate);

            testEmployee.RemoveFromDatabase();
        }

        [TestMethod]
        public void AddFirstNameTest()
        {
            Employee testEmployee = new Employee(username, password, salaryHourlyRate, role, depID, workHours);
            testEmployee.FirstName = firstName;

            Assert.AreEqual(firstName, testEmployee.FirstName);

            testEmployee.RemoveFromDatabase();
        }
        [TestMethod]
        public void AddLastNameTest()
        {
            Employee testEmployee = new Employee(username, password, salaryHourlyRate, role, depID, workHours);
            testEmployee.LastName = lastName;

            Assert.AreEqual(lastName, testEmployee.LastName);

            testEmployee.RemoveFromDatabase();
        }
        [TestMethod]
        public void AddNationalityTest()
        {
            Employee testEmployee = new Employee(username, password, salaryHourlyRate, role, depID, workHours);
            testEmployee.Nationality = nationality;

            Assert.AreEqual(nationality, testEmployee.Nationality);

            testEmployee.RemoveFromDatabase();
        }
        [TestMethod]
        public void AddAddressTest()
        {
            Employee testEmployee = new Employee(username, password, salaryHourlyRate, role, depID, workHours);
            testEmployee.Address = address;

            Assert.AreEqual(address, testEmployee.Address);

            testEmployee.RemoveFromDatabase();
        }
        [TestMethod]
        public void AddEmailTest()
        {
            Employee testEmployee = new Employee(username, password, salaryHourlyRate, role, depID, workHours);
            testEmployee.Email = email;

            Assert.AreEqual(email, testEmployee.Email);

            testEmployee.RemoveFromDatabase();
        }
        [TestMethod]
        public void AddPhoneTest()
        {
            Employee testEmployee = new Employee(username, password, salaryHourlyRate, role, depID, workHours);
            testEmployee.PhoneNumber = phoneNumber;

            Assert.AreEqual(phoneNumber, testEmployee.PhoneNumber);

            testEmployee.RemoveFromDatabase();
        }
        [TestMethod]
        public void AddDateOfBirthTest()
        {
            Employee testEmployee = new Employee(username, password, salaryHourlyRate, role, depID, workHours);
            testEmployee.DateOfBirth = dateofBirth;

            Assert.AreEqual(dateofBirth, testEmployee.DateOfBirth);

            testEmployee.RemoveFromDatabase();
        }
        [TestMethod]
        public void CheckNameNoPersonalDetailsTest()
        {
            Employee testEmployee = new Employee(username, password, salaryHourlyRate, role, depID, workHours);
            

            Assert.AreEqual(username, testEmployee.Name);

            testEmployee.RemoveFromDatabase();
        }
        [TestMethod]
        public void CheckNameWithPersonalDetailsTest()
        {
            Employee testEmployee = new Employee(username, password, salaryHourlyRate, role, depID, workHours);
            testEmployee.FirstName = firstName;
            testEmployee.LastName = lastName;

            Assert.AreEqual($"{firstName} {lastName} ({username})", testEmployee.Name);

            testEmployee.RemoveFromDatabase();
        }
        [TestMethod]
        public void SetPersonalInfoTest()
        {
            Employee testEmployee = new Employee(username, password, salaryHourlyRate, role, depID, workHours);
            testEmployee.SetPersonalInfo(firstName, lastName, dateofBirth, sex);
            testEmployee = new Employee(testEmployee.UserID, true);
            Assert.AreEqual(firstName, testEmployee.FirstName);
            Assert.AreEqual(lastName, testEmployee.LastName);
            Assert.AreEqual(dateofBirth, testEmployee.DateOfBirth);
            Assert.AreEqual(sex, testEmployee.Sex);

            testEmployee.RemoveFromDatabase();
        }
        [TestMethod]
        public void SetAllPersonalInfoTest()
        {
            Employee testEmployee = new Employee(username, password, salaryHourlyRate, role, depID, workHours);
            testEmployee.SetPersonalInfo(firstName, lastName, nationality, address, email, phoneNumber, dateofBirth, sex, salary);
            testEmployee = new Employee(testEmployee.UserID, true);

            Assert.AreEqual(firstName, testEmployee.FirstName);
            Assert.AreEqual(lastName, testEmployee.LastName);
            Assert.AreEqual(dateofBirth, testEmployee.DateOfBirth);
            Assert.AreEqual(sex, testEmployee.Sex);
            Assert.AreEqual(nationality, testEmployee.Nationality);
            Assert.AreEqual(address, testEmployee.Address);
            Assert.AreEqual(phoneNumber, testEmployee.PhoneNumber);
            Assert.AreEqual(salary, testEmployee.SalaryHourlyRate);

            testEmployee.RemoveFromDatabase();
        }
        [TestMethod]
        public void TakeCreatedEmployeeNoFullDetailsTest()
        {
            Employee testEmployee = new Employee(username, password, salaryHourlyRate, role, depID, workHours);
            Employee takenEmployee = new Employee(testEmployee.UserID, false);

            Assert.AreEqual(username, takenEmployee.Username);
            Assert.AreEqual(role, takenEmployee.Role);
            Assert.AreEqual(depID, takenEmployee.DepartmentID);
            Assert.AreEqual(testEmployee.FirstName, takenEmployee.FirstName);
            Assert.AreEqual(testEmployee.LastName, takenEmployee.LastName);

            testEmployee.RemoveFromDatabase();
        }
        [TestMethod]
        public void TakeCreatedEmployeeFullDetailsTest()
        {
            Employee testEmployee = new Employee(username, password, salaryHourlyRate, role, depID, workHours); //object without personal data
            testEmployee.SetPersonalInfo(firstName, lastName, nationality, address, email, phoneNumber, dateofBirth, sex, salary); // This only sets the values in the DB, does not give them in the employee object
            Employee takenEmployee = new Employee(testEmployee.UserID, true); //object with personal data

            Assert.AreEqual(username, takenEmployee.Username);
            Assert.AreEqual(role, takenEmployee.Role);
            Assert.AreEqual(depID, takenEmployee.DepartmentID);
            Assert.AreNotEqual(testEmployee.FirstName, takenEmployee.FirstName);
            Assert.AreNotEqual(testEmployee.LastName, takenEmployee.LastName);
            Assert.AreEqual(firstName, takenEmployee.FirstName) ;
            Assert.AreEqual(lastName, takenEmployee.LastName);
            Assert.AreEqual(nationality, takenEmployee.Nationality);
            Assert.AreEqual(salaryHourlyRate, takenEmployee.SalaryHourlyRate);
            Assert.AreEqual(address, takenEmployee.Address);
            Assert.AreEqual(email, takenEmployee.Email);
            Assert.AreEqual(phoneNumber, takenEmployee.PhoneNumber);
            Assert.AreEqual(workHours, takenEmployee.WorkHours);
            Assert.AreEqual(salary, takenEmployee.SalaryHourlyRate);


            testEmployee.RemoveFromDatabase();
        }
        [TestMethod]
        public void RemoveEmployeeTest()
        {
            Employee testEmployee = new Employee(username, password, salaryHourlyRate, role, depID, workHours);
            testEmployee.RemoveFromDatabase();
            testEmployee = new Employee(testEmployee.UserID, true);
            Assert.AreEqual(null, testEmployee.Username);
            Assert.AreEqual(0, testEmployee.SalaryHourlyRate);
            Assert.AreEqual(null, testEmployee.DepartmentID);
            Assert.AreEqual(0, testEmployee.WorkHours);
            Assert.AreEqual(null, testEmployee.StartDate);
        }
        [TestMethod]
        public void StaticRemoveEmployeeTest()
        {
            Employee testEmployee = new Employee(username, password, salaryHourlyRate, role, depID, workHours);
            Employee.RemoveFromDatabase(testEmployee.UserID);
            testEmployee = new Employee(testEmployee.UserID, true);
            Assert.AreEqual(null, testEmployee.Username);
            Assert.AreEqual(0, testEmployee.SalaryHourlyRate);
            Assert.AreEqual(null, testEmployee.DepartmentID);
            Assert.AreEqual(0, testEmployee.WorkHours);
            Assert.AreEqual(null, testEmployee.StartDate);
        }
        int GetAllEmployeesCount()
        {
            int employeeCount = 0;

            using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand($"SELECT userID FROM users", conn))
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        employeeCount++;
                    }
                    cmd.Dispose();
                    dataReader.Close();
                }
                conn.Close();

            }
            return employeeCount;
        }
        [TestMethod]
        public void GetAllEmployeesWithoutFullDetailsTest()
        {
            int employeeCount = GetAllEmployeesCount();
            List<Employee> allEmployees = Employee.GetAllEmployees(false);
            Assert.AreEqual(employeeCount, allEmployees.Count);
        }
        [TestMethod]
        public void GetAllEmployeesWithFullDetailsTest()
        {
            int employeeCount = GetAllEmployeesCount();
            List<Employee> allEmployees = Employee.GetAllEmployees(true);
            Assert.AreEqual(employeeCount, allEmployees.Count);

        }
        [TestMethod]
        public void TestIsUniqueUsername()
        {
            Employee testEmployee = new Employee(username, password, salaryHourlyRate, role, depID, workHours);
            Assert.AreEqual(false, Employee.IsUniqueUsername(username));
            testEmployee.RemoveFromDatabase();
        }
        [TestMethod]
        public void CalculateWorkingSinceTest()
        {
            Employee testEmployee = new Employee(username, password, salaryHourlyRate, role, depID, workHours);
            Assert.AreEqual("Working since: 0 days", Employee.CalculateWorkingSince(testEmployee));
            testEmployee.RemoveFromDatabase();
        }
    }
}
