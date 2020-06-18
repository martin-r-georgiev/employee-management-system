using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MediaBazaarApplicationWPF
{
    public class StockItem
    {
        #region # Instance variable(s)

        private readonly string stockID;
        private string departmentID;
        private string name;
        private int currentAmount;
        private int threshold;

        #endregion

        #region # Properties

        public string StockID => this.stockID;

        public string DepartmentID
        {
            get => this.departmentID;
            set
            {
                if (value != null) this.departmentID = value;
                else throw new ArgumentException("Invalid department ID has been parsed to stock item. Given value cannot be empty (null).");
            }
        }

        public string Name
        {
            get => this.name;
            set
            {
                if (value != null) this.name = value;
                else throw new ArgumentException("Invalid name has been parsed to stock item. Given value cannot be empty (null).");
            }
        }

        public override string ToString() => this.Name;

        public int CurrentAmount
        {
            get => this.currentAmount;
            set
            {
                if (value >= 0) this.currentAmount = value;
                else throw new ArgumentException("Invalid current amount has beene parsed to stock item. Given value can only be positive.");
            }
        }

        public int Threshold
        {
            get => this.threshold;
            set
            {
                if (value >= 0) this.threshold = value;
                else throw new ArgumentException("Invalid current amount has beene parsed to stock item. Given value can only be positive.");
            }
        }

        #endregion

        #region # Constructors

        public StockItem(string stockID, string departmentID, string name, int currentAmount, int threshold)
        {
            this.stockID = stockID;
            this.Name = name;
            this.DepartmentID = departmentID;
            this.CurrentAmount = currentAmount;
            this.Threshold = threshold;
        }

        public StockItem(string stockID, string departmentID, string name)
        {
            this.stockID = stockID;
            this.DepartmentID = departmentID;
            this.Name = name;
            this.CurrentAmount = 0;
            this.Threshold = 0;
        }

        public StockItem(string stockID, string name)
        {
            this.stockID = stockID;
            this.departmentID = null;
            this.Name = name;
            this.CurrentAmount = 0;
            this.Threshold = 0;
        }

        #endregion     
    }
}
