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
        private string departmentID;

        public string UserID
        {
            get { return this.userID; }
            private set { }
        }

        public string DepartmentID
        {
            get { return this.departmentID; }
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

        #region Constructrors
        public Prefrence(string userID, string date, int workshift, string day,string departmentID) // used in AutoWorkshift
        {
            this.date = date;
            this.userID = userID;
            this.workshift = workshift;
            this.day = day;
            this.shiftsworked = 0;
            this.departmentID = departmentID;
           
        }
        public Prefrence(string userID, string day, int workshift, string date)
        {
            this.date = date;
            this.userID = userID;
            this.day = day;
            this.workshift = workshift;
        }
        #endregion
        #region Methods
        public void ExpediteToDatabase()
        {
            using (MySqlConnection con = SqlConnectionHandler.GetSqlConnection())
            {
                MySqlCommand cmd;
                using (cmd = new MySqlCommand($"INSERT INTO preferences (userID, day, date, workshift) VALUES (@userID,@day,@date,@workshift)", con))
                {
                    cmd.Parameters.AddWithValue("@userID",this.userID);
                    cmd.Parameters.AddWithValue("@day", this.day);
                    cmd.Parameters.AddWithValue("@date",this.date);
                    cmd.Parameters.AddWithValue("@workshift", this.workshift);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();

                }
                con.Close();
            }
        }
        #endregion
    }

}
    

