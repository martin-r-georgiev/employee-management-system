using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApplicationWPF
{
    class Department
    {
        #region variables + properties

        private EmployeeManager employeeManager;
        private string departmentId;
        private string name;
        private string address;
        List<Employee> employees;
        // public Inventory inventory; add inventory first
        public List<Employee> Employees
        {
            get { return this.employees; }
        }
        public string Address
        {
            get { return address; }
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                    address = value;
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                    name = value;
            }
        }

        public string DepartmentId
        {
            get { return departmentId; }
            set { departmentId = value; }
        }

        #endregion
        #region Constructors
        public Department(string name, string address, string departmentID)
        {
            if (name.Length == 0 && address.Length == 0)
                throw new InvalidEntryException("Please provide the needed details for the department!");

            this.name = name;
            this.address = address;
            this.departmentId = departmentID;
            employees = new List<Employee>();
            employeeManager = new EmployeeManager();
            // inventory = new Inventory(this.departmentId);
        }

        #endregion
        #region Methods

        public override string ToString()
        {
            return $"Department {this.Name} on {this.Address} - {this.employees.Count} Workers.";
        }

        public Employee GetEmployee(string userID)
        {
            foreach (Employee employee in Employees)
                if (employee.UserID == userID)
                    return employee;
            return null;
        }

        public void RemoveEmployee(string userID)
        {
            foreach (Employee e in employees)
                if (e.UserID == userID)
                {
                    employeeManager.RemoveEmployee(e);
                    employees.Remove(e);
                    break;
                }
        }

        public void AssignEmployeeTo(string userID, string newDepartmentId)
        {
            foreach (Employee e in employeeManager.GetAllEmployees(true))
                if (e.UserID == userID)
                {
                    e.DepartmentID = newDepartmentId;
                    employeeManager.UpdateEmployee(e);
                    break;
                }
        }
        #endregion
    }
}

