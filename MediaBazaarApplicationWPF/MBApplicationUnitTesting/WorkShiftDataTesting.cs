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
    public class WorkShiftDataTesting
    {
        private string userID = "UNIT_TEST_PREFERENCE_USERID";
        private DateTime date = System.DateTime.Now;
        private int workshift = 0;
        private string day = "Monday";
        private string departmentID = "UNIT_TEST_PREFERENCE_DEPID";

        [TestMethod]
        public void CreateWorkShiftData()
        {
            //Arrage
            WorkshiftData testworkshiftData = new WorkshiftData(userID, date, workshift, day, departmentID);

            //Assert
            Assert.AreEqual(userID, testworkshiftData.UserID);
            Assert.AreEqual(date, testworkshiftData.Date);
            Assert.AreEqual(workshift, testworkshiftData.Workshift);
            Assert.AreEqual(day, testworkshiftData.Day);
            Assert.AreEqual(departmentID, testworkshiftData.DepartmentID);
        }
    }
}
