using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApplicationWPF.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {
        private string _test = "Potato";

        public string Test
        {
            get { return _test; }
        }
    }
}
