using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Sem2IntroProjectWaterfall0._1
{
   public class WorkshiftData
    {
        #region Properties+variables
        private string userID;
        private DateTime date;
        private int workshift;
        private string day;
        private string departmentID;
        public string UserID
        {
            get { return this.userID; }
            private set { }
        }
        public DateTime Date
        {
            get { return this.date; }
            private set { }
        }
        public string Day
        {
            get { return this.day; }
            private set { }
        }
        public string DepartmentID
        {
            get { return this.departmentID; }
            private set { }
        }
        public int Workshift
        {
            get { return this.workshift; }
            private set { }
        }

        #endregion

        #region Constructors
        public WorkshiftData(string userID, DateTime date, int workshift, string day,string departmentID)
        {
            this.date = date;
            this.userID = userID;
            this.workshift = workshift;
            this.day = day;
            this.departmentID = departmentID;
            
           
        }
        #endregion
    }
}

