using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApplicationWPF
{
    public class WorkshiftFilter
    {
        private bool? _showWorkers;
        private bool? _showManagers;
        private bool? _showAdmins;

        public bool? ShowWorkers
        {
            get { return _showWorkers; }
            set { _showWorkers = value; }
        }

        public bool? ShowManagers
        {
            get { return _showManagers; }
            set { _showManagers = value; }
        }

        public bool? ShowAdmins
        {
            get { return _showAdmins; }
            set { _showAdmins = value; }
        }

        public WorkshiftFilter(bool defaultVisibility)
        {
            this.ShowWorkers = defaultVisibility;
            this.ShowManagers = defaultVisibility;
            this.ShowAdmins = defaultVisibility;
        }

        public bool? GetValue(EmployeeRole role)
        {
            bool? result = null;

            switch (role)
            {
                case EmployeeRole.Worker: result = this.ShowWorkers; break;
                case EmployeeRole.Manager: result = this.ShowManagers; break;
                case EmployeeRole.Admin: result = this.ShowAdmins; break;
                default: result = true; break;
            }

            return result;
        }
    }
}
