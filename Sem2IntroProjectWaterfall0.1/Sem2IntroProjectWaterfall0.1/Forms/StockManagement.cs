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

            loggedInEmployee = new Employee(LoggedInUser.userID);
            currentInventory = new Inventory(loggedInEmployee.DepartmentID);
            foreach (StockItem s in currentInventory.Items)
                pnlStocks.Controls.Add(new StockUC(s));
            if (loggedInEmployee.Role >= Role.Manager)
            {
                lblDepartment.Visible = true;
                cbDepartments.Visible = true;
            }

            departments = Department.GetAllDepartments();
            cbDepartments.DataSource = departments;
            cbDepartments.DisplayMember = "Name";

            foreach (Department department in departments)
            {
                if (LoggedInUser.departmentID == department.DepartmentId)
                {
                    cbDepartments.Text = department.Name;
                    break;
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Dashboard newScreen = new Dashboard();
            newScreen.Show();
            this.Close();
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            if (btnShowRestock.Text == "All stock") btnShowRestock.Text = "Restock";
            pnlStocks.Controls.Clear();
            foreach (StockItem s in currentInventory.Items)
                if (s.Name.ToLower().Contains(tbSearch.Text.ToLower()))
                    pnlStocks.Controls.Add(new StockUC(s));
        }

        private void btnShowRestock_Click(object sender, EventArgs e)
        {
            if (btnShowRestock.Text == "Restock")
            {
                btnShowRestock.Text = "All stock";
                pnlStocks.Controls.Clear();
                foreach (StockItem s in currentInventory.GetRestockItemsCurrentDept())
                    pnlStocks.Controls.Add(new StockUC(s));
            } else
            {
                btnShowRestock.Text = "Restock";
                pnlStocks.Controls.Clear();
                foreach (StockItem s in currentInventory.Items)
                    pnlStocks.Controls.Add(new StockUC(s));
            }
        }

        private void UpdateDepartments() { departments = Department.GetAllDepartments(); }

        private void pnlStocks_SizeChanged(object sender, EventArgs e)
        {
            pnlStocks.SuspendLayout();
            foreach(Control control in pnlStocks.Controls)
            {
                control.Width = pnlStocks.ClientSize.Width - 10;
            }
            pnlStocks.ResumeLayout();
        }

        private void pnlStocks_ControlAdded(object sender, ControlEventArgs e)
        {
            pnlStocks.SuspendLayout();
            foreach (Control control in pnlStocks.Controls)
            {
                control.Width = pnlStocks.ClientSize.Width - 10;
            }
            pnlStocks.ResumeLayout();
        }

        private void cbDepartments_DropDown(object sender, EventArgs e) { UpdateDepartments(); }

        private void cbDepartments_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlStocks.SuspendLayout();
            pnlStocks.Controls.Clear();
            if (cbDepartments.SelectedIndex != -1)
            {
                if (btnShowRestock.Text == "All stock") btnShowRestock.Text = "Restock";
                currentInventory = new Inventory(departments[cbDepartments.SelectedIndex].DepartmentId);
                foreach (StockItem s in currentInventory.Items)
                    pnlStocks.Controls.Add(new StockUC(s));
            }
            pnlStocks.ResumeLayout();
        }
    }
}
