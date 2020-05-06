using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sem2IntroProjectWaterfall0._1
{
    public partial class EmployeeControl : UserControl
    {
        Employee selectedEmployee;
        public EmployeeControl(Employee emp)
        {
            InitializeComponent();
            SelectedEmployee = emp;
        }
        public Employee SelectedEmployee
        {
            get { return selectedEmployee; }
            set { 
                selectedEmployee = value;
                lblEmployee.Text = selectedEmployee.Name;
                lblDepartment.Text = new Department(selectedEmployee.DepartmentID).Name;
            }
        }

        private void EmployeeControl_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(192, 255, 255);
            this.lblDepartment.BackColor = Color.FromArgb(192, 255, 255);
            this.lblEmployee.BackColor = Color.FromArgb(192, 255, 255);
            this.lblDepartment.Font = new Font(lblDepartment.Font.FontFamily, 10, FontStyle.Regular);
            this.lblEmployee.Font = new Font(lblEmployee.Font.FontFamily, 10, FontStyle.Bold);
            this.Size = new Size(313, 50);
        }

        private void EmployeeControl_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(128, 255, 255);
            this.lblDepartment.BackColor = Color.FromArgb(128, 255, 255);
            this.lblEmployee.BackColor = Color.FromArgb(128, 255, 255);
            this.lblDepartment.Font = new Font(lblDepartment.Font.FontFamily, 9, FontStyle.Regular);
            this.lblEmployee.Font = new Font(lblEmployee.Font.FontFamily, 9, FontStyle.Bold);
            this.Size = new Size(313, 43);
        }

        private void EmployeeControl_MouseClick(object sender, MouseEventArgs e)
        {
            EmployeeListing pForm = (EmployeeListing)this.ParentForm;
            Employee fullEmployee = new Employee(this.SelectedEmployee.UserID, true);
            pForm.RefreshGUI(fullEmployee);
        }
    }
}
