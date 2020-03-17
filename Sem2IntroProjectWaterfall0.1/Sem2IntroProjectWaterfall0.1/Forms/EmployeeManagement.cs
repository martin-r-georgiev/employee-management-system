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
        public EmployeeManagement()
        {
            InitializeComponent();
            RefreshComboboxes();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Dashboard newScreen = new Dashboard();
            newScreen.Show();
            this.Close();
        }

        private void cmbHouseUnits_DropDown(object sender, EventArgs e)
        {

        }

        private void cbAdmin_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cbShowHide_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnAddNewTenant_Click(object sender, EventArgs e)
        {

        }

        private void btnRemoveUser_Click(object sender, EventArgs e)
        {

        }

        private void cmbUserList_DropDown(object sender, EventArgs e)
        {

        }

        private void btnAssignUser_Click(object sender, EventArgs e)
        {

        }

        private void cmbAssignUnitList_DropDown(object sender, EventArgs e)
        {

        }

        private void cmbAssignUserList_DropDown(object sender, EventArgs e)
        {

        }

        private void btnCreateNewDepartment_Click(object sender, EventArgs e)
        {
            try
            {
                Department newDepartment = new Department(tbDepartmentCreateName.Text, tbDepartmentCreateAddress.Text);
            } catch (Exception exc) { MessageBox.Show(exc.Message); }
            }

        void RefreshComboboxes()
        {
            List<Employee> allEmployees = Employee.GetAllEmployees();
            List<Department> allDepartments = Department.GetAllDepartments();

            cbEmployeeAssign.Items.Clear();
            cbDepartmentAssign.Items.Clear();
            cbDepartmentEdit.Items.Clear();
            cbDepartmentRemove.Items.Clear();

            cbEmployeeAssign.DataSource = allEmployees;
            cbEmployeeAssign.DisplayMember = "MainDetails";
            cbDepartmentAssign.DataSource = allDepartments;
            cbDepartmentAssign.DisplayMember = "Name";
            cbDepartmentEdit.DataSource = allDepartments;
            cbDepartmentEdit.DisplayMember = "Name";
            cbDepartmentRemove.DataSource = allDepartments;
            cbDepartmentRemove.DisplayMember = "Name";
        }

        private void btnAssignEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                Employee selectedUser = (Employee)cbEmployeeAssign.SelectedItem;
                Department selectedDepartment = (Department)cbDepartmentAssign.SelectedItem;
                Department.AssignEmployeeTo(selectedUser.UserID, selectedDepartment.DepartmentId);
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
                }
            }
            catch (Exception exc) { MessageBox.Show(exc.Message); }
        }

        private void btnDepartmentRemove_Click(object sender, EventArgs e)
        {
            try
            {
                Department selectedDepartment = (Department)cbDepartmentEdit.SelectedItem;
                selectedDepartment.RemoveFromDatabase();
            }
            catch (Exception exc) { MessageBox.Show(exc.Message); }
        }
    }
}
