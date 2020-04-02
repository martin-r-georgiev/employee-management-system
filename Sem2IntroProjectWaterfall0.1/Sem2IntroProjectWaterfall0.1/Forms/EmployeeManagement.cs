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
                    if (hourlySalary < 0) { MessageBox.Show("Please enter a positive salary"); return; }
                    if (cbDepartments.SelectedIndex == -1) { MessageBox.Show("Please select a department and try again."); return; }
                    if (cbRole.SelectedIndex == -1) { MessageBox.Show("Please select a role and try again."); return; }
                    if (!Employee.IsUniqueUsername(tbUsername.Text)) { MessageBox.Show("Username is taken. Please choose another and try again."); return; }
                    try
                    {
                        Employee newEmployee = new Employee(tbUsername.Text, tbPassword.Text, hourlySalary, (Role)cbRole.SelectedIndex, departments[cbDepartments.SelectedIndex].DepartmentId);
                        MessageBox.Show("Sucessfully added new employee to the system!");
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
        private void btnAssignEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                Employee selectedUser = employees[cbEmployeeAssign.SelectedIndex];
                Department selectedDepartment = departments[cbDepartmentEdit.SelectedIndex];
                Department oldDepartment = new Department(selectedUser.DepartmentID);
                oldDepartment.AssignEmployeeTo(selectedUser.UserID, selectedDepartment.DepartmentId);
            } catch (Exception exc) { MessageBox.Show(exc.Message); }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (rbCreate.Checked)
            {
                if (checkforwhitespace(tbDepartmentEditName.Text))
                {
                    try
                    {
                        Department newDepartment = new Department(tbDepartmentEditName.Text, tbDepartmentEditAddress.Text);
                        tbDepartmentEditAddress.Clear();
                        tbDepartmentEditName.Clear();
                    }
                    catch (Exception exc) { MessageBox.Show(exc.Message); }
                }
                else
                {
                    MessageBox.Show("Please enter a valid name, adress");
                }
            }
            else if (rbModify.Checked)
            {
                try
                {
                    if (tbDepartmentEditAddress.TextLength > 0 && tbDepartmentEditName.TextLength > 0)
                    {
                        Department selectedDepartment = departments[cbDepartmentEdit.SelectedIndex];
                        selectedDepartment.Address = tbDepartmentEditAddress.Text;
                        selectedDepartment.Name = tbDepartmentEditName.Text;
                        tbDepartmentEditAddress.Clear();
                        tbDepartmentEditName.Clear();
                    }
                }
                catch (Exception exc) { MessageBox.Show(exc.Message); }
            }
        }

        private void btnDepartmentRemove_Click(object sender, EventArgs e)
        {
            try
            {
                Department selectedDepartment = departments[cbDepartmentEdit.SelectedIndex];
                selectedDepartment.RemoveFromDatabase();
            }
            catch (MinimalEmployeesException ex) { MessageBox.Show(ex.Message); }
            catch (Exception exc) { MessageBox.Show(exc.Message); }
        }


        private void cbEmployeeList_DropDown(object sender, EventArgs e)
        {

        }

        private void cbDepartmentList_DropDown(object sender, EventArgs e)
        {

        }

        private void btnRemoveEmployee_Click(object sender, EventArgs e)
        {
            if (cbPersonalInfoList.SelectedIndex != -1)
            {
                try
                {
                    int index = cbPersonalInfoList.SelectedIndex;
                    employees[index].RemoveFromDatabase();
                    employees.RemoveAt(index);
                    MessageBox.Show($"Employee successfully removed from the system.");
                    cbPersonalInfoList.SelectedIndex = -1;
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
            foreach (Employee employee in employees) { cbPersonalInfoList.Items.Add($"{employee.MainDetails}"); }
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
                Department selectedDepartment = departments[cbDepartmentEdit.SelectedIndex];
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


        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            if (!cbRemoveCompletely.Checked)
            {
                if (cbDepartmentAssignItem.SelectedIndex != -1 && cbItemAssignItem.SelectedIndex != -1)
                {
                    int iIndex = cbItemAssignItem.SelectedIndex, dIndex = cbDepartmentAssignItem.SelectedIndex;
                    if (Inventory.Exists(stocks[iIndex].StockID, departments[dIndex].DepartmentId))
                    {
                        Inventory.RemoveItem(stocks[iIndex].StockID, departments[dIndex].DepartmentId);
                        MessageBox.Show($"Successfully removed item from department {departments[dIndex].Name}");
                        cbDepartmentAssignItem.SelectedIndex = -1;
                        cbItemAssignItem.SelectedIndex = -1;
                    }
                    else MessageBox.Show("Selected item is not part of this department.");
                }
                else MessageBox.Show("Please select an item and a department and try again.");
            }
            else
            {
                if (cbItemAssignItem.SelectedIndex != -1)
                {
                    foreach (StockItem stock in stocks)
                    {
                        if (stock.Name == cbItemAssignItem.SelectedItem.ToString())
                        {
                            Inventory.RemoveItemGlobal(stock.StockID);
                            MessageBox.Show("Successfully removed item from system.");
                            cbItemAssignItem.SelectedIndex = -1;
                            break;
                        }
                    }
                }
                else MessageBox.Show("Select an item to be deleted");
            }
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

        private void cbPassVisible_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPassVisible.Checked) tbPassword.UseSystemPasswordChar = false;
            else tbPassword.UseSystemPasswordChar = true;
        }

        private void rbCreate_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCreate.Checked)
            {
                ChangeDepartmentEditMode(true);
                ClearDepartmentTextboxes();
            }
            else if (rbModify.Checked)
            {
                ChangeDepartmentEditMode(false);
                ClearDepartmentTextboxes();

            }
        }
        private void ChangeDepartmentEditMode(bool isCreateMode)
        {
            lblEditDep.Visible = !isCreateMode;
            cbDepartmentEdit.Visible = !isCreateMode;
            pnlAssignEmployee1.Visible = !isCreateMode;
            pnlAssignEmployee2.Visible = !isCreateMode;
            lblEmployeeAssign.Visible = !isCreateMode;
            cbEmployeeAssign.Visible = !isCreateMode;
            btnAssignEmployee.Visible = !isCreateMode;
            btnDepartmentRemove.Visible = !isCreateMode;
            lblEmployeeMove.Visible = !isCreateMode;
            if (isCreateMode)
            {
                btnEdit.Location = new Point(82, 235);
                btnEdit.Size = new Size(176, 30);
                tbDepartmentEditName.Location = new Point(82, 54);
                tbDepartmentEditAddress.Location = new Point(82, 89);
                lblEditName.Location = new Point(13, 56);
                lblEditAddress.Location = new Point(13, 91);
            } else
            {
                btnEdit.Location = new Point(173, 339);
                btnEdit.Size = new Size(85, 43);
                tbDepartmentEditName.Location = new Point(82,89);
                tbDepartmentEditAddress.Location = new Point(82,121);
                lblEditName.Location = new Point(13,91);
                lblEditAddress.Location = new Point(13, 123);
            }
        }
        void ClearDepartmentTextboxes()
        {
            tbDepartmentEditName.Clear();
            tbDepartmentEditAddress.Clear();
        }

        private void cbDepartmentEdit_DropDown(object sender, EventArgs e)
        {
            cbDepartmentEdit.Items.Clear();
            UpdateDepartmentList();
            foreach (Department department in departments) cbDepartmentEdit.Items.Add(department.Name);
        }

        private void cbEmployeeAssign_DropDown(object sender, EventArgs e)
        {
            cbEmployeeAssign.Items.Clear();
            UpdateEmployeeList();
            foreach (Employee emp in employees) cbEmployeeAssign.Items.Add(emp.MainDetails);
        }

        private void tcManagement_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcManagement.SelectedIndex == 1) { rbCreate.Checked = true; rbAdd.Checked = true; }
        }

        private void rbAdd_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAdd.Checked)
            {
                ChangeStockEditMode(true);
            } else if (rbRemove.Checked)
            {
                ChangeStockEditMode(false);
            }
        }
        void ChangeStockEditMode(bool isAddMode)
        {
            cbRemoveCompletely.Visible = !isAddMode;
            btnRemoveItem.Visible = !isAddMode;
            lblAddDepCAmount.Visible = isAddMode;
            lblAddDepThreshold.Visible = isAddMode;
            numUdCurrentAmmount.Visible = isAddMode;
            numUdThreshold.Visible = isAddMode;
            btnAssignItemToDepartment.Visible = isAddMode;
            
            if (isAddMode)
            {
                btnAssignItemToDepartment.Size = new Size(256, 24);
            } else
            {
                btnRemoveItem.Location = new Point(13, 280);
                btnRemoveItem.Size = new Size(256, 24);
            }
        }

        private void cbRemoveCompletely_CheckedChanged(object sender, EventArgs e)
        {
            cbDepartmentAssignItem.Enabled = !cbRemoveCompletely.Checked;
        }
    }
}
