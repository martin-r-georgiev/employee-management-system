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
        public static void AddStockItemToStock(StockItem item)
        {
            using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
            {
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand($"REPLACE INTO stock (stockID, departmentID, threshold, currentAmount) VALUES (@stockID, @departmentID, @threshold, @currentAmount)", conn))
                    {
                        cmd.Parameters.AddWithValue("@stockID", item.StockID);
                        cmd.Parameters.AddWithValue("@departmentID", item.DepartmentID);
                        cmd.Parameters.AddWithValue("@threshold", item.Threshold);
                        cmd.Parameters.AddWithValue("@currentAmount", item.CurrentAmount);
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                finally { conn.Close(); }
            }
        }

        public static void AddStockItemToDepartment(StockItem item, string departmentID)
        {
            using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
            {
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand($"REPLACE INTO stock (stockID, departmentID, threshold, currentAmount) VALUES (@stockID, @departmentID, @threshold, @currentAmount)", conn))
                    {
                        cmd.Parameters.AddWithValue("@stockID", item.StockID);
                        cmd.Parameters.AddWithValue("@departmentID", departmentID);
                        cmd.Parameters.AddWithValue("@threshold", item.Threshold);
                        cmd.Parameters.AddWithValue("@currentAmount", item.CurrentAmount);
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                finally { conn.Close(); }
            }
        }

        public static void RemoveStockItemFromStock(StockItem item)
        {
            using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
            {
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand($"DELETE FROM stock WHERE stockID=@stockID", conn))
                    {
                        cmd.Parameters.AddWithValue("@stockID", item.StockID);
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                finally { conn.Close(); }
            }
        }

        public static void RemoveStockItemFromDepartment(StockItem item, string departmentID)
        {
            using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
            {
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand($"DELETE FROM stock WHERE stockID=@stockID AND departmentID=@departmentID", conn))
                    {
                        cmd.Parameters.AddWithValue("@stockID", item.StockID);
                        cmd.Parameters.AddWithValue("@departmentID", departmentID);
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                finally { conn.Close(); }
            }
        }

        public static void RemoveStockItemGlobally(StockItem item)
        {
            RemoveStockItemFromStock(item);
            RemoveStockItem(item);
        }

        public static StockItem GetStockItemFromDepartment(string stockID, string departmentID)
        {
            StockItem returnItem = null;

            using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
            {
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand($"SELECT i.name, s.currentAmount, s.threshold FROM stock as s INNER JOIN stock_item as i ON i.stockID = s.stockID WHERE s.stockID=@stockID AND s.departmentID=@departmentID", conn))
                    {
                        cmd.Parameters.AddWithValue("@stockID", stockID);
                        cmd.Parameters.AddWithValue("@departmentID", departmentID);
                        MySqlDataReader dataReader = cmd.ExecuteReader();
                        if (dataReader.Read())
                        {
                            returnItem = new StockItem(stockID, departmentID, dataReader.GetString(0), dataReader.GetInt32(1), dataReader.GetInt32(2));
                        }
                        dataReader.Close();
                        cmd.Dispose();
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                finally { conn.Close(); }
            }

            return returnItem;
        }

        public static List<StockItem> GetAllStockFromDepartment(string departmentID)
        {
            List<StockItem> returnList = new List<StockItem>();

            using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
            {
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand($"SELECT s.stockID, i.name, s.currentAmount, s.threshold FROM stock as s INNER JOIN stock_item as i ON i.stockID = s.stockID WHERE s.departmentID=@departmentID", conn))
                    {
                        cmd.Parameters.AddWithValue("@departmentID", departmentID);
                        MySqlDataReader dataReader = cmd.ExecuteReader();
                        while (dataReader.Read())
                        {
                            returnList.Add(new StockItem(dataReader.GetString(0), departmentID, dataReader.GetString(1), dataReader.GetInt32(2), dataReader.GetInt32(3)));
                        }
                        dataReader.Close();
                        cmd.Dispose();
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                finally { conn.Close(); }
            }

            return returnList;
        }

        public static List<StockItem> ListAllItemsFromStockItem()
        {
            List<StockItem> returnList = new List<StockItem>();

            using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
            {
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand($"SELECT stockID, name FROM stock_item", conn))
                    {
                        MySqlDataReader dataReader = cmd.ExecuteReader();
                        while (dataReader.Read()) returnList.Add(new StockItem(dataReader.GetString(0), dataReader.GetString(1)));
                        dataReader.Close();
                        cmd.Dispose();
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                finally { conn.Close(); }
            }

            return returnList;
        }

        public static List<Department> GetAssignedDepartments(string stockID)
        {
            List<Department> returnList = new List<Department>();
            using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
            {
                try
                {
                    using(MySqlCommand cmd = new MySqlCommand("SELECT departmentID FROM stock WHERE stockID=@stockID", conn))
                    {
                        cmd.Parameters.AddWithValue("@stockid", stockID);
                        MySqlDataReader dataReader = cmd.ExecuteReader();
                        while (dataReader.Read()) returnList.Add(DepartmentManager.GetDepartment(dataReader.GetString(0), true));
                        dataReader.Close();
                        cmd.Dispose();
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                finally { conn.Close(); }
            }
            return returnList;
        }

        public static void UpdateStockItem(StockItem item)
        {
            using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
            {
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand($"UPDATE stock SET currentAmount = @currentAmount, threshold = @threshold WHERE stockID = @stockID AND departmentID = @departmentID", conn))
                    {
                        cmd.Parameters.AddWithValue("@currentAmount", item.CurrentAmount);
                        cmd.Parameters.AddWithValue("@threshold", item.Threshold);
                        cmd.Parameters.AddWithValue("@stockID", item.StockID);
                        cmd.Parameters.AddWithValue("@departmentID", item.DepartmentID);
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                finally { conn.Close(); }
            }
        }

        public static void UpdateStockItem(string stockID, string departmentID, int currentAmount, int threshold)
        {
            using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
            {
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand($"UPDATE stock SET currentAmount = @currentAmount, threshold = @threshold WHERE stockID = @stockID AND departmentID = @departmentID", conn))
                    {
                        cmd.Parameters.AddWithValue("@currentAmount", currentAmount);
                        cmd.Parameters.AddWithValue("@threshold", threshold);
                        cmd.Parameters.AddWithValue("@stockID", stockID);
                        cmd.Parameters.AddWithValue("@departmentID", departmentID);
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                finally { conn.Close(); }
            }
        }

        public static void AddStockItem(string name)
        {
            if (IsUnique(name))
            {
                string stockID = GenerateUniqueID();
                using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
                {
                    try
                    {
                        using (MySqlCommand cmd = new MySqlCommand($"INSERT IGNORE INTO stock_item (stockID, name) VALUES (@stockID, @name)", conn))
                        {
                            cmd.Parameters.AddWithValue("@stockID", stockID);
                            cmd.Parameters.AddWithValue("@name", name);
                            cmd.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                    }
                    catch (Exception ex) { Console.WriteLine(ex.Message); }
                    finally { conn.Close(); }
                }
            }
            else throw new ArgumentException($"Stock item with name '{name}' already exists.");
        }

        private static void RemoveStockItem(StockItem item)
        {
            using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
            {
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand($"DELETE FROM stock_item WHERE stockID=@stockID", conn))
                    {
                        cmd.Parameters.AddWithValue("@stockID", item.StockID);
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                finally { conn.Close(); }
            }
        }

        public static bool IsUnique(string name)
        {
            bool result = true;

            using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
            {
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand("SELECT stockID FROM stock_item WHERE name=@name", conn))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        MySqlDataReader dataReader = cmd.ExecuteReader();
                        if (dataReader.Read()) result = false;
                        dataReader.Close();
                        cmd.Dispose();
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                finally { conn.Close(); }
            }

            return result;
        }

        public static string GenerateUniqueID()
        {
            string stockID = "";
            using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
            {
                try
                {
                    MySqlCommand cmd;
                    MySqlDataReader reader;

                    //Checking if auto-generated stockID already exists in database
                    do
                    {
                        stockID = GenerateStockID();
                        cmd = new MySqlCommand($"SELECT stockID FROM stock_item WHERE stockID=@stockID", conn);
                        cmd.Parameters.AddWithValue("@stockID", stockID);
                        reader = cmd.ExecuteReader();
                    }
                    while (reader.Read());

                    reader.Close();
                    cmd.Dispose();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                finally { conn.Close(); }
            }
            return stockID;
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
    }
}
