using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem2IntroProjectWaterfall0._1
{
    public abstract class WorkshiftFilters
    {
        private static bool _showWorkers = true;
        private static bool _showManagers = true;
        private static bool _showAdmins = true;

        public static bool ShowWorkers
        {
            get { return _showWorkers; }
            set { _showWorkers = value; }
        }

        public static bool ShowManagers
        {
            get { return _showManagers; }
            set { _showManagers = value; }
        }

        public static bool ShowAdmins
        {
            get { return _showAdmins; }
            set { _showAdmins = value; }
        }
    }
}
