using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem2IntroProjectWaterfall0._1
{
    class Attendance
    {
        private double attendanceRate;

        public double AttendanceRate
        {
            get { return attendanceRate; }
            set { attendanceRate = value; }
        }


        public Attendance(string userID, bool updateDB)
        {
            if (updateDB)
            {
            float missedShifts = 0;
            float totalShifts = 0;
            DateTime endDate = DateTime.Today;

            using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(@"SELECT status FROM workshifts WHERE userID=@userID AND date<=@endDate",conn))
                {
                    cmd.Parameters.AddWithValue("@userID", userID);
                    cmd.Parameters.AddWithValue("@endDate", endDate);
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        int shiftStatus = dataReader.GetInt16(0);
                        if (shiftStatus == 3) missedShifts++;
                        totalShifts++;
                    }
                    cmd.Dispose();
                    dataReader.Close();
                }
                conn.Close();
            }
            if (totalShifts != 0) AttendanceRate = ((totalShifts - missedShifts) / totalShifts) * 100;
            else AttendanceRate = 0;

                using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand($"UPDATE employees SET attendance=@attendance WHERE userID=@userID", conn))
                    {
                        cmd.Parameters.AddWithValue("@attendance", AttendanceRate);
                        cmd.Parameters.AddWithValue("@userID", userID);
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                    conn.Close();
                }
            } else
            {
                using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(@"SELECT attendance FROM employees WHERE userID=@userID", conn))
                    {
                        cmd.Parameters.AddWithValue("@userID", userID);
                        MySqlDataReader dataReader = cmd.ExecuteReader();

                        if (dataReader.Read())
                        {
                            if (!dataReader.IsDBNull(0)) AttendanceRate = Convert.ToDouble(dataReader.GetDecimal(0));
                        }
                        cmd.Dispose();
                        dataReader.Close();
                    }
                    conn.Close();
                }
            }
        }

        public override string ToString()
        {
            return $"{attendanceRate:F2}%";
        }
        public static void UpdateAllAttendance()
        {
            foreach (Employee e in Employee.GetAllEmployees(false))
            {
                Attendance newAttendance = new Attendance(e.UserID, true);
            }
        }
    }
}
