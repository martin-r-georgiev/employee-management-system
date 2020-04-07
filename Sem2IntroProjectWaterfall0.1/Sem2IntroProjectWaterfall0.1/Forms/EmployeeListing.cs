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
    public partial class EmployeeListing : Form
    {
        List<Employee> displayedEmployees;
        public EmployeeListing()
        {
            InitializeComponent();
            Department loggedInDepartment = new Department(LoggedInUser.userID, true);
            displayedEmployees = loggedInDepartment.GetAllEmployees();
            foreach (Employee e in displayedEmployees)
                pnlEmployees.Controls.Add(new EmployeeControl(e));
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Dashboard newScreen = new Dashboard();
            newScreen.Show();
            this.Close();
        }

        private void btnStatistics_Click(object sender, EventArgs e)
        {
            StatisticsForm newForm = new StatisticsForm();
            newForm.Show();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            pnlEmployees.Controls.Clear();
            foreach (Employee emp in displayedEmployees)
                if (emp.Name.ToLower().Contains(tbEmployeeName.Text.ToLower()))
                    pnlEmployees.Controls.Add(new EmployeeControl(emp));
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            pnlEmployees.Controls.Clear();
            foreach (Employee emp in displayedEmployees)
                    pnlEmployees.Controls.Add(new EmployeeControl(emp));
        }

        private void cbDepartments_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDepartments.SelectedItem.ToString() == "All") displayedEmployees = Employee.GetAllEmployees(false);
            else
            {
                foreach (Department d in Department.GetAllDepartments())
                    if (d.Name == cbDepartments.SelectedItem.ToString())
                        displayedEmployees = d.GetAllEmployees();
            }
            pnlEmployees.Controls.Clear();
            foreach (Employee emp in displayedEmployees)
                pnlEmployees.Controls.Add(new EmployeeControl(emp));
        }

        private void cbDepartments_DropDown(object sender, EventArgs e)
        {
            cbDepartments.Items.Clear();
            cbDepartments.Items.Add("All");
            foreach (Department d in Department.GetAllDepartments())
                cbDepartments.Items.Add(d.Name);
        }
    }
}
