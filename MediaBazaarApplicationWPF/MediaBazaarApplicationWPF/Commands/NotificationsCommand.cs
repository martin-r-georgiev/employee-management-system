using MediaBazaarApplicationWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MediaBazaarApplicationWPF.Commands
{
    class NotificationsCommand : ICommand
    {
        DashboardViewModel model;

        public NotificationsCommand(DashboardViewModel model)
        {
            this.model = model;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            if (model.RequestsBtnContent == "Show Requests")
            {
                model.PnlRequestsVisibility = true;
                model.RequestsBtnContent = "Close Requests";
                model.RefreshNotifications();
            } else
            {
                model.PnlRequestsVisibility = false;
                model.RequestsBtnContent = "Show Requests";
            }
        }
    }
}
