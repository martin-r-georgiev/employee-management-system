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
        private string _toggleWorkshiftViewText;
        private WorkshiftPanelStatus _panelStatus;
        private ObservableCollection<DailyWorkshift> _dailyWorkshiftList;
        private ObservableCollection<WeeklyWorkshift> _weeklyWorkshiftList;
        private List<Department> _departments;
        private Department _selectedDepartment;
        private WorkshiftFilter _workshiftFilter;

        AutoWorkshift ScheduleGenerator;

        private bool _departmentControlsVisible;

        // Commands

        private readonly DelegateCommand _previousDatePeriodCommand;
        private readonly DelegateCommand _nextDatePeriodCommand;
        private readonly DelegateCommand _toggleWorkshiftViewCommand;

        // Properties

        public bool DepartmentControlsVisible
        {
            get => this._departmentControlsVisible;
            private set
            {
                this._departmentControlsVisible = value;
                OnPropertyChanged();
            }
        }

        public WorkshiftFilter WorkshiftFilter => this._workshiftFilter;

        public bool? ShowWorkers
        {
            get => (this.WorkshiftFilter.ShowWorkers != null) ? this.WorkshiftFilter.ShowWorkers : true;
            set
            {
                if(this.WorkshiftFilter.ShowWorkers != value)
                {
                    this.WorkshiftFilter.ShowWorkers = value;
                    switch (this.PanelStatus)
                    {
                        case WorkshiftPanelStatus.Weekly: RefreshWorkshiftsPanel(startDate, this.SelectedDepartmentID, this.WorkshiftFilter); break;
                        case WorkshiftPanelStatus.Daily: RefreshWorkshiftsPanel(selectedDate, this.SelectedDepartmentID, this.WorkshiftFilter); break;
                    }
                    OnPropertyChanged();
                }
            }
        }

        public bool? ShowManagers
        {
            get => (this.WorkshiftFilter.ShowManagers != null) ? this.WorkshiftFilter.ShowManagers : true;
            set
            {
                if (this.WorkshiftFilter.ShowManagers != value)
                {
                    this.WorkshiftFilter.ShowManagers = value;
                    switch (this.PanelStatus)
                    {
                        case WorkshiftPanelStatus.Weekly: RefreshWorkshiftsPanel(startDate, this.SelectedDepartmentID, this.WorkshiftFilter); break;
                        case WorkshiftPanelStatus.Daily: RefreshWorkshiftsPanel(selectedDate, this.SelectedDepartmentID, this.WorkshiftFilter); break;
                    }
                    OnPropertyChanged();
                }
            }
        }

        public bool? ShowAdmins
        {
            get => (this.WorkshiftFilter.ShowAdmins != null) ? this.WorkshiftFilter.ShowAdmins : true;
            set
            {
                if (this.WorkshiftFilter.ShowAdmins != value)
                {
                    this.WorkshiftFilter.ShowAdmins = value;
                    switch (this.PanelStatus)
                    {
                        case WorkshiftPanelStatus.Weekly: RefreshWorkshiftsPanel(startDate, this.SelectedDepartmentID, this.WorkshiftFilter); break;
                        case WorkshiftPanelStatus.Daily: RefreshWorkshiftsPanel(selectedDate, this.SelectedDepartmentID, this.WorkshiftFilter); break;
                    }
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<DailyWorkshift> DailyWorkshiftList
        {
            get => this._dailyWorkshiftList;
            private set
            {
                this._dailyWorkshiftList = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<WeeklyWorkshift> WeeklyWorkshiftList
        {
            get => this._weeklyWorkshiftList;
            private set
            {
                this._weeklyWorkshiftList = value;
                OnPropertyChanged();
            }
        }

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
        public ICommand ToggleWorkshiftView => _toggleWorkshiftViewCommand;

        public string DatePeriodText
        {
            get => this._datePeriodText;
            private set
            {
                this._datePeriodText = value;
                OnPropertyChanged();
            }
        }

        public string ToggleWorkshiftViewText
        {
            get => this._toggleWorkshiftViewText;
            private set
            {
                this._toggleWorkshiftViewText = value;
                OnPropertyChanged();
            }
        }

        public List<Department> Departments
        {
            get => this._departments;
            private set
            {
                this._departments = value;
                OnPropertyChanged();
            }
        }

        public Department SelectedDepartment
        {
            get { return _selectedDepartment; }
            set
            {
                _selectedDepartment = value;
                switch (this.PanelStatus)
                {
                    case WorkshiftPanelStatus.Weekly: RefreshWorkshiftsPanel(startDate, value.DepartmentId, this.WorkshiftFilter); break;
                    case WorkshiftPanelStatus.Daily: RefreshWorkshiftsPanel(selectedDate, value.DepartmentId, this.WorkshiftFilter); break;
                }
                OnPropertyChanged();
            }
        }

        public string SelectedDepartmentID
        {
            get => (this.SelectedDepartment != null) ? this.SelectedDepartment.DepartmentId : LoggedInUser.departmentID;
        }

        public WorkshiftsViewModel()
        {
            _previousDatePeriodCommand = new DelegateCommand(GoToPreviousDatePeriod_Event, CanChangeDate);
            _nextDatePeriodCommand = new DelegateCommand(GoToNextDatePeriod_Event, CanChangeDate);
            _toggleWorkshiftViewCommand = new DelegateCommand(ToggleWorkshiftView_Event, CanChangeDate);

            this.ScheduleGenerator = new AutoWorkshift();
            ScheduleChecker();

            // Window defaults to displaying daily workshifts
            this.PanelStatus = WorkshiftPanelStatus.Weekly;
            this.ToggleWorkshiftViewText = "Toggle Daily view";

            this.DailyWorkshiftList = new ObservableCollection<DailyWorkshift>();
            this.WeeklyWorkshiftList = new ObservableCollection<WeeklyWorkshift>();
            this.Departments = DepartmentManager.GetAllDepartments(false);
            this.selectedDate = DateTime.Now;
            this.startDate = DateTimeControls.StartOfWeek(selectedDate, DayOfWeek.Monday);
            this.endDate = startDate.AddDays(6);
            this._workshiftFilter = new WorkshiftFilter(true);
            
            UpdateDateText();
            RefreshWorkshiftsPanel(selectedDate, LoggedInUser.departmentID, this.WorkshiftFilter);
            RefreshGUI();
        }

        public void RefreshWorkshiftsPanel(DateTime time, string departmentID, WorkshiftFilter filter)
        {
            DailyWorkshiftList.Clear();
            WeeklyWorkshiftList.Clear();

            ObservableCollection<DailyWorkshift> retrievedDailyList = null;
            ObservableCollection<WeeklyWorkshift> retrievedWeeklyList = null;

            WorkshiftDatabaseHandler.CheckMissedWorkshifts(selectedDate, LoggedInUser.departmentID);

            switch (this.PanelStatus)
            {
                case WorkshiftPanelStatus.Weekly:
                    {
                        retrievedWeeklyList = WorkshiftDatabaseHandler.GetWeeklyEmployees(time, departmentID, filter);

                        if (retrievedWeeklyList.Count > 0)
                        {
                            retrievedWeeklyList[0].ShowHeader();
                            foreach (WeeklyWorkshift item in retrievedWeeklyList) { WeeklyWorkshiftList.Add(item); }
                        }
                    } break;
                case WorkshiftPanelStatus.Daily:
                    { 
                        retrievedDailyList = WorkshiftDatabaseHandler.GetEmployees(time, departmentID, filter);

                        if (retrievedDailyList.Count > 0)
                        {
                            retrievedDailyList[0].ShowHeader();
                            foreach (DailyWorkshift item in retrievedDailyList) { DailyWorkshiftList.Add(item); }
                        }
                    } break;
            } 
        }

        public void ScheduleChecker()
        {
            string message = ScheduleGenerator.GenerateAndUpload();
            if (message != "") Console.WriteLine(message);
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
                    } break;
            }
        }

        private void RefreshGUI()
        {
            if (LoggedInUser.role == EmployeeRole.Worker)
            {
                this.DepartmentControlsVisible = false;
            }
            else
            {
                this.DepartmentControlsVisible = true;
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
                        RefreshWorkshiftsPanel(startDate, this.SelectedDepartmentID, this.WorkshiftFilter);
                    } break;
                case WorkshiftPanelStatus.Daily:
                    {
                        selectedDate = selectedDate.AddDays(-1);
                        RefreshWorkshiftsPanel(selectedDate, this.SelectedDepartmentID, this.WorkshiftFilter);
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
                        RefreshWorkshiftsPanel(startDate, this.SelectedDepartmentID, this.WorkshiftFilter);
                    } break;

                case WorkshiftPanelStatus.Daily:
                    {
                        selectedDate = selectedDate.AddDays(1);
                        RefreshWorkshiftsPanel(selectedDate, this.SelectedDepartmentID, this.WorkshiftFilter);
                    } break;
            }
            UpdateDateText();
        }

        private void ToggleWorkshiftView_Event(object commandParameter)
        {
            this.ToggleWorkshiftViewText = $"Toggle {this.PanelStatus.ToString()} view";

            switch (this.PanelStatus)
            {
                case WorkshiftPanelStatus.Weekly:
                    {
                        this.PanelStatus = WorkshiftPanelStatus.Daily;
                        RefreshWorkshiftsPanel(selectedDate, this.SelectedDepartmentID, this.WorkshiftFilter);
                        
                    } break;
                case WorkshiftPanelStatus.Daily:
                    {
                        this.PanelStatus = WorkshiftPanelStatus.Weekly;
                        RefreshWorkshiftsPanel(startDate, this.SelectedDepartmentID, this.WorkshiftFilter);
                    }
                    break;
            }
            UpdateDateText();
        }

        private bool CanChangeDate(object commandParameter) => true;
    }
}
