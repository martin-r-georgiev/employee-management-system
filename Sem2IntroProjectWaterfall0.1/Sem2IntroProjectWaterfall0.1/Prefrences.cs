using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace Sem2IntroProjectWaterfall0._1
{
    public class Prefrence
    {
        #region Properties+variables
        private string userID;
        private string date;
        private int workshift;
        private string day;
        private int shiftsworked;
        private string depID;

        public string UserID
        {
            get { return this.userID; }
            private set { }
        }

        public string DepID
        {
            get { return this.depID; }
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
        public int ShiftsWorked
        {
            get { return this.shiftsworked; }
            set { this.shiftsworked = value; }
        }
        public string Day
        {
            get { return this.day; }
            private set { }
        }
        #endregion


        public Prefrence(string userID, string date, int workshift, string day)
        {
            this.date = date;
            this.userID = userID;
            this.workshift = workshift;
            this.day = day;
            this.shiftsworked = 0;
        }
       
     }

    }
    

