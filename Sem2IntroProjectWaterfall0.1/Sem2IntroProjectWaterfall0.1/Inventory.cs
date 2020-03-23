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

        public string DepartmentId
        {
            get { return this.departmentId; }
            private set { }
        }

        public List<StockItem> Items
        {
            get { return this.items; }
        }
        #endregion

        #region Constructors
        public Inventory(string departmentId)
        {
            this.departmentId = departmentId;
            items = new List<StockItem>();
            using (MySqlConnection con = SqlConnectionHandler.GetSqlConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand($"SELECT * FROM stock WHERE departmentID=@depID", con))
                {
                    cmd.Parameters.AddWithValue("@depID", this.departmentId);
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read()) items.Add(new StockItem(dataReader.GetString(1), dataReader.GetString(0)));
                    cmd.Dispose();
                    dataReader.Close();
                }
                con.Close();
            }
        }

        #endregion
        #region Methods

        public void AddItem(StockItem item, int Threshold, int CurrentAmount)
        {
            using (MySqlConnection con = SqlConnectionHandler.GetSqlConnection())
            {
                MySqlCommand cmd;
                MySqlDataReader dataReader;

                cmd = new MySqlCommand($"SELECT stockID FROM stock WHERE stockID=@stockID AND departmentID=@departmentID", con);
                cmd.Parameters.AddWithValue("@name", item.StockID);
                cmd.Parameters.AddWithValue("@departmentID", this.departmentId);
                dataReader = cmd.ExecuteReader(); 

                if (dataReader.Read())
                {
                    cmd.Dispose();
                    dataReader.Close();
                    throw new NameTakenException("The item already exists in the department");
                    //EmployeeManagement.ItemAlreadyAdded(); incase the error doesnt show up
                }
                else
                {
                    cmd.Dispose();
                    dataReader.Close();

                    item.Threshold = Threshold;
                    item.CurrentAmount = CurrentAmount;

                    using (cmd = new MySqlCommand($"INSERT INTO stock (stockID, departmentID, threshold,currentAmount) VALUES (@stockID,@departmentID, @threshold, @currentAmount)", con))
                    {
                        // should not error checeking it before hand
                        cmd.Parameters.AddWithValue("@stockID", item.StockID);
                        cmd.Parameters.AddWithValue("@departmentID", this.departmentId);
                        cmd.Parameters.AddWithValue("@threshold", Threshold);
                        cmd.Parameters.AddWithValue("@currentAmount", CurrentAmount);
                        cmd.ExecuteNonQuery(); /// crash here somereason should be fixed
                        cmd.Dispose();
                        items.Add(item);
                    }
                    con.Close();
                }
            }
        }

        public static void AddItem(string stockID, string departmentID, int threshold, int currentAmount)
        {
            using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
            {
                using(MySqlCommand cmd = new MySqlCommand($"SELECT stockID FROM stock WHERE stockID=@stockID AND departmentID=@departmentID", conn))
                {
                    cmd.Parameters.AddWithValue("@stockID", stockID);
                    cmd.Parameters.AddWithValue("@departmentID", departmentID);
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    if(!dataReader.Read())
                    {
                        using (MySqlConnection connInner = SqlConnectionHandler.GetSqlConnection())
                        {
                            using (MySqlCommand cmdInner = new MySqlCommand($"INSERT INTO stock (stockID, departmentID, threshold, currentAmount) VALUES (@stockID, @depID, @threshold, @cAmount)", connInner))
                            {
                                cmdInner.Parameters.AddWithValue("@stockID", stockID);
                                cmdInner.Parameters.AddWithValue("@depID", departmentID);
                                cmdInner.Parameters.AddWithValue("@threshold", threshold);
                                cmdInner.Parameters.AddWithValue("@cAmount", currentAmount);
                                cmdInner.ExecuteNonQuery();
                                cmdInner.Dispose();
                            }
                            connInner.Close();
                        }
                    }
                    cmd.Dispose();
                    dataReader.Close();
                    dataReader.Dispose();
                }
                conn.Close();
            }
        }

        public void RemoveItem(StockItem item) //good
        {
            // maybe working
            using (MySqlConnection con = SqlConnectionHandler.GetSqlConnection())
            {
                MySqlCommand cmd;
                MySqlDataReader dataReader;

                cmd = new MySqlCommand($"SELECT stockID FROM stock WHERE stockID=@stockID AND  departmentID=@departmentID ", con);
                cmd.Parameters.AddWithValue("@name", item.StockID);
                cmd.Parameters.AddWithValue("@departmentID", this.departmentId);
                dataReader = cmd.ExecuteReader();

                if (!dataReader.Read())
                {
                    cmd.Dispose();
                    dataReader.Close();
                    throw new NameTakenException("The item already exists in the department");
                    //EmployeeManagement.ItemAlreadyAdded(); incase the error doesnt show up
                }
                else
                {
                    cmd.Dispose();
                    dataReader.Close();
                    using ( cmd = new MySqlCommand($"DELETE FROM stock WHERE stockID=@stockID AND departmentID=@departmentID", con))
                    {
                        cmd.Parameters.AddWithValue("@stockID", item);
                        cmd.Parameters.AddWithValue("@departmentID", this.departmentId);

                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                }
                con.Close();
            }
        }

        public static void RemoveItem(string stockID, string departmentID)
        {
            using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand($"DELETE FROM stock WHERE stockID=@stockID AND departmentID=@departmentID", conn))
                {
                    cmd.Parameters.AddWithValue("@stockID", stockID);
                    cmd.Parameters.AddWithValue("@departmentID", departmentID);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                conn.Close();
            }
        }

        public static void RemoveItemGlobal(string stockID) //good
        {
            using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand($"DELETE FROM stock WHERE stockID=@stockID", conn))
                {
                    cmd.Parameters.AddWithValue("@stockID", stockID);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }

                using (MySqlCommand cmd = new MySqlCommand($"DELETE FROM stock_item WHERE stockID=@stockID", conn))
                {
                    cmd.Parameters.AddWithValue("@stockID", stockID);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                conn.Close();
            }
        }

        public void UpdateAmmount(int newAmmount, string StockID) //good
        {
            int indextoupdate=GetIndex(StockID);
            items[indextoupdate].CurrentAmount=newAmmount;
        }

        public void UpdateTreshhold(int newTreshhold, string StockID)//good
        {
            int index = GetIndex(StockID);
            if (index >= 0) items[index].Threshold = newTreshhold;
        }

        public static List<StockItem> GetAllRestockItems() //good
        {
            List<StockItem> OutOfStockItems = new List<StockItem>();
            using (MySqlConnection con = SqlConnectionHandler.GetSqlConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand($"SELECT departmentID,stockID FROM stock WHERE currentAmount<threshold", con))
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                   while (dataReader.Read())
                    {
                        OutOfStockItems.Add(new StockItem(dataReader["departmentID"].ToString(),dataReader["stockID"].ToString()));
                    }
                    cmd.Dispose();
                    dataReader.Close();
               }  
              con.Close();
            }    
            return OutOfStockItems;
        }// returns all out of stock items
        
        public static List<StockItem> ListAllItemsFromStock() //prob neeeds treshold/ammount
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
                        string departmentID =dataReader["departmentID"].ToString();
                     //   int currentamount = Convert.ToInt32(dataReader["currentAmount"]);
                        Allitems.Add(new StockItem( departmentID,  stockID)); 
                    }
                    cmd.Dispose();
                    dataReader.Close();
                }
                con.Close();
            }
            return Allitems;
        }
        
        public static bool Exists(string stockID, string departmentID)
        {
            bool result = false;
            using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand($"SELECT threshold FROM stock where stockID=@stockID AND departmentID=@departmentID", conn))
                {
                    cmd.Parameters.AddWithValue("@stockID", stockID);
                    cmd.Parameters.AddWithValue("@departmentID", departmentID);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.Read()) result = true;
                    cmd.Dispose();
                    dataReader.Close();
                    dataReader.Dispose();
                }
                conn.Close();
            }
            return result;
        }

        public static List<StockItem> ListAllItemsFromStockItem()
        {
            List<StockItem> allItems = new List<StockItem>();
            using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand($"SELECT name FROM stock_item", conn))
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read()) allItems.Add(new StockItem(dataReader.GetString(0)));
                    cmd.Dispose();
                    dataReader.Close();
                }
                conn.Close();
            }
            return allItems;
        }

        public List<StockItem> GetRestockItemsCurrentDept()
        {
            List<StockItem> itemsOutOfStock = new List<StockItem>();
            foreach(StockItem item in this.Items)
            {
                if (item.CurrentAmount < item.Threshold) itemsOutOfStock.Add(item);
            }
            return itemsOutOfStock;
        }

        #endregion
        
        #region Auxiliary methods 
        public int GetIndex(string StockID)
        {
            for (int i=0; i < items.Count(); i++)
            {
                if(items[i].StockID == StockID) return i;
            }
            return -1;
        }
        #endregion

    }
}
