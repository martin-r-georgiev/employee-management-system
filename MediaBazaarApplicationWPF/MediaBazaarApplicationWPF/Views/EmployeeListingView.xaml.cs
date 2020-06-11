using MediaBazaarApplicationWPF.ViewModels;
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
using System.Windows.Shapes;

namespace MediaBazaarApplicationWPF.Views
{
    /// <summary>
    /// Interaction logic for EmployeeListingView.xaml
    /// </summary>
    public partial class EmployeeListingView : Window
    {
        public EmployeeListingView()
        {
            InitializeComponent();
            var ViewModel = new EmployeeListingViewModel();
            DataContext = ViewModel;
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            var DashboardView = new DashboardView();
            DashboardView.Show();
            this.Close();
        }

        private void BtnHistory_Click(object sender, RoutedEventArgs e)
        {
            var HistoryLogView = new HistoryLogView();
            HistoryLogView.Show();
        }
    }
}
