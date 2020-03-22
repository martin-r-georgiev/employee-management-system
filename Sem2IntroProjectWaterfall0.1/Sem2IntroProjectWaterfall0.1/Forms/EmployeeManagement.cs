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
        private List<StockItem> stonks;
        private List<Inventory> inventories = new List<Inventory>();
        public EmployeeManagement()
        {
            InitializeComponent();
            RefreshComboboxes();
            employees = Employee.GetAllEmployees();
            departments = Department.GetAllDepartments();
            //stonks = Inventory.ListAllItemsFromStockItem(); // might cause crash but it might be servers comment out in case it crashes
            UpdateInventoryList();
        }

        private void UpdateDepartmentList() { departments = Department.GetAllDepartments(); }
        private void UpdateEmployeeList() { employees = Employee.GetAllEmployees(); }

        private void UpdateStockList() { stonks = Inventory.ListAllItemsFromStockItem(); }

        private void UpdateInventoryList()
        {
            int i = 0;
            foreach (Department dep in departments)
            {
                if (i < inventories.Count())
                {
                    if (!(inventories[i].DepartmentId == dep.DepartmentId) && (departments.Count() > inventories.Count()))
                    {
                        Inventory toadd = new Inventory(dep.DepartmentId);
                        inventories.Add(toadd);
                    }
                }
                else
                {
                    Inventory toadd = new Inventory(dep.DepartmentId);
                    inventories.Add(toadd);
                }

                i++;



            }
        }

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

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbUsername.Text) || string.IsNullOrEmpty(tbPassword.Text) || string.IsNullOrEmpty(tbHourlySalary.Text))
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

        private void btnCreateNewStock_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbStockCreateName.Text))
            { StockItem stockItem = new StockItem(tbStockCreateName.Text); }
            else
                MessageBox.Show("Enter a name for the stock!");
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            if (cbRemoveItem.SelectedIndex > 0)
            {
                foreach (StockItem stock in stonks)
                {
                    if (stock.Name == cbRemoveItem.SelectedItem.ToString())
                    {
                        Inventory.RemoveItemGlobal(stock);// static method to be used to remove items from both tables
                        break;
                    }
                }

            }
            else
            {
                MessageBox.Show("Select an item to be deleted");
            }
        }

        private StockItem GetStockItemByName(string name)
        {
            foreach (StockItem stock in stonks)
            {
                if (stock.Name == name)
                {
                    return stock;
                }
            }
            StockItem error = new StockItem("ERROR"); // shouldnt reach this code
            return error;
        }

        private Department GetDepartmentByName(string name)
        {
            foreach (Department dep in departments)
            {
                if (dep.Name == name)
                {
                    return dep;
                }
            }
            Department error = new Department("ERROR"); // shouldnt reach this code
            return error;
        }

        private int GetDepartmentIndexInInventory(string departmentID)
        {
            int i = 0;
            foreach (Inventory inv in inventories)
            {
                if (inv.DepartmentId == departmentID)
                {
                    return i;
                }
                i++;

            }
            return -1;
        }
        private string GetDepIDByName(string name)
        {
            foreach (Department dep in departments)
            {
                if (name == dep.Name)
                {
                    return dep.DepartmentId;
                }
               

            }
            return "error";
        }



            


        private void btnAssignItemToDepartment_Click(object sender, EventArgs e)
        {
            if (!(numUdCurrentAmmount.Value == 0 || cbDepartmentAssignItem.SelectedIndex < 0 || cbItemAssignItem.SelectedIndex<0)) // idk if they should be 0
            {
                string item = cbItemAssignItem.Text;
                string departmentname = cbDepartmentAssignItem.Text;
                string departmentid = GetDepIDByName(departmentname);
                int indexInInventory = GetDepartmentIndexInInventory(departmentid);
                //Department DepToAssignTo = GetDepartmentByName(department); 
                StockItem ItemToAssign = GetStockItemByName(item);
                if (Inventory.IsItemThere(ItemToAssign.StockID, departmentid))
                {
                    inventories[indexInInventory].AddItem(ItemToAssign, Convert.ToInt32(numUdThreshold.Value), Convert.ToInt32(numUdCurrentAmmount.Value));
                }
                else
                {
                    MessageBox.Show("Item already assigd");
                }

            }
            else
            {
                MessageBox.Show("Please select values");
            }
        }

        private void cbRemoveItem_DropDown(object sender, EventArgs e)
        {
            cbRemoveItem.Items.Clear();
            UpdateStockList();
            foreach (StockItem stock in stonks)
            { cbRemoveItem.Items.Add(stock.Name); }
        }

        private void cbItemAssignItem_DropDown(object sender, EventArgs e)
        {
            cbItemAssignItem.Items.Clear();
            UpdateStockList();
            foreach (StockItem stock in stonks)
            { cbItemAssignItem.Items.Add(stock.Name); }
        }

        private void cbDepartmentAssignItem_DropDown(object sender, EventArgs e)
        {
            cbDepartmentAssignItem.Items.Clear();
            UpdateDepartmentList();
            foreach (Department dep in departments)
            { cbDepartmentAssignItem.Items.Add(dep.Name); }
        }
        public static void ItemAlreadyAdded()
        {
            MessageBox.Show("The item is already in the department");
        }

        private void cbItemRemoveFromDpt_DropDown(object sender, EventArgs e)
        {
            cbItemRemoveFromDpt.Items.Clear();
            UpdateStockList();
            foreach (StockItem stock in stonks)
            { cbItemRemoveFromDpt.Items.Add(stock.Name); }
        }

        private void cbDptRemoveFromDpt_DropDown(object sender, EventArgs e)
        {
            cbDptRemoveFromDpt.Items.Clear();
            UpdateDepartmentList();
            foreach (Department dep in departments)
            { cbDptRemoveFromDpt.Items.Add(dep.Name); }
        }

        private void button1_Click(object sender, EventArgs e) 
        {
            if(cbDptRemoveFromDpt.SelectedIndex>0 && cbItemRemoveFromDpt.SelectedIndex>0)
            {
               
                string item = cbItemRemoveFromDpt.Text;
                string departmentname = cbDptRemoveFromDpt.Text;
                string departmentid = GetDepIDByName(departmentname);
                int indexInInventory = GetDepartmentIndexInInventory(departmentid);
                //Department DepToAssignTo = GetDepartmentByName(department); 
                StockItem ItemToAssign = GetStockItemByName(item);
                if (!Inventory.IsItemThere(ItemToAssign.StockID, departmentid))
                {
                    inventories[indexInInventory].RemoveItem(ItemToAssign);
                }
                else
                {
                    MessageBox.Show("Item doesnt exist");
                }
            }
            else
            {
                MessageBox.Show("Please select an item");
            }
        }
    }
}
