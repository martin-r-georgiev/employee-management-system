using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApplicationWPF
{
    class StockItem
    {
        #region Variables
        private string name;
        private string stockID;
        private int threshold;
        private int currentAmount;
        private string departmentID;
        #endregion

        #region Properties

        public string StockID
        {
            get { return this.stockID; }
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Invalid name!");

                this.name = value;
            }
        }

        public int Threshold
        {
            get { return this.threshold; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Invalid threshold!");

                this.threshold = value;
            }
        }

        public int CurrentAmount
        {
            get { return this.currentAmount; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Invalid ammount!");

                this.currentAmount = value;
            }
        }
        
        public string DepartmentID
        {
            get { return this.departmentID; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Invalid departmentID!");
                this.departmentID = value;
                
            }
        }
        #endregion

        #region Constructors

        ////TO DO: Shorten and clean code
        public StockItem(string name, int threshold, string departmentID, int currentAmount, string stockID)
        {
            this.Name = name;
            this.Threshold = threshold;
            this.CurrentAmount = currentAmount;
            this.DepartmentID = departmentID;
            this.stockID = stockID;   
        }



        //public StockItem(string name)
        //{
        //    using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
        //    {
        //        MySqlCommand cmd;
        //        MySqlDataReader dataReader, reader;
        //        cmd = new MySqlCommand("SELECT stockID, name FROM stock_item WHERE name=@name", conn);
        //        cmd.Parameters.AddWithValue("@name", name);
        //        dataReader = cmd.ExecuteReader();
        //        if (!dataReader.Read())
        //        {
        //            this.name = name;
        //            using (MySqlConnection con = SqlConnectionHandler.GetSqlConnection())
        //            {
        //                do
        //                {
        //                    this.stockID = StockItem.GenerateStockID();
        //                    cmd = new MySqlCommand($"SELECT stockID FROM stock_item WHERE stockID=@stockID", con);
        //                    cmd.Parameters.AddWithValue("@stockID", this.stockID);
        //                    reader = cmd.ExecuteReader();
        //                }
        //                while (reader.Read());
        //                cmd.Dispose();
        //                dataReader.Close();
        //                dataReader.Dispose();
        //                con.Close();
        //            }
        //            using (MySqlCommand cmdInner = new MySqlCommand($"INSERT IGNORE stock_item (stockID, name) VALUES (@stockID, @name)", conn))
        //            {
        //                cmdInner.Parameters.AddWithValue("@stockID", this.stockID);
        //                cmdInner.Parameters.AddWithValue("@name", name);
        //                cmdInner.ExecuteNonQuery();
        //                cmdInner.Dispose();
        //            }
        //        }
        //        else
        //        {
        //            this.stockID = dataReader.GetString(0);
        //            this.name = dataReader.GetString(1);
        //            cmd.Dispose();
        //            dataReader.Close();
        //            dataReader.Dispose();
        //        }
        //        conn.Close();
        //    }
        //}

        #endregion

        //#region Methods


        //public static void NewItem(string name)
        //{
        //    using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
        //    {
        //        MySqlCommand cmd;
        //        MySqlDataReader dataReader, reader;

        //        cmd = new MySqlCommand("SELECT stockID FROM stock_item WHERE name=@name", conn);
        //        cmd.Parameters.AddWithValue("@name", name);
        //        dataReader = cmd.ExecuteReader();
        //        string stockID = "";
        //        if (!dataReader.Read())
        //        {
        //            using (MySqlConnection con = SqlConnectionHandler.GetSqlConnection())
        //            {
        //                do
        //                {
        //                    stockID = StockItem.GenerateStockID();
        //                    cmd = new MySqlCommand($"SELECT stockID FROM stock_item WHERE stockID=@stockID", con);
        //                    cmd.Parameters.AddWithValue("@stockID", stockID);
        //                    reader = cmd.ExecuteReader();
        //                }
        //                while (reader.Read());
        //                cmd.Dispose();
        //                dataReader.Close();
        //                con.Close();
        //            }

        //            using (cmd = new MySqlCommand($"INSERT IGNORE stock_item (stockID, name) VALUES (@stockID, @name)", conn))
        //            {
        //                cmd.Parameters.AddWithValue("@stockID", stockID);
        //                cmd.Parameters.AddWithValue("@name", name);
        //                cmd.ExecuteNonQuery();
        //                cmd.Dispose();
        //            }
        //        }
        //        else { cmd.Dispose(); dataReader.Close(); }
        //        conn.Close();
        //    }
        //}

        //public List<Department> GetAssignedDepartments()
        //{
        //    List<Department> listToSend = new List<Department>();
        //    using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
        //    {
        //        MySqlCommand cmd;
        //        MySqlDataReader dataReader;

        //        cmd = new MySqlCommand("SELECT departmentID FROM stock WHERE stockID=@stockid", conn);
        //        cmd.Parameters.AddWithValue("@stockid", this.StockID);
        //        dataReader = cmd.ExecuteReader();
        //        while (dataReader.Read())
        //        {
        //            listToSend.Add(new Department(dataReader.GetString(0), true));
        //        }
        //        return listToSend;
        //    }
        //}
        //#endregion
    }
}
