using MediaBazaarApplicationWPF.UserControls.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MediaBazaarApplicationWPF.ViewModels
{
    public class EmployeeListingViewModel : BaseViewModel
    {
        EmployeeManager man;

        private ObservableCollection<EmployeeControl> _employees;
        public ObservableCollection<EmployeeControl> Employees => this._employees;
        private Employee _selectedEmployee;

        public Employee SelectedEmployee
        {
            get { return _selectedEmployee; }
            set { _selectedEmployee = value;

                if (SelectedEmployee.DateOfBirth == null) SelectedEmpAge = "Unknown";
                else SelectedEmpAge = $"{DateTime.Today.Year - SelectedEmployee.DateOfBirth.Value.Year}";

                if (SelectedEmployee.Sex == null) Gender = "Unknown";
                else if ((bool)SelectedEmployee.Sex) Gender = "Female";
                else Gender = "Male";

                WorkingSince = EmployeeManager.CalculateWorkingSince(SelectedEmployee);
                PicURL = EmployeeManager.GetPictureURL(SelectedEmployee.UserID);
                OnPropertyChanged();
            }
        }
        private string selectedEmpAge;

        public string SelectedEmpAge
        {
            get { return selectedEmpAge; }
            set { 
                selectedEmpAge = value;
                OnPropertyChanged();
            }
        }

        private string workingSince;

        public string WorkingSince
        {
            get { return workingSince; }
            set { workingSince = value; OnPropertyChanged(); }
        }


        private string picURL;

        public string PicURL
        {
            get { return picURL; }
            set { picURL = value; OnPropertyChanged(); }
        }


        private string gender;

        public string Gender
        {
            get { return gender; }
            set { gender = value; OnPropertyChanged(); }
        }

        private List<Department> _departments;

        public List<Department> Departments
        {
            get { return _departments; }
            set { _departments = value; OnPropertyChanged(); }
        }
        private string searchContent;

        public string SearchContent
        {
            get { return searchContent; }
            set
            {
                searchContent = value;

                Employees.Clear();
                foreach (Employee emp in SelectedDepartment.Employees)
                    if (emp.FullName.ToLower().Contains(value.ToLower()))
                        Employees.Add(new EmployeeControl(emp, SelectedDepartment.Name, this));

                OnPropertyChanged();
            }
        }


        private Department _selectedDepartment;

        public Department SelectedDepartment
        {
            get { return _selectedDepartment; }
            set
            {
                if (!String.IsNullOrWhiteSpace(SearchContent)) SearchContent = "";
                _selectedDepartment = DepartmentManager.GetDepartment(value.DepartmentId, true);
                RefreshEmployees(_selectedDepartment);
                OnPropertyChanged();
            }
        }
        private bool cbDepartmentsVisible;

        public bool CbDepartmentsVisible
        {
            get => this.cbDepartmentsVisible;
            private set
            {
                this.cbDepartmentsVisible = value;
                OnPropertyChanged();
            }
        }
        void RefreshGUI()
        {
            if (LoggedInUser.role == EmployeeRole.Worker)
            {
                CbDepartmentsVisible = false;
            }
            else
            {
                CbDepartmentsVisible = true;
                this.Departments = DepartmentManager.GetAllDepartments(false);
            }
        }

        void RefreshEmployees(Department dep)
        {
            Employees.Clear();
            dep.Employees.Sort();
            foreach (Employee e in dep.Employees)
                Employees.Add(new EmployeeControl(e,dep.Name, this));
        }

        public EmployeeListingViewModel()
        {
            man = new EmployeeManager();
            this._departments = new List<Department>();
            this._employees = new ObservableCollection<EmployeeControl>();

            this.SelectedDepartment = DepartmentManager.GetDepartment(LoggedInUser.departmentID, true);
            RefreshGUI();
        }

        public void RefreshGUI(Employee selectedEmployee, string departmentName)
        {

            Employee employee = man.GetEmployee(selectedEmployee.UserID, true);
            employee.DepartmentName = departmentName;
            SelectedEmployee = employee;
        }
    }
}
