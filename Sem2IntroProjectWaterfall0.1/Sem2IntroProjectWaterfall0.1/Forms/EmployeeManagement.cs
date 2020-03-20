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
    public partial class EmployeeManagement : Form
    {
        private List<Department> departments;
        private List<Employee> employees;

        public EmployeeManagement()
        {
            InitializeComponent();
            RefreshComboboxes();
            employees = Employee.GetAllEmployees();
            departments = Department.GetAllDepartments();
        }

        private void UpdateDepartmentList() { departments = Department.GetAllDepartments(); }
        private void UpdateEmployeeList() { employees = Employee.GetAllEmployees(); }

        private void ClearEmployeePersonalInfo()
        {
            cbPersonalInfoList.SelectedIndex = -1;
            tbFirstName.Clear();
            tbLastName.Clear();
            tbNationality.Clear();
            tbPhoneNumber.Clear();
            tbAddress.Clear();
            tbEmail.Clear();
            dtpBirthday.Value = DateTime.Now.Date;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Dashboard newScreen = new Dashboard();
            newScreen.Show();
            this.Close();
        }

        private void cbRole_DropDown(object sender, EventArgs e)
        {
            cbRole.Items.Clear();
            foreach(Role role in Enum.GetValues(typeof(Role))) { cbRole.Items.Add(role); }
        }

        private void cbDepartments_DropDown(object sender, EventArgs e)
        {
            cbDepartments.Items.Clear();
            UpdateDepartmentList();
            foreach (Department department in departments) { cbDepartments.Items.Add(department.Name); }
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(tbUsername.Text) || string.IsNullOrEmpty(tbPassword.Text) || string.IsNullOrEmpty(tbHourlySalary.Text))
            {
                MessageBox.Show("Please fill all required fields and try again.");
            }
            else
            {
                decimal hourlySalary;
                if (Decimal.TryParse(tbHourlySalary.Text, out hourlySalary))
                {
                    if (cbDepartments.SelectedIndex == -1) { MessageBox.Show("Please select a department and try again."); return; }
                    if (cbRole.SelectedIndex == -1) { MessageBox.Show("Please select a role and try again."); return; }
                    if (!Employee.IsUniqueUsername(tbUsername.Text)) { MessageBox.Show("Username is taken. Please choose another and try again."); return; }
                    try
                    {
                        Employee newEmployee = new Employee(tbUsername.Text, tbPassword.Text, hourlySalary, (Role) cbRole.SelectedIndex, departments[cbDepartments.SelectedIndex].DepartmentId);
                        MessageBox.Show("Sucessfully added new employee to the system!");
                        RefreshComboboxes();
                        tbUsername.Clear();
                        tbPassword.Clear();
                        tbHourlySalary.Clear();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), $"Failed to create new employee", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else MessageBox.Show("Invalid hourly salary input. Please check for any mistakes and try again.");
            }
        }

        private void btnMoveEmployee_Click(object sender, EventArgs e)
        {
            if (cbEmployeeList.SelectedIndex != -1 && cbDepartmentList.SelectedIndex != -1)
            {
                try
                {
                    int eIndex = cbEmployeeList.SelectedIndex, dIndex = cbDepartmentList.SelectedIndex;
                    if (employees[eIndex].DepartmentID != departments[dIndex].DepartmentId)
                    {
                        employees[eIndex].DepartmentID = departments[dIndex].DepartmentId;
                        MessageBox.Show($"Successfully moved {employees[eIndex].Username} to department ({departments[dIndex].Name})");
                    }
                    else MessageBox.Show("Selected employee is already part of this department.");
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), $"Failed to move employee", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else MessageBox.Show("Missing information in required fields. Please check for mistakes and try again.");
        }

        void RefreshComboboxes()
        {
            cbEmployeeAssign.DataSource = null;
            cbDepartmentAssign.DataSource = null;
            cbDepartmentEdit.DataSource = null;
            cbDepartmentRemove.DataSource = null;
            List<Employee> allEmployees = Employee.GetAllEmployees();
            List<Department> allDepartmentsAssign = Department.GetAllDepartments();
            List<Department> allDepartmentsEdit = Department.GetAllDepartments();
            List<Department> allDepartmentsRemove = Department.GetAllDepartments();
            cbEmployeeAssign.DataSource = allEmployees;
            cbEmployeeAssign.DisplayMember = "MainDetails";
            cbDepartmentAssign.DataSource = allDepartmentsAssign;
            cbDepartmentAssign.DisplayMember = "Name";
            cbDepartmentEdit.DataSource = allDepartmentsEdit;
            cbDepartmentEdit.DisplayMember = "Name";
            cbDepartmentRemove.DataSource = allDepartmentsRemove;
            cbDepartmentRemove.DisplayMember = "Name";
        }

        private void btnAssignEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                Employee selectedUser = (Employee)cbEmployeeAssign.SelectedItem;
                Department selectedDepartment = (Department)cbDepartmentAssign.SelectedItem;
                Department oldDepartment = new Department(selectedUser.DepartmentID);
                oldDepartment.AssignEmployeeTo(selectedUser.UserID, selectedDepartment.DepartmentId);
                RefreshComboboxes();
            }catch(Exception exc) { MessageBox.Show(exc.Message); }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbDepartmentEditAddress.TextLength > 0 && tbDepartmentEditName.TextLength > 0)
                {
                    Department selectedDepartment = (Department)cbDepartmentEdit.SelectedItem;
                    selectedDepartment.Address = tbDepartmentEditAddress.Text;
                    selectedDepartment.Name = tbDepartmentEditName.Text;
                    RefreshComboboxes();
                    tbDepartmentEditAddress.Clear();
                    tbDepartmentEditName.Clear();
                }
            }
            catch (Exception exc) { MessageBox.Show(exc.Message); }
        }

        private void btnDepartmentRemove_Click(object sender, EventArgs e)
        {
            try
            {
                Department selectedDepartment = (Department)cbDepartmentRemove.SelectedItem;
                selectedDepartment.RemoveFromDatabase();
                RefreshComboboxes();
            }
            catch (Exception exc) { MessageBox.Show(exc.Message); }
        }
        
        private void btnCreateNewDepartment_Click(object sender, EventArgs e)
        {
            try
            {
                Department newDepartment = new Department(tbDepartmentCreateName.Text, tbDepartmentCreateAddress.Text);
                RefreshComboboxes();
                tbDepartmentCreateAddress.Clear();
                tbDepartmentCreateName.Clear();
            }
            catch (Exception exc) { MessageBox.Show(exc.Message); }
        }

        private void cbEmployeeList_DropDown(object sender, EventArgs e)
        {
            cbEmployeeList.Items.Clear();
            UpdateEmployeeList();
            foreach (Employee employee in employees) { cbEmployeeList.Items.Add($"{employee.Name} ({employee.Username})"); }
        }

        private void cbDepartmentList_DropDown(object sender, EventArgs e)
        {
            cbDepartmentList.Items.Clear();
            UpdateDepartmentList();
            foreach (Department department in departments) { cbDepartmentList.Items.Add(department.Name); }
        }

        private void cbRemoveList_DropDown(object sender, EventArgs e)
        {
            cbRemoveList.Items.Clear();
            UpdateEmployeeList();
            foreach (Employee employee in employees) { cbRemoveList.Items.Add($"{employee.Name} ({employee.Username})"); }
        }

        private void btnRemoveEmployee_Click(object sender, EventArgs e)
        {
            if (cbRemoveList.SelectedIndex != -1)
            {
                try
                {
                    int index = cbRemoveList.SelectedIndex;
                    employees[index].RemoveFromDatabase();
                    employees.RemoveAt(index);
                    MessageBox.Show($"Employee successfully removed from the system.");
                    cbRemoveList.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), $"Failed to remove employee", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else MessageBox.Show("Please select an employee and try again.");
        }

        private void cbPersonalInfoList_DropDown(object sender, EventArgs e)
        {
            cbPersonalInfoList.Items.Clear();
            UpdateEmployeeList();
            foreach (Employee employee in employees) { cbPersonalInfoList.Items.Add($"{employee.Name} ({employee.Username})"); }
        }

        private void cbPersonalInfoList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbPersonalInfoList.SelectedIndex != -1)
            {
                int index = cbPersonalInfoList.SelectedIndex;
                tbFirstName.Text = employees[index].FirstName;
                tbLastName.Text = employees[index].LastName;
                tbNationality.Text = employees[index].Nationality;
                tbPhoneNumber.Text = employees[index].PhoneNumber;
                tbAddress.Text = employees[index].Address;
                tbEmail.Text = employees[index].Email;
                if (employees[index].DateOfBirth > dtpBirthday.MinDate && employees[index].DateOfBirth < dtpBirthday.MaxDate) dtpBirthday.Value = employees[index].DateOfBirth;
                else dtpBirthday.Value = DateTime.Now.Date;
            }
        }

        private void btnUpdateEmployee_Click(object sender, EventArgs e)
        {
            if (cbPersonalInfoList.SelectedIndex != -1)
            {
                try
                {
                    employees[cbPersonalInfoList.SelectedIndex].SetPersonalInfo(tbFirstName.Text, tbLastName.Text, tbNationality.Text, tbAddress.Text, tbEmail.Text, tbPhoneNumber.Text, dtpBirthday.Value, false);
                    MessageBox.Show("Successfully updated employee personal information.");
                    ClearEmployeePersonalInfo();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), $"Failed to remove employee", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else MessageBox.Show("Please select an employee and try again.");
        }

        private void btnClearPersonalInfo_Click(object sender, EventArgs e)
        {
            ClearEmployeePersonalInfo();
        }

        private void cbDepartmentEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDepartmentEdit.SelectedIndex > -1)
            {
                Department selectedDepartment = (Department)cbDepartmentEdit.SelectedItem;
                tbDepartmentEditName.Text = selectedDepartment.Name;
                tbDepartmentEditAddress.Text = selectedDepartment.Address;
            }
        }
    }
}
