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

        int panelState = 0;
        AutoWorkshift ScheduleGenerator = new AutoWorkshift();

        public Workshifts()
        {
            InitializeComponent();
            selectedDate = DateTime.Now;
            startDate = DateTimeControls.StartOfWeek(selectedDate, DayOfWeek.Monday);
            endDate = startDate.AddDays(6);
            lblDate.Text = $"{selectedDate.ToString("dddd, dd MMMM yyyy")} (Today)";
            lblDate.Text = $"{startDate.ToString("dd MMMM yyyy")} - {endDate.ToString("dd MMMM yyyy")}";
            WorkshiftUC.shiftOneStart = "9:00";
            WorkshiftUC.shiftTwoStart = "13:00";
            WorkshiftUC.shiftThreeStart = "17:00";
            WorkshiftUC.shiftThreeEnd = "21:00";
            UpdateWeeklyWorkshiftPanel(selectedDate);
            ScheduleChecker();  
            
        }
        public void ScheduleChecker()
        {
            string message= ScheduleGenerator.GenerateAndUpload();
            if(message!="")
            {
                MessageBox.Show(message);
            }
        }
        void UpdateDailyWorkshiftPanel(DateTime time)
        {
            bool isHeader = true;
            flpWorkshifts.Controls.Clear();
            List<WorkshiftUC> workshiftList = WorkshiftDatabaseHandler.GetEmployees(time);
            foreach (WorkshiftUC control in workshiftList)
            {
                if (isHeader)
                {
                    control.ShowHeader();
                    isHeader = false;
                }
                flpWorkshifts.Controls.Add(control);
            }
        }

        void UpdateWeeklyWorkshiftPanel(DateTime time)
        {
            bool isHeader = true;
            flpWorkshifts.Controls.Clear();
            List<WorkshiftWeeklyUC> workshiftList = WorkshiftDatabaseHandler.GetWeeklyEmployees(time);
            foreach (WorkshiftWeeklyUC control in workshiftList)
            {
                if (isHeader)
                {
                    control.ShowHeader();
                    isHeader = false;
                }
                flpWorkshifts.Controls.Add(control);
            }
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
                        UpdateWeeklyWorkshiftPanel(startDate);
                        UpdateDateText();
                    }   break;
                case 1:
                    {
                        selectedDate = selectedDate.AddDays(-1);
                        UpdateDailyWorkshiftPanel(selectedDate);
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
                        UpdateWeeklyWorkshiftPanel(startDate);
                        UpdateDateText();
                    }
                    break;
                case 1:
                    {
                        selectedDate = selectedDate.AddDays(1);
                        UpdateDailyWorkshiftPanel(selectedDate);
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
                        UpdateDailyWorkshiftPanel(selectedDate);
                        
                        btnToggleView.Text = "Toggle Weekly view";
                    }
                    break;
                case 1:
                    {
                        panelState = 0;
                        UpdateDateText();
                        UpdateWeeklyWorkshiftPanel(selectedDate);
                        btnToggleView.Text = "Toggle Daily view";
                    }
                    break;
            }
        }

        private void btnChangePreferences_Click(object sender, EventArgs e)
        {
            PreferencesNew fsd = new PreferencesNew();
            fsd.Show();
        }
    }
}
