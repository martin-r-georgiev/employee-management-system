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
    public partial class Workshifts : Form
    {
        //Daily view
        DateTime selectedDate;
        //Weekly view
        DateTime startDate, endDate;

        string selectedDepartmentID;
        List<Department> departments;

        int panelState = 0;
        AutoWorkshift ScheduleGenerator = new AutoWorkshift();

        public Workshifts()
        {
            InitializeComponent();
            DoubleBuffered = true;
            ScheduleChecker();
            selectedDate = DateTime.Now;
            startDate = DateTimeControls.StartOfWeek(selectedDate, DayOfWeek.Monday);
            endDate = startDate.AddDays(6);
            lblDate.Text = $"{selectedDate.ToString("dddd, dd MMMM yyyy")} (Today)";
            lblDate.Text = $"{startDate.ToString("dd MMMM yyyy")} - {endDate.ToString("dd MMMM yyyy")}";
            WorkshiftUC.shiftOneStart = "9:00";
            WorkshiftUC.shiftTwoStart = "13:00";
            WorkshiftUC.shiftThreeStart = "17:00";
            WorkshiftUC.shiftThreeEnd = "21:00";
            selectedDepartmentID = LoggedInUser.departmentID;
            departments = new List<Department>();
            UpdateWeeklyWorkshiftPanel(selectedDate, selectedDepartmentID);
            UpdateDepartmentCombobox();
            UpdateRoleControls();
        }
        private void UpdateRoleControls()
        {
            if (LoggedInUser.role == Role.Worker)
            {
                lblDepartmentSelect.Visible = false;
                cmbDepartmentSelect.Visible = false;
            }
        }
        public void ScheduleChecker()
        {
            string message= ScheduleGenerator.GenerateAndUpload();
            if(message!="")
            {
                MessageBox.Show(message);
            }
        }
        void UpdateDailyWorkshiftPanel(DateTime time, string departmentID)
        {
            bool isHeader = true;
            flpWorkshifts.SuspendLayout();
            flpWorkshifts.Controls.Clear();
            List<WorkshiftUC> workshiftList = WorkshiftDatabaseHandler.GetEmployees(time, departmentID);
            foreach (WorkshiftUC control in workshiftList)
            {
                if (isHeader)
                {
                    control.ShowHeader();
                    isHeader = false;
                }
                flpWorkshifts.Controls.Add(control);
            }
            flpWorkshifts.Refresh();
            flpWorkshifts.ResumeLayout();
        }

        void UpdateWeeklyWorkshiftPanel(DateTime time, string departmentID)
        {
            bool isHeader = true;
            flpWorkshifts.SuspendLayout();
            flpWorkshifts.Controls.Clear();
            List<WorkshiftWeeklyUC> workshiftList = WorkshiftDatabaseHandler.GetWeeklyEmployees(time, departmentID);
            foreach (WorkshiftWeeklyUC control in workshiftList)
            {
                if (isHeader)
                {
                    control.ShowHeader();
                    isHeader = false;
                }
                flpWorkshifts.Controls.Add(control);
            }
            flpWorkshifts.Refresh();
            flpWorkshifts.ResumeLayout();
        }

        void UpdateDateText()
        {
            switch(panelState)
            {
                case 0: lblDate.Text = $"{startDate.ToString("dd MMMM yyyy")} - {endDate.ToString("dd MMMM yyyy")}"; break;
                case 1:
                    {
                        if (selectedDate.Date.Equals(DateTime.Now.Date)) lblDate.Text = $"{selectedDate.ToString("dddd, dd MMMM yyyy")} (Today)";
                        else lblDate.Text = selectedDate.ToString("dddd, dd MMMM yyyy");
                    }   break;
            }        
        }

        void UpdateDepartmentCombobox()
        {
            cmbDepartmentSelect.Items.Clear();
            departments = Department.GetAllDepartments();
            for (int i = 0; i < departments.Count; i ++)
            {
                cmbDepartmentSelect.Items.Add(departments[i].Name);
                if (departments[i].DepartmentId == selectedDepartmentID) cmbDepartmentSelect.SelectedIndex = i;
            }        
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Dashboard newScreen = new Dashboard();
            newScreen.Show();
            this.Close();
        }

        private void btnPreviousDay_Click(object sender, EventArgs e)
        {
            switch(panelState)
            {
                case 0:
                    {
                        startDate = startDate.AddDays(-7);
                        endDate = endDate.AddDays(-7);
                        UpdateWeeklyWorkshiftPanel(startDate, selectedDepartmentID);
                        UpdateDateText();
                    }   break;
                case 1:
                    {
                        selectedDate = selectedDate.AddDays(-1);
                        UpdateDailyWorkshiftPanel(selectedDate, selectedDepartmentID);
                        UpdateDateText();
                    }   break;
            }
        }

        private void btnNextDay_Click(object sender, EventArgs e)
        {
            switch (panelState)
            {
                case 0:
                    {
                        startDate = startDate.AddDays(7);
                        endDate = endDate.AddDays(7);
                        UpdateWeeklyWorkshiftPanel(startDate, selectedDepartmentID);
                        UpdateDateText();
                    }
                    break;
                case 1:
                    {
                        selectedDate = selectedDate.AddDays(1);
                        UpdateDailyWorkshiftPanel(selectedDate, selectedDepartmentID);
                        UpdateDateText();
                    }
                    break;
            }
        }

        private void btnToggleView_Click(object sender, EventArgs e)
        {
            switch (panelState)
            {
                case 0:
                    {
                        panelState = 1;
                        UpdateDateText();
                        UpdateDailyWorkshiftPanel(selectedDate, selectedDepartmentID);
                        
                        btnToggleView.Text = "Toggle Weekly view";
                    }
                    break;
                case 1:
                    {
                        panelState = 0;
                        UpdateDateText();
                        UpdateWeeklyWorkshiftPanel(selectedDate, selectedDepartmentID);
                        btnToggleView.Text = "Toggle Daily view";
                    }
                    break;
            }
        }

        private void cmbDepartmentSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbDepartmentSelect.SelectedIndex != -1 && departments.Count > cmbDepartmentSelect.SelectedIndex)
            {
                selectedDepartmentID = departments[cmbDepartmentSelect.SelectedIndex].DepartmentId;
                switch (panelState)
                {
                    case 0: UpdateWeeklyWorkshiftPanel(startDate, selectedDepartmentID); break;                    
                    case 1: UpdateDailyWorkshiftPanel(selectedDate, selectedDepartmentID); break;
                }
            }
        }

        private void checkWorkers_CheckedChanged(object sender, EventArgs e)
        {
            if(selectedDepartmentID != null)
            {
                WorkshiftFilters.ShowWorkers = checkWorkers.Checked;
                switch (panelState)
                {
                    case 0: UpdateWeeklyWorkshiftPanel(startDate, selectedDepartmentID); break;
                    case 1: UpdateDailyWorkshiftPanel(selectedDate, selectedDepartmentID); break;
                }
            }
        }

        private void checkAdmins_CheckedChanged(object sender, EventArgs e)
        {
            if (selectedDepartmentID != null)
            {
                WorkshiftFilters.ShowAdmins = checkAdmins.Checked;

                switch (panelState)
                {
                    case 0: UpdateWeeklyWorkshiftPanel(startDate, selectedDepartmentID); break;
                    case 1: UpdateDailyWorkshiftPanel(selectedDate, selectedDepartmentID); break;
                }
            }
        }

        private void checkManagers_CheckedChanged(object sender, EventArgs e)
        {
            if (selectedDepartmentID != null)
            {
                WorkshiftFilters.ShowManagers = checkManagers.Checked;
                switch (panelState)
                {
                    case 0: UpdateWeeklyWorkshiftPanel(startDate, selectedDepartmentID); break;
                    case 1: UpdateDailyWorkshiftPanel(selectedDate, selectedDepartmentID); break;
                }
            }
        }

        private void btnChangePreferences_Click(object sender, EventArgs e)
        {
            PreferencesNew fsd = new PreferencesNew();
            fsd.Show();
        }
    }
}
