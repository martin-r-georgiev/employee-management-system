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
    public partial class LoginScreen : Form
    {
        public static Logger logger = new Logger(LoggingLevels.INFO);
        List<WorkshiftData> workshiftss;

        public LoginScreen()
        {
            InitializeComponent();
            this.AcceptButton = btnLogin;
            //AutoWorkshift generate = new AutoWorkshift();
            //workshiftss= generate.GenerateWorkshiftSchedule();
            //testingworkshift();
            //generate.ExportToDatabase();
         }

        private void testingworkshift()
        {
            string message = "";
            List<WorkshiftData> sortedlist= workshiftss.OrderBy(workshiftss => workshiftss.Date).ToList(); 
            foreach (WorkshiftData w in sortedlist)
            {
                message = message +w.Date.ToString("yyyy/MM/dd")+" "+ w.Day + " " + w.Workshift + " " + w.UserID +" "+w.DepartmentID+"\n";
            }
            MessageBox.Show(message);
        }

       

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbUsername.Text) && !string.IsNullOrEmpty(tbPassword.Text))
            {
                using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
                {
                    try
                    {
                        using (MySqlCommand cmd = new MySqlCommand($"SELECT userID, username, password, role, departmentID FROM users WHERE username=@username AND password=@password", conn))
                        {
                            cmd.Parameters.AddWithValue("@username", tbUsername.Text);
                            cmd.Parameters.AddWithValue("@password", HashManager.GetSha256(tbPassword.Text));
                            MySqlDataReader dataReader = cmd.ExecuteReader();

                            if (dataReader.Read())
                            {
                                LoggedInUser.userID = dataReader.GetString(0);
                                LoggedInUser.role = (Role)dataReader.GetInt16(3);
                                LoggedInUser.departmentID = dataReader.GetString(4);
                                //Opening dashboard on successful login
                                Dashboard newScreen = new Dashboard();
                                newScreen.Show();
                                this.Hide();
                            }
                            else MessageBox.Show("Failed login attempt. Please try again.");
                        }
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show(ex.ToString(), $"Login failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    conn.Close();
                }
            }
            else MessageBox.Show("Please fill all required fields before attempting to log in!");
        }

        private void btnTempLogin_Click(object sender, EventArgs e)
        {
            LoggedInUser.userID = "AHrsSBGtkCE9kwraDlC5g";
            LoggedInUser.role = (Role)3;
            LoggedInUser.departmentID = "ebcpNLREqnrQjWbkrNNA";
            //Opening dashboard on successful login
            Dashboard newScreen = new Dashboard();
            newScreen.Show();
            this.Hide();
        }
    }   
}
