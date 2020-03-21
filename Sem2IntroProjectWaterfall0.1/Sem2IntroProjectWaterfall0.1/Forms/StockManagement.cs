using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sem2IntroProjectWaterfall0._1
{
    public partial class StockManagement : Form
    {
        Employee loggedInEmployee;
        Inventory currentInventory;
        public StockManagement()
        {
            InitializeComponent();
            loggedInEmployee = new Employee(LoggedInUser.userID);
            currentInventory = new Inventory(loggedInEmployee.DepartmentID);
            foreach (StockItem s in currentInventory.GetStockItems())
                pnlStocks.Controls.Add(new StockUC(s));
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Dashboard newScreen = new Dashboard();
            newScreen.Show();
            this.Close();
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            pnlStocks.Controls.Clear();
            foreach (StockItem s in currentInventory.GetStockItems())
                if (s.Name.Contains(tbSearch.Text))
                    pnlStocks.Controls.Add(new StockUC(s));
        }

        private void btnShowRestock_Click(object sender, EventArgs e)
        {
            pnlStocks.Controls.Clear();
            foreach (StockItem s in currentInventory.GetRestockItemsCurrentDept())
                    pnlStocks.Controls.Add(new StockUC(s));
        }
    }
}
