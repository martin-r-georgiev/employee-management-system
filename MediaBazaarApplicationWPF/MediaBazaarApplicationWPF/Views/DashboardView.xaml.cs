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
    /// Interaction logic for DashboardView.xaml
    /// </summary>
    public partial class DashboardView : Window
    {
        public DashboardView()
        {
            var ViewModel = new DashboardViewModel();
            DataContext = ViewModel;
            InitializeComponent();
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            var LoginView = new LoginView();
            LoginView.Show();
            this.Close();
        }

        private void StockButton_Click(object sender, RoutedEventArgs e)
        {
            var StockView = new StockView();
            StockView.Show();
            this.Close();
        }

        private void WorkshiftsButton_Click(object sender, RoutedEventArgs e)
        {
            var WorkshiftsView = new WorkshiftsView();
            WorkshiftsView.Show();
            //this.Close();
        }

        private void StatisticsButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ManagementButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RequestsButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.RequestsButton.Content.ToString() == "Show Requests")
            {
                this.PanelRequests.Visibility = Visibility.Visible;
                this.RequestsButton.Content = "Hide Requests";
            } else
            {
                this.PanelRequests.Visibility = Visibility.Hidden;
                this.RequestsButton.Content = "Show Requests";
            }
        }
    }
}
