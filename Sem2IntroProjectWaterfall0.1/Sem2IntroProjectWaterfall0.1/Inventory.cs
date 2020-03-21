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
            using (MySqlConnection con = SqlConnectionHandler.GetSqlConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand($"SELECT * FROM stock WHERE departmentID=@depID", con))
                {
                    cmd.Parameters.AddWithValue("@depID", this.departmentId);
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        items.Add(new StockItem(dataReader.GetString(0), dataReader.GetInt32(2), dataReader.GetInt32(3)));
                    }
                    cmd.Dispose();
                    dataReader.Close();
                }
                con.Close();
            }
        }
        #endregion
        #region Methods
         public void AddItem(StockItem item) //good
        {
            items.Add(item);
        }

        public void RemoveItem(StockItem item) //good
        {
            string stockname = item.Name;
            string StockID = item.StockID;
            using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
            {
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
            }
            items.RemoveAt(getindex(item.StockID));
        }

        public void UpdateAmmount(int newAmmount, string StockID) //good
        {
            int indextoupdate=getindex(StockID);
            items[indextoupdate].CurrentAmmount=newAmmount;
        }

        public void UpdateTreshhold(int newTreshhold, string StockID)//good
        {
            int indextoupdate=getindex(StockID);
            items[indextoupdate].Threshold=newTreshhold;
        }


        public  List<StockItem> GetRestockItems() //FIXXXXXXX
        {
            List<StockItem> OutOfStockItems = new List<StockItem>();
            //using (MySqlConnection con = SqlConnectionHandler.GetSqlConnection())
            //{
            //    using (MySqlCommand cmd = new MySqlCommand($"SELECT StockID FROM stock WHERE currentAmount<threshold", con))
            //    {
            //        MySqlDataReader dataReader = cmd.ExecuteReader();

            //        while (dataReader.Read())
            //        {
            //            OutOfStockItems.Add(new StockItem(dataReader["stockID"].ToString()));
            //        }
            //        cmd.Dispose();
            //        dataReader.Close();
            //    }  
            //    con.Close();
            //}    
            return OutOfStockItems;
        }
        // List of all stockitems


        public  List<StockItem> ListAllItems() //good
        {
            List<StockItem> Allitems = new List<StockItem>();
            using (MySqlConnection con = SqlConnectionHandler.GetSqlConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand($"SELECT * FROM stock", con))
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        string stockID = dataReader["stockID"].ToString();
                        int threshold = Convert.ToInt32(dataReader["threshold"]);
                        int currentammount = Convert.ToInt32(dataReader["currentAmount"]);
                        Allitems.Add(new StockItem(stockID, threshold, currentammount)); // maybe add name to stock table
                    }
                    cmd.Dispose();
                    dataReader.Close();
                }
                con.Close();
            }
            return Allitems;
        }

        public List<StockItem> GetStockItems()
        {
            return items;
        }

        #endregion
        
        #region Auxiliary methods 
        public int getindex(string StockID)
        {
            int i=0;
            for(i=0;i<items.Count();i++)
                {
                if(StockID==items[i].StockID)
                    return i;
            }
            return -1;
        }
        #endregion

    }
}
