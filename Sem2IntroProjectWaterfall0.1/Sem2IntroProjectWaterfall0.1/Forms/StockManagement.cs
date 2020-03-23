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
        List<Department> departments;

        public StockManagement()
        {
            InitializeComponent();
            departments = Department.GetAllDepartments();
            loggedInEmployee = new Employee(LoggedInUser.userID);
            currentInventory = new Inventory(loggedInEmployee.DepartmentID);
            foreach (StockItem s in currentInventory.Items)
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
            foreach (StockItem s in currentInventory.Items)
                if (s.Name.ToLower().Contains(tbSearch.Text.ToLower()))
                    pnlStocks.Controls.Add(new StockUC(s));
        }

        private void btnShowRestock_Click(object sender, EventArgs e)
        {
            pnlStocks.Controls.Clear();
            foreach (StockItem s in currentInventory.GetRestockItemsCurrentDept())
                    pnlStocks.Controls.Add(new StockUC(s));
        }

        private void CbDepartments_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlStocks.Controls.Clear();
            if (cbDepartments.SelectedIndex != -1)
            {
                currentInventory = new Inventory(departments[cbDepartments.SelectedIndex].DepartmentId);
                foreach (StockItem s in currentInventory.Items)
                    pnlStocks.Controls.Add(new StockUC(s));
            }
        }

        private void CbDepartments_DropDown(object sender, EventArgs e)
        {
            cbDepartments.Items.Clear();
            UpdateDepartmentList();
            foreach (Department department in departments) { cbDepartments.Items.Add(department.Name); }
        }

        private void UpdateDepartmentList() { departments = Department.GetAllDepartments(); }
    }
}
