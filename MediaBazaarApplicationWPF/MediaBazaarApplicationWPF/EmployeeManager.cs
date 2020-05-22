using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApplicationWPF
{
    public class EmployeeManager
    {
        #region Delegates + Events

        public delegate void AddedEmployeeHandler(Employee employee);
        public delegate void RemovedEmployeeHandler(Employee employee);

        public event AddedEmployeeHandler AddedEmployeeEvent;
        public event RemovedEmployeeHandler RemovedEmployeeEvent;
        #endregion

        #region #Method(s)

        public Employee AddEmployee(string username, string password, decimal salaryRate, EmployeeRole role, string depID, int workHours, bool hashPassword)
        {
            Employee newEmployee = null;
            try
            {
                string userID = EmployeeDatabaseHandler.GenerateUniqueUserID();
                newEmployee = new Employee(userID, username, password, salaryRate, role, depID, workHours, hashPassword);
                EmployeeDatabaseHandler.InsertToDatabase(newEmployee);

                if (this.AddedEmployeeEvent != null) this.AddedEmployeeEvent(newEmployee);
            }
            catch(Exception ex)
            {
                throw new ArgumentException($"Failed to create new employee. Reason: {ex.Message}");
            }
            return newEmployee;
        }

        public Employee AddEmployee(Employee employee)
        {
            EmployeeDatabaseHandler.InsertToDatabase(employee);
            if (this.AddedEmployeeEvent != null) this.AddedEmployeeEvent(employee);
            return employee;
        }

        public Employee UpdateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Employee RemoveEmployee(Employee employee)
        {
            EmployeeDatabaseHandler.RemoveFromDatabase(employee.UserID);
            if (this.RemovedEmployeeEvent != null) this.RemovedEmployeeEvent(employee);
            return employee;
        }

        public Employee RemoveEmployee(string userIdentifier)
        {
            Employee employee = EmployeeDatabaseHandler.GetEmployee(userIdentifier, true);
            EmployeeDatabaseHandler.RemoveFromDatabase(userIdentifier);
            if (this.RemovedEmployeeEvent != null) this.RemovedEmployeeEvent(employee);
            return employee;
        }
        #endregion
    }
}
