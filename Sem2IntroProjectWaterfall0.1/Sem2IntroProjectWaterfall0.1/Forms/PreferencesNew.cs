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
    public partial class PreferencesNew : Form
    {
        CheckBox[] allCbs;
        Employee currentEmployee;
        int employeeWorkshifts;
        public PreferencesNew()
        {
            InitializeComponent();
            allCbs = new CheckBox[] {cbMonM, cbMonA, cbMonE, cbTueM, cbTueA, cbTueE, cbWedM, cbWedA, cbWedE, cbThursdayMorning,
                cbThursdayAfternoon, cbThursdayEvening, cbFridayMorning, cbFridayAfternoon, cbFridayEvening};
            currentEmployee = new Employee(LoggedInUser.userID,true);
            employeeWorkshifts = currentEmployee.WorkHours / 4;
            lblPreferences.Text = $"0/{employeeWorkshifts}";
        }

        private void cbMon_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++) allCbs[i].Checked = cbMon.Checked;
        }

        private void cbTue_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 3; i < 6; i++) allCbs[i].Checked = cbTue.Checked;
        }

        private void cbWed_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 6; i < 9; i++) allCbs[i].Checked = cbWed.Checked;
        }

        private void cbThursday_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 9; i < 12; i++) allCbs[i].Checked = cbThursday.Checked;
        }

        private void cbFriday_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 12; i < 15; i++) allCbs[i].Checked = cbFriday.Checked;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            int shiftCount = 0;
            foreach (CheckBox cb in allCbs)
                if (cb.Checked) shiftCount++;
            if (shiftCount != employeeWorkshifts) MessageBox.Show($"Please pick shifts to match your work hours ({employeeWorkshifts} shifts)", "Workshifts not enough", MessageBoxButtons.OK);
            else
            {

                // code here
                if (CheckIfAlreadyPicked() == false)
                {
                    for (int i = 0; i < 15; i++)
                    {
                        if (allCbs[i].Checked == true)
                        {
                            int day = (i / 3);
                            int shift = i % 3;
                            DateTime DateOfPreferencePick = new DateTime();
                            DateOfPreferencePick = DateTime.Now;
                            Prefrence ToAdd = new Prefrence(LoggedInUser.userID, day, shift, DateOfPreferencePick.ToString("yyyy/MM/dd"));
                            ToAdd.ExpediteToDatabase();
                        }

                        this.Close();
                    }
                    MessageBox.Show("Succesfully picked preferences", "Preferences success", MessageBoxButtons.OK);
                    UploadPreferences();
                }
                else
                {

                    using (MySqlConnection con = SqlConnectionHandler.GetSqlConnection()) // deletes current preferences
                    {
                        MySqlCommand cmd;
                        using (cmd = new MySqlCommand($"DELETE from preferences where userID=@userID", con))
                        {
                            cmd.Parameters.AddWithValue("@userID",LoggedInUser.userID);
                            cmd.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        con.Close();
                    }
                    for (int i = 0; i < 15; i++) // adds current preferences
                    {
                        if (allCbs[i].Checked == true)
                        {
                            int day = (i / 3);
                            int shift = i % 3;
                            DateTime DateOfPreferencePick = new DateTime();
                            DateOfPreferencePick = DateTime.Now;
                            Prefrence ToAdd = new Prefrence(LoggedInUser.userID, day, shift, DateOfPreferencePick.ToString("yyyy/MM/dd"));
                            ToAdd.ExpediteToDatabase();
                        }

                        this.Close();
                    }


                    MessageBox.Show("Preferences updated!");
                }
            }
        }

        private bool CheckIfAlreadyPicked()
        {
            using (MySqlConnection con = SqlConnectionHandler.GetSqlConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand($"SELECT * FROM preferences", con))
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        string userID = dataReader["userID"].ToString();
                        if (userID == LoggedInUser.userID)
                            return true;
                    }

                    dataReader.Close();
                }
                con.Close();
            }// load preferences and departments    
            return false;
        }

        //Still testing
        private void RefreshGUI(int checkBoxIndex, CheckBox mainCheckbox)
        {
            for (int i = checkBoxIndex; i < checkBoxIndex + 3; i++)
                if (allCbs[i].Checked)
                {
                    mainCheckbox.Checked = true;
                    return;
                }
            mainCheckbox.Checked = false;
        }

        private void cbMonM_CheckedChanged(object sender, EventArgs e)
        {
            int shiftCount = 0;
            foreach (CheckBox cb in allCbs)
                if (cb.Checked) shiftCount++;
            lblPreferences.Text = $"{shiftCount}/{employeeWorkshifts}";

            if (shiftCount < employeeWorkshifts) lblPreferences.ForeColor = Color.FromArgb(192, 64, 0);
            else if (shiftCount > employeeWorkshifts) lblPreferences.ForeColor = Color.Red;
            else lblPreferences.ForeColor = Color.Green;
        }

        public void UploadPreferences()
        {

            List<Prefrence> prefrences = new List<Prefrence>();
            List<WorkshiftData> Schedule = new List<WorkshiftData>();
            using (MySqlConnection con = SqlConnectionHandler.GetSqlConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand($"SELECT * FROM preferences WHERE userID=@userID ", con))
                {
                    cmd.Parameters.AddWithValue("@userID", LoggedInUser.userID);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        string userID = dataReader["userID"].ToString();
                        string day = dataReader["day"].ToString();
                        string date = dataReader["date"].ToString();
                        int workshift = Convert.ToInt32(dataReader["workshift"]);
                        string departmentID ="";
                        Prefrence ToAdd = new Prefrence(userID, date, workshift, day, departmentID);
                        prefrences.Add(ToAdd);
                    }

                    dataReader.Close();
                }
                con.Close();
            }// load preferences and departments       
            foreach (Prefrence p in prefrences)
            {
                WorkshiftData ToAdd = new WorkshiftData(LoggedInUser.userID, ConvertToDateString(p.Day), p.Workshift, p.Day, p.DepartmentID);
                Schedule.Add(ToAdd);
            }

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
                using (MySqlConnection con = SqlConnectionHandler.GetSqlConnection())
                {
                    MySqlCommand cmd;
                    if (w.Date > DateTime.Now)
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

        public DateTime ConvertToDateString(string ToConvert)
        {
            DateTime nextmonday = DateTime.Now.StartOfWeek(DayOfWeek.Monday); // gets the current weeks monday
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
    }
}
