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
        List<Prefrence> prefrences = new List<Prefrence>();
        List<WorkshiftData> Schedule = new List<WorkshiftData>();
        List<ShiftsWorked> shiftsWorked = new List<ShiftsWorked>();
        DateTime nextmonday = DateTime.Now.StartOfWeek(DayOfWeek.Monday);


        public void intitializeShiftsWorked()
        {
            foreach (Prefrence p in prefrences)
            {
                bool value = !searchforworker(p.UserID);
                if (value)
                {
                    ShiftsWorked toadd = new ShiftsWorked();
                    toadd.userID = p.UserID;
                    toadd.shifts = 0;
                    toadd.prefrences = 0;
                    shiftsWorked.Add(toadd);
                }
            }
        }
        public bool searchforworker(string id)
        {
            foreach (ShiftsWorked s in shiftsWorked)
            {
                if (s.userID == id)
                    return true;
            }
            return false;
        }
        public void testdata1()
        {

            Prefrence toadd;
            toadd = new Prefrence("John1", "2020-03-20", 1, "Tuesday");
            prefrences.Add(toadd);
            toadd = new Prefrence("John1", "2020-03-20", 0, "Tuesday");
            prefrences.Add(toadd);
            toadd = new Prefrence("John1", "2020-03-20", 2, "Tuesday");
            prefrences.Add(toadd);
            toadd = new Prefrence("John3", "2020-03-20", 1, "Friday");
            prefrences.Add(toadd);
            toadd = new Prefrence("John4", "2020-03-20", 2, "Friday");
            prefrences.Add(toadd);
            toadd = new Prefrence("John5", "2020-03-20", 0, "Friday");
            prefrences.Add(toadd);
            toadd = new Prefrence("John7", "2020-03-20", 2, "Tuesday");
            prefrences.Add(toadd);
            toadd = new Prefrence("John8", "2020-03-20", 2, "Tuesday");
            prefrences.Add(toadd);
            toadd = new Prefrence("John8", "2020-03-20", 0, "Tuesday");
            prefrences.Add(toadd);





        }

        public void LoadData()
        {
            using (MySqlConnection con = SqlConnectionHandler.GetSqlConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand($"SELECT * FROM prefrences ", con))
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        Prefrence toadd = new Prefrence(dataReader["userID"].ToString(), dataReader["date"].ToString(), Convert.ToInt32(dataReader["workshift"]), dataReader["day"].ToString());
                    }

                    dataReader.Close();
                }
                con.Close();
            }
        }




        public List<WorkshiftData> GenerateSchedule()
        {
            
            testdata1();
            intitializeShiftsWorked();
            int totalemployees = shiftsWorked.Count();
            int totalshifts = 15;
            int minimumshifts = 10;
            int pplpershift = 0;
            int shiftswithextrappl = 0;
            //10 shifts is minimum amount of shifts
            if (totalemployees < 2)
            {
                minimumshifts = 15;
                pplpershift = 1;
            }
            else
            {

                pplpershift = 10 * totalemployees / totalshifts;
                shiftswithextrappl = 10 * totalemployees - pplpershift * totalshifts;
                minimumshifts = 10;


            }

            for (int i = 0; i < 5; i++) //days of the week
            {
                
                for (int j = 0; j < 3; j++)// shifts
                {
                    List<Prefrence> currentshiftprefrence = ReturnPrefrences(converttoday(i), j);
                    if (currentshiftprefrence.Count() > 0)// if there's ppl who have a prefrence for this shift
                    {
                        int current = 0;
                        if (currentshiftprefrence.Count() > pplpershift) // more ppl that want than spots
                        {

                            foreach (Prefrence p in currentshiftprefrence)
                            {


                                if (current < pplpershift)
                                {
                                    int index = findindex(p.UserID);
                                    if (shiftsWorked[index].shifts < minimumshifts)
                                    {
                                        shiftsWorked[index].shifts++;
                                        WorkshiftData toadd = new WorkshiftData(p.UserID, converttodate(i).ToString("yyyy/MM/dd"), j, converttoday(i));
                                        Schedule.Add(toadd);
                                        current++;
                                        shiftsWorked[index].prefrences++;
                                    }
                                }
                                else if (shiftswithextrappl > 0)
                                {
                                    int index = findindex(p.UserID);

                                    if (shiftsWorked[index].shifts < minimumshifts)
                                    {

                                        shiftsWorked[index].shifts++;
                                        shiftsWorked[index].prefrences++;
                                        WorkshiftData toadd = new WorkshiftData(p.UserID, converttodate(i).ToString("yyyy/MM/dd"), j, converttoday(i));
                                        Schedule.Add(toadd);
                                        shiftswithextrappl--;
                                        break;
                                    }
                                }

                            }



                        }
                        else // enough spots to people that want it
                        {
                            //add them to the schedule
                            foreach (Prefrence p in currentshiftprefrence)
                            {

                                int index = findindex(p.UserID);
                                if (shiftsWorked[index].shifts < minimumshifts)
                                {
                                    WorkshiftData toadd = new WorkshiftData(p.UserID, converttodate(i).ToString("yyyy/MM/dd"), j, converttoday(i));
                                    Schedule.Add(toadd);
                                    shiftsWorked[index].shifts++;
                                    shiftsWorked[index].prefrences++;
                                }

                            }
                        }
                    }
                    else // noone prefers this shift so we assign the number of people per shift with the lowest worked hours
                    {
                        List<ShiftsWorked> sortedlist = shiftsWorked.OrderByDescending(ShiftsWorked => ShiftsWorked.prefrences).ToList();
                        int current = 0;
                        foreach (ShiftsWorked s in sortedlist)
                        {

                            if (s.shifts < minimumshifts)
                            {
                                if (current < pplpershift)
                                {
                                    int index = findindex(s.userID);
                                    shiftsWorked[index].shifts++;
                                    WorkshiftData toadd = new WorkshiftData(s.userID, converttodate(i).ToString("yyyy/MM/dd"), j, converttoday(i));
                                    Schedule.Add(toadd);
                                    current++;
                                }
                                else if (shiftswithextrappl > 0)
                                {
                                    int index = findindex(s.userID);
                                    shiftsWorked[index].shifts++;
                                    WorkshiftData toadd = new WorkshiftData(s.userID, converttodate(i).ToString("yyyy/MM/dd"), j, converttoday(i));
                                    Schedule.Add(toadd);
                                    shiftswithextrappl--;
                                    break;
                                }
                            }


                        }


                    }
                }// shift loop

            }// day loop

            return Schedule;
        }// end of generate workshift 





        public List<Prefrence> ReturnPrefrences(string day, int workshift)
        {
            List<Prefrence> toreturn = new List<Prefrence>();
            foreach (Prefrence p in prefrences)
            {
                if (p.Workshift == workshift && p.Day == day)
                    toreturn.Add(p);
            }
            return toreturn;
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
            switch (x)
            {
                case 0:
                    return nextmonday;


                case 1:
                    return nextmonday.AddDays(1);


                case 2:
                    return nextmonday.AddDays(2);


                case 3:
                    return nextmonday.AddDays(3);


                case 4:
                    return nextmonday.AddDays(4);

                case 5:
                    return nextmonday.AddDays(5);


                case 6:
                    return nextmonday.AddDays(6);

                default:
                    return nextmonday.AddDays(7);


            }
        }
        public int findindex(string ID) //shiftsworked class
        {
            int i = 0;
            foreach (ShiftsWorked s in shiftsWorked)
            {
                if (s.userID == ID)
                    return i;
                i++;
            }
            return -1;
        }

    }
}

