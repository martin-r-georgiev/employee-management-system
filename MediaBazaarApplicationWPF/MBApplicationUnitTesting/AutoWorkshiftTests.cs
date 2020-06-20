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
    public class AutoWorkshiftTests
    {
        private List<WorkshiftData> mySchedule = new List<WorkshiftData>();

        public void PopulatemySchedule()
        {
            DateTime myDate = DateTime.Parse("6/19/2020");
            WorkshiftData ToAdd = new WorkshiftData("John4", myDate, 0, "Friday", "dep2");
            mySchedule.Add(ToAdd);

            myDate = DateTime.Parse("6/19/2020");
            ToAdd = new WorkshiftData("John4", myDate, 1, "Friday", "dep2");
            mySchedule.Add(ToAdd);

            myDate = DateTime.Parse("6/19/2020");
            ToAdd = new WorkshiftData("John4", myDate, 2, "Friday", "dep2");
            mySchedule.Add(ToAdd);

            myDate = DateTime.Parse("6/18/2020");
            ToAdd = new WorkshiftData("John4", myDate, 0, "Thursday", "dep2");
            mySchedule.Add(ToAdd);

            myDate = DateTime.Parse("6/18/2020");
            ToAdd = new WorkshiftData("John4", myDate, 2, "Thursday", "dep2");
            mySchedule.Add(ToAdd);

            myDate = DateTime.Parse("6/19/2020");
            ToAdd = new WorkshiftData("John5", myDate, 0, "Friday", "dep2");
            mySchedule.Add(ToAdd);

            myDate = DateTime.Parse("6/19/2020");
            ToAdd = new WorkshiftData("John5", myDate, 1, "Friday", "dep2");
            mySchedule.Add(ToAdd);

            myDate = DateTime.Parse("6/19/2020");
            ToAdd = new WorkshiftData("John5", myDate, 2, "Friday", "dep2");
            mySchedule.Add(ToAdd);


            myDate = DateTime.Parse("6/18/2020");
            ToAdd = new WorkshiftData("John5", myDate, 0, "Thursday", "dep2");
            mySchedule.Add(ToAdd);

            myDate = DateTime.Parse("6/18/2020");
            ToAdd = new WorkshiftData("John5", myDate, 2, "Thursday", "dep2");
            mySchedule.Add(ToAdd); //9

            myDate = DateTime.Parse("6/17/2020");
            ToAdd = new WorkshiftData("John5", myDate, 0, "Wednesday", "dep2");
            mySchedule.Add(ToAdd);//10


            myDate = DateTime.Parse("6/17/2020");
            ToAdd = new WorkshiftData("John5", myDate, 1, "Wednesday", "dep2");
            mySchedule.Add(ToAdd);

            myDate = DateTime.Parse("6/17/2020");
            ToAdd = new WorkshiftData("John5", myDate, 2, "Wednesday", "dep2");
            mySchedule.Add(ToAdd);

            myDate = DateTime.Parse("6/18/2020");
            ToAdd = new WorkshiftData("John5", myDate, 1, "Thursday", "dep2");
            mySchedule.Add(ToAdd);

            myDate = DateTime.Parse("6/19/2020");
            ToAdd = new WorkshiftData("John6", myDate, 0, "Friday", "dep2");
            mySchedule.Add(ToAdd);

            myDate = DateTime.Parse("6/19/2020");
            ToAdd = new WorkshiftData("John6", myDate, 1, "Friday", "dep2");
            mySchedule.Add(ToAdd);

            myDate = DateTime.Parse("6/19/2020");
            ToAdd = new WorkshiftData("John6", myDate, 2, "Friday", "dep2");
            mySchedule.Add(ToAdd);

            myDate = DateTime.Parse("6/18/2020");
            ToAdd = new WorkshiftData("John6", myDate, 0, "Thursday", "dep2");
            mySchedule.Add(ToAdd);

            myDate = DateTime.Parse("6/18/2020");
            ToAdd = new WorkshiftData("John6", myDate, 1, "Thursday", "dep2");
            mySchedule.Add(ToAdd);//20

            myDate = DateTime.Parse("6/18/2020");
            ToAdd = new WorkshiftData("John6", myDate, 2, "Thursday", "dep2");
            mySchedule.Add(ToAdd);

            myDate = DateTime.Parse("6/17/2020");
            ToAdd = new WorkshiftData("John6", myDate, 0, "Wednesday", "dep2");
            mySchedule.Add(ToAdd);

            myDate = DateTime.Parse("6/17/2020");
            ToAdd = new WorkshiftData("John6", myDate, 1, "Wednesday", "dep2");
            mySchedule.Add(ToAdd);

            myDate = DateTime.Parse("6/17/2020");
            ToAdd = new WorkshiftData("John6", myDate, 2, "Wednesday", "dep2");
            mySchedule.Add(ToAdd);

            myDate = DateTime.Parse("6/16/2020");
            ToAdd = new WorkshiftData("John6", myDate, 1, "Thursday", "dep2");
            mySchedule.Add(ToAdd);//23

            myDate = DateTime.Parse("6/15/2020");
            ToAdd = new WorkshiftData("John4", myDate, 0, "Monday", "dep2");
            mySchedule.Add(ToAdd);

            myDate = DateTime.Parse("6/15/2020");
            ToAdd = new WorkshiftData("John5", myDate, 1, "Monday", "dep2");
            mySchedule.Add(ToAdd);

            myDate = DateTime.Parse("6/15/2020");
            ToAdd = new WorkshiftData("John5", myDate, 2, "Monday", "dep2");
            mySchedule.Add(ToAdd);

            myDate = DateTime.Parse("6/16/2020");
            ToAdd = new WorkshiftData("John4", myDate, 0, "Tuesday", "dep2");
            mySchedule.Add(ToAdd);

            myDate = DateTime.Parse("6/16/2020");
            ToAdd = new WorkshiftData("John4", myDate, 1, "Tuesday", "dep2");
            mySchedule.Add(ToAdd);
            

            myDate = DateTime.Parse("6/16/2020");
            ToAdd = new WorkshiftData("John5", myDate, 2, "Tuesday", "dep2");
            mySchedule.Add(ToAdd);
            //29
        }

        [TestMethod]
        public void TestAlgorithm()
        {
            AutoWorkshift autoWorkshift = new AutoWorkshift();
            PopulatemySchedule();
            List<WorkshiftData> GeneratedDatas = autoWorkshift.GenerateWorkshiftSchedule(false);// false to get manual test data
            for (int i = 0; i < mySchedule.Count(); i++)
            {
                Assert.AreEqual(mySchedule[i].Day, GeneratedDatas[i].Day);
                Assert.AreEqual(mySchedule[i].UserID, GeneratedDatas[i].UserID);
                Assert.AreEqual(mySchedule[i].Workshift, GeneratedDatas[i].Workshift);

            }
        }
    }
}
