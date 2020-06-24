using MediaBazaarApplicationWPF.Commands;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace MediaBazaarApplicationWPF.ViewModels
{
    class PreferencesViewModel : BaseViewModel
    {
        private bool?[,] CheckBoxes;
        private readonly Employee employee;
        private string lblWorkhours;
        private SolidColorBrush lblWorkshoursForeground;

        private string confirmText;
        private bool confirmTextVisible;
        private SolidColorBrush confirmTextForeground;

        public delegate void CloseWindowHandler(string message);
        public event CloseWindowHandler CloseWindowEvent;

        private readonly DelegateCommand _confirmWorkshiftPreferences;

        public bool? this[int i, int j]
        {
            get => this.CheckBoxes[i, j];
            set
            {
                this.CheckBoxes[i, j] = value;
                OnPropertyChanged();
            }
        }

        #region # Monday CheckBox Properties

        public bool? CheckBoxMonday
        {
            get => this.CheckBoxes[0, 0];
            set
            {
                this.CheckBoxes[0, 0] = value;
                OnPropertyChanged();

                this.CheckBoxMondayM = this.CheckBoxMondayA = this.CheckBoxMondayE = this.CheckBoxMonday;
                CalculateWorkhours();
            }
        }

        public bool? CheckBoxMondayM
        {
            get => this.CheckBoxes[0, 1];
            set
            {
                this.CheckBoxes[0, 1] = value;
                OnPropertyChanged();
                CalculateWorkhours();
            }
        }

        public bool? CheckBoxMondayA
        {
            get => this.CheckBoxes[0, 2];
            set
            {
                this.CheckBoxes[0, 2] = value;
                OnPropertyChanged();
                CalculateWorkhours();
            }
        }

        public bool? CheckBoxMondayE
        {
            get => this.CheckBoxes[0, 3];
            set
            {
                this.CheckBoxes[0, 3] = value;
                OnPropertyChanged();
                CalculateWorkhours();
            }
        }

        #endregion

        #region # Tuesday CheckBox Properties

        public bool? CheckBoxTuesday
        {
            get => this.CheckBoxes[1, 0];
            set
            {
                this.CheckBoxes[1, 0] = value;
                OnPropertyChanged();

                this.CheckBoxTuesdayM = this.CheckBoxTuesdayA = this.CheckBoxTuesdayE = this.CheckBoxTuesday;
                CalculateWorkhours();
            }
        }

        public bool? CheckBoxTuesdayM
        {
            get => this.CheckBoxes[1, 1];
            set
            {
                this.CheckBoxes[1, 1] = value;
                OnPropertyChanged();
                CalculateWorkhours();
            }
        }

        public bool? CheckBoxTuesdayA
        {
            get => this.CheckBoxes[1, 2];
            set
            {
                this.CheckBoxes[1, 2] = value;
                OnPropertyChanged();
                CalculateWorkhours();
            }
        }

        public bool? CheckBoxTuesdayE
        {
            get => this.CheckBoxes[1, 3];
            set
            {
                this.CheckBoxes[1, 3] = value;
                OnPropertyChanged();
                CalculateWorkhours();
            }
        }

        #endregion

        #region # Wednesday CheckBox Properties

        public bool? CheckBoxWednesday
        {
            get => this.CheckBoxes[2, 0];
            set
            {
                this.CheckBoxes[2, 0] = value;
                OnPropertyChanged();

                this.CheckBoxWednesdayM = this.CheckBoxWednesdayA = this.CheckBoxWednesdayE = this.CheckBoxWednesday;
                CalculateWorkhours();
            }
        }
        public bool? CheckBoxWednesdayM
        {
            get => this.CheckBoxes[2, 1];
            set
            {
                this.CheckBoxes[2, 1] = value;
                OnPropertyChanged();
                CalculateWorkhours();
            }
        }
        public bool? CheckBoxWednesdayA
        {
            get => this.CheckBoxes[2, 2];
            set
            {
                this.CheckBoxes[2, 2] = value;
                OnPropertyChanged();
                CalculateWorkhours();
            }
        }
        public bool? CheckBoxWednesdayE
        {
            get => this.CheckBoxes[2, 3];
            set
            {
                this.CheckBoxes[2, 3] = value;
                OnPropertyChanged();
                CalculateWorkhours();
            }
        }

        #endregion

        #region # Thursday CheckBox Properties

        public bool? CheckBoxThursday
        {
            get => this.CheckBoxes[3, 0];
            set
            {
                this.CheckBoxes[3, 0] = value;
                OnPropertyChanged();

                this.CheckBoxThursdayM = this.CheckBoxThursdayA = this.CheckBoxThursdayE = this.CheckBoxThursday;
                CalculateWorkhours();
            }
        }

        public bool? CheckBoxThursdayM
        {
            get => this.CheckBoxes[3, 1];
            set
            {
                this.CheckBoxes[3, 1] = value;
                OnPropertyChanged();
                CalculateWorkhours();
            }
        }

        public bool? CheckBoxThursdayA
        {
            get => this.CheckBoxes[3, 2];
            set
            {
                this.CheckBoxes[3, 2] = value;
                OnPropertyChanged();
                CalculateWorkhours();
            }
        }

        public bool? CheckBoxThursdayE
        {
            get => this.CheckBoxes[3, 3];
            set
            {
                this.CheckBoxes[3, 3] = value;
                OnPropertyChanged();
                CalculateWorkhours();
            }
        }

        #endregion

        #region # Friday CheckBox Properties

        public bool? CheckBoxFriday
        {
            get => this.CheckBoxes[4, 0];
            set
            {
                this.CheckBoxes[4, 0] = value;
                OnPropertyChanged();

                this.CheckBoxFridayM = this.CheckBoxFridayA = this.CheckBoxFridayE = this.CheckBoxFriday;
                CalculateWorkhours();
            }
        }

        public bool? CheckBoxFridayM
        {
            get => this.CheckBoxes[4, 1];
            set
            {
                this.CheckBoxes[4, 1] = value;
                OnPropertyChanged();
                CalculateWorkhours();
            }
        }

        public bool? CheckBoxFridayA
        {
            get => this.CheckBoxes[4, 2];
            set
            {
                this.CheckBoxes[4, 2] = value;
                OnPropertyChanged();
                CalculateWorkhours();
            }
        }

        public bool? CheckBoxFridayE
        {
            get => this.CheckBoxes[4, 3];
            set
            {
                this.CheckBoxes[4, 3] = value;
                OnPropertyChanged();
                CalculateWorkhours();
            }
        }

        #endregion

        public Employee Employee => this.employee;
        public string LabelWorkhours
        {
            get => this.lblWorkhours;
            set
            {
                this.lblWorkhours = value;
                OnPropertyChanged();
            }
        }

        public string ConfirmText
        {
            get => this.confirmText;
            set
            {
                this.confirmText = value;
                OnPropertyChanged();
            }
        }

        public bool ConfirmTextVisible
        {
            get => this.confirmTextVisible;
            set
            {
                this.confirmTextVisible = value;
                OnPropertyChanged();
            }
        }

        public SolidColorBrush ConfirmTextVisibleForeground
        {
            get => this.confirmTextForeground;
            set
            {
                this.confirmTextForeground = value;
                OnPropertyChanged();
            }
        }

        public ICommand ConfirmWorkshiftPreferences => _confirmWorkshiftPreferences;

        public SolidColorBrush LabelWorkshoursForeground
        {
            get => this.lblWorkshoursForeground;
            set
            {
                this.lblWorkshoursForeground = value;
                OnPropertyChanged();
            }
        }

        public PreferencesViewModel()
        {
            this._confirmWorkshiftPreferences = new DelegateCommand(ConfirmWorkshiftPreferences_Event, CanChangeDate);

            this.CheckBoxes = new bool?[5, 4];
            this.employee = EmployeeDatabaseHandler.GetEmployee(LoggedInUser.userID, false);
            this.ConfirmTextVisible = false;

            CalculateWorkhours();
        }

        public void CalculateWorkhours()
        {
            int shiftCount = 0;

            for (int i = 0; i < 5; i++)
            {
                for (int j = 1; j < 4; j++) if (this.CheckBoxes[i, j] == true) shiftCount++;
            }

            this.LabelWorkhours = $"{shiftCount}/{this.Employee.WorkHours / 4}";

            if (shiftCount < (this.Employee.WorkHours / 4)) this.LabelWorkshoursForeground = new SolidColorBrush(Color.FromRgb(192, 64, 0));
            else if (shiftCount > (this.Employee.WorkHours / 4)) this.LabelWorkshoursForeground = new SolidColorBrush(Colors.Red);
            else this.LabelWorkshoursForeground = new SolidColorBrush(Colors.Green);
        }

        private bool PreferencesAlreadyPicked()
        {
            bool alreadyPicked = false;
            using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
            {
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand($"SELECT * FROM preferences", conn))
                    {
                        MySqlDataReader dataReader = cmd.ExecuteReader();

                        while (dataReader.Read())
                        {
                            if (dataReader["userID"].ToString() == LoggedInUser.userID)
                            {
                                alreadyPicked = true;
                                break;
                            }
                        }

                        dataReader.Close();
                        cmd.Dispose();
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                finally { conn.Close(); }
            }   
            return alreadyPicked;
        }

        private void PreparePreferences()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (this.CheckBoxes[i, j] == true)
                    {
                        int day = (i / 3);
                        int shift = i % 3;
                        WorkshiftPreferences newPreference = new WorkshiftPreferences(LoggedInUser.userID, day, shift, DateTime.Now.ToString("yyyy/MM/dd"));
                        newPreference.ExpediteToDatabase();
                    }
                }
            }
        }

        public void UploadPreferences()
        {
            List<WorkshiftPreferences> prefrences = new List<WorkshiftPreferences>();
            List<WorkshiftData> Schedule = new List<WorkshiftData>();
            using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
            {
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand($"SELECT * FROM preferences WHERE userID=@userID ", conn))
                    {
                        cmd.Parameters.AddWithValue("@userID", LoggedInUser.userID);
                        MySqlDataReader dataReader = cmd.ExecuteReader();
                        while (dataReader.Read())
                        {
                            string userID = dataReader["userID"].ToString();
                            string day = dataReader["day"].ToString();
                            string date = dataReader["date"].ToString();
                            int workshift = Convert.ToInt32(dataReader["workshift"]);
                            string departmentID = "";
                            prefrences.Add(new WorkshiftPreferences(userID, date, workshift, day, departmentID));
                        }
                        dataReader.Close();
                        cmd.Dispose();
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                finally { conn.Close(); }
            }
            
            foreach (WorkshiftPreferences p in prefrences)
            {
                Schedule.Add(new WorkshiftData(LoggedInUser.userID, ConvertToDateString(p.Day), p.Workshift, p.Day, p.DepartmentID));
            }

            int entries = Schedule.Count;
            for (int i = 0; i < entries; i++)
            {
                string userID = Schedule[i].UserID;
                DateTime date = Schedule[i].Date;
                int workshift = Schedule[i].Workshift;
                string day = Schedule[i].Day;
                string departmentID = Schedule[i].DepartmentID;
                Schedule.Add(new WorkshiftData(userID, date.AddDays(7), workshift, day, departmentID));
                Schedule.Add(new WorkshiftData(userID, date.AddDays(14), workshift, day, departmentID));
            }

            foreach (WorkshiftData w in Schedule) // actually adding it to the database
            {
                using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
                {
                    try
                    {
                        if (w.Date > DateTime.Now)
                        {
                            using (MySqlCommand cmd = new MySqlCommand($"INSERT INTO workshifts (userID, date, workshift) VALUES (@userID,@date, @workshift)", conn))
                            {
                                cmd.Parameters.AddWithValue("@userID", w.UserID);
                                cmd.Parameters.AddWithValue("@date", w.Date.ToString("yyyy/MM/dd"));
                                cmd.Parameters.AddWithValue("@workshift", w.Workshift);
                                cmd.ExecuteNonQuery();
                                cmd.Dispose();
                            }
                        }
                    }
                    catch (Exception ex) { Console.WriteLine(ex.Message); }
                    finally { conn.Close(); }
                }
            }
        }

        public DateTime ConvertToDateString(string ToConvert)
        {
            DateTime nextmonday = DateTimeControls.StartOfWeek(DateTime.Now, DayOfWeek.Monday);
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

        private void ConfirmWorkshiftPreferences_Event(object commandParameter)
        {
            int shiftCount = 0;

            for (int i = 0; i < 5; i++)
            {
                for (int j = 1; j < 4; j++) if (this.CheckBoxes[i, j] == true) shiftCount++;
            }


            if (shiftCount != (this.Employee.WorkHours / 4))
            {
                this.ConfirmText = $"Please pick enough shifts to match your work hours ({(this.Employee.WorkHours / 4)} shifts)";
                this.ConfirmTextVisibleForeground = new SolidColorBrush(Colors.Red);
                this.ConfirmTextVisible = true;
            }
            else
            {

                if (!PreferencesAlreadyPicked())
                {
                    PreparePreferences();
                    UploadPreferences();
                }
                else
                {
                    using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
                    {
                        try
                        {
                            using (MySqlCommand cmd = new MySqlCommand($"DELETE from preferences where userID=@userID", conn))
                            {
                                cmd.Parameters.AddWithValue("@userID", LoggedInUser.userID);
                                cmd.ExecuteNonQuery();
                                cmd.Dispose();
                            }
                        }
                        catch (Exception ex) { Console.WriteLine(ex.Message); }
                        finally { conn.Close(); }
                    }

                    PreparePreferences();
                }

                if (this.CloseWindowEvent != null) this.CloseWindowEvent("Succesfully updated preferences!");

                //this.ConfirmTextVisibleForeground = new SolidColorBrush(Colors.Green);
                //this.ConfirmText = "Succesfully updated preferences! You can now close this window.";
            }
        }

        private bool CanChangeDate(object commandParameter) => true;
    }
}
