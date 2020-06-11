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
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            var ViewModel = new LoginViewModel();
            //ViewModel.FirstName = "Martin";

            DataContext = ViewModel;
            InitializeComponent();

        }

        private void TestLogin_Click(object sender, RoutedEventArgs e)
        {
            LoggedInUser.role = EmployeeRole.Owner;
            LoggedInUser.userID = "AHrsSBGtkCE9kwraDlC5g";
            LoggedInUser.departmentID = "ebcpNLREqnrQjWbkrNNA";
            var newWindow = new DashboardView();
            newWindow.Show();
            this.Close();
        }
    }
}
