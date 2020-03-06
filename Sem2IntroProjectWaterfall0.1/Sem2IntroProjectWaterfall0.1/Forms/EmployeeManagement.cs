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
    }
}
