using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApplicationWPF
{
    public static class CheckIn
    {
		public static void Checkin(string userID, DateTime checkInTime)
		{
			using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
			{
				using (MySqlCommand cmd = new MySqlCommand(@"INSERT INTO checkins (userID, checkin) VALUES (@userID, @checkin)", conn))
				{
					cmd.Parameters.AddWithValue("@userID", userID);
					cmd.Parameters.AddWithValue("@checkin", checkInTime);
					cmd.ExecuteNonQuery();
					cmd.Dispose();
				}
				conn.Close();
			}
		}

		public static void Checkout(string userID, DateTime checkOutTime)
		{
			using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
			{
				using (MySqlCommand cmd = new MySqlCommand(@"UPDATE checkins SET checkout=@checkoutTime WHERE userID=@userID AND checkout IS NULL", conn))
				{
					cmd.Parameters.AddWithValue("@checkoutTime", checkOutTime);
					cmd.Parameters.AddWithValue("@userID", userID);
					cmd.ExecuteNonQuery();
					cmd.Dispose();
				}
				conn.Close();
			}
		}
		public static List<EmployeeAtWorkModel> GetEmployeesAtWork(string departmentID)
		{
			List<EmployeeAtWorkModel> employees = new List<EmployeeAtWorkModel>();
			EmployeeManager man = new EmployeeManager();
			using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
			{
				using (MySqlCommand cmd = new MySqlCommand(@"SELECT userID, checkin FROM checkins WHERE checkout IS NULL AND userID IN 
				( SELECT userID FROM users WHERE departmentID=@departmentID)", conn))
				{
					cmd.Parameters.AddWithValue("@departmentID", departmentID);
					MySqlDataReader dataReader = cmd.ExecuteReader();
					while (dataReader.Read())
					{
						Employee e = man.GetEmployee(dataReader.GetString(0), false);
						string name = "";
						if (String.IsNullOrWhiteSpace(e.FirstName)) name = $"{e.Username}";
						else name = $"{e.FirstName} {e.LastName}";
						string checkin = dataReader.GetDateTime(1).TimeOfDay.ToString();
						employees.Add(new EmployeeAtWorkModel(name, checkin));
					}
					cmd.Dispose();
					dataReader.Close();
				}
				conn.Close();
			}
			return employees;
		}
		public static List<Employee> GetAllEmployeesAtWork() //Method not used - add if you need to get all workers regardless of department
		{ //Method not updated for EmployeeModel, if you need to use this, copy the procedure with the one above
			List<Employee> employees = new List<Employee>();
			EmployeeManager man = new EmployeeManager();
			using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
			{
				using (MySqlCommand cmd = new MySqlCommand(@"SELECT userID FROM checkins WHERE checkout IS NULL", conn))
				{
					MySqlDataReader dataReader = cmd.ExecuteReader();
					while (dataReader.Read())
					{
						employees.Add(man.GetEmployee(dataReader.GetString(0), false));
					}
					cmd.Dispose();
					dataReader.Close();
				}
				conn.Close();
			}
			return employees;
		}
		public static bool IsAtWork(string userID)
		{
			bool isAtWork = false;

			using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
			{
				using (MySqlCommand cmd = new MySqlCommand(@"SELECT checkout FROM checkins WHERE userID=@userID ORDER BY checkin DESC LIMIT 1", conn))
				{

					cmd.Parameters.AddWithValue("@userID", userID);
					MySqlDataReader dataReader = cmd.ExecuteReader();
					if (dataReader.Read())
					{
						DateTime checkout = new DateTime(1, 1, 1);
						if (!dataReader.IsDBNull(0)) checkout = dataReader.GetDateTime(0);

						DateTime firstDate = new DateTime(2000, 1, 1);
						if (checkout.Date <= firstDate) isAtWork = true;
					}
					cmd.Dispose();
					dataReader.Close();
				}
				conn.Close();
			}
			return isAtWork;
		}
		public static void ClearNotificationsBefore(DateTime time)
		{
			using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
			{
				using (MySqlCommand cmd = new MySqlCommand(@"DELETE FROM `notifications` WHERE date < @date", conn))
				{
					cmd.Parameters.AddWithValue("@date", time);
					cmd.ExecuteNonQuery();
					cmd.Dispose();
				}
				conn.Close();
			}
		}
	}
}
