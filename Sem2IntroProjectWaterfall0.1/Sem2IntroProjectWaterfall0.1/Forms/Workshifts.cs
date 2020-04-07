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
        DateTime selectedDate;

        public Workshifts()
        {
            InitializeComponent();
            selectedDate = DateTime.Now;
            lblDate.Text = $"{selectedDate.ToString("dddd, dd MMMM yyyy")} (Today)";
            WorkshiftUC.shiftOneStart = "9:00";
            WorkshiftUC.shiftTwoStart = "13:00";
            WorkshiftUC.shiftThreeStart = "17:00";
            WorkshiftUC.shiftThreeEnd = "21:00";
            //UpdateWorkshiftPanel(selectedDate);
            UpdateWeeklyWorkshiftPanel(selectedDate);
        }

        void UpdateWorkshiftPanel(DateTime time)
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
            if (selectedDate.Date.Equals(DateTime.Now.Date)) lblDate.Text = $"{selectedDate.ToString("dddd, dd MMMM yyyy")} (Today)";
            else lblDate.Text = selectedDate.ToString("dddd, dd MMMM yyyy");
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Dashboard newScreen = new Dashboard();
            newScreen.Show();
            this.Close();
        }

        private void btnPreviousDay_Click(object sender, EventArgs e)
        {
            selectedDate = selectedDate.AddDays(-1);
            UpdateWorkshiftPanel(selectedDate);
            UpdateDateText();
        }

        private void btnNextDay_Click(object sender, EventArgs e)
        {
            selectedDate = selectedDate.AddDays(1);
            UpdateWorkshiftPanel(selectedDate);
            UpdateDateText();
        }
        
       
    }
}
