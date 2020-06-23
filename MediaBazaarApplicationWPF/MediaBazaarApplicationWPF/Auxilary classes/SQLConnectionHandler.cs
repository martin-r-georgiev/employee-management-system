using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MediaBazaarApplicationWPF
{
    class SqlConnectionHandler
    {
        public static string ServerConnection
        {
            get
            {
                return @"server=studmysql01.fhict.local;userid=dbi426053;database=dbi426053;password=SuperSecurePassword;";
            }
        }

        public static MySqlConnection GetSqlConnection()
        {
            MySqlConnection connection = new MySqlConnection(SqlConnectionHandler.ServerConnection);
            try
            {
                connection.Open();
                return connection;
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Error: {0}", e.ToString());
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
            return null;
        }
    }
}
