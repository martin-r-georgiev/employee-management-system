using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MediaBazaarApplicationWPF
{
    public static class DepartmentManager
    {
        public static void AddDepartment(string name, string address)
        {
            Department newDep = null;
            try
            {
                string depID = DepartmentDatabaseHandler.GenerateUniqueID();
                newDep = new Department(name, address, depID);
                DepartmentDatabaseHandler.InsertToDB(newDep);
            }
            catch (Exception ex) { MessageBox.Show($"Failed to create Department. Reason: {ex.Message}"); }
        }

        public static Department GetDepartment(string departmentId, bool needFullData)
        {
            Department newDep = DepartmentDatabaseHandler.GetDepartment(departmentId);
            if (needFullData) newDep = DepartmentDatabaseHandler.GetUsersForDepartment(newDep);

            return newDep;
        }

        public static void RemoveFromDatabase(Department department)
        {
            if (department.Employees.Count != 0) throw new MinimalEmployeesException("You still have employees in this department!");

            DepartmentDatabaseHandler.RemoveStockOfDepartment(department.DepartmentId);
            DepartmentDatabaseHandler.RemoveDepartment(department.DepartmentId);
        }

        public static void RemoveFromDatabase(string departmentID)
        {
            Department selectedDep = GetDepartment(departmentID, true);
            if (selectedDep.Employees.Count != 0) throw new MinimalEmployeesException("You still have employees in this department!");

            DepartmentDatabaseHandler.RemoveStockOfDepartment(selectedDep.DepartmentId);
            DepartmentDatabaseHandler.RemoveDepartment(selectedDep.DepartmentId);
        }

        public static void UpdateDepartment(string departmentID, string newName, string newAddress)
        {
            DepartmentDatabaseHandler.UpdateDepartmentData(departmentID, newName, newAddress);
        }

        public static List<Department> GetAllDepartments(bool needFullInformation)
        {
            if (needFullInformation) return DepartmentDatabaseHandler.GetAllDepartments();
            else return DepartmentDatabaseHandler.GetAllDepartmentsMinimalInformation();
        }
    }
}
