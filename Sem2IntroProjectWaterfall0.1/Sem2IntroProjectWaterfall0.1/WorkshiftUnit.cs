using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem2IntroProjectWaterfall0._1
{
    public class WorkshiftUnit
    {
        //Instance variable(s)
        private Employee employee;
        private int workshift;
        private int status;

        //Properties
        public Employee Employee
        {
            get { return this.employee; }
        }

        public int Workshift
        {
            get { return this.workshift; }
            set
            {
                if (value >= 0 && value <= 2) this.workshift = value;
                else this.workshift = 0;
            }
        }

        public int Status
        {
            get { return this.status; }
            set
            {
                if (value >= 0 && value <= 3) this.status = value;
                else this.status = 0;
            }
        }

        //Constructor(s)
        public WorkshiftUnit(Employee newEmployee, int workshift, int status)
        {
            this.employee = newEmployee;
            this.Workshift = workshift;
            this.Status = status;
        }
    }
}
