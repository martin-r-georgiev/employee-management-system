using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data.MySqlClient;
using MediaBazaarApplicationWPF;


namespace MBApplicationUnitTesting
{
    [TestClass]
    public class DepartmentTesting
    {
        // department data
        private readonly string departmentID="UNIT_TEST_DEPID";
        private readonly string name="UNIT_TEST_NAME";
        private readonly string address="UNIT_TEST_ADRESS";

        //employee data
        private readonly string username="UNIT_TEST_USERNAME";
        private readonly string password="UNIT_TEST_PASSWORD";
        private readonly string userID="UNIT_TEST_ID";
        private readonly decimal salaryHourlyRat=10;
        private readonly EmployeeRole role=EmployeeRole.Worker;
        private readonly string firstName="UNIT_TEST_FNAME";
        private readonly string lastName="UNIT_TEST_LNAME";
        private readonly string nationality="UNIT_TEST_NATIONALITY";
        private readonly string addressemp="UNIT_TEST_ADRESS";
        private readonly string email="UNIT_TEST_EMAIL";
        private readonly string phoneNumber="UNIT_TEST_PHONE";
        private readonly int workHours=16;
        private readonly DateTime dateofBirth= new DateTime(2000, 1, 1);
        private readonly bool sex=true;
        private readonly string depID= "UNIT_TEST_DEPID";


        [TestMethod]
        public void CreateDepartmentTest()
        {
            //Arrange
            Department Test = new Department(name, address, departmentID);

            //Assert
            Assert.AreEqual(name, Test.Name);
            Assert.AreEqual(address, Test.Address);
            Assert.AreEqual(departmentID, Test.DepartmentId);

        }
        [TestMethod]
        public void ChangeAdressTest()
        {
            //Arrange
            const  string new_adress = "NEWADRESSTEST";
            Department Test = new Department(name, address, departmentID);
            Test.Address = new_adress;
            //Assert
            Assert.AreEqual(new_adress, Test.Address);

        }

        [TestMethod]
        public void ChangeNameTest()
        {
            //Arrange
            const string new_name = "NEWNAMETEST";
            Department Test = new Department(name, address, departmentID);
            Test.Name = new_name;
            //Assert
            Assert.AreEqual(new_name, Test.Name);
         

        }
        [TestMethod]
        public void ChangeDepIDTest()
        {
            //Arrange
            const string new_depID = "NEWDEPID";
            Department Test = new Department(name, address, departmentID);
            Test.DepartmentId = new_depID;
            //Assert
        
            Assert.AreEqual(new_depID, Test.DepartmentId);

        }
        [TestMethod]
        public void ToStringTest()
        {
            //Arrange
            
            Department Test = new Department(name, address, departmentID);

            //Assert
            string toString = Test.ToString();
            Assert.AreEqual("UNIT_TEST_NAME on UNIT_TEST_ADRESS", toString);

        }

        /*
        [TestMethod] //bugged 
        public void AssignEmployeeandGetEmployeeTest()
        {
            //Arrange

            Department Test = new Department(name, address, departmentID);
            Department Test2 = new Department("name2", "adress2", "id2");
            Employee TestEmplyoee = new Employee(userID,username,password,salaryHourlyRat,role,departmentID,workHours,false);
            Test.AssignEmployeeTo(TestEmplyoee, "id2");

            Employee AssignedEmplyoee = Test2.GetEmployee(userID);

            //Assert
            

            Assert.AreEqual(TestEmplyoee.UserID,AssignedEmplyoee.UserID);

            EmployeeDatabaseHandler.RemoveFromDatabase(userID);
        }*/ 

        [TestMethod]
        public void RemoveEmployeeTest()
        {
            //Arrange

            Department Test = new Department(name, address, departmentID);
            Employee TestEmplyoee = new Employee(userID, username, password, salaryHourlyRat, role, departmentID, workHours, false);
            Employee TestEmplyoee2 = new Employee("TEST_ID_2", username, password, salaryHourlyRat, role, departmentID, workHours, false);
            Test.AssignEmployeeTo(TestEmplyoee, departmentID);
            Test.AssignEmployeeTo(TestEmplyoee2, departmentID);
            Test.RemoveEmployee(userID);
            Employee AssignedEmplyoee = Test.GetEmployee(userID);

            //Assert


            Assert.IsNull(AssignedEmplyoee);

            EmployeeDatabaseHandler.RemoveFromDatabase(userID);
            EmployeeDatabaseHandler.RemoveFromDatabase("TEST_ID_2");

        }

    }
    [TestClass]
    public class DepartmentHandlingTesting
    {
        private readonly string departmentID = "UNIT_TEST_DEPID";
        private readonly string name = "UNIT_TEST_NAME";
        private readonly string address = "UNIT_TEST_ADRESS";

        [TestMethod]
        public void CreateDepartmentDatabaseTest()
        {
            //Arrange
            Department Test = new Department(name, address, departmentID);
            DepartmentDatabaseHandler.InsertToDB(Test);

            Department FromDatabase = DepartmentManager.GetDepartment(departmentID, false);
            //Assert
            Assert.AreEqual(Test.DepartmentId, FromDatabase.DepartmentId);
            DepartmentManager.RemoveFromDatabase(Test);
        }

        [TestMethod]
        public void UpdateDepartmentTest()
        {
            //Arrange
            Department Test = new Department(name, address, departmentID);
            DepartmentDatabaseHandler.InsertToDB(Test);
            Test.Address = "newAddress";
            Test.Name = "newName";
            DepartmentManager.UpdateDepartment(departmentID, "newName", "newAddress");
            Department FromDatabase = DepartmentManager.GetDepartment(departmentID, false);
            DepartmentManager.GetAllDepartments(true);
            //Assert
            Assert.AreEqual(Test.DepartmentId, FromDatabase.DepartmentId);
            Assert.AreEqual(Test.Name, FromDatabase.Name);
            Assert.AreEqual(Test.Address, FromDatabase.Address);
            DepartmentManager.RemoveFromDatabase(departmentID);
        }

        [TestMethod]
        public void IsUniqueDepartmentTest()
        {
            //Arrange
            Department Test = new Department(name, address, departmentID);
            DepartmentDatabaseHandler.InsertToDB(Test);
            bool unique = DepartmentDatabaseHandler.IsUniqueDepartment(name);

            //Assert
            Assert.AreEqual(false, unique);
            DepartmentManager.RemoveFromDatabase(Test);
        }

        [TestMethod]
        public void GetDepartmentDatabaseHandlerTest()
        {
            //Arrange
            Department Test = new Department(name, address, departmentID);
            DepartmentDatabaseHandler.InsertToDB(Test);
            DepartmentDatabaseHandler.GetAllDepartmentsMinimalInformation();

            Department FromDatabase = DepartmentDatabaseHandler.GetDepartment(departmentID);
            //Assert
            Assert.AreEqual(Test.DepartmentId, FromDatabase.DepartmentId);
            DepartmentManager.RemoveFromDatabase(Test);
        }

        [TestMethod]
        public void GetUsersForDepartmentTest()
        {
            //Arrange
            Department Test = new Department(name, address, departmentID);
            DepartmentDatabaseHandler.InsertToDB(Test);
            DepartmentManager.GetAllDepartments(false);
            Department FromDatabase = DepartmentDatabaseHandler.GetUsersForDepartment(Test);
            //Assert
            Assert.AreEqual(0,FromDatabase.Employees.Count());
            DepartmentManager.RemoveFromDatabase(Test);
        }
     

        [TestMethod]
        public void GetUsersFromDepIDTest()
        {
            //Arrange
            Department Test = new Department(name, address, departmentID);
            DepartmentDatabaseHandler.InsertToDB(Test);

            List<Employee> FromDatabase = DepartmentDatabaseHandler.GetEmployeesFromDepartmentID(departmentID);
            //Assert
            Assert.AreEqual(0,FromDatabase.Count());
            DepartmentManager.RemoveFromDatabase(Test);
        }

        [TestMethod]
        public void RemoveDepDatabaseHandlerTest()
        {
            //Arrange
            Department Test = new Department(name, address, departmentID);
            DepartmentDatabaseHandler.InsertToDB(Test);
            DepartmentDatabaseHandler.RemoveDepartment(departmentID);
            Department FromDatabase = DepartmentDatabaseHandler.GetDepartment(departmentID);
           
            //Assert
            Assert.IsNull(FromDatabase);
            DepartmentManager.RemoveFromDatabase(Test);
        }

        [TestMethod]
        public void UpdateDepartmentDataDatabaseHandlerTest()
        {
            Department Test = new Department(name, address, departmentID);
            DepartmentDatabaseHandler.InsertToDB(Test);
            DepartmentDatabaseHandler.GetAllDepartments();
            Test.Address = "newAddress";
            Test.Name = "newName";
            DepartmentDatabaseHandler.UpdateDepartmentData(departmentID, "newName", "newAddress");
            Department FromDatabase = DepartmentManager.GetDepartment(departmentID, false);
            //Assert
            Assert.AreEqual(Test.DepartmentId, FromDatabase.DepartmentId);
            Assert.AreEqual(Test.Name, FromDatabase.Name);
            Assert.AreEqual(Test.Address, FromDatabase.Address);
            DepartmentManager.RemoveFromDatabase(departmentID);
        }

        [TestMethod]
        public void IsUniqueIDNotCrashTest()
        {
            string uniqueID=DepartmentDatabaseHandler.GenerateUniqueID();
           
        }

     
    }
}
