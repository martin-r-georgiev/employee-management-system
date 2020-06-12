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
    /// Interaction logic for DailyWorkshift.xaml
    /// </summary>
    public partial class DailyWorkshift : UserControl
    {
        private WorkshiftsManager manager;
        private Employee employee;
        private readonly DateTime date;

        public Employee Employee => this.employee;
        public DateTime Date => this.date;

        public DailyWorkshift(Employee employee, DateTime date)
        {
            InitializeComponent();
            this.employee = employee;
            this.date = date;
            manager = new WorkshiftsManager(this.Date, Employee.UserID);
            manager.SetWorkshiftPanels(workshiftOneCell, workshiftTwoCell, workshiftThreeCell);

            this.lblEmployeeName.Text = Employee.FullName;
        }

        public void ShowHeader()
        {
            this.headerRow.Height = new GridLength(0, GridUnitType.Auto);
        }

        public void SetStatus(int status, int index) { manager.SetStatus(status, index); }
    }
}
