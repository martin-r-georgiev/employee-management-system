using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApplicationWPF
{
    public class AutoWorkshift
    {

        private List<WorkshiftPreferences> preferences; // copy of the database's prefence table 
        private List<WorkshiftData> schedule; // the schedule that will be uploaded to the database; contains all departments
        private DateTime nextmonday = DateTimeControls.StartOfWeek(DateTime.Now, DayOfWeek.Monday); // gets the current weeks monday 
        private List<string> departmentIDs = new List<string>(); // storing the department IDs to be used for workshift generation per departmetn

        public List<WorkshiftData> Schedule => this.schedule;

        public AutoWorkshift()
        {
            this.preferences = new List<WorkshiftPreferences>();
            this.schedule = new List<WorkshiftData>();
        }

        #region DataLoading
        public void LoadManualTestData()
        {
            preferences.Add(new WorkshiftPreferences("John4", "2020-03-20", 0, "Friday", "dep2"));
            preferences.Add(new WorkshiftPreferences("John4", "2020-03-20", 1, "Friday", "dep2"));
            preferences.Add(new WorkshiftPreferences("John4", "2020-03-20", 2, "Friday", "dep2"));
            preferences.Add(new WorkshiftPreferences("John4", "2020-03-20", 0, "Thursday", "dep2"));
            preferences.Add(new WorkshiftPreferences("John4", "2020-03-20", 1, "Thursday", "dep2"));
            preferences.Add(new WorkshiftPreferences("John4", "2020-03-20", 2, "Thursday", "dep2"));
            preferences.Add(new WorkshiftPreferences("John4", "2020-03-20", 0, "Wednesday", "dep2"));
            preferences.Add(new WorkshiftPreferences("John4", "2020-03-20", 1, "Wednesday", "dep2"));
            preferences.Add(new WorkshiftPreferences("John4", "2020-03-20", 2, "Wednesday", "dep2"));
            preferences.Add(new WorkshiftPreferences("John4", "2020-03-20", 1, "Thursday", "dep2"));

            preferences.Add(new WorkshiftPreferences("John5", "2020-03-20", 0, "Friday", "dep2"));
            preferences.Add(new WorkshiftPreferences("John5", "2020-03-20", 1, "Friday", "dep2"));
            preferences.Add(new WorkshiftPreferences("John5", "2020-03-20", 2, "Friday", "dep2"));
            preferences.Add(new WorkshiftPreferences("John5", "2020-03-20", 0, "Thursday", "dep2"));
            preferences.Add(new WorkshiftPreferences("John5", "2020-03-20", 1, "Thursday", "dep2"));
            preferences.Add(new WorkshiftPreferences("John5", "2020-03-20", 2, "Thursday", "dep2"));
            preferences.Add(new WorkshiftPreferences("John5", "2020-03-20", 0, "Wednesday", "dep2"));
            preferences.Add(new WorkshiftPreferences("John5", "2020-03-20", 1, "Wednesday", "dep2"));
            preferences.Add(new WorkshiftPreferences("John5", "2020-03-20", 2, "Wednesday", "dep2"));
            preferences.Add(new WorkshiftPreferences("John5", "2020-03-20", 1, "Thursday", "dep2"));

            preferences.Add(new WorkshiftPreferences("John6", "2020-03-20", 0, "Friday", "dep2"));
            preferences.Add(new WorkshiftPreferences("John6", "2020-03-20", 1, "Friday", "dep2"));
            preferences.Add(new WorkshiftPreferences("John6", "2020-03-20", 2, "Friday", "dep2"));
            preferences.Add(new WorkshiftPreferences("John6", "2020-03-20", 0, "Thursday", "dep2"));
            preferences.Add(new WorkshiftPreferences("John6", "2020-03-20", 1, "Thursday", "dep2"));
            preferences.Add(new WorkshiftPreferences("John6", "2020-03-20", 2, "Thursday", "dep2"));
            preferences.Add(new WorkshiftPreferences("John6", "2020-03-20", 0, "Wednesday", "dep2"));
            preferences.Add(new WorkshiftPreferences("John6", "2020-03-20", 1, "Wednesday", "dep2"));
            preferences.Add(new WorkshiftPreferences("John6", "2020-03-20", 2, "Wednesday", "dep2"));
            preferences.Add(new WorkshiftPreferences("John6", "2020-03-20", 1, "Thursday", "dep2"));


            departmentIDs.Add("dep2");

         
        }

        public void LoadDataFromDatabase() // used to load data  from preference table and department table
        {
            using (MySqlConnection con = SqlConnectionHandler.GetSqlConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand($"SELECT * FROM preferences INNER JOIN users ON users.userID=preferences.userID", con))
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        string userID = dataReader["userID"].ToString();
                        string day = dataReader["day"].ToString();
                        string date = dataReader["date"].ToString();
                        int workshift = Convert.ToInt32(dataReader["workshift"]);
                        string departmentID = dataReader["departmentID"].ToString();
                        preferences.Add(new WorkshiftPreferences(userID, date, workshift, day, departmentID));

                        if (!departmentIDs.Exists(w => w == departmentID)) departmentIDs.Add(departmentID);
                    }

                    dataReader.Close();
                    cmd.Dispose();
                }
                con.Close();
            } // load preferences and departments       
        }
        #endregion

        #region Main Methods
        public List<WorkshiftData> GenerateWorkshiftSchedule(bool select)
        {
            if(select==true) // true gets data from database
            LoadDataFromDatabase();
            else
            LoadManualTestData();// false gets from manual testdata for unit testing

            foreach (string department in departmentIDs)
            {
                List<WorkshiftPreferences> currentDepartmentPreferences = GetCurrentDeparmentPreferences(department);

                foreach (WorkshiftPreferences p in currentDepartmentPreferences)
                {
                    Schedule.Add(new WorkshiftData(p.UserID, ConvertToDateString(p.Day), p.Workshift, p.Day, p.DepartmentID));
                }

                for (int i = 0; i < 5; i++) // Monday (0) -> Friday (4)
                {
                    for (int j = 0; j < 3; j++) // Morning (0) -> Evening (2)
                    {
                        // Checks if anyone is assigned to current shift
                        if(!HasPeopleAssigned(converttoday(i), j, department))
                        {
                            for (int index = 0; index < Schedule.Count; index++)
                            {
                                if(HasMultipleEntries(Schedule[i].Day, Schedule[i].Workshift) && Schedule[i].DepartmentID == department)
                                {
                                    var Max = SortSchedule(Schedule);
                                    if(converttoday(Max.Item1) == Schedule[index].Day && Max.Item2 == Schedule[index].Workshift) // making it take from the biggest shift change the IF statement to true if bugged
                                    {
                                        //remove this guy from workshift and add it to current
                                        Schedule.RemoveAt(index); // remove the current guy from his already assigned workshift
                                        Schedule.Add(new WorkshiftData(Schedule[index].UserID, converttodate(i), j, converttoday(i), department)); // add him to this one that requries someone to cover it
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return Schedule;
        }

        public string GenerateAndUpload() // call this one to generate and upload with checks in regard to not flood the database
        {
            string message = "";
            using (MySqlConnection con = SqlConnectionHandler.GetSqlConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand($"SELECT nextupdate FROM workshiftsupdate", con))
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    if (dataReader.Read())
                    {
                        if (dataReader.GetDateTime(0) <= DateTime.Now)
                        {
                            Attendance.UpdateAllAttendance();
                            GenerateWorkshiftSchedule(true);
                            ExportToDatabase();
                            message = "Sorry for the wait time, schedule was generating!";
                        }
                    }
                    else
                    {
                        Attendance.UpdateAllAttendance();
                        GenerateWorkshiftSchedule(true);
                        ExportToDatabase();
                        message = "Sorry for the wait time, schedule was generating!";
                    }
                    dataReader.Close();
                }
                con.Close();
            }
            return message;
        }

        public void ExportToDatabase()
        {
            int entries = Schedule.Count();
            for (int i = 0; i < entries; i++) // creating the entries for the whole month 
            {
                string userID = Schedule[i].UserID;
                DateTime date = Schedule[i].Date;
                int workshift = Schedule[i].Workshift;
                string day = Schedule[i].Day;
                string departmentID = Schedule[i].DepartmentID;
                WorkshiftData ToAdd = new WorkshiftData(userID, date.AddDays(7), workshift, day, departmentID); //week2
                Schedule.Add(ToAdd);
                ToAdd = new WorkshiftData(userID, date.AddDays(14), workshift, day, departmentID); //week3
                Schedule.Add(ToAdd);

            }

            foreach (WorkshiftData w in Schedule) // actually adding it to the database
            {
                if(w.Date>DateTime.Now)
                using (MySqlConnection con = SqlConnectionHandler.GetSqlConnection())
                {
                    MySqlCommand cmd;
                    using (cmd = new MySqlCommand($"INSERT INTO workshifts (userID, date, workshift) VALUES (@userID,@date, @workshift)", con))
                    {
                        cmd.Parameters.AddWithValue("@userID", w.UserID);
                        cmd.Parameters.AddWithValue("@date", w.Date.ToString("yyyy/MM/dd"));
                        cmd.Parameters.AddWithValue("@workshift", w.Workshift);
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();

                    }

                    con.Close();
                }
            }

            if(Schedule.Count > 0)
            {
                using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
                {
                    try
                    {
                        using (MySqlCommand cmd = new MySqlCommand($"DELETE FROM workshiftsupdate", conn))
                        {
                            cmd.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        using (MySqlCommand cmd = new MySqlCommand($"INSERT INTO workshiftsupdate (nextupdate) VALUES (@nextupdate)", conn))
                        {
                            cmd.Parameters.AddWithValue("@nextupdate", Schedule[Schedule.Count - 1].Date.Date);
                            cmd.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                    }
                    catch(Exception ex) { Console.WriteLine(ex.Message); }
                    finally { conn.Close(); }
                }
            }
        }

        #endregion

        #region Auxiliary Methods
        public bool HasMultipleEntries(string day, int workshift) => (schedule.Where(w => w.Day == day && w.Workshift == workshift).Count() > 1) ? true : false;

        public (int, int) SortSchedule(List<WorkshiftData> ToSort)
        {
            int[] workshift = new int[15]; // each workshift represents a number monday morning is 0 ... friday evening is 14
            foreach (WorkshiftData w in ToSort)
            {
                int day = ConvertDayToNumber(w.Day);
                int shift = Convert.ToInt32(w.Workshift);
                int index = day * 3 + shift;
                workshift[index]++;
            }
            int maxValue = workshift.Max();
            int maxIndex = workshift.ToList().IndexOf(maxValue);
            int maxDay = maxIndex / 3;
            int maxShift = maxIndex - (maxDay * 3);
            return (maxDay, maxShift);
        }

        // Returns the workshifts for all employees in a given department
        public List<WorkshiftPreferences> GetCurrentDeparmentPreferences(string departmentID) => preferences.FindAll(p => p.DepartmentID == departmentID);

        // Checks if people are assigned to given shift
        public bool HasPeopleAssigned(string day, int shift, string departmentID) => schedule.Exists(w => w.Day == day && w.Workshift == shift && w.DepartmentID == departmentID);

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

        public int ConvertDayToNumber(string day)
        {
            switch (day)
            {
                case "Monday": return 0;
                case "Tuesday": return 1;
                case "Wednesday": return 2;
                case "Thursday": return 3;
                case "Friday": return 4;
                default: return -1;
            }
        }

        public DateTime converttodate(int x) => nextmonday.AddDays(x);

        public DateTime ConvertToDateString(string ToConvert)
        {
            switch (ToConvert)
            {
                case "Monday": return nextmonday;
                case "Tuesday": return nextmonday.AddDays(1);
                case "Wednesday": return nextmonday.AddDays(2);
                case "Thursday": return nextmonday.AddDays(3);
                case "Friday": return nextmonday.AddDays(4);
                case "Saturday": return nextmonday.AddDays(5);
                case "Sunday": return nextmonday.AddDays(6);
                default: return nextmonday.AddDays(7);
            }
        }
        #endregion
    }
}
