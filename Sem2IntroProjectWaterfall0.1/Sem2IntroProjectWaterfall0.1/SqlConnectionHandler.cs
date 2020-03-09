using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Sem2IntroProjectWaterfall0._1
{
    class SqlConnectionHandler
    {
        public static MySqlConnection GetSqlConnection()
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(@"server=studmysql01.fhict.local;userid=dbi426060;database=dbi426060;password=SuperSecurePassword;");
                connection.Open();

                return connection;                
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Error: {0}", e.ToString());
            }
            return null;
        }
    }
}
