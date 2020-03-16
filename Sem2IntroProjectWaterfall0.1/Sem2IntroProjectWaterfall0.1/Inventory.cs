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
        public Inventory(string departmentId) // good 
        {
            this.departmentId = departmentId;
            items = new List<StockItem>();
            MySqlConnection con = SqlConnectionHandler.GetSqlConnection();
            MySqlCommand cmd;
            MySqlDataReader dataReader;

            cmd = new MySqlCommand($"SELECT * FROM stock", con);
            dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                string stockID=dataReader["stockID"].ToString();
                int threshold=Convert.ToInt32(dataReader["threshold"]);
                int currentammount=Convert.ToInt32(dataReader["currentAmmount"]);
                items.Add(new StockItem(stockID,threshold,currentammount)); // maybe add name to stock table
            }
            cmd.Dispose();
            dataReader.Close();
            con.Close();

        }
        #endregion
        #region Methods
         public void AddItem(StockItem item) //good
        {
            items.Add(item);
            // no need to add to the database as in order for the item to exist it will have a database entry
        }

        public void RemoveItem(StockItem item) //good
        {
            MySqlConnection conn = SqlConnectionHandler.GetSqlConnection();

            string stockname = item.Name;
            string StockID = item.StockID;

            using (MySqlCommand cmd = new MySqlCommand($"DELETE FROM stock WHERE stockID=@stockID", conn))
            {
                cmd.Parameters.AddWithValue("@stockID", StockID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            using (MySqlCommand cmd = new MySqlCommand($"DELETE FROM stock_item WHERE stockID=@stockID", conn))
            {
                cmd.Parameters.AddWithValue("@stockID", StockID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            conn.Close();
            items.RemoveAt(getindex(item));
        }
        public void UpdateAmmount(int newAmmount, string StockID) //good
        {
            int indextoupdate=getindex(StockID);
            items[indextoupdate].CurrentAmmount=newAmmount;

            // should be the same as below   grammar
           /* MySqlConnection conn = SqlConnectionHandler.GetSqlConnection();
            using (MySqlCommand cmd = new MySqlCommand($"UPDATE stock SET currentAmmount = @newAmmount WHERE StockID=@StockID", conn))
            {
                cmd.Parameters.AddWithValue("@newAmmount", newAmmount);
                cmd.Parameters.AddWithValue("@StockID", StockID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            conn.Close(); // use stockitem instead of this
            */ 
        }
        public void UpdateTreshhold(int newTreshhold, string StockID)//good
        {
            int indextoupdate=getindex(StockID);
            items[indextoupdate].Threshold=newTreshhold;
            
            //should be same as below grammar
            /*
            MySqlConnection conn = SqlConnectionHandler.GetSqlConnection();
            using (MySqlCommand cmd = new MySqlCommand($"UPDATE stock SET threshold = @newTreshhold WHERE StockID=@StockID", conn))
            {
                cmd.Parameters.AddWithValue("@Treshold", newTreshhold);
                cmd.Parameters.AddWithValue("@StockID", StockID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            conn.Close();
            */
        }


        public static List<StockItem> GetRestockItems() //good
        {
            List<StockItem> OutOfStockItems = new List<StockItem>();
            MySqlConnection con = SqlConnectionHandler.GetSqlConnection();
            MySqlCommand cmd;
            MySqlDataReader dataReader;

            cmd = new MySqlCommand($"SELECT StockID FROM stock WHERE currentAmmount<threshold", con);
            dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                OutOfStockItems.Add(new StockItem(dataReader["stockID"].ToString()));
            }
            cmd.Dispose();
            dataReader.Close();
            con.Close();
            return OutOfStockItems;
        }
        // List of all stockitems


        public static List<StockItem> ListAllItems() //good
        {
            List<StockItem> Allitems = new List<StockItem>();
            MySqlConnection con = SqlConnectionHandler.GetSqlConnection();
            MySqlCommand cmd;
            MySqlDataReader dataReader;

            cmd = new MySqlCommand($"SELECT * FROM stock", con);
            dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                string stockID=dataReader["stockID"].ToString();
                int threshold=Convert.ToInt32(dataReader["threshold"]);
                int currentammount=Convert.ToInt32(dataReader["currentAmmount"]);
                items.Add(new StockItem(stockID,threshold,currentammount)); // maybe add name to stock table
            }
            cmd.Dispose();
            dataReader.Close();
            con.Close();
            return Allitems;
        }


        #endregion

        public int getindex(StockItem item)
        {
            int i=0;
            for(i=0;i<items.Count();i++)
                {
                if(item.StockID==items[i].StockID)
                    return i;
            }
            return -1;
        }

    }
}
