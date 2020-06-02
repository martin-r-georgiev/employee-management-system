using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApplicationWPF
{
    class StockItemDatabaseHandler
    {
        private static void UpdateThreshhold(StockItem item, int newThreshold)
        {
            using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand($"UPDATE stock SET threshold = @threshold WHERE stockID=@stockID", conn))
                {
                    cmd.Parameters.AddWithValue("@threshold", newThreshold);
                    cmd.Parameters.AddWithValue("@stockID", item.StockID);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                conn.Close();
                item.Threshold = newThreshold;
            }
        }
        private static void UpdateCurrentAmmount(StockItem item, int newCurrentAmmount)
        {
            using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand($"UPDATE stock SET currentAmount = @currentAmount WHERE stockID=@stockID", conn))
                {
                    cmd.Parameters.AddWithValue("@currentAmount", newCurrentAmmount);
                    cmd.Parameters.AddWithValue("@stockID", item.StockID);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                conn.Close();
                item.CurrentAmount = newCurrentAmmount;
            }
        }
        public static bool IsUnique(string name)
        {
            using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT stockID FROM stock_item WHERE name=@name", conn))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.Read())
                    {
                        dataReader.Close();
                        cmd.Dispose();
                        conn.Close();
                        return false;
                    }
                    dataReader.Close();
                    cmd.Dispose();
                }
                conn.Close();
                return true;
            }
        }

        private static string GenerateStockID()
        {
            Guid key = Guid.NewGuid();
            string GuidString = Convert.ToBase64String(key.ToByteArray());
            GuidString = GuidString.Replace("=", "");
            GuidString = GuidString.Replace("+", "");
            GuidString = GuidString.Replace("/", "");

            return GuidString;
        }
        public static string GenerateUniqueID()
        {
            string stockID = "";
            MySqlConnection con;
            MySqlCommand cmd;
            MySqlDataReader reader;
            using (con = SqlConnectionHandler.GetSqlConnection())
            {
                do
                {
                    stockID = GenerateStockID();
                    using (cmd = new MySqlCommand($"SELECT stockID FROM stock_item WHERE stockID=@stockID", con))
                    {
                        cmd.Parameters.AddWithValue("@stockID", stockID);
                        reader = cmd.ExecuteReader();
                    }
                }
                while (reader.Read());
                reader.Close();
                cmd.Dispose();
                con.Close();
            }
            return stockID;
        }
        public static void InsertIgnoreToStockItem(StockItem item)
        {
            using (MySqlConnection con = SqlConnectionHandler.GetSqlConnection()) {
                using (MySqlCommand cmd = new MySqlCommand($"INSERT IGNORE stock_item (stockID, name) VALUES (@stockID, @name)", con))
                {
                    cmd.Parameters.AddWithValue("@stockID", item.StockID);
                    cmd.Parameters.AddWithValue("@name", item.Name);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                con.Close();
            }
        }
        public static void InsertToStock(StockItem item)
        {
            using (MySqlConnection con = SqlConnectionHandler.GetSqlConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand($"REPLACE INTO stock (stockID, departmentID, threshold, currentAmount) VALUES (@stockID, @departmentID, @threshold, @currentAmount)", con))
                {
                    cmd.Parameters.AddWithValue("@stockID", item.StockID);
                    cmd.Parameters.AddWithValue("@departmentID", item.DepartmentID);
                    cmd.Parameters.AddWithValue("@threshold", item.Threshold);
                    cmd.Parameters.AddWithValue("@currentAmount", item.CurrentAmount);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                con.Close();
            }
        }
        public static StockItem GetStock(string departmentID, string stockID)
        {
            StockItem item = null;
            using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand($"SELECT s.threshold, s.currentAmount, i.name FROM stock as s INNER JOIN stock_item as i ON i.stockID = s.stockID WHERE s.departmentID=@departmentID AND s.stockID=@stockID", conn))
                {
                    cmd.Parameters.AddWithValue("@departmentID", departmentID);
                    cmd.Parameters.AddWithValue("@stockID", stockID);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.Read())
                    {
                        int threshold = dataReader.GetInt32(0);
                        int currentAmount = dataReader.GetInt32(1);
                        string name = dataReader.GetString(2);
                        // item = new StockItem(name, threshold, departmentID, currentAmount, stockID);
                    }
                    cmd.Dispose();
                    dataReader.Close();
                }
                conn.Close();
            }
            return item;
        }
    }
}
