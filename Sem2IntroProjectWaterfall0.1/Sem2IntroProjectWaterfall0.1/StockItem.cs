using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Sem2IntroProjectWaterfall0._1
{
    class StockItem
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

        public int CurrentAmmount
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
        

        public StockItem(string stockID,  int treshold, int currentAmmount)
        {

            this.stockID = stockID;
            this.threshold = treshold;
            this.currentAmount = currentAmmount;
        }


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

        public StockItem(string name)
        {
            this.name = name;

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
            else { cmd.Dispose(); dataReader.Close(); }
        }

        public StockItem(string departmentID, string stockID)
        {
            this.departmentID = departmentID;
            this.stockID = stockID;

            MySqlConnection conn = SqlConnectionHandler.GetSqlConnection();
            MySqlCommand cmd;
            MySqlDataReader dataReader;
            {
                using (cmd = new MySqlCommand($"SELECT threshold, currentAmount FROM stock WHERE departmentID=@departmentID AND stockID=@stockID", conn))
                {
                    cmd.Parameters.AddWithValue("@departmentID", departmentID);
                    cmd.Parameters.AddWithValue("@stockID", stockID);
                    dataReader = cmd.ExecuteReader();

                    if (dataReader.Read())
                    {
                        this.threshold = Convert.ToInt32(dataReader.GetString(0));
                        this.currentAmount = Convert.ToInt32(dataReader.GetString(1));
                    }
                    cmd.Dispose();
                    dataReader.Close();
                }
            }
        }
        #endregion

        #region Methods
        private string GenerateStockID()
        {
            Guid key = Guid.NewGuid();
            string GuidString = Convert.ToBase64String(key.ToByteArray());
            GuidString = GuidString.Replace("=", "");
            GuidString = GuidString.Replace("+", "");
            GuidString = GuidString.Replace("/", "");

            return GuidString;
        }
        #endregion
    }
}
