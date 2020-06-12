using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MediaBazaarApplicationWPF.UserControls
{
    /// <summary>
    /// Interaction logic for WeeklyWorkshift.xaml
    /// </summary>
    public partial class WeeklyWorkshift : UserControl
    {
        Dictionary<string, WorkshiftsManager> manager;
        private Employee employee;
        private readonly DateTime startDate;
        private readonly DateTime endDate;

        public Employee Employee => this.employee;

        public DateTime StartDate => this.startDate;
        public DateTime EndDate => this.endDate;

        public WeeklyWorkshift(Employee employee, DateTime start, DateTime end)
        {
            InitializeComponent();
            this.employee = employee;
            this.startDate = start;
            this.endDate = end;

            this.lblEmployeeName.Text = Employee.FullName;

            manager = new Dictionary<string, WorkshiftsManager>();

            for (DateTime date = start; date <= end; date = date.AddDays(1))
            {
                manager.Add(date.DayOfWeek.ToString(), new WorkshiftsManager(date, this.employee.UserID));
                MarkIfToday(date);
            }

            lblMondayDate.Text = manager["Monday"].Date.ToString("dd");
            manager["Monday"].SetWorkshiftPanels(cellOneMonday, cellTwoMonday, cellThreeMonday);
            lblTuesdayDate.Text = manager["Tuesday"].Date.ToString("dd");
            manager["Tuesday"].SetWorkshiftPanels(cellOneTuesday, cellTwoTuesday, cellThreeTuesday);
            lblWednesdayDate.Text = manager["Wednesday"].Date.ToString("dd");
            manager["Wednesday"].SetWorkshiftPanels(cellOneWednesday, cellTwoWednesday, cellThreeWednesday);
            lblThursdayDate.Text = manager["Thursday"].Date.ToString("dd");
            manager["Thursday"].SetWorkshiftPanels(cellOneThursday, cellTwoThursday, cellThreeThursday);
            lblFridayDate.Text = manager["Friday"].Date.ToString("dd");
            manager["Friday"].SetWorkshiftPanels(cellOneFriday, cellTwoFriday, cellThreeFriday);
            lblSaturdayDate.Text = manager["Saturday"].Date.ToString("dd");
            manager["Saturday"].SetWorkshiftPanels(cellOneSaturday, cellTwoSaturday, cellThreeSaturday);
            lblSundayDate.Text = manager["Sunday"].Date.ToString("dd");
            manager["Sunday"].SetWorkshiftPanels(cellOneSunday, cellTwoSunday, cellThreeSunday);
        }

        public void ShowHeader()
        {
            this.headerDateRow.Height = new GridLength(0, GridUnitType.Auto);
            this.headerWeekdayRow.Height = new GridLength(0, GridUnitType.Auto);
            this.headerWorkshiftRow.Height = new GridLength(0, GridUnitType.Auto);
        }

        private void MarkIfToday(DateTime date)
        {
            if (DateTime.Now.Date.Equals(date))
            {
                SolidColorBrush brush = new SolidColorBrush(Colors.LimeGreen);

                switch ((int)date.DayOfWeek)
                {
                    case 0: lblSundayDate.Foreground = lblSundayWeekday.Foreground = brush; break;
                    case 1: lblMondayDate.Foreground = lblMondayWeekday.Foreground = brush; break;
                    case 2: lblTuesdayDate.Foreground = lblTuesdayWeekday.Foreground = brush; break;
                    case 3: lblWednesdayDate.Foreground = lblWednesdayWeekday.Foreground = brush; break;
                    case 4: lblThursdayDate.Foreground = lblThursdayWeekday.Foreground = brush; break;
                    case 5: lblFridayDate.Foreground = lblFridayWeekday.Foreground = brush; break;
                    case 6: lblSaturdayDate.Foreground = lblSaturdayWeekday.Foreground = brush; break;
                }
            }
        }

        public void SetStatus(DayOfWeek weekday, int status, int index) { manager[weekday.ToString()].SetStatus(status, index); }

        private void WeeklyWorkshift_MouseEnter(object sender, MouseEventArgs e)
        {
            this.WorkshiftGrid.Fill = new SolidColorBrush(Colors.WhiteSmoke);
        }

        private void WeeklyWorkshift_MouseLeave(object sender, MouseEventArgs e)
        {
            this.WorkshiftGrid.Fill = new SolidColorBrush(Colors.White);
        }
    }
}
