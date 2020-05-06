using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Sem2IntroProjectWaterfall0._1
{
    public class StockItem
    {
        #region Var and prop
        private string name;
        private string stockID;
        private int threshold;
        private int currentAmount;
        private string departmentID;

        public string StockID
        {
            get{ return this.stockID; }
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
                    {
                        using (MySqlCommand cmd = new MySqlCommand($"UPDATE stock_item SET name = @name WHERE stockID=@stockID", conn))
                        {
                            cmd.Parameters.AddWithValue("@name", value);
                            cmd.Parameters.AddWithValue("@stockID", this.stockID);
                            cmd.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        conn.Close();
                        this.name = value;
                    }
                }
            }
        }
       

        public int Threshold
        {
            get { return this.threshold; }
            set
            {
                using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand($"UPDATE stock SET threshold = @threshold WHERE stockID=@stockID", conn))
                    {
                        cmd.Parameters.AddWithValue("@threshold", value);
                        cmd.Parameters.AddWithValue("@stockID", this.stockID);
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                    conn.Close();
                    this.threshold = value;
                }
            }
        }

        public int CurrentAmount
        {
            get { return this.currentAmount; }
            set
            {
                using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand($"UPDATE stock SET currentAmount = @currentAmount WHERE stockID=@stockID", conn))
                    {
                        cmd.Parameters.AddWithValue("@currentAmount", value);
                        cmd.Parameters.AddWithValue("@stockID", this.stockID);
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                    conn.Close();
                    this.currentAmount = value;
                }
            }
        }

        public string DepartmentID
        {
            get { return this.departmentID; }
            set
            {
                using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand($"UPDATE stock SET departmentID=@departmentID WHERE stockID=@stockID", conn))
                    {
                        cmd.Parameters.AddWithValue("@depID", value);
                        cmd.Parameters.AddWithValue("@stockID", this.stockID);
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                    conn.Close();
                    this.departmentID = value;
                }
            }
        }
        #endregion

        #region Constructors

        //TO DO: Shorten and clean code
        public StockItem(string name, int threshold, string departmentID, int currentAmount)
        {
            this.name = name;
            this.threshold = threshold;
            this.currentAmount = currentAmount;
            this.departmentID = departmentID;

            MySqlConnection conn = SqlConnectionHandler.GetSqlConnection();
            MySqlCommand cmd;
            MySqlDataReader dataReader, reader;

            cmd = new MySqlCommand("SELECT stockID FROM stock_item WHERE name=@name", conn);
            cmd.Parameters.AddWithValue("@name", this.name);
            dataReader = cmd.ExecuteReader();
            if (!dataReader.Read())
            {
                using (MySqlConnection con = SqlConnectionHandler.GetSqlConnection())
                {
                    do
                    {
                        this.stockID = GenerateStockID();
                        cmd = new MySqlCommand($"SELECT stockID FROM stock_item WHERE stockID=@stockID", con);
                        cmd.Parameters.AddWithValue("@stockID", this.stockID);
                        reader = cmd.ExecuteReader();
                    }
                    while (reader.Read());
                    cmd.Dispose();
                    dataReader.Close();
                }

                using (cmd = new MySqlCommand($"INSERT IGNORE stock_item (stockID, name) VALUES (@stockID, @name)", conn))
                {
                    cmd.Parameters.AddWithValue("@stockID", this.stockID);
                    cmd.Parameters.AddWithValue("@name", this.name);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
            }

            else { this.stockID = dataReader.GetString(0); }

            dataReader.Dispose();
            using (cmd = new MySqlCommand($"REPLACE INTO stock (stockID, departmentID, threshold, currentAmount) VALUES (@stockID, @departmentID, @threshold, @currentAmount)", conn))
            {
                cmd.Parameters.AddWithValue("@stockID", this.stockID);
                cmd.Parameters.AddWithValue("@departmentID", this.departmentID);
                cmd.Parameters.AddWithValue("@threshold", this.threshold);
                cmd.Parameters.AddWithValue("@currentAmount", this.currentAmount);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            conn.Close();
        }

        public StockItem(string departmentID, string stockID)
        {
            this.departmentID = departmentID;
            this.stockID = stockID;

            using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand($"SELECT s.threshold, s.currentAmount, i.name FROM stock as s INNER JOIN stock_item as i ON i.stockID = s.stockID WHERE s.departmentID=@departmentID AND s.stockID=@stockID", conn))
                {
                    cmd.Parameters.AddWithValue("@departmentID", this.departmentID);
                    cmd.Parameters.AddWithValue("@stockID", this.stockID);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.Read())
                    {
                        this.threshold = dataReader.GetInt32(0);
                        this.currentAmount = dataReader.GetInt32(1);
                        this.name = dataReader.GetString(2);
                    }
                    cmd.Dispose();
                    dataReader.Close();
                }
                conn.Close();
            }
        }

        public StockItem(string name)
        {
            using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
            {
                MySqlCommand cmd;
                MySqlDataReader dataReader, reader;

                cmd = new MySqlCommand("SELECT stockID, name FROM stock_item WHERE name=@name", conn);
                cmd.Parameters.AddWithValue("@name", name);
                dataReader = cmd.ExecuteReader();
                if (!dataReader.Read())
                {
                    this.name = name;
                    using (MySqlConnection con = SqlConnectionHandler.GetSqlConnection())
                    {
                        do
                        {
                            this.stockID = StockItem.GenerateStockID();
                            cmd = new MySqlCommand($"SELECT stockID FROM stock_item WHERE stockID=@stockID", con);
                            cmd.Parameters.AddWithValue("@stockID", this.stockID);
                            reader = cmd.ExecuteReader(); 
                        }
                        while (reader.Read());
                        cmd.Dispose();
                        dataReader.Close();
                        dataReader.Dispose();
                        con.Close();
                    }
                    using (MySqlCommand cmdInner = new MySqlCommand($"INSERT IGNORE stock_item (stockID, name) VALUES (@stockID, @name)", conn))
                    {
                        cmdInner.Parameters.AddWithValue("@stockID", this.stockID);
                        cmdInner.Parameters.AddWithValue("@name", name);
                        cmdInner.ExecuteNonQuery();
                        cmdInner.Dispose();
                    }
                }
                else
                {
                    this.stockID = dataReader.GetString(0);
                    this.name = dataReader.GetString(1);
                    cmd.Dispose();
                    dataReader.Close();
                    dataReader.Dispose();
                }
                conn.Close();
            }
        }

        #endregion

        #region Methods
        private static string GenerateStockID()
        {
            Guid key = Guid.NewGuid();
            string GuidString = Convert.ToBase64String(key.ToByteArray());
            GuidString = GuidString.Replace("=", "");
            GuidString = GuidString.Replace("+", "");
            GuidString = GuidString.Replace("/", "");

            return GuidString;
        }

        public static void NewItem(string name)
        {
            using(MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
            {
                MySqlCommand cmd;
                MySqlDataReader dataReader, reader;

                cmd = new MySqlCommand("SELECT stockID FROM stock_item WHERE name=@name", conn);
                cmd.Parameters.AddWithValue("@name", name);
                dataReader = cmd.ExecuteReader();
                string stockID = "";
                if (!dataReader.Read())
                {
                    using (MySqlConnection con = SqlConnectionHandler.GetSqlConnection())
                    {
                        do
                        {
                            stockID = StockItem.GenerateStockID();
                            cmd = new MySqlCommand($"SELECT stockID FROM stock_item WHERE stockID=@stockID", con);
                            cmd.Parameters.AddWithValue("@stockID", stockID);
                            reader = cmd.ExecuteReader();
                        }
                        while (reader.Read());
                        cmd.Dispose();
                        dataReader.Close();
                        con.Close();
                    }

                    using (cmd = new MySqlCommand($"INSERT IGNORE stock_item (stockID, name) VALUES (@stockID, @name)", conn))
                    {
                        cmd.Parameters.AddWithValue("@stockID", stockID);
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                }
                else { cmd.Dispose(); dataReader.Close(); }
                conn.Close();
            }
        }

        public List<Department> GetAssignedDepartments()
        {
            List<Department> listToSend = new List<Department>();
            using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
            {
                MySqlCommand cmd;
                MySqlDataReader dataReader;

                cmd = new MySqlCommand("SELECT departmentID FROM stock WHERE stockID=@stockid", conn);
                cmd.Parameters.AddWithValue("@stockid", this.StockID);
                dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    listToSend.Add(new Department(dataReader.GetString(0)));
                }
                return listToSend;
            }
        }
        #endregion
    }
}
