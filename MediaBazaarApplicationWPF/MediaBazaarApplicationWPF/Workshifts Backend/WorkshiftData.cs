using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApplicationWPF
{
    public class WorkshiftData
    {
        #region Properties+variables

        private readonly string userID;
        private readonly DateTime date;
        private readonly int workshift;
        private readonly string day;
        private readonly string departmentID;

        public string UserID => this.userID;
        public DateTime Date => this.date;
        public string Day => this.day;
        public string DepartmentID => this.departmentID;
        public int Workshift => this.workshift;
        #endregion

        #region Constructors
        public WorkshiftData(string userID, DateTime date, int workshift, string day, string departmentID)
        {
            this.userID = userID;
            this.date = date;
            this.workshift = workshift;
            this.day = day;
            this.departmentID = departmentID;
        }
        #endregion
    }
}
