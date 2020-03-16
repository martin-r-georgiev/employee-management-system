using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Sem2IntroProjectWaterfall0._1
{
    class Inventory
    {
        List<StockItem> items;
        #region variables + properties
        private string departmentId;
        #endregion

        #region Constructors
        public Inventory(string departmentId)
        {
            this.departmentId = departmentId;
            items = new List<StockItem>();
            MySqlConnection con = SqlConnectionHandler.GetSqlConnection();
            MySqlCommand cmd;
            MySqlDataReader dataReader;

            cmd = new MySqlCommand($"SELECT * FROM Stock WHERE CurrentAmmount<Treshold", con);
            dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                items.Add(new StockItem(dataReader["StockID"].ToString(),Convert.ToInt32(dataReader["threshold"]),Convert.ToInt32(dataReader["currentAmmount"])));
            }
            cmd.Dispose();
            dataReader.Close();
            con.Close();

        }
        #endregion
        #region Methods
        // useless lmao public void AddItem(StockItem item)

        public void RemoveItem(StockItem item)
        {
            MySqlConnection conn = SqlConnectionHandler.GetSqlConnection();

            string stockname = item.Name;
            string StockID = item.StockID;

            using (MySqlCommand cmd = new MySqlCommand($"DELETE FROM Stock WHERE StockID=@StockID", conn))
            {
                cmd.Parameters.AddWithValue("@StockID", StockID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            using (MySqlCommand cmd = new MySqlCommand($"DELETE FROM StockItem WHERE StockID=@StockID", conn))
            {
                cmd.Parameters.AddWithValue("@StockID", StockID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            conn.Close();
        }
        public void UpdateAmmount(int newAmmount, string StockID)
        {
            MySqlConnection conn = SqlConnectionHandler.GetSqlConnection();
            using (MySqlCommand cmd = new MySqlCommand($"UPDATE STOCK SET currentAmmount = @newAmmount WHERE StockID=@StockID", conn))
            {
                cmd.Parameters.AddWithValue("@newAmmount", newAmmount);
                cmd.Parameters.AddWithValue("@StockID", StockID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            conn.Close();
        }
        public void UpdateTreshhold(int newTreshhold, string StockID)
        {
            MySqlConnection conn = SqlConnectionHandler.GetSqlConnection();
            using (MySqlCommand cmd = new MySqlCommand($"UPDATE STOCK SET Treshold = @newTreshhold WHERE StockID=@StockID", conn))
            {
                cmd.Parameters.AddWithValue("@Treshold", newTreshhold);
                cmd.Parameters.AddWithValue("@StockID", StockID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            conn.Close();
        }


        public static List<StockItem> GetRestockItems()
        {
            List<StockItem> OutOfStockItems = new List<StockItem>();
            MySqlConnection con = SqlConnectionHandler.GetSqlConnection();
            MySqlCommand cmd;
            MySqlDataReader dataReader;

            cmd = new MySqlCommand($"SELECT StockID FROM Stock WHERE CurrentAmmount<Treshold", con);
            dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                OutOfStockItems.Add(new StockItem(dataReader["StockID"].ToString()));
            }
            cmd.Dispose();
            dataReader.Close();
            con.Close();
            return OutOfStockItems;
        }


        #endregion


    }
}
