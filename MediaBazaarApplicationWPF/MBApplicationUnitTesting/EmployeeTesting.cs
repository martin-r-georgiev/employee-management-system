using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MediaBazaarApplicationWPF;
using System.Threading;

namespace MBApplicationUnitTesting
{
    [TestClass]
    public class CoreEmployeeTesting
    {
        private readonly string username;
        private readonly string password;
        private readonly string userID;
        private readonly decimal salaryHourlyRate;
        private readonly EmployeeRole role;
        private readonly string firstName;
        private readonly string lastName;
        private readonly string nationality;
        private readonly string address;
        private readonly string email;
        private readonly string phoneNumber;
        private readonly int workHours;
        private readonly DateTime dateofBirth;
        private readonly bool sex;
        private readonly string depID;

        public CoreEmployeeTesting()
        {
            this.username = "UnitTest";
            this.password = "UnitTest";
            this.userID = "UNIT_TEST_RESERVED";
            this.salaryHourlyRate = 10;
            this.role = EmployeeRole.Worker;
            this.firstName = "Test";
            this.lastName = "Dummy";
            this.nationality = "Test";
            this.address = "Test";
            this.email = "test@mediabazaar.nl";
            this.phoneNumber = "+31645889304";
            this.workHours = 16;
            this.dateofBirth = new DateTime(2000, 1, 1);
            this.sex = true;
            this.depID = "cOAyYEYI90OPfEfVhXAHVA";
        }

        [TestMethod]
        public void EmployeeInitializationTest()
        {
            // Arrange
            Employee employee = new Employee(userID, username, password, salaryHourlyRate, role, depID, workHours, false);

            // Assert
            Assert.AreEqual(userID, employee.UserID);
            Assert.AreEqual(username, employee.Username);
            Assert.AreEqual(password, employee.Password);
            Assert.AreEqual(salaryHourlyRate, employee.SalaryHourlyRate);
            Assert.AreEqual(role, employee.Role);
            Assert.AreEqual(depID, employee.DepartmentID);
            Assert.AreEqual(workHours, employee.WorkHours);
        }

        [TestMethod]
        public void EmployeeUsernameChangeTest()
        {
            // Arrange
            Employee employee = new Employee(userID, username, password, salaryHourlyRate, role, depID, workHours, false);
            const string NEW_USERNAME = "NewUsername";

            // Act
            employee.Username = NEW_USERNAME;

            // Assert
            Assert.AreEqual(NEW_USERNAME, employee.Username);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EmployeeInvalidUsernameChangeTest()
        {
            // Arrange
            Employee employee = new Employee(userID, username, password, salaryHourlyRate, role, depID, workHours, false);
            const string NEW_USERNAME = "InvalidNewUsername/";

            // Act
            employee.Username = NEW_USERNAME;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EmployeeNullUsernameChangeTest()
        {
            // Arrange
            Employee employee = new Employee(userID, username, password, salaryHourlyRate, role, depID, workHours, false);
            const string NEW_USERNAME = null;

            // Act
            employee.Username = NEW_USERNAME;
        }

        [TestMethod]
        public void EmployeePasswordChangeTest()
        {
            // Arrange
            Employee employee = new Employee(userID, username, password, salaryHourlyRate, role, depID, workHours, false);
            const string NEW_PASSWORD = "NewPassword";
            string NEW_PASSWORD_HASHED = HashManager.GetSha256(NEW_PASSWORD);

            // Act
            employee.Password = NEW_PASSWORD;

            // Assert
            Assert.AreEqual(NEW_PASSWORD_HASHED, employee.Password);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EmployeeInvalidPasswordChangeTest()
        {
            // Arrange
            Employee employee = new Employee(userID, username, password, salaryHourlyRate, role, depID, workHours, false);
            const string NEW_PASSWORD = "InvalidNewPassword/";

            // Act
            employee.Password = NEW_PASSWORD;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EmployeeNullPasswordChangeTest()
        {
            // Arrange
            Employee employee = new Employee(userID, username, password, salaryHourlyRate, role, depID, workHours, false);
            const string NEW_PASSWORD = null;

            // Act
            employee.Password = NEW_PASSWORD;
        }

        [TestMethod]
        public void EmployeeSalaryRateChangeTest()
        {
            // Arrange
            Employee employee = new Employee(userID, username, password, salaryHourlyRate, role, depID, workHours, false);
            const decimal NEW_SALARY_RATE = 15;

            // Act
            employee.SalaryHourlyRate = NEW_SALARY_RATE;

            // Assert
            Assert.AreEqual(NEW_SALARY_RATE, employee.SalaryHourlyRate);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EmployeeSalaryRateOutofRangeTest()
        {
            // Arrange
            Employee employee = new Employee(userID, username, password, salaryHourlyRate, role, depID, workHours, false);
            const decimal NEW_SALARY_RATE = -5;

            // Act
            employee.SalaryHourlyRate = NEW_SALARY_RATE;
        }

        [TestMethod]
        public void EmployeeFirstNameChangeTest()
        {
            // Arrange
            Employee employee = new Employee(userID, username, password, salaryHourlyRate, role, depID, workHours, false);
            const string NEW_FIRST_NAME = "John";

            // Act
            employee.FirstName = NEW_FIRST_NAME;

            // Assert
            Assert.AreEqual(NEW_FIRST_NAME, employee.FirstName);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EmployeeInvalidFirstNameChangeTest()
        {
            // Arrange
            Employee employee = new Employee(userID, username, password, salaryHourlyRate, role, depID, workHours, false);
            const string NEW_FIRST_NAME = "John101";

            // Act
            employee.FirstName = NEW_FIRST_NAME;

            // Assert
            Assert.AreEqual(NEW_FIRST_NAME, employee.FirstName);
        }

        [TestMethod]
        public void EmployeeNullFirstNameChangeTest()
        {
            // Arrange
            Employee employee = new Employee(userID, username, password, salaryHourlyRate, role, depID, workHours, false);
            const string NEW_FIRST_NAME = null;

            // Act
            employee.FirstName = NEW_FIRST_NAME;
            // Assert
            Assert.AreEqual(NEW_FIRST_NAME, employee.FirstName);
        }

        [TestMethod]
        public void EmployeeLastNameChangeTest()
        {
            // Arrange
            Employee employee = new Employee(userID, username, password, salaryHourlyRate, role, depID, workHours, false);
            const string NEW_LAST_NAME = "Doe";

            // Act
            employee.LastName = NEW_LAST_NAME;

            // Assert
            Assert.AreEqual(NEW_LAST_NAME, employee.LastName);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EmployeeInvalidLastNameChangeTest()
        {
            // Arrange
            Employee employee = new Employee(userID, username, password, salaryHourlyRate, role, depID, workHours, false);
            const string NEW_LAST_NAME = "Doe101";

            // Act
            employee.LastName = NEW_LAST_NAME;
        }

        [TestMethod]
        public void EmployeeNullLastNameChangeTest()
        {
            // Arrange
            Employee employee = new Employee(userID, username, password, salaryHourlyRate, role, depID, workHours, false);
            const string NEW_LAST_NAME = null;

            // Act
            employee.LastName = NEW_LAST_NAME;

            // Assert
            Assert.AreEqual(NEW_LAST_NAME, employee.LastName);
        }

        [TestMethod]
        public void EmployeeNationalityChangeTest()
        {
            // Arrange
            Employee employee = new Employee(userID, username, password, salaryHourlyRate, role, depID, workHours, false);
            const string NEW_NATIONALITY = "Polish";

            // Act
            employee.Nationality = NEW_NATIONALITY;

            // Assert
            Assert.AreEqual(NEW_NATIONALITY, employee.Nationality);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EmployeeInvalidNationalityChangeTest()
        {
            // Arrange
            Employee employee = new Employee(userID, username, password, salaryHourlyRate, role, depID, workHours, false);
            const string NEW_NATIONALITY = "Polish101";

            // Act
            employee.Nationality = NEW_NATIONALITY;
        }

        [TestMethod]
        public void EmployeeNullNationalityChangeTest()
        {
            // Arrange
            Employee employee = new Employee(userID, username, password, salaryHourlyRate, role, depID, workHours, false);
            const string NEW_NATIONALITY = null;

            // Act
            employee.Nationality = NEW_NATIONALITY;

            // Assert
            Assert.AreEqual(NEW_NATIONALITY, employee.Nationality);
        }

        [TestMethod]
        public void EmployeeAddressChangeTest()
        {
            // Arrange
            Employee employee = new Employee(userID, username, password, salaryHourlyRate, role, depID, workHours, false);
            const string NEW_ADDRESS = "Test Address 123";

            // Act
            employee.Address = NEW_ADDRESS;

            // Assert
            Assert.AreEqual(NEW_ADDRESS, employee.Address);
        }

        [TestMethod]
        public void EmployeeInvalidAddressChangeTest()
        {
            // Arrange
            Employee employee = new Employee(userID, username, password, salaryHourlyRate, role, depID, workHours, false);
            const string NEW_ADDRESS = "";

            // Act
            employee.Address = NEW_ADDRESS;

            // Assert
            Assert.AreEqual(NEW_ADDRESS, employee.Address);
        }

        [TestMethod]
        public void EmployeeNullAddressChangeTest()
        {
            // Arrange
            Employee employee = new Employee(userID, username, password, salaryHourlyRate, role, depID, workHours, false);
            const string NEW_ADDRESS = null;

            // Act
            employee.Address = NEW_ADDRESS;
        }

        [TestMethod]
        public void EmployeeEmailChangeTest()
        {
            // Arrange
            Employee employee = new Employee(userID, username, password, salaryHourlyRate, role, depID, workHours, false);
            const string NEW_EMAIL_ADDRESS = "new@mediabazaar.nl";

            // Act
            employee.Email = NEW_EMAIL_ADDRESS;

            // Assert
            Assert.AreEqual(NEW_EMAIL_ADDRESS, employee.Email);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EmployeeInvalidEmailChangeTest()
        {
            // Arrange
            Employee employee = new Employee(userID, username, password, salaryHourlyRate, role, depID, workHours, false);
            const string NEW_EMAIL_ADDRESS = "new@mediabazaar";

            // Act
            employee.Email = NEW_EMAIL_ADDRESS;
        }

        [TestMethod]
        public void EmployeeNullEmailChangeTest()
        {
            // Arrange
            Employee employee = new Employee(userID, username, password, salaryHourlyRate, role, depID, workHours, false);
            const string NEW_EMAIL_ADDRESS = null;

            // Act
            employee.Email = NEW_EMAIL_ADDRESS;

            //Assert
            Assert.AreEqual(NEW_EMAIL_ADDRESS, employee.Email);
        }

        [TestMethod]
        public void EmployeePhoneNumberChangeTest()
        {
            // Arrange
            Employee employee = new Employee(userID, username, password, salaryHourlyRate, role, depID, workHours, false);
            const string NEW_PHONE_NUMBER = "+31645000941";

            // Act
            employee.PhoneNumber = NEW_PHONE_NUMBER;

            // Assert
            Assert.AreEqual(NEW_PHONE_NUMBER, employee.PhoneNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EmployeeInvalidPhoneNumberChangeTest()
        {
            // Arrange
            Employee employee = new Employee(userID, username, password, salaryHourlyRate, role, depID, workHours, false);
            const string NEW_PHONE_NUMBER = "InvalidPhoneNumber";

            // Act
            employee.PhoneNumber = NEW_PHONE_NUMBER;
        }

        [TestMethod]
        public void EmployeeBirthDateChangeTest()
        {
            // Arrange
            Employee employee = new Employee(userID, username, password, salaryHourlyRate, role, depID, workHours, false);
            DateTime NEW_BIRTHDATE = new DateTime(2000, 1, 1);

            // Act
            employee.DateOfBirth = NEW_BIRTHDATE;

            // Assert
            Assert.AreEqual(NEW_BIRTHDATE, employee.DateOfBirth);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EmployeeInvalidBirthDateChangeTest()
        {
            // Arrange
            Employee employee = new Employee(userID, username, password, salaryHourlyRate, role, depID, workHours, false);
            DateTime NEW_BIRTHDATE = DateTime.Now.AddDays(1);

            // Act
            employee.DateOfBirth = NEW_BIRTHDATE;
        }

        [TestMethod]
        public void EmployeeWorkhoursChangeTest()
        {
            // Arrange
            Employee employee = new Employee(userID, username, password, salaryHourlyRate, role, depID, workHours, false);
            const int NEW_WORKHOURS = 24;

            // Act
            employee.WorkHours = NEW_WORKHOURS;

            // Assert
            Assert.AreEqual(NEW_WORKHOURS, employee.WorkHours);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EmployeeInvalidWorkhoursChangeTest()
        {
            // Arrange
            Employee employee = new Employee(userID, username, password, salaryHourlyRate, role, depID, workHours, false);
            const int NEW_WORKHOURS = 25;

            // Act
            employee.WorkHours = NEW_WORKHOURS;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EmployeeNegativeWorkhoursChangeTest()
        {
            // Arrange
            Employee employee = new Employee(userID, username, password, salaryHourlyRate, role, depID, workHours, false);
            const int NEW_WORKHOURS = -5;

            // Act
            employee.WorkHours = NEW_WORKHOURS;
        }

        [TestMethod]
        public void EmployeeAttendanceChangeTest()
        {
            // Arrange
            Employee employee = new Employee(userID, username, password, salaryHourlyRate, role, depID, workHours, false);
            const int NEW_ATTENDANCE = 50;

            // Act
            employee.Attendance = NEW_ATTENDANCE;

            // Assert
            Assert.AreEqual(NEW_ATTENDANCE, employee.Attendance);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EmployeeInvalidAttendanceChangeTest()
        {
            // Arrange
            Employee employee = new Employee(userID, username, password, salaryHourlyRate, role, depID, workHours, false);
            const int NEW_ATTENDANCE = -1;

            // Act
            employee.Attendance = NEW_ATTENDANCE;
        }

        [TestMethod]
        public void EmployeeSetPersonalInfoTest()
        {
            // Arrange
            Employee employee = new Employee(userID, username, password, salaryHourlyRate, role, depID, workHours, false);

            // Act
            employee.SetPersonalInfo(firstName, lastName, dateofBirth, sex);

            // Assert
            Assert.AreEqual(firstName, employee.FirstName);
            Assert.AreEqual(lastName, employee.LastName);
            Assert.AreEqual(dateofBirth, employee.DateOfBirth);
            Assert.AreEqual(sex, employee.Sex);
        }

        [TestMethod]
        public void EmployeeFullSetPersonalInfoTest()
        {
            // Arrange
            Employee employee = new Employee(userID, username, password, salaryHourlyRate, role, depID, workHours, false);

            // Act
            employee.SetPersonalInfo(firstName, lastName, nationality, address, email, phoneNumber, dateofBirth, sex);

            // Assert
            Assert.AreEqual(firstName, employee.FirstName);
            Assert.AreEqual(lastName, employee.LastName);
            Assert.AreEqual(nationality, employee.Nationality);
            Assert.AreEqual(address, employee.Address);
            Assert.AreEqual(email, employee.Email);
            Assert.AreEqual(phoneNumber, employee.PhoneNumber);
            Assert.AreEqual(dateofBirth, employee.DateOfBirth);
            Assert.AreEqual(sex, employee.Sex);
        }

        [TestMethod]
        public void EmployeeStartEndDateTest()
        {
            // Arrange
            Employee employee = new Employee(userID, username, password, salaryHourlyRate, role, depID, workHours, false);
            DateTime start = new DateTime(2000, 10, 10);
            DateTime end = new DateTime(2000, 11, 10);
            employee.EndDate = end;
            employee.StartDate = start;

            //Assert
            Assert.AreEqual(start, employee.StartDate);
            Assert.AreEqual(end, employee.EndDate);

        }
        [TestMethod]
        public void EmployeeTestFullName()
        {
            // Arrange
            Employee employee = new Employee(userID, username, password, salaryHourlyRate, role, depID, workHours, false);
            string FullName = employee.FullName;
            string expectedFullName = username;

            //Assert
            Assert.AreEqual(expectedFullName, FullName);
           
        }
        [TestMethod]
        public void EmployeeTestName()
        {
            // Arrange
            Employee employee = new Employee(userID, username, password, salaryHourlyRate, role, depID, workHours, false);
            employee.DepartmentName = "Test";
            string FullName = employee.Name;
            string expectedFullName = username+" (Test)";

            //Assert
            Assert.AreEqual(expectedFullName,FullName);

        }
    }

    [TestClass]
    public class EmployeeManagerTesting
    {
        EmployeeManager employeeManager;

        [TestInitialize]
        public void Initialize()
        {
            employeeManager = new EmployeeManager();
        }

        [TestMethod]
        public void AddEmployeeWithCredentialsTest()
        {
            // Act
            Employee testEmployee = employeeManager.AddEmployee("UnitTest", "UnitTest", 10, EmployeeRole.Worker, "cOAyYEYI90OPfEfVhXAHVA", 16, true);
            Employee employeeEntry = employeeManager.GetEmployee(testEmployee.UserID, false);

            // Assert
            Assert.AreEqual(testEmployee.UserID, employeeEntry.UserID);

            employeeManager.RemoveEmployee(testEmployee);
            // Thread.Sleep(1000);
        }

        [TestMethod]
        public void AddEmployeeCredentialsEventRaisedTest()
        {
            // Arrange
            Employee eventEmployee = null;

            // Act
            employeeManager.AddedEmployeeEvent += delegate (Employee e) { eventEmployee = e; };
            Employee testEmployee = employeeManager.AddEmployee("UnitTest", "UnitTest", 10, EmployeeRole.Worker, "cOAyYEYI90OPfEfVhXAHVA", 16, true);

            // Assert
            Assert.AreEqual(testEmployee.UserID, eventEmployee.UserID);

            employeeManager.RemoveEmployee(testEmployee);
            // Thread.Sleep(1000);
        }

        [TestMethod]
        public void AddEmployeeObjectTest()
        {
            // Arrange
            Employee testEmployee = new Employee("UNIT_TEST_RESERVED", "UnitTest", "UnitTest", 10, EmployeeRole.Worker, "cOAyYEYI90OPfEfVhXAHVA", 16, true);

            // Act
            employeeManager.AddEmployee(testEmployee);
            Employee employeeEntry = employeeManager.GetEmployee("UNIT_TEST_RESERVED", false);

            // Assert
            Assert.AreEqual(testEmployee.UserID, employeeEntry.UserID);

            employeeManager.RemoveEmployee(testEmployee);
            // Thread.Sleep(1000);
        }

        [TestMethod]
        public void AddEmployeeObjectEventRaisedTest()
        {
            // Arrange
            Employee testEmployee = new Employee("UNIT_TEST_RESERVED", "UnitTest", "UnitTest", 10, EmployeeRole.Worker, "cOAyYEYI90OPfEfVhXAHVA", 16, true);
            Employee eventEmployee = null;

            // Act
            employeeManager.AddedEmployeeEvent += delegate (Employee e) { eventEmployee = e; };
            employeeManager.AddEmployee(testEmployee);

            // Assert
            Assert.AreEqual(testEmployee.UserID, eventEmployee.UserID);

            employeeManager.RemoveEmployee(testEmployee);
            // Thread.Sleep(1000);
        }

        [TestMethod]
        public void UpdateEmployeeTest()
        {
            // Arrange
            Employee testEmployee = new Employee("UNIT_TEST_RESERVED", "UnitTest", "UnitTest", 10, EmployeeRole.Worker, "cOAyYEYI90OPfEfVhXAHVA", 16, true);
            employeeManager.AddEmployee(testEmployee);
            Employee employeeEntry = employeeManager.GetEmployee("UNIT_TEST_RESERVED", false);
            const int NEW_SALARY_RATE = 20;

            // Act
            testEmployee.SalaryHourlyRate = NEW_SALARY_RATE;
            employeeManager.UpdateEmployee(testEmployee);

            // Assert
            employeeEntry = employeeManager.GetEmployee("UNIT_TEST_RESERVED", false);
            Assert.AreEqual(NEW_SALARY_RATE, employeeEntry.SalaryHourlyRate);

            employeeManager.RemoveEmployee(testEmployee);
            // Thread.Sleep(1000);
        }

        [TestMethod]
        public void UpdateEmployeeEventRaisedTest()
        {
            // Arrange
            Employee testEmployee = new Employee("UNIT_TEST_RESERVED", "UnitTest", "UnitTest", 10, EmployeeRole.Worker, "cOAyYEYI90OPfEfVhXAHVA", 16, true);
            employeeManager.AddEmployee(testEmployee);
            Employee eventEmployee = null;

            // Act
            employeeManager.UpdatedEmployeeEvent += delegate (Employee e) { eventEmployee = e; };
            employeeManager.UpdateEmployee(testEmployee);

            // Assert
            Assert.AreEqual(testEmployee.UserID, eventEmployee.UserID);

            employeeManager.RemoveEmployee(testEmployee);
            // Thread.Sleep(1000);
        }

        [TestMethod]
        public void RemoveEmployeeEventRaisedTest()
        {
            // Arrange
            Employee testEmployee = new Employee("UNIT_TEST_RESERVED", "UnitTest", "UnitTest", 10, EmployeeRole.Worker, "cOAyYEYI90OPfEfVhXAHVA", 16, true);
            employeeManager.AddEmployee(testEmployee);
            Employee eventEmployee = null;

            // Act
            employeeManager.RemovedEmployeeEvent += delegate (Employee e) { eventEmployee = e; };
            employeeManager.RemoveEmployee(testEmployee);

            // Assert
            Assert.AreEqual(testEmployee.UserID, eventEmployee.UserID);

            // Thread.Sleep(1000);
        }

        [TestMethod]
        public void GetEmployeePictureTest()
        {
            // Act
            Employee testEmployee = new Employee("UNIT_TEST_RESERVED", "UnitTest", "UnitTest", 10, EmployeeRole.Worker, "cOAyYEYI90OPfEfVhXAHVA", 16, true); 
            string actual = EmployeeManager.GetPictureURL("UNIT_TEST_RESERVED");
            string hello = "http://placehold.it/150";
            // Assert
            Assert.AreEqual(hello, actual);

            employeeManager.RemoveEmployee(testEmployee);
            // Thread.Sleep(1000);
        }
        [TestMethod]
        public void GetEmployeePictureDatabaseHandlerTest()
        {
            // Act
            Employee testEmployee = new Employee("UNIT_TEST_RESERVED", "UnitTest", "UnitTest", 10, EmployeeRole.Worker, "cOAyYEYI90OPfEfVhXAHVA", 16, true);
            string actual = EmployeeDatabaseHandler.GetPictureURL("UNIT_TEST_RESERVED");
            string hello = "http://placehold.it/150";
            // Assert
            Assert.AreEqual(hello, actual);

            employeeManager.RemoveEmployee(testEmployee);
            // Thread.Sleep(1000);
        }

        [TestMethod]
        public void IsUniqueUsernameTest()
        {
            // Act
            Employee testEmployee = new Employee("UNIT_TEST_RESERVED", "UnitTest", "UnitTest", 10, EmployeeRole.Worker, "cOAyYEYI90OPfEfVhXAHVA", 16, true);
            bool expected = EmployeeDatabaseHandler.IsUniqueUsername("UNIT_TEST_RESERVED");
            bool actual = true;
            // Assert
            Assert.AreEqual(expected, actual);

            employeeManager.RemoveEmployee(testEmployee);
            // Thread.Sleep(1000);
        }

        [TestMethod]
        public void CalculateWorkingSinceTest()
        {
            // Act
            Employee testEmployee = new Employee("UNIT_TEST_RESERVED", "UnitTest", "UnitTest", 10, EmployeeRole.Worker, "cOAyYEYI90OPfEfVhXAHVA", 16, true);
            string expected = EmployeeManager.CalculateWorkingSince(testEmployee);
            string actual = $"Working since: 0 days";
            // Assert
            Assert.AreEqual(expected, actual);

            employeeManager.RemoveEmployee("UNIT_TEST_RESERVED");
            // Thread.Sleep(1000);
        }

        [TestMethod]
        public void GetFullDataAllDataTest()
        {
            // Act
            Employee testEmployee = new Employee("UNIT_TEST_RESERVED", "UnitTest", "UnitTest", 10, EmployeeRole.Worker, "cOAyYEYI90OPfEfVhXAHVA", 16, true);
            Employee expected = EmployeeDatabaseHandler.GetEmployee("UNIT_TEST_RESERVED",true);
            bool actual = true;
            // Assert
            Assert.AreEqual(testEmployee.UserID, testEmployee.UserID);

            employeeManager.RemoveEmployee(testEmployee);
            // Thread.Sleep(1000);
        }

    }

}
