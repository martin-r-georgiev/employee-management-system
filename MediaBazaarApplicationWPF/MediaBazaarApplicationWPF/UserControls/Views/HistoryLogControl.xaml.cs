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

namespace MediaBazaarApplicationWPF.UserControls.Views
{
    /// <summary>
    /// Interaction logic for HistoryLogControl.xaml
    /// </summary>
    public partial class HistoryLogControl : UserControl
    {
        private string employeeHistory;

        public string EmployeeHistory
        {
            get { return employeeHistory; }
            set { employeeHistory = value; lblHistory.Content = employeeHistory; }
        }

        public HistoryLogControl(string history)
        {
            InitializeComponent();
            this.EmployeeHistory = history;
        }
    }
}
