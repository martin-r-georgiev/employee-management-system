using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sem2IntroProjectWaterfall0._1
{
    public partial class WorkshiftWeeklyUC : UserControl
    {
        private Employee employee;
        private int?[] statusIndex;
        private List<WorkshiftCells> workshiftCells;

        private DateTime startDate, endDate;

        public DateTime StartDate
        {
            get { return this.startDate; }
        }

        public DateTime EndDate
        {
            get { return this.endDate; }
        }

        public Employee Employee
        {
            get { return this.employee; }
        }

        public WorkshiftWeeklyUC(Employee employee, DateTime start, DateTime end)
        {
            InitializeComponent();
            this.employee = employee;
            this.startDate = start;
            this.endDate = end;
            lblName.Text = employee.Name;
            statusIndex = new int?[21];
            workshiftCells = new List<WorkshiftCells>();
            DateTime date_iterator = start;
            for(int i = 0; i < 7; i++)
            {
                WorkshiftCells newCell = new WorkshiftCells();
                switch (i)
                {
                    case 0: workshiftCells.Add(newCell); panelMonday.Controls.Add(newCell); lblMondayDate.Text = date_iterator.ToString("dd"); break;
                    case 1: workshiftCells.Add(newCell); panelTuesday.Controls.Add(newCell); lblTuesdayDate.Text = date_iterator.ToString("dd"); break;
                    case 2: workshiftCells.Add(newCell); panelWednesday.Controls.Add(newCell); lblWednesdayDate.Text = date_iterator.ToString("dd"); break;
                    case 3: workshiftCells.Add(newCell); panelThursday.Controls.Add(newCell); lblThursdayDate.Text = date_iterator.ToString("dd"); break;
                    case 4: workshiftCells.Add(newCell); panelFriday.Controls.Add(newCell); lblFridayDate.Text = date_iterator.ToString("dd"); break;
                    case 5: workshiftCells.Add(newCell); panelSaturday.Controls.Add(newCell); lblSaturdayDate.Text = date_iterator.ToString("dd"); break;
                    case 6: workshiftCells.Add(newCell); panelSunday.Controls.Add(newCell); lblSundayDate.Text = date_iterator.ToString("dd"); break;
                }
                IsToday(date_iterator);
                date_iterator = date_iterator.AddDays(1);
            }
        }

        public void SetStatus(DayOfWeek weekday, int status, int index)
        {
            if (index < statusIndex.Length && index >= 0)
            {
                switch ((int)weekday)
                {
                    case 0: workshiftCells[0].SetStatus(status, index); statusIndex[(int)weekday + index] = status; break;
                    case 1: workshiftCells[1].SetStatus(status, index); statusIndex[(int)weekday + index] = status; break;
                    case 2: workshiftCells[2].SetStatus(status, index); statusIndex[(int)weekday + index] = status; break;
                    case 3: workshiftCells[3].SetStatus(status, index); statusIndex[(int)weekday + index] = status; break;
                    case 4: workshiftCells[4].SetStatus(status, index); statusIndex[(int)weekday + index] = status; break;
                    case 5: workshiftCells[5].SetStatus(status, index); statusIndex[(int)weekday + index] = status; break;
                    case 6: workshiftCells[6].SetStatus(status, index); statusIndex[(int)weekday + index] = status; break;
                }
            }
        }

        public void ShowHeader()
        {
            panelHeader.Visible = true;
        }

        private void IsToday(DateTime time)
        {
            if(DateTime.Now.Date.Equals(time))
            {
                switch((int) DateTimeControls.StartOfWeek(time, DayOfWeek.Monday).DayOfWeek)
                {
                    case 0: lblMonday.ForeColor = lblMondayDate.ForeColor = Color.LimeGreen; break;
                    case 1: lblTuesday.ForeColor = lblTuesdayDate.ForeColor = Color.LimeGreen; break;
                    case 2: lblWednesday.ForeColor = lblWednesdayDate.ForeColor = Color.LimeGreen; break;
                    case 3: lblThursday.ForeColor = lblThursdayDate.ForeColor = Color.LimeGreen; break;
                    case 4: lblFriday.ForeColor = lblFridayDate.ForeColor = Color.LimeGreen; break;
                    case 5: lblSaturday.ForeColor = lblSaturdayDate.ForeColor = Color.LimeGreen; break;
                    case 6: lblSunday.ForeColor = lblSundayDate.ForeColor = Color.LimeGreen; break;
                }
            }
        }
    }
}
