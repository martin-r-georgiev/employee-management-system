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
   public class PreferencesTesting
    {

        private string userID = "UNIT_TEST_PREFERENCE_USERID";
        private string date = "2020-01-01";
        private int workshift = 0;
        private string day = "Monday";
        private string departmentID = "UNIT_TEST_PREFERENCE_DEPID";

        [TestMethod]
        public void CreatePreference()
        {
            //Arrage
            WorkshiftPreferences testPrefrerence = new WorkshiftPreferences(userID, date, workshift, day, departmentID);

            //Assert
            Assert.AreEqual(userID, testPrefrerence.UserID);
            Assert.AreEqual(date, testPrefrerence.Date);
            Assert.AreEqual(workshift, testPrefrerence.Workshift);
            Assert.AreEqual(day, testPrefrerence.Day);
            Assert.AreEqual(departmentID, testPrefrerence.DepartmentID);
        }
    }
    [TestClass]
    public class PreferencesWindowTesting
    {

    }
}
