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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            lbWorkers.Items.Add("Ivan");
            lbWorkers.Items.Add("John");
            lbWorkers.Items.Add("Peter");

            Inventory newInv = new Inventory("ALeOUe860aghE7oYKzSqQ");

            List<StockItem> list = newInv.GetStockItems();

            foreach(StockItem item in list)
            {
                Console.WriteLine($"{item.Name} - {item.DepartmentID} - {item.CurrentAmmount}/{item.Threshold}");
            }

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            LoginScreen newScreen = new LoginScreen();
            newScreen.Show();
            this.Close();
        }

        private void btnStocks_Click(object sender, EventArgs e)
        {
            StockManagement newScreen = new StockManagement();
            newScreen.Show();
            this.Close();
        }

        private void btnStatistics_Click(object sender, EventArgs e)
        {
            EmployeeListing newScreen = new EmployeeListing();
            newScreen.Show();
            this.Close();
        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            EmployeeManagement newScreen = new EmployeeManagement();
            newScreen.Show();
            this.Close();
        }

        private void btnWorkshifts_Click(object sender, EventArgs e)
        {
            Workshifts newScreen = new Workshifts();
            newScreen.Show();
            this.Close();
        }

        private void BtnCheckin_Click(object sender, EventArgs e)
        {
            StockItem item = new StockItem("Samsung S2");
        }
    }
}
