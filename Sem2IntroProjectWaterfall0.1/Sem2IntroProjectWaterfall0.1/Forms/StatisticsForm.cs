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
    public partial class StatisticsForm : Form
    {
        bool AlreadyClear = true;

        public StatisticsForm()
        {
            InitializeComponent();
            GetDataForGeneral();
        }

        private void StatisticsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbStatistic.SelectedIndex)
            {
                case 0: // employeePerDepartment
                    ClearChart();
                    GetDataForEmployeePerDepartment();
                    chart1.Visible = true;
                    gbGeneralStat.Visible = false;
                    break;
                case 1: // employeePerRole
                    ClearChart();
                    GetDataForEmployeePerRole();
                    chart1.Visible = true;
                    gbGeneralStat.Visible = false;
                    break;
                case 2: // ItemsPerDepartment
                    ClearChart();
                    GetDataForItemsPerDepartment();
                    chart1.Visible = true;
                    gbGeneralStat.Visible = false;
                    break;
                case 3: //Prefered Day
                    ClearChart();
                    GetDataForPreferedDay();
                    chart1.Visible = true;
                    gbGeneralStat.Visible = false;
                    break;
                case 4: //Prefered shift
                    ClearChart();
                    GetDataForPreferedShift();
                    chart1.Visible = true;
                    gbGeneralStat.Visible = false;
                    break;
                case 5:   // General Statistics aka text
                    chart1.Visible = false;
                    gbGeneralStat.Visible = true;
                    GetDataForGeneral();
                    break;
                default:
                    break;
            }
        }
        #region MethodsToCreateChart
        private void GetDataForGeneral()
        {
            double totalEmplyoees = 0;

            using (MySqlConnection con = SqlConnectionHandler.GetSqlConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand($"select count(userID) as 'Total' from users ", con)) // just getting the total emplyoees
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        totalEmplyoees = Convert.ToDouble(dataReader["total"]);
                    }

                    dataReader.Close();
                }

                using (MySqlCommand cmd = new MySqlCommand($"SELECT sum(YEAR(CURRENT_TIMESTAMP) - YEAR(dateofBirth) - (RIGHT(CURRENT_TIMESTAMP, 5) < RIGHT(dateofBirth, 5))) as age ,sum(employees.Workhours) as 'total',sum(users.salary) as 'salary'  from employees INNER JOIN users  on employees.userID=users.userID ", con))
                {// Average hours,salary per all of them
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        double totalHours= Convert.ToDouble(dataReader["total"]);
                        double salary = Convert.ToDouble(dataReader["salary"]);
                        double age = Convert.ToDouble(dataReader["age"]);
                        lbAge.Text = "Average employee age is " + (age / totalEmplyoees).ToString("0.##") + ".";
                        lbHours.Text = "Average hours worked are " + (totalHours / totalEmplyoees).ToString("0.##")+".";
                        lbSalary.Text = "Average salary for an employee is " + (salary / totalEmplyoees).ToString("0.##") + ".";
                    }

                    dataReader.Close();
                }

                using (MySqlCommand cmd = new MySqlCommand($"SELECT users.role, sum(YEAR(CURRENT_TIMESTAMP) - YEAR(dateofBirth) - (RIGHT(CURRENT_TIMESTAMP, 5) < RIGHT(dateofBirth, 5))) as age,sum(users.salary) as 'salary',sum(employees.workHours) as 'hours', count(users.role) as 'emp'   from employees INNER JOIN users on employees.userID=users.userID group by role", con)) // average hours per role
                {// doing average salary and  hoursworked for each role
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                       if(dataReader["role"].ToString()=="0")
                        {
                            double hours= Convert.ToDouble(dataReader["hours"]);
                            double emp= Convert.ToDouble(dataReader["emp"]);
                            double salary = Convert.ToDouble(dataReader["salary"]);
                            double age = Convert.ToDouble(dataReader["age"]);
                            lbAgeWorker.Text = "Average Worker age is " + (age / emp).ToString("0.##") + ".";
                            lbSalaryWorker.Text = "Average salary for a Worker is " + (salary / emp).ToString("0.##") + ".";
                            lbHoursWorker.Text = "Average hours worked for a Worker are " + (hours / emp).ToString("0.##") + ".";
                        }
                        if (dataReader["role"].ToString() == "1")
                        {
                            double hours = Convert.ToDouble(dataReader["hours"]);
                            double emp = Convert.ToDouble(dataReader["emp"]);
                            double salary = Convert.ToDouble(dataReader["salary"]);
                            double age = Convert.ToDouble(dataReader["age"]);
                            lbAgeManager.Text = "Average Manager age is " + (age / emp).ToString("0.##") + ".";
                            lbSalaryManager.Text = "Average salary for a Manager is " + (salary / emp).ToString("0.##") + ".";
                            lbHoursManager.Text = "Average hours worked for a Manager are " + (hours / emp).ToString("0.##") + ".";
                        }
                        if (dataReader["role"].ToString() == "2")
                        {
                            double hours = Convert.ToDouble(dataReader["hours"]);
                            double emp = Convert.ToDouble(dataReader["emp"]);
                            double salary = Convert.ToDouble(dataReader["salary"]);
                            double age = Convert.ToDouble(dataReader["age"]);
                            lbAgeAdmin.Text = "Average Admin age is " + (age / emp).ToString("0.##") + ".";
                            lbSalaryAdmin.Text = "Average salary for an Admin is " + (salary / emp).ToString("0.##") + ".";
                            lbHoursAdmin.Text = "Average hours worked for an Admin are " + (hours / emp).ToString("0.##") + ".";
                        }

                    }

                    dataReader.Close();
                }

                using (MySqlCommand cmd = new MySqlCommand($"  SELECT employees.sex as 'gender',COUNT(employees.sex) as 'number' from employees WHERE employees.sex is not null GROUP by employees.sex ", con))
                {// Gender for all 
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    string messagestart = "There are ";
                    string message1 = "";
                    string message2 = "";

                    while (dataReader.Read())
                    {
                       if(dataReader["gender"].ToString()== "False")
                        {
                            message1 = message1 + dataReader["number"] + " female";
                        }else
                        {
                            message2= message2 +dataReader["number"] + " male";
                        }
                    }
                    lbGender.Text = messagestart+message1+ " and " + message2 + " employees.";
                    dataReader.Close();
                }


                using (MySqlCommand cmd = new MySqlCommand($" SELECT   users.role,employees.sex as 'gender', COUNT(employees.sex) as 'number' from employees INNER  JOIN users on users.userID=employees.userID where employees.sex is not null GROUP by users.role, employees.sex", con))
                {// Gender for each role 
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    string messagestart = "There are ";
                    string work1 = "";
                    string manager1 = "";
                    string admin1 = "";
                    string work2 = "";
                    string manager2 = "";
                    string admin2 = "";
                    while (dataReader.Read())
                    {
                        if (dataReader["role"].ToString() == "0")
                        {
                            if (dataReader["gender"].ToString() == "False")
                            {
                                work1 = work1 + dataReader["number"] + " female";
                            }
                            else
                            {
                                work2= work2 + dataReader["number"] + " male";
                               
                            }
                        }
                        if (dataReader["role"].ToString() == "1")
                        {
                            if (dataReader["gender"].ToString() == "False")
                            {
                                manager1 = manager1 + dataReader["number"] + " female";
                            }
                            else
                            {
                                manager2 = manager2 + dataReader["number"] + " male";
                            }
                        }
                        if (dataReader["role"].ToString() == "2")
                        {
                            if (dataReader["gender"].ToString() == "False")
                            {
                                admin1 = admin1 + dataReader["number"] + " female";
                            }
                            else
                            {
                                admin2 = admin2 + dataReader["number"] + " male";
                                
                            }
                        }
                    }
                    lbGenderWorker.Text = messagestart + work1+ "and" + work2 + " workers.";
                    lbGenderManager.Text = messagestart+ manager1+ "and" + manager2 + " managers.";
                    lbGenderAdmin.Text = messagestart+ admin1+"and"+admin2+" admins.";

                    dataReader.Close();
                }




                con.Close();
            }
        
        }
        private void GetDataForEmployeePerDepartment()
        {
            int totalEmplyoees=0;
            chart1.Titles.Add("Employees per Department");
            chart1.Series.Add("EmployeesPerDepartment");
            chart1.Series["EmployeesPerDepartment"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            using (MySqlConnection con = SqlConnectionHandler.GetSqlConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand($"select count(userID) as 'Total' from users ", con))
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        totalEmplyoees = Convert.ToInt32(dataReader["total"]);
                    }

                    dataReader.Close();
                }
                using (MySqlCommand cmd = new MySqlCommand($"SELECT COUNT(users.departmentID) as 'Employees',department.name FROM users INNER JOIN department ON users.departmentID=department.departmentID GROUP BY users.departmentID ", con))
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        int NumberOfEmplyoees = Convert.ToInt32(dataReader["Employees"]);
                        string databaseDepartment = dataReader["name"].ToString();
                        int percentage = (NumberOfEmplyoees * 100) / totalEmplyoees;
                        chart1.Series["EmployeesPerDepartment"].Points.AddXY(databaseDepartment+" "+NumberOfEmplyoees, percentage);
                    }

                    dataReader.Close();
                }
                con.Close();
            }  
            AlreadyClear = false;
        }

        private void GetDataForItemsPerDepartment()
        {
            List<string> ItemsWithADepartment = new List<string>();
            chart1.Titles.Add("Items distribution per Department");
            chart1.Series.Add("Items Per Department");
            
            using (MySqlConnection con = SqlConnectionHandler.GetSqlConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand($"SELECT stock_item.name, count(stock.departmentID) as 'count'  FROM stock  JOIN stock_item on stock_item.stockID=stock.stockID GROUP BY stock.stockID", con))
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        string numberOfDepartmentsItemIsIn = dataReader["count"].ToString();
                        string name = dataReader["name"].ToString();
                        ItemsWithADepartment.Add(name);
                        chart1.Series["Items Per Department"].Points.AddXY(name, numberOfDepartmentsItemIsIn);
                    }

                    dataReader.Close();
                }
                using (MySqlCommand cmd = new MySqlCommand($"select * from stock_item", con))
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                       
                        string name = dataReader["name"].ToString();

                        if (ItemsWithADepartment.IndexOf(name)<0)
                        chart1.Series["Items Per Department"].Points.AddXY(name, 0);
                    }

                    dataReader.Close();
                }

                con.Close();
            }
            AlreadyClear = false;
        }

        private void GetDataForEmployeePerRole() // weird error idk why bruh
        {
            chart1.Titles.Add("Employees per Role");
            chart1.Series.Add("EmployeesPerRole");
            using (MySqlConnection con = SqlConnectionHandler.GetSqlConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand($"SELECT COUNT(role) as 'Employees', role as 'notreservedkeyword' FROM users GROUP by role", con))
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        string NumberOfEmplyoees = dataReader["Employees"].ToString();
                        string role = dataReader["notreservedkeyword"].ToString();
                        chart1.Series["EmployeesPerRole"].Points.AddXY(ReturnRole(role), NumberOfEmplyoees);
                    }
                    dataReader.Close();
                }
                con.Close();
            }
            AlreadyClear = false;
        }

        private void GetDataForPreferedDay()
        {
            int totalSelections = 0;
            chart1.Titles.Add("Day preferences");
            chart1.Series.Add("DayPref");
            chart1.Series["DayPref"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            using (MySqlConnection con = SqlConnectionHandler.GetSqlConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand($"SELECT COUNT(day) as 'count' FROM preferences ", con))
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        totalSelections = Convert.ToInt32(dataReader["count"]);
                    }

                    dataReader.Close();
                }
                using (MySqlCommand cmd = new MySqlCommand($"SELECT COUNT(day) as 'count', day FROM preferences GROUP by day", con))
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        int nrOfTimesSelected = Convert.ToInt32(dataReader["count"]);
                        string day = dataReader["day"].ToString();
                        int percentage = (nrOfTimesSelected * 100) / totalSelections;
                        chart1.Series["DayPref"].Points.AddXY(day + " " + nrOfTimesSelected, percentage);
                    }

                    dataReader.Close();
                }
                con.Close();
            }
            AlreadyClear = false;
        }

        private void GetDataForPreferedShift()
        {
            int totalSelections = 0;
            chart1.Titles.Add("Shift preferences");
            chart1.Series.Add("ShiftPref");
            chart1.Series["ShiftPref"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            using (MySqlConnection con = SqlConnectionHandler.GetSqlConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand($"SELECT COUNT(day) as 'count' FROM preferences ", con))
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        totalSelections = Convert.ToInt32(dataReader["count"]);
                    }

                    dataReader.Close();
                }
                using (MySqlCommand cmd = new MySqlCommand($"SELECT count(workshift) as 'count',workshift from preferences GROUP BY workshift", con))
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        int nrOfTimesSelected = Convert.ToInt32(dataReader["count"]);
                        string workshift = dataReader["workshift"].ToString();
                        int percentage = (nrOfTimesSelected * 100) / totalSelections;
                        chart1.Series["ShiftPref"].Points.AddXY(ReturnShiftName(workshift) + " " + nrOfTimesSelected, percentage);
                    }

                    dataReader.Close();
                }
                con.Close();
            }
            AlreadyClear = false;
        }

        #endregion
        #region Auxiliary Methods

        public string ReturnShiftName(string shift)
        {
            switch (shift)
            {
                case "0": return "Morning";
                case "1": return "Lunch";
                case "2": return "Evening";
                default: return "EEROR";
            }
        }
        public string ReturnRole(string role)
        {
            switch(role)
            {
                case "0":
                    return "Worker";
                case "1":
                    return "Manager";
                case "2":
                    return "Administrator";
                case "3":
                    return "Owner";
                default:
                    return "ERROR";


            }
        }

        private void ClearChart()
        {
            if (!AlreadyClear)
            {
                chart1.Titles.RemoveAt(0);
                chart1.Series.RemoveAt(0);
                AlreadyClear = true;
            }
        }

        private void gbGeneralStat_Enter(object sender, EventArgs e)
        {

        }
    }
    #endregion
}
