using MediaBazaarApplicationWPF.UserControls;
using MediaBazaarApplicationWPF.UserControls.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MediaBazaarApplicationWPF.ViewModels
{
    public class WorkshiftsViewModel : BaseViewModel
    {
        private ObservableCollection<DailyWorkshiftViewModel> _dailyWorkshiftList;
        private string _test = "Martin";

        public string Test => _test;

        public ObservableCollection<DailyWorkshiftViewModel> DailyWorkshiftList => this._dailyWorkshiftList;

        public WorkshiftsViewModel()
        {
            _dailyWorkshiftList = new ObservableCollection<DailyWorkshiftViewModel>();
            RefreshWorkshiftsPanel();
        }

        public void RefreshWorkshiftsPanel()
        {
            //Model database
            DailyWorkshiftList.Clear();

            ObservableCollection<DailyWorkshiftViewModel> retrievedList = WorkshiftDatabaseHandler.GetEmployees(new DateTime(2020, 6, 10), LoggedInUser.departmentID);

            foreach(DailyWorkshiftViewModel item in retrievedList)
            {
                DailyWorkshiftList.Add(item);
            }

            //Header Row
            //var headerControl = new DailyWorkshiftViewModel();
            //headerControl.ToggleHeaderVisibility();
            //DailyWorkshiftList.Add(headerControl);

            for (int i = 0; i < 3; i++)
            {
                //DailyWorkshiftList.Add(new DailyWorkshiftViewModel());
            }
        }
    }
}
