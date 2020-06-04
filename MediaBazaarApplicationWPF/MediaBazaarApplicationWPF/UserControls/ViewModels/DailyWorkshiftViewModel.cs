using MediaBazaarApplicationWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApplicationWPF.UserControls.ViewModels
{
    public class DailyWorkshiftViewModel : BaseViewModel
    {
        private bool _headerVisible;

        public bool HeaderVisible
        {
            get => this._headerVisible;
            private set
            {
                this._headerVisible = value;
                OnPropertyChanged();
            }
        }

        WorkshiftsManager manager;

        public DailyWorkshiftViewModel()
        {
            this.HeaderVisible = false;
            //manager = new WorkshiftsManager(date, userID);
        }

        public void ToggleHeaderVisibility()
        {
            this.HeaderVisible = !HeaderVisible;
        }
    }
}
