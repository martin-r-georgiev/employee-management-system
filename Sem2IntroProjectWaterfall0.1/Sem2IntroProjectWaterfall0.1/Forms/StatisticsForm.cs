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
                case 2:
                    ClearChart();
                    GetDataForItemsPerDepartment();
                    break;
                default:
                    break;
            }
        }

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
                using (MySqlCommand cmd = new MySqlCommand($"SELECT COUNT(role) as 'Employees', role FROM users GROUP by role", con))
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        string NumberOfEmplyoees = dataReader["Employees"].ToString();
                        string role = dataReader["role"].ToString();
                        chart1.Series["EmplyoeesPerRole"].Points.AddXY(role, NumberOfEmplyoees);
                    }

                    dataReader.Close();
                }
                con.Close();
            }
            AlreadyClear = false;
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
}
