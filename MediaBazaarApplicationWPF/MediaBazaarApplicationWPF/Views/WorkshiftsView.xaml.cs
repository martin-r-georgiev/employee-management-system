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
    /// Interaction logic for WorkshiftsView.xaml
    /// </summary>
    public partial class WorkshiftsView : Window
    {
        public WorkshiftsView()
        {
            InitializeComponent();
            var ViewModel = new WorkshiftsViewModel();
            DataContext = ViewModel;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new DashboardView();
            newWindow.Show();
            this.Close();
        }
    }
}
