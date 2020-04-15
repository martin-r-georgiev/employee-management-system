using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Sem2IntroProjectWaterfall0._1
{
    public class AutoWorkshift
    {
        
        List<Prefrence> prefrences = new List<Prefrence>(); // copy of the database's prefence table 
        List<WorkshiftData> Schedule = new List<WorkshiftData>();// the schedule that will be uploaded to the database; contains all departments 
        DateTime nextmonday = DateTime.Now.StartOfWeek(DayOfWeek.Monday); // gets the current weeks monday
        List<string> departments = new List<string>(); // storing the department IDs to be used for workshift generation per departmetn


        #region DataLoading
        public void LoadManualTestData()
        {

            Prefrence toadd;
            toadd = new Prefrence("John1", "2020-03-20", 0, "Tuesday", "dep1"); prefrences.Add(toadd);
            toadd = new Prefrence("John1", "2020-03-20", 1, "Tuesday", "dep1"); prefrences.Add(toadd);
            toadd = new Prefrence("John1", "2020-03-20", 2, "Tuesday", "dep1"); prefrences.Add(toadd);
            toadd = new Prefrence("John1", "2020-03-20", 0, "Monday", "dep1"); prefrences.Add(toadd);
            toadd = new Prefrence("John1", "2020-03-20", 1, "Monday", "dep1"); prefrences.Add(toadd);
            toadd = new Prefrence("John1", "2020-03-20", 2, "Monday", "dep1"); prefrences.Add(toadd);
            toadd = new Prefrence("John1", "2020-03-20", 0, "Wednesday", "dep1"); prefrences.Add(toadd);
            toadd = new Prefrence("John1", "2020-03-20", 1, "Wednesday", "dep1"); prefrences.Add(toadd);
            toadd = new Prefrence("John1", "2020-03-20", 2, "Wednesday", "dep1"); prefrences.Add(toadd);
            toadd = new Prefrence("John1", "2020-03-20", 1, "Friday", "dep1"); prefrences.Add(toadd);

            toadd = new Prefrence("John2", "2020-03-20", 0, "Tuesday", "dep1"); prefrences.Add(toadd);
            toadd = new Prefrence("John2", "2020-03-20", 1, "Tuesday", "dep1"); prefrences.Add(toadd);
            toadd = new Prefrence("John2", "2020-03-20", 2, "Tuesday", "dep1"); prefrences.Add(toadd);
            toadd = new Prefrence("John2", "2020-03-20", 0, "Monday", "dep1"); prefrences.Add(toadd);
            toadd = new Prefrence("John2", "2020-03-20", 1, "Monday", "dep1"); prefrences.Add(toadd);
            toadd = new Prefrence("John2", "2020-03-20", 2, "Monday", "dep1"); prefrences.Add(toadd);
            toadd = new Prefrence("John2", "2020-03-20", 0, "Wednesday", "dep1"); prefrences.Add(toadd);
            toadd = new Prefrence("John2", "2020-03-20", 1, "Wednesday", "dep1"); prefrences.Add(toadd);
            toadd = new Prefrence("John2", "2020-03-20", 2, "Wednesday", "dep1"); prefrences.Add(toadd);
            toadd = new Prefrence("John2", "2020-03-20", 1, "Friday", "dep1"); prefrences.Add(toadd);

            toadd = new Prefrence("John3", "2020-03-20", 0, "Tuesday", "dep1"); prefrences.Add(toadd);
            toadd = new Prefrence("John3", "2020-03-20", 1, "Tuesday", "dep1"); prefrences.Add(toadd);
            toadd = new Prefrence("John3", "2020-03-20", 2, "Tuesday", "dep1"); prefrences.Add(toadd);
            toadd = new Prefrence("John3", "2020-03-20", 0, "Monday", "dep1"); prefrences.Add(toadd);
            toadd = new Prefrence("John3", "2020-03-20", 1, "Monday", "dep1"); prefrences.Add(toadd);
            toadd = new Prefrence("John3", "2020-03-20", 2, "Monday", "dep1"); prefrences.Add(toadd);
            toadd = new Prefrence("John3", "2020-03-20", 0, "Wednesday", "dep1"); prefrences.Add(toadd);
            toadd = new Prefrence("John3", "2020-03-20", 1, "Wednesday", "dep1"); prefrences.Add(toadd);
            toadd = new Prefrence("John3", "2020-03-20", 2, "Wednesday", "dep1"); prefrences.Add(toadd);
            toadd = new Prefrence("John3", "2020-03-20", 1, "Friday", "dep1"); prefrences.Add(toadd);

            toadd = new Prefrence("John4", "2020-03-20", 0, "Tuesday", "dep2"); prefrences.Add(toadd);
            toadd = new Prefrence("John4", "2020-03-20", 1, "Tuesday", "dep2"); prefrences.Add(toadd);
            toadd = new Prefrence("John4", "2020-03-20", 2, "Tuesday", "dep2"); prefrences.Add(toadd);
            toadd = new Prefrence("John4", "2020-03-20", 0, "Monday", "dep2"); prefrences.Add(toadd);
            toadd = new Prefrence("John4", "2020-03-20", 1, "Monday", "dep2"); prefrences.Add(toadd);
            toadd = new Prefrence("John4", "2020-03-20", 2, "Monday", "dep2"); prefrences.Add(toadd);
            toadd = new Prefrence("John4", "2020-03-20", 0, "Wednesday", "dep2"); prefrences.Add(toadd);
            toadd = new Prefrence("John4", "2020-03-20", 1, "Wednesday", "dep2"); prefrences.Add(toadd);
            toadd = new Prefrence("John4", "2020-03-20", 2, "Wednesday", "dep2"); prefrences.Add(toadd);
            toadd = new Prefrence("John4", "2020-03-20", 1, "Friday", "dep2"); prefrences.Add(toadd);

            toadd = new Prefrence("John5", "2020-03-20", 0, "Tuesday", "dep2"); prefrences.Add(toadd);
            toadd = new Prefrence("John5", "2020-03-20", 1, "Tuesday", "dep2"); prefrences.Add(toadd);
            toadd = new Prefrence("John5", "2020-03-20", 2, "Tuesday", "dep2"); prefrences.Add(toadd);
            toadd = new Prefrence("John5", "2020-03-20", 0, "Monday", "dep2"); prefrences.Add(toadd);
            toadd = new Prefrence("John5", "2020-03-20", 1, "Monday", "dep2"); prefrences.Add(toadd);
            toadd = new Prefrence("John5", "2020-03-20", 2, "Monday", "dep2"); prefrences.Add(toadd);
            toadd = new Prefrence("John5", "2020-03-20", 0, "Wednesday", "dep2"); prefrences.Add(toadd);
            toadd = new Prefrence("John5", "2020-03-20", 1, "Wednesday", "dep2"); prefrences.Add(toadd);
            toadd = new Prefrence("John5", "2020-03-20", 2, "Wednesday", "dep2"); prefrences.Add(toadd);
            toadd = new Prefrence("John5", "2020-03-20", 1, "Friday", "dep2"); prefrences.Add(toadd);
            departments.Add("dep1");
            departments.Add("dep2");
        }

        public void LoadDataFromDatabase() // used to load data  from preference table and department table
        {
            using (MySqlConnection con = SqlConnectionHandler.GetSqlConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand($"SELECT * FROM preferences INNER JOIN users ON users.userID=preferences.userID ", con))
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        string userID = dataReader["userID"].ToString();
                        string day = dataReader["day"].ToString();
                        string date = dataReader["date"].ToString();
                        int workshift = Convert.ToInt32(dataReader["workshift"]);
                        string departmentID = dataReader["departmentID"].ToString();
                        Prefrence ToAdd = new Prefrence(userID, date, workshift, day,departmentID);
                        departments.Add(departmentID);
                        prefrences.Add(ToAdd);
                    }

                    dataReader.Close();
                }
                con.Close();
            }// load preferences and departments       
        }
        #endregion

        #region Main Methods
        public List<WorkshiftData> GenerateWorkshiftSchedule()
        {
            //LoadDataFromDatabase();
            LoadManualTestData();

            foreach(string department in departments) // will do this for each department
            {
                List<Prefrence> CurrentDepartmentEmployeesPreferences = GetCurrentDeparmentPreferences(department);
                // for simplicity's sake making a secondary list of preferences for the current department
                foreach(Prefrence p in CurrentDepartmentEmployeesPreferences)
                {
                    WorkshiftData ToAdd = new WorkshiftData(p.UserID,ConvertToDateString(p.Day),p.Workshift,p.Day,p.DepartmentID);
                    Schedule.Add(ToAdd);
                }
                for(int i=0;i<5;i++)
                    for(int j=0;j<3;j++)
                    {
                        if(HasPeopleAssigned(converttoday(i),j,department)==false)// checks if there is anyone assigned on this shift
                        {
                            for(int index=0;index<Schedule.Count();index++)
                            {
                                WorkshiftData ToCheck = Schedule[index];
                                if(HasMultipleEntries(Schedule[i].Day, Schedule[i].Workshift) == true && Schedule[i].DepartmentID==department)
                                {
                                    //remove this guy from workshift and add it to current
                                    WorkshiftData ToAdd = new WorkshiftData(Schedule[index].UserID, converttodate(i), j, converttoday(i), department);
                                    Schedule.RemoveAt(index);// remove the current guy from his already assigned workshift
                                    Schedule.Add(ToAdd);// add him to this one that requries someone to cover it
                                }
                            }

                        }
                    }
            }
            return Schedule;
        }

        public void ExportToDatabase()
        {
            int entries = Schedule.Count();
            for(int i=0;i<entries;i++) // creating the entries for the whole month 
            {
                string userID = Schedule[i].UserID;
                DateTime date = Schedule[i].Date;
                int workshift = Schedule[i].Workshift;
                string day = Schedule[i].Day;
                string departmentID = Schedule[i].DepartmentID;
                WorkshiftData ToAdd = new WorkshiftData(userID, date.AddDays(7),workshift, day, departmentID); //week2
                Schedule.Add(ToAdd);
                ToAdd = new WorkshiftData(userID, date.AddDays(14), workshift, day, departmentID); //week3
                Schedule.Add(ToAdd);
                ToAdd = new WorkshiftData(userID, date.AddDays(21), workshift, day, departmentID); //week4
                Schedule.Add(ToAdd);
            }

            foreach(WorkshiftData w in Schedule) // actually adding it to the database
            {
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
        }

        #endregion

        #region Auxiliary Methods
        public bool HasMultipleEntries(string day, int workshift)
        {
            int timesfound = 0;
            foreach(WorkshiftData w in Schedule)
            {
                if (timesfound == 2)
                    return true;
                else
                {
                    if ( day == w.Day && workshift == w.Workshift)
                        timesfound++;
                }
            }
            return false;
        }
        public List<Prefrence> GetCurrentDeparmentPreferences( string departmentID) // will return preferences of emplyoees that are in the provided department 
        {
            List<Prefrence> ToReturn = new List<Prefrence>();
            foreach(Prefrence p in prefrences)
            {
                if (p.DepartmentID == departmentID)
                    ToReturn.Add(p);
            }
            return ToReturn;
        }
       
        public bool HasPeopleAssigned(string day, int shift,string departmentID) // checks if the shift has people assigned to it or not, by checking its existence
        {
            foreach(WorkshiftData w in Schedule)
            {
                if (w.Day == day && w.Workshift == shift && w.DepartmentID == departmentID)
                    return true;
            }
            return false;
        }
        public string converttoday(int x)
        {
            switch (x)
            {
                case 0:
                    return "Monday";


                case 1:
                    return "Tuesday";


                case 2:
                    return "Wednesday";


                case 3:
                    return "Thursday";


                case 4:
                    return "Friday";

                case 5:
                    return "Saturday";


                case 6:
                    return "Sunday";

                default:
                    return "Error";


            }
        }

        public DateTime converttodate(int x)
        {
            return nextmonday.AddDays(x);
            
        }
        public DateTime ConvertToDateString(string ToConvert)
        {
            switch (ToConvert)
            {
                case "Monday":
                    return nextmonday;


                case "Tuesday":
                    return nextmonday.AddDays(1);


                case "Wednesday":
                    return nextmonday.AddDays(2);


                case "Thursday":
                    return nextmonday.AddDays(3);


                case "Friday":
                    return nextmonday.AddDays(4);

                case "Saturday":
                    return nextmonday.AddDays(5);


                case "Sunday":
                    return nextmonday.AddDays(6);

                default:
                    return nextmonday.AddDays(7);


            }
        }
        #endregion
    }
}

