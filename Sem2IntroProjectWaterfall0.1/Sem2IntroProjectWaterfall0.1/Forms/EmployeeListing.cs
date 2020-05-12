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
        List<Department> departments;

        public EmployeeListing()
        {
            InitializeComponent();
            departments = Department.GetAllDepartments();
            //Department loggedInDepartment = new Department(LoggedInUser.userID, true);
            //displayedEmployees = loggedInDepartment.GetAllEmployees();
            displayedEmployees = Department.GetEmployeesFromDepartmentID(LoggedInUser.departmentID);
            Department selectedDepartment = departments.Find(x => x.DepartmentId == LoggedInUser.departmentID);
            foreach (Employee e in displayedEmployees)
                pnlEmployees.Controls.Add(new EmployeeControl(e, selectedDepartment.Name));
            if (LoggedInUser.role >= Role.Manager) cbDepartments.Visible = true;
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
                {
                    foreach (Department dep in departments)
                    {
                        if (emp.DepartmentID == dep.DepartmentId) pnlEmployees.Controls.Add(new EmployeeControl(emp, dep.Name));
                    }
                }
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            pnlEmployees.Controls.Clear();
            foreach (Employee emp in displayedEmployees)
                foreach (Department dep in departments)
                {
                    if (emp.DepartmentID == dep.DepartmentId) pnlEmployees.Controls.Add(new EmployeeControl(emp, dep.Name));
                }
        }

        private void cbDepartments_SelectedIndexChanged(object sender, EventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            //Index 0 is reserved for 'All' departments option
            if (cbDepartments.SelectedIndex == 0)
            {
                displayedEmployees.Clear();
                foreach (Department d in departments) displayedEmployees.AddRange(d.Employees);
            }
            else if (cbDepartments.SelectedIndex > 0)
            {
                displayedEmployees = departments[cbDepartments.SelectedIndex - 1].Employees;
            }

            //if (cbDepartments.SelectedItem.ToString() == "All") displayedEmployees = Employee.GetAllEmployees(false);
            //else
            //{
            //    foreach (Department d in departments)
            //        if (d.Name == cbDepartments.SelectedItem.ToString())
            //        {
            //            displayedEmployees = d.GetAllEmployees();
            //        }    
            //}
            
            pnlEmployees.Controls.Clear();
            pnlEmployees.SuspendLayout();
            foreach (Employee emp in displayedEmployees)
            {
                foreach(Department dep in departments)
                {
                    if(emp.DepartmentID == dep.DepartmentId) pnlEmployees.Controls.Add(new EmployeeControl(emp, dep.Name));
                }
            }
            pnlEmployees.ResumeLayout();
            watch.Stop();
            Console.WriteLine($"{watch.ElapsedMilliseconds}ms");
        }

        private void cbDepartments_DropDown(object sender, EventArgs e)
        {
            UpdateDepartments();
            cbDepartments.Items.Clear();
            cbDepartments.Items.Add("All");
            foreach (Department d in departments) cbDepartments.Items.Add(d.Name);
        }

        private void UpdateDepartments() { departments = Department.GetAllDepartments(); }

        public void RefreshGUI(Employee selectedEmployee)
        {
            //lblEmployeeAttendance;
            
            lblEmployeeRole.Text = $"Role: {selectedEmployee.Role}";
            lblEmployeeSalary.Text = $"Salary: ${selectedEmployee.SalaryHourlyRate}/hr";
            lblEmployeeWorkingSince.Text = Employee.CalculateWorkingSince(selectedEmployee);
            lblEmployeeDepartment.Text = "Department: " + new Department(selectedEmployee.DepartmentID).Name;

            int age = DateTime.Today.Year - selectedEmployee.DateOfBirth.Year;
            if (age > 100) lblEmployeeAge.Text = $"Age: Unknown";
            else lblEmployeeAge.Text = $"Age: {age}";


            if (selectedEmployee.Sex == null) lblEmployeeGender.Text = "Gender: Unknown";
            else
            {
                if (selectedEmployee.Sex) lblEmployeeGender.Text = $"Gender: Female";
                else lblEmployeeGender.Text = $"Gender: Male";
            }
            lblEmployeeEmail.Text = String.IsNullOrEmpty(selectedEmployee.Email) ? "E-mail: Unknown" : $"E-mail: {selectedEmployee.Email}";
            lblEmployeeAddress.Text = String.IsNullOrEmpty(selectedEmployee.Address) ? "Address: Unknown" : $"Address: {selectedEmployee.Address}";
            lblEmployeeName.Text = String.IsNullOrEmpty(selectedEmployee.FirstName) ? "Name: Unknown" : $"Name: {selectedEmployee.FirstName} {selectedEmployee.LastName}";
            lblEmployeeNationality.Text = String.IsNullOrEmpty(selectedEmployee.Nationality) ? "Nationality: Unknown" : $"Nationality: {selectedEmployee.Nationality}";
            lblEmployeePhone.Text = String.IsNullOrEmpty(selectedEmployee.PhoneNumber) ? "Phone: Unknown" : $"Phone: {selectedEmployee.PhoneNumber}";

            lblEmployeeAttendance.Text = $"Attendance: {selectedEmployee.Attendance:F2}%";
        }

        private void tbEmployeeName_TextChanged(object sender, EventArgs e)
        {
            pnlEmployees.Controls.Clear();
            foreach (Employee emp in displayedEmployees)
                if (emp.Name.ToLower().Contains(tbEmployeeName.Text.ToLower()))
                {
                    foreach (Department dep in departments)
                    {
                        if (emp.DepartmentID == dep.DepartmentId) pnlEmployees.Controls.Add(new EmployeeControl(emp, dep.Name));
                    }
                }
        }
    }
}
