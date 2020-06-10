using MediaBazaarApplicationWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MediaBazaarApplicationWPF.UserControls.ViewModels
{
    public class DailyWorkshiftViewModel : BaseViewModel
    {
        private Employee employee;
        private bool _headerVisible;
        public WorkshiftsManager manager;
        public Panel workshiftOneCell, workshiftTwoCell, workshiftThreeCell;

        public Employee Employee => this.employee;

        public bool HeaderVisible
        {
            get => this._headerVisible;
            set
            {
                this._headerVisible = value;
                OnPropertyChanged();
            }
        }

        public DailyWorkshiftViewModel(Employee employee, DateTime date)
        {
            this.employee = employee;
            this.HeaderVisible = false;
            manager = new WorkshiftsManager(date, employee.UserID);
            manager.SetWorkshiftPanels(workshiftOneCell, workshiftTwoCell, workshiftThreeCell);
        }

        public void ToggleHeaderVisibility()
        {
            this.HeaderVisible = !HeaderVisible;
        }

        public void SetStatus(int status, int index)
        {
            manager.SetStatus(status, index);
        }
    }
}
