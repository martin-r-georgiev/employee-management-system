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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MediaBazaarApplicationWPF.UserControls.Views
{
    /// <summary>
    /// Interaction logic for NotificationsControlView.xaml
    /// </summary>
    public partial class NotificationsControlView : UserControl
    {
        RescheduleNotification notification;
        Employee employee;
        DashboardViewModel model;
        public NotificationsControlView(RescheduleNotification notification, DashboardViewModel model)
        {
            this.model = model;
            EmployeeManager man = new EmployeeManager();
            InitializeComponent();
            this.notification = notification;
            this.employee = man.GetEmployee(notification.UserID, false);


            if (!string.IsNullOrEmpty(this.employee.FirstName) || !string.IsNullOrEmpty(this.employee.LastName))
            {
                lblName.Text = this.employee.FirstName + " " + this.employee.LastName;
            }
            else lblName.Text = this.employee.Username;

            lblTime.Text = this.notification.Date.ToString("dd/MM/yyyy") + " ";
            switch (this.notification.WorkshiftIndex)
            {
                case 0: lblTime.Text += "Morning"; break;
                case 1: lblTime.Text += "Afternoon"; break;
                case 2: lblTime.Text += "Evening"; break;
            }
        }

        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            notification.UpdateWorkshift(2);
            notification.RemoveNotification();
            model.RefreshNotifications();
        }

        private void btnDecline_Click(object sender, RoutedEventArgs e)
        {
            notification.UpdateWorkshift(0);
            notification.RemoveNotification();
            model.RefreshNotifications();
        }

        private void UserControl_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Background = Brushes.LightGray;
        }

        private void UserControl_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Background = Brushes.White;
        }
    }
}
