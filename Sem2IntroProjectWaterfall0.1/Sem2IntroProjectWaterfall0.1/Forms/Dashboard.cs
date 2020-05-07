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
    public partial class Dashboard : Form
    {
        List<RescheduleNotification> notifications;
        public Dashboard()
        {
            InitializeComponent();
            UpdateRoleGUI();
            notifications = new List<RescheduleNotification>();
            UpdatePresentWorkers();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            LoginScreen newScreen = new LoginScreen();
            newScreen.Show();
            this.Close();
        }

        private void btnStocks_Click(object sender, EventArgs e)
        {
            StockManagement newScreen = new StockManagement();
            newScreen.Show();
            this.Close();
        }

        private void btnStatistics_Click(object sender, EventArgs e)
        {
            EmployeeListing newScreen = new EmployeeListing();
            newScreen.Show();
            this.Close();
        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            EmployeeManagement newScreen = new EmployeeManagement();
            newScreen.Show();
            this.Close();
        }

        private void btnWorkshifts_Click(object sender, EventArgs e)
        {
            if (CheckIfUserHasPreference() == true)
            {
                Workshifts newScreen = new Workshifts();
                newScreen.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("You don't have any preferences selected. You will be taken to a preference selection page");
                PreferencesNew fsd = new PreferencesNew();
                fsd.Show();
                
            }
        }

        private void BtnCheckin_Click(object sender, EventArgs e)
        {
            if (btnCheckin.Text == "Check In")
            {
                CheckIn.Checkin(LoggedInUser.userID, DateTime.Now);
                btnCheckin.Text = "Check Out";
            } else if (btnCheckin.Text == "Check Out")
            {
                CheckIn.Checkout(LoggedInUser.userID, DateTime.Now);
                btnCheckin.Text = "Check In";
            }
            UpdatePresentWorkers();
        }
        private void UpdatePresentWorkers()
        {
            lbWorkers.Items.Clear();
            foreach (Employee e in CheckIn.GetEmployeesAtWork(LoggedInUser.departmentID))
            {
                if (e.FirstName == null) lbWorkers.Items.Add($"{e.Username}");
                else lbWorkers.Items.Add($"{e.FirstName} {e.LastName}");
            }
        }
        private void UpdateRoleGUI()
        {
            if (CheckIn.IsAtWork(LoggedInUser.userID)) btnCheckin.Text = "Check Out";
            else btnCheckin.Text = "Check In";

            if (LoggedInUser.role >= Role.Manager)
            {
                btnRequests.Visible = true;
                btnStatistics.Visible = true;
            }
            if (LoggedInUser.role >= Role.Admin) btnEmployees.Visible = true;
        }
        public bool CheckIfUserHasPreference()
        {
            int numberofpreferences = 0;
            using (MySqlConnection con = SqlConnectionHandler.GetSqlConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand($"SELECT * FROM preferences where userID=@userID ", con))
                {
                    cmd.Parameters.AddWithValue("@userID", LoggedInUser.userID);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    
                    while (dataReader.Read())
                    {
                        numberofpreferences++;
                    }

                    dataReader.Close();
                }
                con.Close();
            }
            if(numberofpreferences==0)
            {
                return false;
            }
            return true;
        }

        private void btnRequests_Click(object sender, EventArgs e)
        {
            if (btnRequests.Text == "Open Requests")
            {
                pnlNotifications.Visible = true;
                btnRequests.Text = "Close Requests";
                RefreshNotifications();
                
            } else if (btnRequests.Text == "Close Requests")
            {
                pnlNotifications.Visible = false;
                btnRequests.Text = "Open Requests";
            }
        }

        public void RefreshNotifications()
        {
            if (LoggedInUser.role == Role.Owner) notifications = RescheduleNotification.GetAllNotifications();
            else notifications = RescheduleNotification.GetAllNotifications(LoggedInUser.departmentID);
            if (notifications.Count < 4) pnlNotifications.Size = new Size(200, 20 + 50 * notifications.Count);
            pnlNotifications.Controls.Clear();
            foreach (RescheduleNotification n in notifications)
                pnlNotifications.Controls.Add(new NotificationUC(n));
        }
    }
}
