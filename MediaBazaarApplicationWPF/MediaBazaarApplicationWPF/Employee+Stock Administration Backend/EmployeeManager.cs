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
        public delegate void UpdatedEmployeeHandler(Employee employee);
        public delegate void RemovedEmployeeHandler(Employee employee);

        public event AddedEmployeeHandler AddedEmployeeEvent;
        public event UpdatedEmployeeHandler UpdatedEmployeeEvent;
        public event RemovedEmployeeHandler RemovedEmployeeEvent;
        #endregion

        #region #Method(s)

        public Employee AddEmployee(string username, string password, decimal salaryRate, EmployeeRole role, string depID, int workHours, bool hashPassword)
        {
            Employee newEmployee = null;
            try
            {
                string userID = EmployeeDatabaseHandler.GenerateUniqueUserID();
                if (userID != null)
                {
                    newEmployee = new Employee(userID, username, password, salaryRate, role, depID, workHours, hashPassword);
                    EmployeeDatabaseHandler.InsertToDatabase(newEmployee);

                    if (this.AddedEmployeeEvent != null) this.AddedEmployeeEvent(newEmployee);
                }
                else throw new Exception("Fatal error. Failed to generate employee user identifier.");
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

        public void UpdateEmployee(Employee employee)
        {
            EmployeeDatabaseHandler.UpdateDatabaseEntry(employee);
            if (this.UpdatedEmployeeEvent != null) this.UpdatedEmployeeEvent(employee);
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

        public Employee GetEmployee(string userIdentifier, bool needFullDetails) => EmployeeDatabaseHandler.GetEmployee(userIdentifier, needFullDetails);
        public List<Employee> GetAllEmployees(bool needFullDetails) => EmployeeDatabaseHandler.GetAllEmployees(needFullDetails);

        public static string CalculateWorkingSince(Employee selectedEmployee)
        {
            string s = "";
            if (selectedEmployee.StartDate.HasValue)
            {
                int workingSince = DateTime.Today.Year - selectedEmployee.StartDate.Value.Year;
                if (workingSince > 0)
                {
                    s = $"Working since: {workingSince} years";
                    if (workingSince == 1) s.Replace("years", "year");
                }
                else
                {
                    workingSince = DateTime.Today.Month - selectedEmployee.StartDate.Value.Month;
                    if (workingSince > 0)
                    {
                        s = $"Working since: {workingSince} months";
                        if (workingSince == 1) s.Replace("months", "month");
                    }
                    else
                    {
                        workingSince = DateTime.Today.Day - selectedEmployee.StartDate.Value.Day;
                        s = $"Working since: {workingSince} days";
                        if (workingSince == 1) s.Replace("days", "day");
                    }
                }
            }
            else s = $"Working since: Unknown";
            return s;
        }

        public static string GetPictureURL(string userIdentifier) => EmployeeDatabaseHandler.GetPictureURL(userIdentifier);
        #endregion
    }
}
