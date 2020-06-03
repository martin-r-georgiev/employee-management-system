using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApplicationWPF
{
    class StockItemManager
    {
        public static void AddStockToDepartment(string name, int threshold, string departmentID, int currentAmount)
        {
            if (StockItemDatabaseHandler.IsUnique(name))
            {
                string stockID = StockItemDatabaseHandler.GenerateUniqueID();
                // StockItem newItem = new StockItem(name, threshold, departmentID, currentAmount, stockID);
                // StockItemDatabaseHandler.InsertIgnoreToStockItem(newItem);
                // StockItemDatabaseHandler.InsertToStock(newItem);
            }
            else throw new ArgumentException("Item already added");
        }
        public static StockItem GetStock(string departmentID, string stockID)
        {
            return StockItemDatabaseHandler.GetStock(departmentID, stockID);
        }
    }
}
