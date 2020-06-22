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
    public class HistoryLogTesting
    {
        private  string username;
        private  string password;
        private  string userID;
        private  decimal salaryHourlyRate;
        private  EmployeeRole role;
        private  string firstName;
        private  string lastName;
        private  string nationality;
        private  string address;
        private  string email;
        private  string phoneNumber;
        private  int workHours;
        private  DateTime dateofBirth;
        private  bool sex;
        private  string depID;

        [TestInitialize]
        public void CoreEmployeeTesting()
        {
            this.username = "UnitTest";
            this.password = "UnitTest";
            this.userID = "UNIT_TEST_RESERVED_HISTORYLOG";
            this.salaryHourlyRate = 10;
            this.role = EmployeeRole.Worker;
            this.firstName = "Test";
            this.lastName = "Dummy";
            this.nationality = "Test";
            this.address = "Test";
            this.email = "test@mediabazaar.nl";
            this.phoneNumber = "56416";
            this.workHours = 16;
            this.dateofBirth = new DateTime(2000, 1, 1);
            this.sex = true;
            this.depID = "cOAyYEYI90OPfEfVhXAHVA";
        }



        [TestMethod]
        public void AddToHistoryLogTest()
        {
            Employee employee = new Employee(userID, username, password, salaryHourlyRate, role, depID, workHours, false);
            HistoryLog.AddToHistoryLog(employee);
            bool exisits=HistoryLog.CheckIfPersonExists(userID);
            Assert.AreEqual(true, exisits);
            HistoryLog.DeleteFromHistoryLog(userID);
        }

        [TestMethod]
        public void UpdateHistoryLogTest()
        {
            Employee employee = new Employee(userID, username, password, salaryHourlyRate, role, depID, workHours, false);
            HistoryLog.AddToHistoryLog(employee);
            HistoryLog.UpdateHistoryLog(employee, firstName, lastName, phoneNumber, dateofBirth.ToString("yyyy-MM-dd"), salaryHourlyRate.ToString(), email, address, nationality);
            bool exisits = HistoryLog.CheckIfPersonExists(userID);
            Assert.AreEqual(true, exisits);
            HistoryLog.DeleteFromHistoryLog(userID);

        }

        [TestMethod]
        public void ShowLogNoErrorTest()
        {
           List<string> message= HistoryLog.ShowLog();

        }
    }
}
