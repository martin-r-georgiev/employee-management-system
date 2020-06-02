using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApplicationWPF.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {
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

        public DashboardViewModel()
        {
            UpdateRoleGUI();
        }

        public void UpdateRoleGUI()
        {
            if(LoggedInUser.role >= EmployeeRole.Worker)
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
