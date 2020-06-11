using MediaBazaarApplicationWPF.Commands;
using MediaBazaarApplicationWPF.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace MediaBazaarApplicationWPF.ViewModels
{
    public class WorkshiftsViewModel : BaseViewModel
    {
        public enum WorkshiftPanelStatus
        {
            Daily,
            Weekly
        }

        // Instance variables

        private DateTime selectedDate;          // Daily view
        private DateTime startDate, endDate;    // Weekly view
        private string _datePeriodText;
        private string _selectedDepartmentID;
        private WorkshiftPanelStatus _panelStatus;
        private ObservableCollection<DailyWorkshift> _dailyWorkshiftList;

        private readonly DelegateCommand _previousDatePeriodCommand;
        private readonly DelegateCommand _nextDatePeriodCommand;

        // Properties

        public ObservableCollection<DailyWorkshift> DailyWorkshiftList => this._dailyWorkshiftList;
        public WorkshiftPanelStatus PanelStatus
        {
            get => this._panelStatus;
            private set
            {
                this._panelStatus = value;
                OnPropertyChanged();
            }
        }

        public ICommand GoToPreviousDatePeriod => _previousDatePeriodCommand;
        public ICommand GoToNextDatePeriod => _nextDatePeriodCommand;

        public string DatePeriodText
        {
            get => this._datePeriodText;
            private set
            {
                this._datePeriodText = value;
                OnPropertyChanged();
            }
        }

        public string SelectedDepartmentID
        {
            get => this._selectedDepartmentID;
            private set
            {
                this._selectedDepartmentID = value;
            }
        }

        public WorkshiftsViewModel()
        {
            _previousDatePeriodCommand = new DelegateCommand(GoToPreviousDatePeriod_Event, CanChangeDate);
            _nextDatePeriodCommand = new DelegateCommand(GoToNextDatePeriod_Event, CanChangeDate);

            this.PanelStatus = WorkshiftPanelStatus.Daily;
            this.selectedDate = DateTime.Now;
            this.startDate = DateTimeControls.StartOfWeek(selectedDate, DayOfWeek.Monday);
            this.endDate = startDate.AddDays(6);
            this.SelectedDepartmentID = LoggedInUser.departmentID;
            _dailyWorkshiftList = new ObservableCollection<DailyWorkshift>();
            UpdateDateText();
            RefreshWorkshiftsPanel(selectedDate, this.SelectedDepartmentID);
        }

        public void RefreshWorkshiftsPanel(DateTime time, string departmentID)
        {
            //Model database
            DailyWorkshiftList.Clear();

            ObservableCollection<DailyWorkshift> retrievedList = WorkshiftDatabaseHandler.GetEmployees(time, departmentID);

            if(retrievedList.Count > 0)
            {
                retrievedList[0].ShowHeader();
                foreach (DailyWorkshift item in retrievedList) { DailyWorkshiftList.Add(item); }   
            }
        }

        private void UpdateDateText()
        {
            switch (this.PanelStatus)
            {
                case WorkshiftPanelStatus.Weekly: this.DatePeriodText = $"{startDate.ToString("dd MMMM yyyy")} - {endDate.ToString("dd MMMM yyyy")}"; break;
                case WorkshiftPanelStatus.Daily:
                    {
                        if (selectedDate.Date.Equals(DateTime.Now.Date)) this.DatePeriodText = $"{selectedDate.ToString("dddd, dd MMMM yyyy")} (Today)";
                        else this.DatePeriodText = selectedDate.ToString("dddd, dd MMMM yyyy");
                    }
                    break;
            }
        }

        private void GoToPreviousDatePeriod_Event(object commandParameter)
        {
            switch (this.PanelStatus)
            {
                case WorkshiftPanelStatus.Weekly:
                    {
                        startDate = startDate.AddDays(-7);
                        endDate = endDate.AddDays(-7);
                        RefreshWorkshiftsPanel(startDate, this.SelectedDepartmentID);
                    } break;
                case WorkshiftPanelStatus.Daily:
                    {
                        selectedDate = selectedDate.AddDays(-1);
                        RefreshWorkshiftsPanel(selectedDate, this.SelectedDepartmentID);
                    } break;
            }
            UpdateDateText();
        }

        private void GoToNextDatePeriod_Event(object commandParameter)
        {
            switch (this.PanelStatus)
            {
                case WorkshiftPanelStatus.Weekly:
                    {
                        startDate = startDate.AddDays(7);
                        endDate = endDate.AddDays(7);
                        RefreshWorkshiftsPanel(startDate, this.SelectedDepartmentID);
                    } break;

                case WorkshiftPanelStatus.Daily:
                    {
                        selectedDate = selectedDate.AddDays(1);
                        RefreshWorkshiftsPanel(selectedDate, this.SelectedDepartmentID);
                    } break;
            }
            UpdateDateText();
        }

        private bool CanChangeDate(object commandParameter) => true;
    }
}
