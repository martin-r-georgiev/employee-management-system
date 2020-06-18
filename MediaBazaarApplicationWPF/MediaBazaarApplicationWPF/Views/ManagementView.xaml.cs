using MediaBazaarApplicationWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for ManagementView.xaml
    /// </summary>
    public partial class ManagementView : Window
    {
        public ManagementView()
        {
            InitializeComponent();
            var ViewModel = new ManagementViewModel();
            DataContext = ViewModel;

            ViewModel.MessageEvent += new ManagementViewModel.MessageHandler(MessageShow_Event);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var DashboardWindow = new DashboardView();
            DashboardWindow.Show();
            this.Close();
        }

        private void RealNumericTextValidation(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9.,]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void IntegerNumericTextValidation(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void PhoneNumberTextValidation(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"^[+]|\+?[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\./0-9]*$");
            e.Handled = !regex.IsMatch(e.Text);
        }

        private void MessageShow_Event(string message) => MessageBox.Show(message);
    }
}
