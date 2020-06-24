using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApplicationWPF
{
    public class WorkshiftPreferences
    {
        #region Properties+variables
        private string userID;
        private string date;
        private int workshift;
        private string day;
        private int shiftsworked;
        private string departmentID;

        public string UserID => this.userID;
        public string DepartmentID => this.departmentID;
        public string Date => this.date;
        public int Workshift => this.workshift;
        public int ShiftsWorked
        {
            get => this.shiftsworked;
            set { this.shiftsworked = value; }
        }
        public string Day => this.day;
        #endregion

        #region Constructrors
        public WorkshiftPreferences(string userID, string date, int workshift, string day, string departmentID) // used in AutoWorkshift
        {
            this.userID = userID;
            this.date = date;
            this.workshift = workshift;
            this.day = day;
            this.shiftsworked = 0;
            this.departmentID = departmentID;

        }
        public WorkshiftPreferences(string userID, int day, int workshift, string date)
        {
            this.date = date;
            this.userID = userID;
            this.day = converttoday(day);
            this.workshift = workshift;
        }
        #endregion
        #region Methods
        public void ExpediteToDatabase()
        {
            using (MySqlConnection con = SqlConnectionHandler.GetSqlConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand($"INSERT INTO preferences (userID, day, date, workshift) VALUES (@userID,@day,@date,@workshift)", con))
                {
                    cmd.Parameters.AddWithValue("@userID", this.userID);
                    cmd.Parameters.AddWithValue("@day", this.day);
                    cmd.Parameters.AddWithValue("@date", this.date);
                    cmd.Parameters.AddWithValue("@workshift", this.workshift);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                con.Close();
            }
        }

        public static bool CheckIfUserHasPreference()
        {
            bool result = false;
            using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
            {
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand($"SELECT index_preferences FROM preferences where userID=@userID ", conn))
                    {
                        cmd.Parameters.AddWithValue("@userID", LoggedInUser.userID);
                        MySqlDataReader dataReader = cmd.ExecuteReader();

                        if (dataReader.Read()) result = true;
                        dataReader.Close();
                        cmd.Dispose();
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                finally { conn.Close(); }
            }
            return result;
        }

        public string converttoday(int x)
        {
            switch (x)
            {
                case 0: return "Monday";
                case 1: return "Tuesday";
                case 2: return "Wednesday";
                case 3: return "Thursday";
                case 4: return "Friday";   
                case 5: return "Saturday";
                case 6: return "Sunday";
                default: return "Error";
            }
        }
        #endregion
    }
}
