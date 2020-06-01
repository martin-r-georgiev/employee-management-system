using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MediaBazaarApplicationWPF;

namespace MBApplicationUnitTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Department d = DepartmentManager.GetDepartment("zfDazXzm8UabCF9sZ2w4g", true);
            Assert.AreEqual("testName", d.Name);

            DepartmentManager.UpdateDepartment("zfDazXzm8UabCF9sZ2w4g", "testName", "notTestAddress");
            d = DepartmentManager.GetDepartment("zfDazXzm8UabCF9sZ2w4g0", true);

            Assert.AreEqual("testName", d.Name);
            Assert.AreEqual("notTestAddress", d.Address);

            DepartmentManager.RemoveFromDatabase("zfDazXzm8UabCF9sZ2w4g");

            Assert.AreEqual(3, DepartmentManager.GetAllDepartments().Count);
        }
    }
}
