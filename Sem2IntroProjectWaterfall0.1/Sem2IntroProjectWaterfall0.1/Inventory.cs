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
                        items.Add(new StockItem(dataReader.GetString(1),dataReader.GetString(0)));
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
    
            
                using (MySqlConnection con = SqlConnectionHandler.GetSqlConnection())
                {
                    MySqlCommand cmd;
                    MySqlDataReader dataReader;

                    cmd = new MySqlCommand($"SELECT stockID FROM stock WHERE stockID=@stockID AND  departmentID=@departmentID ", con);
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
                       

                        using (cmd = new MySqlCommand($"INSERT INTO stock (stockID, departmentID, threshold,currentAmount) VALUES (@stockID,@departmentID, @threshold, @currentAmount)", con))
                        {
                            cmd.Parameters.AddWithValue("@stockID", item.StockID);

                            cmd.Parameters.AddWithValue("@departmentID", this.departmentId);
                            cmd.Parameters.AddWithValue("@threshold", item.Threshold);
                            cmd.Parameters.AddWithValue("@currentAmount",item.CurrentAmmount);
                            cmd.ExecuteNonQuery();
                            cmd.Dispose();
                          items.Add(item);

                        }
                    }
                    con.Close();
                }
            
            

        }

        public  void RemoveItem(StockItem item) //good
        {

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

        public static void RemoveItemGlobal(StockItem item) //good
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


        public static  List<StockItem> GetAllRestockItems() //good
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
        


        public static  List<StockItem> ListAllItems() //fixed 
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
                     //   int currentammount = Convert.ToInt32(dataReader["currentAmount"]);
                        Allitems.Add(new StockItem( departmentID,  stockID)); 
                    }
                    cmd.Dispose();
                    dataReader.Close();
                }
                con.Close();
            }
            return Allitems;
        }
        public static List<StockItem> GetAllItemsWithoutDepartment()
        {
            List<StockItem> listToSend = new List<StockItem>();
            using (MySqlConnection con = SqlConnectionHandler.GetSqlConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand($"SELECT stockID FROM stock_item", con))
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        listToSend.Add(new StockItem(dataReader.GetString(0),true));
                    }
                    cmd.Dispose();
                    dataReader.Close();
                }
                con.Close();
                return listToSend;
            }
        }
        public List<StockItem> GetRestockItemsCurrentDept() //works
        {
            List<StockItem> OutOfStockItems = new List<StockItem>();
            using (MySqlConnection con = SqlConnectionHandler.GetSqlConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand($"SELECT stockID FROM stock WHERE currentAmount<threshold and departmentID=@departmentID", con))
               {
                    cmd.Parameters.AddWithValue("@departmentID", this.departmentId);
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        OutOfStockItems.Add(new StockItem(this.departmentId,dataReader["stockID"].ToString()));
                    }
                    cmd.Dispose();
                    dataReader.Close();
               }  
                con.Close();
           }    
            return OutOfStockItems;
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
