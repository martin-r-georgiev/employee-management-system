using MediaBazaarApplicationWPF.UserControls.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApplicationWPF.ViewModels
{
    public class HistoryLogViewModel : BaseViewModel
    {
        private ObservableCollection<HistoryLogControl> _logs;
        public ObservableCollection<HistoryLogControl> Logs
        {
            get { return _logs; }
            set { _logs = value; OnPropertyChanged(); }
        }
        public HistoryLogViewModel()
        {
            Logs = new ObservableCollection<HistoryLogControl>();
            List<string> histories = HistoryLog.ShowLog();
            foreach (string s in histories)
                Logs.Add(new HistoryLogControl(s));
        }
    }
}
