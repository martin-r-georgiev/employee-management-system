using DocumentFormat.OpenXml.Drawing.Charts;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Collections.ObjectModel;

namespace MediaBazaarApplicationWPF.ViewModels
{
	public class StatisticsViewModel : BaseViewModel
	{
		#region First Chart
		private ChartValues<int> firstammountofpeople;

		public ChartValues<int> FirstAmmountofpeople
		{
			get { return firstammountofpeople; }
			set { firstammountofpeople = value; }
		}
		private List<string> firstroles;
		public List<string> FirstRoles
		{
			get { return firstroles; }
			set { firstroles = value; }
		}
		void FirstChartEmployeesPerRole()
		{
			FirstAmmountofpeople = new ChartValues<int>();
			FirstRoles = new List<string>();
			using (MySqlConnection con = SqlConnectionHandler.GetSqlConnection())
			{
				using (MySqlCommand cmd = new MySqlCommand($"SELECT COUNT(role) as 'Employees', role as 'notreservedkeyword' FROM users GROUP by role", con))
				{
					MySqlDataReader dataReader = cmd.ExecuteReader();

					while (dataReader.Read())
					{
						int NumberOfEmplyoees = Convert.ToInt32(dataReader["Employees"]);
						int role = Convert.ToInt32(dataReader["notreservedkeyword"]);
						FirstAmmountofpeople.Add(NumberOfEmplyoees);
						FirstRoles.Add(((EmployeeRole)role).ToString());
					}
					dataReader.Close();
				}
				con.Close();

			}
		}
		#endregion
		#region Second Chart
		private ChartValues<int> secondAmmountOfItems;

		public ChartValues<int> SecondAmmountOfItems
		{
			get { return secondAmmountOfItems; }
			set { secondAmmountOfItems = value; }
		}
		private List<string> secondItemNames;
		public List<string> SecondItemNames
		{
			get { return secondItemNames; }
			set { secondItemNames = value; }
		}
		void SecondChartItemsPerDepartment()
		{
			SecondAmmountOfItems = new ChartValues<int>();
			SecondItemNames = new List<string>();
			using (MySqlConnection con = SqlConnectionHandler.GetSqlConnection())
			{
				using (MySqlCommand cmd = new MySqlCommand($"SELECT stock_item.name, count(stock.departmentID) as 'count'  FROM stock  JOIN stock_item on stock_item.stockID=stock.stockID GROUP BY stock.stockID", con))
				{
					MySqlDataReader dataReader = cmd.ExecuteReader();

					while (dataReader.Read())
					{
						int numberOfDepartmentsItemIsIn = Convert.ToInt32(dataReader["count"]);
						string name = dataReader["name"].ToString();
						SecondAmmountOfItems.Add(numberOfDepartmentsItemIsIn);
						SecondItemNames.Add(name);
					}
					dataReader.Close();
				}
				con.Close();
			}
		}
		#endregion
		#region Third Chart
		private SeriesCollection firstPie;
		public SeriesCollection FirstPie => firstPie;
		void ThirdChartEmployeesPerDepartment()
		{
			firstPie = new SeriesCollection();
			Func<ChartPoint, string> labelPoint = chartPoint =>
			string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

			using (MySqlConnection con = SqlConnectionHandler.GetSqlConnection())
			{
				using (MySqlCommand cmd = new MySqlCommand($"SELECT COUNT(users.departmentID) as 'Employees',department.name FROM users INNER JOIN department ON users.departmentID=department.departmentID GROUP BY users.departmentID ", con))
				{
					MySqlDataReader dataReader = cmd.ExecuteReader();

					while (dataReader.Read())
					{
						int NumberOfEmplyoees = Convert.ToInt32(dataReader["Employees"]);
						string databaseDepartment = dataReader["name"].ToString();
						FirstPie.Add(new PieSeries() { Title = databaseDepartment, DataLabels = true, LabelPoint = labelPoint, Values = new ChartValues<int>() { NumberOfEmplyoees } });
					}

					dataReader.Close();
				}
				con.Close();
			}
		}
		#endregion
		#region Fourth Chart
		private SeriesCollection secondPie;
		public SeriesCollection SecondPie => secondPie;
		void AddFourthChartPreferredDay()
		{
			secondPie = new SeriesCollection();
			Func<ChartPoint, string> labelPoint = chartPoint =>
	 string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

			using (MySqlConnection con = SqlConnectionHandler.GetSqlConnection())
			{
				using (MySqlCommand cmd = new MySqlCommand($"SELECT COUNT(day) as 'count', day FROM preferences GROUP by day", con))
				{
					MySqlDataReader dataReader = cmd.ExecuteReader();

					while (dataReader.Read())
					{
						int nrOfTimesSelected = Convert.ToInt32(dataReader["count"]);
						string day = dataReader["day"].ToString();
						SecondPie.Add(new PieSeries() { Title = day, DataLabels = true, LabelPoint = labelPoint, Values = new ChartValues<int>() { nrOfTimesSelected } });
					}
					dataReader.Close();
				}
				con.Close();
			}
		}
		#endregion
		#region Fifth Chart
		private SeriesCollection thirdPie;
		public SeriesCollection ThirdPie => thirdPie;

		void AddFifthPreferredShift()
		{
			thirdPie = new SeriesCollection();
			Func<ChartPoint, string> labelPoint = chartPoint =>
			string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

			using (MySqlConnection con = SqlConnectionHandler.GetSqlConnection())
			{
				using (MySqlCommand cmd = new MySqlCommand($"SELECT count(workshift) as 'count',workshift from preferences GROUP BY workshift", con))
				{
					MySqlDataReader dataReader = cmd.ExecuteReader();

					while (dataReader.Read())
					{
						int nrOfTimesSelected = Convert.ToInt32(dataReader["count"]);
						string workshift = dataReader["workshift"].ToString();
						switch (workshift)
						{
							case "0": workshift = "Morning"; break;
							case "1": workshift = "Afternoon"; break;
							case "2": workshift = "Evening"; break;
						}

						ThirdPie.Add(new PieSeries() { Title = workshift, DataLabels = true, LabelPoint = labelPoint, Values = new ChartValues<int>() { nrOfTimesSelected } });
					}
					dataReader.Close();
				}
				con.Close();
			}
		}
        #endregion
        #region General Info

        private ObservableCollection<string> generalData;
        public ObservableCollection<string> GeneralData => generalData;

        private void GetDataForGeneral()
        {
            generalData = new ObservableCollection<string>();
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
						double totalHours = Convert.ToDouble(dataReader["total"]);
						double salary = Convert.ToDouble(dataReader["salary"]);
						double age = Convert.ToDouble(dataReader["age"]);
						GeneralData.Add("Average employee age is " + (age / totalEmplyoees).ToString("0.##") + ".");
						GeneralData.Add("Average hours worked are " + (totalHours / totalEmplyoees).ToString("0.##") + ".");
						GeneralData.Add("Average salary for an employee is " + (salary / totalEmplyoees).ToString("0.##") + ".");
					}

					dataReader.Close();
				}

				using (MySqlCommand cmd = new MySqlCommand($"SELECT users.role, sum(YEAR(CURRENT_TIMESTAMP) - YEAR(dateofBirth) - (RIGHT(CURRENT_TIMESTAMP, 5) < RIGHT(dateofBirth, 5))) as age,sum(users.salary) as 'salary',sum(employees.workHours) as 'hours', count(users.role) as 'emp'   from employees INNER JOIN users on employees.userID=users.userID group by role", con)) // average hours per role
				{// doing average salary and  hoursworked for each role
					MySqlDataReader dataReader = cmd.ExecuteReader();

					while (dataReader.Read())
					{
						if (dataReader["role"].ToString() == "0")
						{
							double hours = Convert.ToDouble(dataReader["hours"]);
							double emp = Convert.ToDouble(dataReader["emp"]);
							double salary = Convert.ToDouble(dataReader["salary"]);
							double age = Convert.ToDouble(dataReader["age"]);
							GeneralData.Add("Average Worker age is " + (age / emp).ToString("0.##") + ".");
							GeneralData.Add("Average salary for a Worker is " + (salary / emp).ToString("0.##") + ".");
							GeneralData.Add("Average hours worked for a Worker are " + (hours / emp).ToString("0.##") + ".");
						}
						if (dataReader["role"].ToString() == "1")
						{
							double hours = Convert.ToDouble(dataReader["hours"]);
							double emp = Convert.ToDouble(dataReader["emp"]);
							double salary = Convert.ToDouble(dataReader["salary"]);
							double age = Convert.ToDouble(dataReader["age"]);
							GeneralData.Add("Average Manager age is " + (age / emp).ToString("0.##") + ".");
							GeneralData.Add("Average salary for a Manager is " + (salary / emp).ToString("0.##") + ".");
							GeneralData.Add("Average hours worked for a Manager are " + (hours / emp).ToString("0.##") + ".");
						}
						if (dataReader["role"].ToString() == "2")
						{
							double hours = Convert.ToDouble(dataReader["hours"]);
							double emp = Convert.ToDouble(dataReader["emp"]);
							double salary = Convert.ToDouble(dataReader["salary"]);
							double age = Convert.ToDouble(dataReader["age"]);
							GeneralData.Add("Average Admin age is " + (age / emp).ToString("0.##") + ".");
							GeneralData.Add("Average salary for an Admin is " + (salary / emp).ToString("0.##") + ".");
							GeneralData.Add("Average hours worked for an Admin are " + (hours / emp).ToString("0.##") + ".");
						}
					}
					dataReader.Close();
				}

				using (MySqlCommand cmd = new MySqlCommand($"  SELECT employees.sex as 'gender',COUNT(employees.sex) as 'number' from employees WHERE employees.sex is not null GROUP by employees.sex ", con))
				{// Gender for all 
					MySqlDataReader dataReader = cmd.ExecuteReader();
					string messagestart = "Sex Distribution: ";
					string message1 = "";
					string message2 = "";

					while (dataReader.Read())
					{
						if (dataReader["gender"].ToString() == "False")
						{
							message1 = message1 + dataReader["number"] + " female";
						}
						else
						{
							message2 = message2 + dataReader["number"] + " male";
						}
					}
                    string s;
					if (message1 == "" || message2 == "")
					{
						s = messagestart + message1 + message2 + " employees.";
					}
					else
					{
						s = messagestart + message1 + " and " + message2 + " employees.";
					}
					dataReader.Close();
					GeneralData.Add(s);
				}

				using (MySqlCommand cmd = new MySqlCommand($" SELECT   users.role,employees.sex as 'gender', COUNT(employees.sex) as 'number' from employees INNER  JOIN users on users.userID=employees.userID where employees.sex is not null GROUP by users.role, employees.sex", con))
				{// Gender for each role 
					MySqlDataReader dataReader = cmd.ExecuteReader();
					
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
								work2 = work2 + dataReader["number"] + " male";

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
                    string messagestart = "Worker Distribution: ";
                    string sWorker, sManager, sAdmin = "";
					if (work1 == "" || work2 == "")
					{
						sWorker = messagestart + work1 + work2 + " workers.";
					}
					else
					{
						sWorker = messagestart + work1 + " and " + work2 + " workers.";
					}
                     messagestart = "Manager Distribution: ";
                    if (manager1 == "" || manager2 == "")
					{
						sManager = messagestart + manager1 + manager2 + " managers.";
					}
					else
					{
						sManager = messagestart + manager1 + " and " + manager2 + " managers.";
					}
                    messagestart = "Admin Distribution: ";
                    if (admin1 == "" || admin2 == "")
					{
						sAdmin = messagestart + admin1 + admin2 + " admins.";

					}
					else
					{
						sAdmin = messagestart + admin1 + " and " + admin2 + " admins.";
					}
					dataReader.Close();
					GeneralData.Add(sWorker);
					GeneralData.Add(sManager);
					GeneralData.Add(sAdmin);

				}
				con.Close();

			}
        }
        #endregion
        public StatisticsViewModel()
		{
			FirstChartEmployeesPerRole();
			SecondChartItemsPerDepartment();
			ThirdChartEmployeesPerDepartment();
			AddFourthChartPreferredDay();
			AddFifthPreferredShift();
			GetDataForGeneral();
		}

		
	}

}
