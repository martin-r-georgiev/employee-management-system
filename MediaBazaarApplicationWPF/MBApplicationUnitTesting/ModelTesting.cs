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
    public class ModelTesting
    {
        [TestMethod]
        public void EmployeeAtWorkTest()
        {
            EmployeeAtWorkModel test=new EmployeeAtWorkModel("name", "2hours");
            PropertyInfo firstName = typeof(EmployeeAtWorkModel).GetProperty("firstName");
            PropertyInfo atWorkSince = typeof(EmployeeAtWorkModel).GetProperty("atWorkSince");

            // Assert.
            Assert.IsNotNull(test.FirstName);
            Assert.IsNotNull(test.AtWorkSince);
        }
    }
}
