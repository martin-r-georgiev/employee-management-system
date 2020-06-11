using MediaBazaarApplicationWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MediaBazaarApplicationWPF.Commands
{
    class CheckInCommand : ICommand
    {
        DashboardViewModel model;

        public CheckInCommand(DashboardViewModel model)
        {
            this.model = model;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            if (model.CheckInBtnContent == "Check In")
            {
                CheckIn.Checkin(LoggedInUser.userID, DateTime.Now);
                model.CheckInBtnContent = "Check Out";
            } else if (model.CheckInBtnContent == "Check Out")
            {
                CheckIn.Checkout(LoggedInUser.userID, DateTime.Now);
                model.CheckInBtnContent = "Check In";
            }
            model.UpdatePresentWorkers();
        }
    }
}
