using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MediaBazaarApplicationWPF.Views
{
    class RestockCommand : ICommand
    {
        StockViewModel model;
        public RestockCommand(StockViewModel model)
        {
            this.model = model;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            if (model.BtnRestockContent == "Restock")
            {
                model.BtnRestockContent = "All stock";
                model.Stocks.Clear();

                foreach(StockItem s in model.CurrentInventory)
                {
                    if (s.CurrentAmount < s.Threshold) model.Stocks.Add(new StockControl(s));
                }
            }
            else
            {
                model.BtnRestockContent = "Restock";
                model.Stocks.Clear();
                foreach (StockItem s in model.CurrentInventory) model.Stocks.Add(new StockControl(s));
            }
        }
    }
}
