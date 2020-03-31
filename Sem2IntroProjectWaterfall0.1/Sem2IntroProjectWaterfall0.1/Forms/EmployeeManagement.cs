using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Sem2IntroProjectWaterfall0._1
{
    public partial class EmployeeManagement : Form
    {
        private List<Department> departments;
        private List<Employee> employees;
        private List<StockItem> stocks;

        public EmployeeManagement()
        {
            InitializeComponent();
            RefreshComboboxes();
            employees = Employee.GetAllEmployees();
            departments = Department.GetAllDepartments();
            stocks = Inventory.ListAllItemsFromStockItem();
        }

        private void UpdateDepartmentList() { departments = Department.GetAllDepartments(); }

        private void UpdateEmployeeList() { employees = Employee.GetAllEmployees(); }

        private void UpdateStockList() { stocks = Inventory.ListAllItemsFromStockItem(); }

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
            foreach (Role role in Enum.GetValues(typeof(Role))) { cbRole.Items.Add(role); }
        }

        private void cbDepartments_DropDown(object sender, EventArgs e)
        {
            cbDepartments.Items.Clear();
            UpdateDepartmentList();
            foreach (Department department in departments) { cbDepartments.Items.Add(department.Name); }
        }
        private bool checkforwhitespace(string input)
        {
            string pattern = @"^(?=.{3,20}$)(?![_.])(?!.*[_.]{2})[a-zA-Z0-9._]+(?<![_.])$";
            Regex rg = new Regex(pattern);
            if (rg.IsMatch(input))
                return true;
            return false;

        }
        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            if (!checkforwhitespace(tbUsername.Text) || string.IsNullOrEmpty(tbPassword.Text) || string.IsNullOrEmpty(tbHourlySalary.Text))
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
                        Employee newEmployee = new Employee(tbUsername.Text, tbPassword.Text, hourlySalary, (Role)cbRole.SelectedIndex, departments[cbDepartments.SelectedIndex].DepartmentId);
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
            } catch (Exception exc) { MessageBox.Show(exc.Message); }
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
            if (checkforwhitespace(tbDepartmentCreateName.Text))
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
            else
            {
                MessageBox.Show("Please enter a valid name, adress");
            }
        }

        private void cbEmployeeList_DropDown(object sender, EventArgs e)
        {

        }

        private void cbDepartmentList_DropDown(object sender, EventArgs e)
        {

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
            if (cbPersonalInfoList.SelectedIndex != -1)
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
            bool gender = false; if (rbFemale.Checked == true) { gender = true; }
            if (cbPersonalInfoList.SelectedIndex != -1)
            {
                try
                {
                    Regex emailValidation = new Regex(@"^(([^<>()[\]\\.,;:\s@\""]+(\.[^<>()[\]\\.,;:\s@\""]+)*)|(\"".+\""))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$");
                    Regex nameValidation = new Regex(@"\d+");
                    Regex phoneValidation = new Regex(@"^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\./0-9]*$");
                    if (!nameValidation.IsMatch(tbFirstName.Text) && !nameValidation.IsMatch(tbLastName.Text))
                    {
                        if (emailValidation.IsMatch(tbEmail.Text))
                        {
                            if (phoneValidation.IsMatch(tbPhoneNumber.Text))
                            {
                                if (dtpBirthday.Value.Date <= System.DateTime.Now.Date)
                                {
                                    employees[cbPersonalInfoList.SelectedIndex].SetPersonalInfo(tbFirstName.Text, tbLastName.Text, tbNationality.Text, tbAddress.Text, tbEmail.Text, tbPhoneNumber.Text, dtpBirthday.Value, gender);
                                    MessageBox.Show("Successfully updated employee personal information.");
                                    ClearEmployeePersonalInfo();
                                }
                                else
                                {
                                    MessageBox.Show("Invalid birth date . Please check back for any mistakes and try again.");
                                }
                            }
                            else MessageBox.Show("Invalid phone number . Please check back for any mistakes and try again.");

                        }
                        else MessageBox.Show("Invalid e-mail address. Please check back for any mistakes and try again.");
                    }
                    else MessageBox.Show("Invalid first name/surname. Digits are not accepted");
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

        //Add item controls

        private bool checkforwhitespacestockitem(string input)
        {
            string pattern = @"^(?=.{3,20}$)(?![_.])(?!.*[_.]{2})[a-zA-Z0-9._][\w\s-]+(?<![_.])$";
            Regex rg = new Regex(pattern);
            if (rg.IsMatch(input))
                return true;
            return false;

        }

        private void btnCreateNewStock_Click(object sender, EventArgs e)
        {
            if (checkforwhitespacestockitem(tbStockCreateName.Text))
            {
                StockItem.NewItem(tbStockCreateName.Text);
                MessageBox.Show("Successfully added new item.");
                tbStockCreateName.Clear();
            }
            else MessageBox.Show("Enter a name for the stock!");
        }

        //Remove item controls

        private void cbRemoveItem_DropDown(object sender, EventArgs e)
        {
            cbRemoveItem.Items.Clear();
            UpdateStockList();
            foreach (StockItem stock in stocks) cbRemoveItem.Items.Add(stock.Name);
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            if (cbRemoveItem.SelectedIndex != -1)
            {
                foreach (StockItem stock in stocks)
                {
                    if (stock.Name == cbRemoveItem.SelectedItem.ToString())
                    {
                        Inventory.RemoveItemGlobal(stock.StockID);
                        MessageBox.Show("Successfully removed item from system.");
                        cbRemoveItem.SelectedIndex = -1;
                        break;
                    }
                }
            }
            else MessageBox.Show("Select an item to be deleted");
        }

        //Assign item to department

        private void cbItemAssignItem_DropDown(object sender, EventArgs e)
        {
            cbItemAssignItem.Items.Clear();
            UpdateStockList();
            foreach (StockItem stock in stocks) cbItemAssignItem.Items.Add(stock.Name);
        }

        private void cbDepartmentAssignItem_DropDown(object sender, EventArgs e)
        {
            cbDepartmentAssignItem.Items.Clear();
            UpdateDepartmentList();
            foreach (Department dep in departments) cbDepartmentAssignItem.Items.Add(dep.Name);
        }

        private void btnAssignItemToDepartment_Click(object sender, EventArgs e)
        {
            if (cbDepartmentAssignItem.SelectedIndex != -1 && cbItemAssignItem.SelectedIndex != -1)
            {
                if (numUdCurrentAmmount.Value >= 0 && numUdThreshold.Value >= 0)
                {
                    int iIndex = cbItemAssignItem.SelectedIndex, dIndex = cbDepartmentAssignItem.SelectedIndex;
                    if (!Inventory.Exists(stocks[iIndex].StockID, departments[dIndex].DepartmentId))
                    {
                        int threshold = Convert.ToInt32(numUdThreshold.Value), currentAmount = Convert.ToInt32(numUdCurrentAmmount.Value);
                        Inventory.AddItem(stocks[iIndex].StockID, departments[dIndex].DepartmentId, threshold, currentAmount);
                        MessageBox.Show($"Successfully added item to department {departments[dIndex].Name}");
                        cbDepartmentAssignItem.SelectedIndex = -1;
                        cbItemAssignItem.SelectedIndex = -1;
                    }
                    else MessageBox.Show("This item already exists in this department.");
                }
                else MessageBox.Show("The threshold and the current amount of items can only be positive values.");
            }
            else MessageBox.Show("Please select an item and a department and try again.");
        }

        //Removing item from department

        private void cbItemRemoveFromDpt_DropDown(object sender, EventArgs e)
        {
            cbItemRemoveFromDpt.Items.Clear();
            UpdateStockList();
            foreach (StockItem stock in stocks) cbItemRemoveFromDpt.Items.Add(stock.Name);
        }

        private void cbDptRemoveFromDpt_DropDown(object sender, EventArgs e)
        {
            cbDptRemoveFromDpt.Items.Clear();
            UpdateDepartmentList();
            foreach (Department dep in departments) cbDptRemoveFromDpt.Items.Add(dep.Name);
        }

        private void btnRemoveItemFromDep_Click(object sender, EventArgs e)
        {
            if (cbDptRemoveFromDpt.SelectedIndex != -1 && cbItemRemoveFromDpt.SelectedIndex != -1)
            {
                int iIndex = cbItemRemoveFromDpt.SelectedIndex, dIndex = cbDptRemoveFromDpt.SelectedIndex;
                if (Inventory.Exists(stocks[iIndex].StockID, departments[dIndex].DepartmentId))
                {
                    Inventory.RemoveItem(stocks[iIndex].StockID, departments[dIndex].DepartmentId);
                    MessageBox.Show($"Successfully removed item from department {departments[dIndex].Name}");
                    cbDptRemoveFromDpt.SelectedIndex = -1;
                    cbItemRemoveFromDpt.SelectedIndex = -1;
                }
                else MessageBox.Show("Selected item is not part of this department.");
                
            }
            else MessageBox.Show("Please select an item and a department and try again.");
        }
    }
}
