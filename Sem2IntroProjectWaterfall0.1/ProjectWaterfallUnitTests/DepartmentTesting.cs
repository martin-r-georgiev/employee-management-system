using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data.MySqlClient;
using Sem2IntroProjectWaterfall0._1;

namespace ProjectWaterfallUnitTests
{
    [TestClass]
    public class DepartmentTesting
    {
        private string name = "test";
        private string address = "test";

        [TestMethod]
        public void CreateDepartmentTest()
        {
            Department testDep = new Department(name, address);
            Assert.AreEqual(name, testDep.Name);
            Assert.AreEqual(address, testDep.Address);

            testDep.RemoveFromDatabase();
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidEntryException))]
        public void CreateDepartmentInvalidNameTest()
        {
            Department testDep = new Department("", address);
            testDep.RemoveFromDatabase();
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidEntryException))]
        public void CreateDepartmentInvalidAddressTest()
        {
            Department testDep = new Department(name, "");
            testDep.RemoveFromDatabase();
        }
        [TestMethod]
        public void GetDepartmentFromDBWithoutEmpListTest()
        {
            Department testDep = new Department(name, address);
            testDep = new Department(testDep.DepartmentId, false);

            Assert.AreEqual(name, testDep.Name);
            Assert.AreEqual(address, testDep.Address);

            testDep.RemoveFromDatabase();
        }
        int GetEmployeesCount(string depId)
        {
            int employeeCount = 0;
            using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand($"SELECT userID FROM users  WHERE departmentID=@departmentID", conn))
                {
                    cmd.Parameters.AddWithValue("@departmentID", depId);
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
        public void GetDepartmentFromDBWithEmpListTest()
        {
            Department testDep = new Department(name, address);
            testDep = new Department(testDep.DepartmentId, true);
            int empCount = GetEmployeesCount(testDep.DepartmentId);

            Assert.AreEqual(name, testDep.Name);
            Assert.AreEqual(address, testDep.Address);
            Assert.AreEqual(empCount, testDep.Employees.Count);

            testDep.RemoveFromDatabase();
        }
        [TestMethod]
        public void DepartmentToStringTest()
        {
            Department testDep = new Department(name, address);
            Assert.AreEqual($"Department {name} on {address} - 0 Workers.", testDep.ToString());

            testDep.RemoveFromDatabase();
        }
        [TestMethod]
        public void DepartmentGetAllEmployeesTest()
        {
            Department testDep = new Department(name, address);
            int empCount = GetEmployeesCount(testDep.DepartmentId);

            Assert.AreEqual(empCount, testDep.GetAllEmployees().Count);
            
            testDep.RemoveFromDatabase();
        }
        [TestMethod]
        public void DepartmentGetEmployeesFromDptTest()
        {
            Department testDep = new Department(name, address);
            int empCount = GetEmployeesCount(testDep.DepartmentId);

            Assert.AreEqual(empCount, Department.GetEmployeesFromDepartmentID(testDep.DepartmentId).Count);

            testDep.RemoveFromDatabase();
        }
        [TestMethod]
        public void GetEmployeeTest()
        {
            Department testDep = new Department(name, address);
            Employee testEmp = new Employee("test", "test", 10, Role.Worker, testDep.DepartmentId, 40);
            testDep = new Department(testDep.DepartmentId, true);
            Employee checkEmp = testDep.GetEmployee(testEmp.UserID);

            Assert.AreEqual(testEmp.Username, checkEmp.Username);
            Assert.AreEqual(testEmp.DepartmentID, checkEmp.DepartmentID);
            testEmp.RemoveFromDatabase();
            testDep = new Department(testDep.DepartmentId, true);
            testDep.RemoveFromDatabase();
        }
        [TestMethod]
        public void RemoveEmployeeTest()
        {
            Department testDep = new Department(name, address);
            Employee testEmp = new Employee("test", "test", 10, Role.Worker, testDep.DepartmentId, 40);
            Employee testEmp2 = new Employee("test2", "test2", 10, Role.Worker, testDep.DepartmentId, 40);
            testDep = new Department(testDep.DepartmentId, true);
            testDep.RemoveEmployee(testEmp.UserID);
            int empCount = GetEmployeesCount(testDep.DepartmentId);

            Assert.AreEqual(empCount, testDep.Employees.Count);

            testEmp2.RemoveFromDatabase();
            testDep = new Department(testDep.DepartmentId, true);
            testDep.RemoveFromDatabase();
        }
        [TestMethod]
        [ExpectedException(typeof(MinimalEmployeesException))]
        public void RemoveEmployeeWithNoEmployeesInDptTest()
        {
            Department testDep = new Department(name, address);
            try
            {
                testDep.RemoveEmployee("blabla");
            }
            finally
            {
                testDep.RemoveFromDatabase();
            }
        }
        [TestMethod]
        public void RemoveFromDBTest()
        {
            Department testDep = new Department(name, address);
            testDep.RemoveFromDatabase();
            testDep = new Department(testDep.DepartmentId, true);

            Assert.AreNotEqual(name, testDep.Name);
            Assert.AreNotEqual(address, testDep.Address);
        }
        [TestMethod]
        [ExpectedException(typeof(MinimalEmployeesException))]
        public void RemoveFromDBWithEmployeesInDptTest()
        {
            Department testDep = new Department(name, address);
            Employee testEmp = new Employee("test", "test", 10, Role.Worker, testDep.DepartmentId, 40);
            testDep = new Department(testDep.DepartmentId, true);
            try
            {
                testDep.RemoveFromDatabase();
            }
            finally
            {
                testEmp.RemoveFromDatabase();
                testDep = new Department(testDep.DepartmentId, true);
                testDep.RemoveFromDatabase();
            }
        }
        int GetDptCount()
        {
            int dptCount = 0;
           
            using (MySqlConnection con = SqlConnectionHandler.GetSqlConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand($"SELECT departmentID FROM department", con))
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        dptCount++;
                    }
                    cmd.Dispose();
                    dataReader.Close();
                }
                con.Close();
            }
            return dptCount;
        }
        [TestMethod]
        public void GetAllDptsTest()
        {
            int dptCount = GetDptCount();
            Assert.AreEqual(dptCount, Department.GetAllDepartments().Count);
        }
        [TestMethod]
        public void AssignEmployeeTest()
        {
            Department testDep = new Department(name, address);
            Employee testEmp = new Employee("test", "test", 10, Role.Worker, testDep.DepartmentId, 40);
            Department testDep2 = new Department("test2", "address2");
            testDep = new Department(testDep.DepartmentId, true);
            testDep.AssignEmployeeTo(testEmp.UserID, testDep2.DepartmentId);
            testDep = new Department(testDep.DepartmentId, true);
            testDep2 = new Department(testDep2.DepartmentId, true);

            int empCount1 = GetEmployeesCount(testDep.DepartmentId);
            int empCount2 = GetEmployeesCount(testDep2.DepartmentId);

            Assert.AreEqual(empCount1, testDep.Employees.Count);
            Assert.AreEqual(empCount2, testDep2.Employees.Count);

            testEmp.RemoveFromDatabase();
            testDep.RemoveFromDatabase();
            testDep2 = new Department(testDep2.DepartmentId, true);
            testDep2.RemoveFromDatabase();
        }
    }
}
