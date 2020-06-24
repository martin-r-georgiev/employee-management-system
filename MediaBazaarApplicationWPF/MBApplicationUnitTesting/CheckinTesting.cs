using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data.MySqlClient;
using MediaBazaarApplicationWPF;
using System.Reflection;


namespace MBApplicationUnitTesting
{
    [TestClass]
    public class CheckinTesting
    {
        private string userID = "UNIT_TEST_RESERVED";
        private DateTime checkin = new DateTime(2000, 10, 10);
        private DateTime checkout = new DateTime(2000, 11, 11);
        [TestMethod]
        public void CheckifUserIsCheckedInTest()
        {
            CheckIn.Checkin(userID, checkin);
            bool currentlyCheckedIn = CheckIn.IsAtWork(userID);
            Assert.AreEqual(true, currentlyCheckedIn);
            CheckIn.DeleteUserData(userID);
            CheckIn.ClearNotificationsBefore(checkout);

        }

        [TestMethod]
        public void CheckifUserIsCheckedOutTest()
        {
            CheckIn.Checkin(userID, checkin);
            CheckIn.Checkout(userID, checkout);
            bool currentlyCheckedIn = CheckIn.IsAtWork(userID);
            Assert.AreEqual(false, currentlyCheckedIn);
            CheckIn.DeleteUserData(userID);
            CheckIn.ClearNotificationsBefore(checkout);

        }

        //[TestMethod]
        //public void GetAllAtWorkUsers()
        //{
        //    bool currentlyCheckedIn = CheckIn.IsAtWork(userID);
        //    List<Employee> AtWork = CheckIn.GetAllEmployeesAtWork();
        //    List<EmployeeAtWorkModel> AtWork2 = CheckIn.GetEmployeesAtWork("TEST_DEPT");
        //    Assert.AreEqual(0,AtWork2.Count());
        //    CheckIn.DeleteUserData(userID);
        //    CheckIn.ClearNotificationsBefore(checkout);
        //}


    }
}
