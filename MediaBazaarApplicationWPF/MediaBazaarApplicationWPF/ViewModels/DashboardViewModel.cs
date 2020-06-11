using MediaBazaarApplicationWPF.Commands;
using MediaBazaarApplicationWPF.UserControls.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MediaBazaarApplicationWPF.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {
        private readonly NotificationsCommand _notificationCommand;
        public ICommand NotificationCommand => _notificationCommand;
        private readonly CheckInCommand _checkInCommand;
        public ICommand CheckInCommand => _checkInCommand;

        private ObservableCollection<EmployeeAtWorkModel> workers;

        public ObservableCollection<EmployeeAtWorkModel> Workers => workers;


        private ObservableCollection<NotificationsControlView> notifications;
        public ObservableCollection<NotificationsControlView> Notifications
        {
            get { return notifications; }
            set { notifications = value; OnPropertyChanged(); }
        }

        private bool btnStockVisible, btnWorkshiftsVisible, btnStatisticsVisible, btnManagementVisible, btnRequestsVisible;

        public bool BtnStockVisible
        {
            get => this.btnStockVisible;
            private set
            {
                this.btnStockVisible = value;
                OnPropertyChanged();
            }
        }

        public bool BtnWorkshiftsVisible
        {
            get => this.btnWorkshiftsVisible;
            private set
            {
                this.btnWorkshiftsVisible = value;
                OnPropertyChanged();
            }
        }

        public bool BtnStatisticsVisible
        {
            get => this.btnStatisticsVisible;
            private set
            {
                this.btnStatisticsVisible = value;
                OnPropertyChanged();
            }
        }

        public bool BtnManagementVisible
        {
            get => this.btnManagementVisible;
            private set
            {
                this.btnManagementVisible = value;
                OnPropertyChanged();
            }
        }

        public bool BtnRequestsVisible
        {
            get => this.btnRequestsVisible;
            private set
            {
                this.btnRequestsVisible = value;
                OnPropertyChanged();
            }
        }

        private bool _pnlRequestsVisibility;

        public bool PnlRequestsVisibility
        {
            get { return _pnlRequestsVisibility; }
            set 
            {
                _pnlRequestsVisibility = value;
                OnPropertyChanged(); 
            }
        }


        private string _requestsBtnContent;

        public string RequestsBtnContent
        {
            get { return _requestsBtnContent; }
            set { _requestsBtnContent = value; OnPropertyChanged(); }
        }

        private string _checkInBtnContent;

        public string CheckInBtnContent
        {
            get { return _checkInBtnContent; }
            set { _checkInBtnContent = value; OnPropertyChanged(); }
        }


        public DashboardViewModel()
        {
            _notificationCommand = new NotificationsCommand(this);
            _checkInCommand = new CheckInCommand(this);
            notifications = new ObservableCollection<NotificationsControlView>();
            workers = new ObservableCollection<EmployeeAtWorkModel>();
            RequestsBtnContent = "Show Requests";
            if (LoggedInUser.role != EmployeeRole.Worker) CheckIn.ClearNotificationsBefore(DateTime.Now);
            UpdateRoleGUI();
            UpdatePresentWorkers();
           
        }

        public void RefreshNotifications()
        {
            List<RescheduleNotification> selectedNotifications = new List<RescheduleNotification>();
            if (LoggedInUser.role == EmployeeRole.Owner) selectedNotifications = RescheduleNotification.GetAllNotifications();
            else selectedNotifications = RescheduleNotification.GetAllNotifications(LoggedInUser.departmentID);
            Notifications.Clear();
            foreach (RescheduleNotification n in selectedNotifications)
                Notifications.Add(new NotificationsControlView(n,this));
        }

        public void UpdatePresentWorkers()
        {
            Workers.Clear();
            foreach (EmployeeAtWorkModel e in CheckIn.GetEmployeesAtWork(LoggedInUser.departmentID))
                Workers.Add(e);
        }

        public void UpdateRoleGUI()
        {
            if (CheckIn.IsAtWork(LoggedInUser.userID)) CheckInBtnContent = "Check Out";
            else CheckInBtnContent = "Check In";

            if (LoggedInUser.role >= EmployeeRole.Worker)
            {
                BtnStockVisible = true;
                BtnWorkshiftsVisible = true;
            }

            if (LoggedInUser.role >= EmployeeRole.Manager)
            {
                BtnRequestsVisible = true;
                BtnStatisticsVisible = true;
            }
            if (LoggedInUser.role >= EmployeeRole.Admin) BtnManagementVisible = true;
        }

    }
}
