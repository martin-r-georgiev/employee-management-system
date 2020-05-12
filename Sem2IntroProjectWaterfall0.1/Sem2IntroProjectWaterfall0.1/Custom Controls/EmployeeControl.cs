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
        public EmployeeControl(Employee emp, string depName)
        {
            InitializeComponent();
            SelectedEmployee = emp;
            lblDepartment.Text = depName;
            lblLetter.Text = emp.Name.Substring(0, 1).ToUpper();
            switch(emp.Role)
            {
                case Role.Worker: lblLetter.BackColor = Color.LightBlue; break;
                case Role.Manager: lblLetter.BackColor = Color.MediumPurple; break;
                case Role.Admin: lblLetter.BackColor = Color.YellowGreen; break;
                case Role.Owner: lblLetter.BackColor = Color.Firebrick; break;
                default: lblLetter.BackColor = Color.DimGray; break;
            }
            roleTooltip.SetToolTip(this.lblLetter, $"Role: {selectedEmployee.Role}");
        }
        public Employee SelectedEmployee
        {
            get { return selectedEmployee; }
            set
            { 
                selectedEmployee = value;
                lblEmployee.Text = selectedEmployee.Name;
            }
        }

        private void EmployeeControl_MouseEnter(object sender, EventArgs e)
        {
            this.SuspendLayout();
            this.BackColor = Color.LightGray;
            this.panelSidebar.BackColor = Color.LightGray;
            this.lblDepartment.Font = new Font(lblDepartment.Font.FontFamily, 10, FontStyle.Regular);
            this.lblEmployee.Font = new Font(lblEmployee.Font.FontFamily, 10, FontStyle.Bold);
            this.ResumeLayout();
        }

        private void EmployeeControl_MouseLeave(object sender, EventArgs e)
        {
            this.SuspendLayout();
            this.BackColor = Color.GhostWhite;
            this.panelSidebar.BackColor = Color.GhostWhite;
            this.lblDepartment.Font = new Font(lblDepartment.Font.FontFamily, 9, FontStyle.Regular);
            this.lblEmployee.Font = new Font(lblEmployee.Font.FontFamily, 9, FontStyle.Bold);
            this.ResumeLayout();
        }

        private void EmployeeControl_MouseClick(object sender, MouseEventArgs e)
        {
            EmployeeListing pForm = (EmployeeListing)this.ParentForm;
            pForm.RefreshGUI(SelectedEmployee);
        }
    }
}
