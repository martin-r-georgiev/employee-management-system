using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApplicationWPF
{
    public class EmployeeAtWorkModel
    {
		private string firstName;
		private string atWorkSince;

		public string AtWorkSince
		{
			get { return atWorkSince; }
			set { atWorkSince = "At work since " + value; }
		}

		public string FirstName
		{
			get { return firstName; }
			set { firstName = value; }
		}
		public EmployeeAtWorkModel(string fName, string atWorkSince)
		{
			this.FirstName = fName;
			this.AtWorkSince = atWorkSince;
		}
	}
}
