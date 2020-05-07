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
        }

        private void StatisticsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbStatistic.SelectedIndex)
            {
                case 0: // empyloeePerDepartment
                    ClearChart();
                    GetDataForEmplyoeePerDepartment();
                    break;
                case 1: // emplyoeePerRole
                    ClearChart();
                    GetDataForEmplyoeePerRole();
                    break;
                case 2: // ItemsPerDepartment
                    ClearChart();
                    GetDataForItemsPerDepartment();
                    break;
                case 3: //Prefered Day
                    ClearChart();
                    GetDataForPreferedDay();
                    break;
                case 4: //Prefered shift
                    ClearChart();
                    GetDataForPreferedShift();
                    break;
                default:
                    break;
            }
        }
        #region MethodsToCreateChart
        private void GetDataForEmplyoeePerDepartment()
        {
            int totalEmplyoees=0;
            chart1.Titles.Add("Emplyoees per Department");
            chart1.Series.Add("EmplyoeesPerDepartment");
            chart1.Series["EmplyoeesPerDepartment"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
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
                        chart1.Series["EmplyoeesPerDepartment"].Points.AddXY(databaseDepartment+" "+NumberOfEmplyoees, percentage);
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
            chart1.Series.Add("ItemsPerDepartment");
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
                        chart1.Series["ItemsPerDepartment"].Points.AddXY(name, numberOfDepartmentsItemIsIn);
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
                        chart1.Series["ItemsPerDepartment"].Points.AddXY(name, 0);
                    }

                    dataReader.Close();
                }

                con.Close();
            }
            AlreadyClear = false;
        }

        private void GetDataForEmplyoeePerRole() // weird error idk why bruh
        {
            chart1.Titles.Add("Emplyoees per Role");
            chart1.Series.Add("EmplyoeesPerRole");
            using (MySqlConnection con = SqlConnectionHandler.GetSqlConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand($"SELECT COUNT(role) as 'Employees', role as 'notreservedkeyword' FROM users GROUP by role", con))
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        string NumberOfEmplyoees = dataReader["Employees"].ToString();
                        string role = dataReader["notreservedkeyword"].ToString();
                        chart1.Series["EmplyoeesPerRole"].Points.AddXY(role, NumberOfEmplyoees);
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
    }
    #endregion
}
