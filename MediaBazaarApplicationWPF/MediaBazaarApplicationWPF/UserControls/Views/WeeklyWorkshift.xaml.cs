using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

            for (DateTime date = start; date <= end; date = date.AddDays(1))
            {
                switch (date.DayOfWeek)
                {
                    case DayOfWeek.Monday: this.workshiftMonday.Initialize(this.Employee, date); lblMondayDate.Text = date.ToString("dd"); break;
                    case DayOfWeek.Tuesday: this.workshiftTuesday.Initialize(this.Employee, date); lblTuesdayDate.Text = date.ToString("dd"); break;
                    case DayOfWeek.Wednesday: this.workshiftWednesday.Initialize(this.Employee, date); lblWednesdayDate.Text = date.ToString("dd"); break;
                    case DayOfWeek.Thursday: this.workshiftThursday.Initialize(this.Employee, date); lblThursdayDate.Text = date.ToString("dd"); break;
                    case DayOfWeek.Friday: this.workshiftFriday.Initialize(this.Employee, date); lblFridayDate.Text = date.ToString("dd"); break;
                    case DayOfWeek.Saturday: this.workshiftSaturday.Initialize(this.Employee, date); lblSaturdayDate.Text = date.ToString("dd"); break;
                    case DayOfWeek.Sunday: this.workshiftSunday.Initialize(this.Employee, date); lblSundayDate.Text = date.ToString("dd"); break;
                }
                MarkIfToday(date);
            }
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

                switch (date.DayOfWeek)
                {
                    case DayOfWeek.Monday: lblMondayDate.Foreground = lblMondayWeekday.Foreground = brush; break;
                    case DayOfWeek.Tuesday: lblTuesdayDate.Foreground = lblTuesdayWeekday.Foreground = brush; break;
                    case DayOfWeek.Wednesday: lblWednesdayDate.Foreground = lblWednesdayWeekday.Foreground = brush; break;
                    case DayOfWeek.Thursday: lblThursdayDate.Foreground = lblThursdayWeekday.Foreground = brush; break;
                    case DayOfWeek.Friday: lblFridayDate.Foreground = lblFridayWeekday.Foreground = brush; break;
                    case DayOfWeek.Saturday: lblSaturdayDate.Foreground = lblSaturdayWeekday.Foreground = brush; break;
                    case DayOfWeek.Sunday: lblSundayDate.Foreground = lblSundayWeekday.Foreground = brush; break;
                }
            }
        }

        public void SetStatus(DayOfWeek weekday, int status, int index)
        {
            switch (weekday)
            {
                case DayOfWeek.Monday: this.workshiftMonday.SetStatus(status, index); break;
                case DayOfWeek.Tuesday: this.workshiftTuesday.SetStatus(status, index); break;
                case DayOfWeek.Wednesday: this.workshiftWednesday.SetStatus(status, index); break;
                case DayOfWeek.Thursday: this.workshiftThursday.SetStatus(status, index); break;
                case DayOfWeek.Friday: this.workshiftFriday.SetStatus(status, index); break;
                case DayOfWeek.Saturday: this.workshiftSaturday.SetStatus(status, index); break;
                case DayOfWeek.Sunday: this.workshiftSunday.SetStatus(status, index); break;
            }
        }

        private void WeeklyWorkshift_MouseEnter(object sender, MouseEventArgs e) => this.WorkshiftGrid.Fill = new SolidColorBrush(Colors.WhiteSmoke);
        private void WeeklyWorkshift_MouseLeave(object sender, MouseEventArgs e)
        {
            SolidColorBrush fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#e9e9e9"));
            fill.Opacity = 0.2;
            this.WorkshiftGrid.Fill = fill;
        }
    }
}
