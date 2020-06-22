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
    public class StockItemTesting
    {
        private readonly string stockID = "UnitTestID";
        private readonly string departmentID = "UnitTestID";
        private readonly string name = "UnitTestName";
        private readonly int currentAmount = 3;
        private readonly int threshold = 4;

        [TestMethod]
        public void StockItemCreate1()
        {
            //Arrange
            StockItem Test = new StockItem(stockID, name);

            //Assert
            Assert.AreEqual(stockID, Test.StockID);
            Assert.AreEqual(name, Test.Name);
        }
        [TestMethod]
        public void StockItemCreate2()
        {
            //Arrange
            StockItem Test = new StockItem(stockID, departmentID, name);

            //Assert
            Assert.AreEqual(stockID, Test.StockID);
            Assert.AreEqual(departmentID, Test.DepartmentID);
            Assert.AreEqual(name, Test.Name);
        }
        [TestMethod]
        public void StockItemCreate3()
        {
            //Arrange
            StockItem Test = new StockItem(stockID, departmentID, name, currentAmount, threshold);

            //Assert
            Assert.AreEqual(stockID, Test.StockID);
            Assert.AreEqual(departmentID, Test.DepartmentID);
            Assert.AreEqual(name, Test.Name);
            Assert.AreEqual(currentAmount, Test.CurrentAmount);
            Assert.AreEqual(threshold, Test.Threshold);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void StockInvalidDepartmentID()
        {
            // Arrange
            StockItem Test = new StockItem(stockID, departmentID, name);
            const string new_depID = null;

            // Act
            Test.DepartmentID = new_depID;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void StockInvalidName()
        {
            // Arrange
            StockItem Test = new StockItem(stockID, departmentID, name);
            const string new_name = null;

            // Act
            Test.Name = new_name;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void StockInvalidThreshold()
        {
            // Arrange
            StockItem Test = new StockItem(stockID, departmentID, name, currentAmount, threshold);
            const int new_theshold = -3;

            // Act
            Test.Threshold = new_theshold;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void StockInvalidAmmount()
        {
            // Arrange
            StockItem Test = new StockItem(stockID, departmentID, name, currentAmount, threshold);
            const int new_amount = -3;

            // Act
            Test.CurrentAmount = new_amount;
        }
    }

    [TestClass]
    public class StockItemHandlerTesting
    {
        private readonly string stockID = "UnitTestID";
        private readonly string departmentID = "UnitTestID";
        private readonly string name = "UnitTestName";
        private readonly int currentAmount = 3;
        private readonly int threshold = 4;

        [TestMethod]
        public void AddStockItemToStockTest()
        {
            //Arrange
            StockItem Test = new StockItem(stockID, departmentID, name, currentAmount, threshold);
            StockItemDatabaseHandler.AddIntoStockItem(name, stockID);
            StockItemDatabaseHandler.AddStockItemToStock(Test);
            StockItem FromDatabase = StockItemDatabaseHandler.GetStockItemFromDepartment(stockID, departmentID);
            //Assert
            Assert.AreEqual(Test.StockID, FromDatabase.StockID);
            StockItemDatabaseHandler.RemoveStockItemGlobally(Test);
        }

        [TestMethod]
        public void AddStockItemToDepartmentTest()
        {
            //Arrange
            const string new_depid = "UnitTestNewDepID";
            StockItem Test = new StockItem(stockID, departmentID, name, currentAmount, threshold);
            StockItemDatabaseHandler.AddIntoStockItem(name, stockID);
            StockItemDatabaseHandler.AddStockItemToDepartment(Test,new_depid);
            StockItem FromDatabase = StockItemDatabaseHandler.GetStockItemFromDepartment(stockID, new_depid);
            //Assert
            Assert.AreEqual(Test.StockID, FromDatabase.StockID);
            StockItemDatabaseHandler.RemoveStockItemGlobally(Test);
        }

        [TestMethod]
        public void RemoveStockItemFromStockTest()
        {
            //Arrange
            
            StockItem Test = new StockItem(stockID, departmentID, name, currentAmount, threshold);
            StockItemDatabaseHandler.AddIntoStockItem(name, stockID);
            StockItemDatabaseHandler.AddStockItemToStock(Test);
            StockItemDatabaseHandler.RemoveStockItemFromStock(Test);
            StockItem FromDatabase = StockItemDatabaseHandler.GetStockItemFromDepartment(stockID, departmentID);
            //Assert
            Assert.IsNull(FromDatabase);
            StockItemDatabaseHandler.RemoveStockItemGlobally(Test);
        }

        [TestMethod]
        public void RemoveStockItemFromDepartmentTest()
        {
            //Arrange

            StockItem Test = new StockItem(stockID, departmentID, name, currentAmount, threshold);
            StockItemDatabaseHandler.AddIntoStockItem(name, stockID);
            StockItemDatabaseHandler.AddStockItemToStock(Test);
            StockItemDatabaseHandler.RemoveStockItemFromDepartment(Test, departmentID);
            StockItem FromDatabase = StockItemDatabaseHandler.GetStockItemFromDepartment(stockID, departmentID);
            //Assert
            Assert.IsNull(FromDatabase);
            StockItemDatabaseHandler.RemoveStockItemGlobally(Test);
        }


        [TestMethod]
        public void RemoveStockItemGloballyTest()
        {
            //Arrange

            StockItem Test = new StockItem(stockID, departmentID, name, currentAmount, threshold);
            StockItemDatabaseHandler.AddIntoStockItem(name, stockID);
            StockItemDatabaseHandler.AddStockItemToStock(Test);
            StockItemDatabaseHandler.RemoveStockItemGlobally(Test);
            StockItem FromDatabase = StockItemDatabaseHandler.GetStockItemFromDepartment(stockID, departmentID);
            StockItemDatabaseHandler.GetAssignedDepartments(stockID);
            //Assert
            Assert.IsNull(FromDatabase);
            StockItemDatabaseHandler.RemoveStockItemGlobally(Test);
        }
        [TestMethod]
        public void GetStockItemFromDepartmentTest()
        {
            //Arrange

            StockItem Test = new StockItem(stockID, departmentID, name, currentAmount, threshold);
            StockItemDatabaseHandler.AddIntoStockItem(name, stockID);
            StockItemDatabaseHandler.AddStockItemToStock(Test);
            StockItem FromDatabase = StockItemDatabaseHandler.GetStockItemFromDepartment(stockID, departmentID);
            StockItemDatabaseHandler.GetAllStockFromDepartment(departmentID);
            //Assert
            Assert.AreEqual(Test.StockID,FromDatabase.StockID);
            StockItemDatabaseHandler.RemoveStockItemGlobally(Test);
        }
        /* 
        [TestMethod]
        public void ReturnAssignedDepartmentsTest() // it calls some department method for some reason
        {
            //Arrange

            StockItem Test = new StockItem(stockID, departmentID, name, currentAmount, threshold);
            StockItemDatabaseHandler.AddIntoStockItem(name, stockID);
            StockItemDatabaseHandler.AddStockItemToStock(Test);
            StockItem FromDatabase = StockItemDatabaseHandler.GetStockItemFromDepartment(stockID, departmentID);
            List<Department> AssignedDepartments = StockItemDatabaseHandler.GetAssignedDepartments(stockID);
            //Assert
            Assert.AreEqual(departmentID, AssignedDepartments[0].DepartmentId);
            StockItemDatabaseHandler.RemoveStockItemGlobally(Test);
        }*/

        [TestMethod]
        public void UpdateStockItemTest1()
        {
            //Arrange
            const int newAmount = 5;
            const int newThreshold = 10;
            StockItemDatabaseHandler.AddIntoStockItem(name, stockID);
            StockItem Test = new StockItem(stockID, departmentID, name, currentAmount, threshold);
            Test.CurrentAmount = newAmount;
            Test.Threshold = newThreshold;
            StockItemDatabaseHandler.AddStockItemToStock(Test);
            StockItemDatabaseHandler.UpdateStockItem(Test);
            StockItemDatabaseHandler.ListAllItemsFromStockItem();
            StockItem FromDatabase = StockItemDatabaseHandler.GetStockItemFromDepartment(stockID, departmentID);
         
            //Assert
            Assert.AreEqual(Test.Threshold,FromDatabase.Threshold);
            StockItemDatabaseHandler.RemoveStockItemGlobally(Test);
        }

        [TestMethod]
        public void UpdateStockItemTest2()
        {
            //Arrange
            const int newAmount = 5;
            const int newThreshold = 10;
            StockItem Test = new StockItem(stockID, departmentID, name, currentAmount, threshold);
            Test.CurrentAmount = newAmount;
            Test.Threshold = newThreshold;
            StockItemDatabaseHandler.AddIntoStockItem(name, stockID);
            StockItemDatabaseHandler.AddStockItemToStock(Test);
            StockItemDatabaseHandler.UpdateStockItem(stockID,departmentID,newAmount,newThreshold);
            StockItem FromDatabase = StockItemDatabaseHandler.GetStockItemFromDepartment(stockID, departmentID);
        
            //Assert
            Assert.AreEqual(Test.Threshold, FromDatabase.Threshold);
            StockItemDatabaseHandler.RemoveStockItemGlobally(Test);
        }

       [TestMethod]
       public void IsUniqueTest()
        {
            StockItem Test = new StockItem(stockID, departmentID, name, currentAmount, threshold);
            StockItemDatabaseHandler.AddIntoStockItem(name, stockID);
            StockItemDatabaseHandler.AddStockItemToStock(Test);
            string uniqueID = StockItemDatabaseHandler.GenerateUniqueID();
            bool unique = StockItemDatabaseHandler.IsUnique(name);
            Assert.AreEqual(false, unique);
            Assert.AreNotEqual(uniqueID, stockID);
        }




    }

}
