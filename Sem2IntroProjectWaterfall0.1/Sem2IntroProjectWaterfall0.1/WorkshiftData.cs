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
        private string date;
        private int workshift;
        public string day;
        public string UserID
        {
            get { return this.userID; }
            private set { }
        }
        public string Date
        {
            get { return this.date; }
            private set { }
        }
        public int Workshift
        {
            get { return this.workshift; }
            private set { }
        }

        #endregion


        public WorkshiftData(string userID, string date, int workshift, string day)
        {
            this.date = date;
            this.userID = userID;
            this.workshift = workshift;
            this.day = day;
            
           
        }
    }
}

