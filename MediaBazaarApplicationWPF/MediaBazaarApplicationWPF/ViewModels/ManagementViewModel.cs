using MediaBazaarApplicationWPF.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MediaBazaarApplicationWPF.ViewModels
{
    class ManagementViewModel : BaseViewModel
    {
        #region # Employee Creation Variables + Properties

        private string _employeeCreationUsername;
        private string _employeeCreationPassword;
        private string _employeeCreationSalary;
        private string _employeeCreationWorkhours;
        private Department _employeeCreationSelectedDepartment;
        private EmployeeRole _employeeCreationSelectedRole;

        public string EmployeeCreationUsername
        {
            get => this._employeeCreationUsername;
            set
            {
                this._employeeCreationUsername = value;
                OnPropertyChanged();
                this._addEmployeeCommand.InvokeCanExecuteChanged();
            }
        }

        public string EmployeeCreationPassword
        {
            get => this._employeeCreationPassword;
            set
            {
                this._employeeCreationPassword = value;
                OnPropertyChanged();
                this._addEmployeeCommand.InvokeCanExecuteChanged();
            }
        }

        public string EmployeeCreationSalary
        {
            get => this._employeeCreationSalary;
            set
            {
                this._employeeCreationSalary = value;
                OnPropertyChanged();
                this._addEmployeeCommand.InvokeCanExecuteChanged();
            }
        }

        public string EmployeeCreationWorkhours
        {
            get => this._employeeCreationWorkhours;
            set
            {
                this._employeeCreationWorkhours = value;
                OnPropertyChanged();
                this._addEmployeeCommand.InvokeCanExecuteChanged();
            }
        }

        public Department EmployeeCreationSelectedDepartment
        {
            get => this._employeeCreationSelectedDepartment;
            set
            {
                this._employeeCreationSelectedDepartment = value;
                OnPropertyChanged();
                this._addEmployeeCommand.InvokeCanExecuteChanged();
            }
        }
        
        public EmployeeRole EmployeeCreationSelectedRole
        {
            get => this._employeeCreationSelectedRole;
            set
            {
                this._employeeCreationSelectedRole = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region # Departments Control Visibility

        private bool createDepartmentPanelVisible;
        private bool addItemPanelVisible;

        public bool CreateDepartmentPanelVisible
        {
            get => this.createDepartmentPanelVisible;
            set
            {
                this.createDepartmentPanelVisible = value;
                OnPropertyChanged();
            }
        }

        public bool ModifyDepartmentPanelVisible
        {
            get => !this.createDepartmentPanelVisible;
            set
            {
                this.createDepartmentPanelVisible = !value;
                OnPropertyChanged();
            }
        }

        public bool AddItemPanelVisible
        {
            get => this.addItemPanelVisible;
            set
            {
                this.addItemPanelVisible = value;
                OnPropertyChanged();
            }
        }

        public bool RemoveItemPanelVisible
        {
            get => !this.addItemPanelVisible;
            set
            {
                this.addItemPanelVisible = !value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region # Employee Modify Variables + Properties

        private Employee _selectedEmployee;
        private string _selectedEmployeeFirstName;
        private string _selectedEmployeeLastName;
        private string _selectedEmployeeNationality;
        private string _selectedEmployeePhoneNumber;
        private bool? _selectedEmployeeIsMale;
        private string _selectedEmployeeSalary;
        private string _selectedEmployeeAddress;
        private string _selectedEmployeeEmail;
        private DateTime? _selectedEmployeeBirthdate;

        public Employee SelectedEmployee
        {
            get => this._selectedEmployee;
            set
            {
                this._selectedEmployee = value;
                OnPropertyChanged();
                this._clearModifyEmployeeSelectedCommand.InvokeCanExecuteChanged();
                SelectedEmployeeFillControls();
            }
        }

        public string SelectedEmployeeFirstName
        {
            get => this._selectedEmployeeFirstName;
            set
            {
                this._selectedEmployeeFirstName = value;
                OnPropertyChanged();
            }
        }

        public string SelectedEmployeeLastName
        {
            get => this._selectedEmployeeLastName;
            set
            {
                this._selectedEmployeeLastName = value;
                OnPropertyChanged();
            }
        }

        public string SelectedEmployeeNationality
        {
            get => this._selectedEmployeeNationality;
            set
            {
                this._selectedEmployeeNationality = value;
                OnPropertyChanged();
            }
        }

        public string SelectedEmployeePhoneNumber
        {
            get => this._selectedEmployeePhoneNumber;
            set
            {
                this._selectedEmployeePhoneNumber = value;
                OnPropertyChanged();
            }
        }

        public bool? SelectedEmployeeIsMale
        {
            get => this._selectedEmployeeIsMale;
            set
            {
                if (value != null) this._selectedEmployeeIsMale = value;
                else this._selectedEmployeeIsMale = null;

                OnPropertyChanged();
            }
        }

        public bool? SelectedEmployeeIsFemale
        {
            get => !this.SelectedEmployeeIsMale;
            set
            {
                if (value != null) this.SelectedEmployeeIsMale = !value;
                else this.SelectedEmployeeIsMale = null;
                OnPropertyChanged();
            }
        }

        public string SelectedEmployeeSalary
        {
            get => this._selectedEmployeeSalary;
            set
            {
                this._selectedEmployeeSalary = value;
                OnPropertyChanged();
            }
        }

        public string SelectedEmployeeAddress
        {
            get => this._selectedEmployeeAddress;
            set
            {
                this._selectedEmployeeAddress = value;
                OnPropertyChanged();
            }
        }

        public string SelectedEmployeeEmail
        {
            get => this._selectedEmployeeEmail;
            set
            {
                this._selectedEmployeeEmail = value;
                OnPropertyChanged();
            }
        }

        public DateTime? SelectedEmployeeBirthdate
        {
            get => this._selectedEmployeeBirthdate;
            set
            {
                this._selectedEmployeeBirthdate = value;
                OnPropertyChanged();
            }
        }

        #endregion

        //Combobox Data
        private List<Employee> _employees;
        private List<Department> _departments;
        private List<EmployeeRole> _roles;

        public List<Employee> Employees
        {
            get => this._employees;
            private set
            {
                this._employees = value;
                OnPropertyChanged();
            }
        }

        public List<Department> Departments
        {
            get => this._departments;
            private set
            {
                this._departments = value;
                OnPropertyChanged();
            }
        }

        public List<EmployeeRole> Roles
        {
            get => this._roles;
            set
            {
                this._roles = value;
                OnPropertyChanged();
            }
        }

        public delegate void MessageHandler(string message);
        public event MessageHandler MessageEvent;

        private readonly DelegateCommand _addEmployeeCommand;
        private readonly DelegateCommand _clearModifyEmployeeSelectedCommand;
        private readonly DelegateCommand _updateEmployeeCommand;
        private readonly DelegateCommand _removeEmployeeCommand;

        public ICommand AddEmployee => this._addEmployeeCommand;
        public ICommand ClearModifyEmployeeSelected => this._clearModifyEmployeeSelectedCommand;
        public ICommand UpdateEmployee => this._updateEmployeeCommand;
        public ICommand RemoveEmployee => this._removeEmployeeCommand;

        public ManagementViewModel()
        {
            this._addEmployeeCommand = new DelegateCommand(AddEmployee_Event, CanAddEmployee);
            this._clearModifyEmployeeSelectedCommand = new DelegateCommand(ClearModifyEmployeeSelected_Event, CanClearSelectedEmployee);
            this._updateEmployeeCommand = new DelegateCommand(UpdateEmployee_Event, CanUseButton);
            this._removeEmployeeCommand = new DelegateCommand(RemoveEmployee_Event, CanUseButton);

            this.CreateDepartmentPanelVisible = true;
            this.AddItemPanelVisible = true;

            this.Departments = DepartmentManager.GetAllDepartments(false);
            RefreshEmployeeList();
            this.Roles = Enum.GetValues(typeof(EmployeeRole)).Cast<EmployeeRole>().ToList();
        }

        private void RefreshEmployeeList() => this.Employees = EmployeeDatabaseHandler.GetAllEmployees(true);

        private void AddEmployee_Event(object commandParameter)
        {
            string message = "";

            if(!UsernameValidation(EmployeeCreationUsername) || string.IsNullOrEmpty(EmployeeCreationPassword) || string.IsNullOrEmpty(EmployeeCreationSalary))
            {
                message = "Please fill all required fields and try again.";
            }
            else
            {
                if (Int32.TryParse(EmployeeCreationWorkhours, out int workHours) && Decimal.TryParse(EmployeeCreationSalary, out decimal hourlySalary))
                {
                    if (workHours % 4 != 0) message = "Invalid workhours entered. Work hours input needs to be divisible by 4\n(A workshift consists of 4 hours)";
                    else if (hourlySalary < 0) message = "Employee salary must be a positive value";
                    else if (EmployeeCreationSelectedDepartment == null) message = "Please select a department and try again.";
                    else if (!EmployeeDatabaseHandler.IsUniqueUsername(EmployeeCreationUsername)) message = "This username is already taken. Please choose another one and try again.";
                    else
                    {
                        try
                        {
                            EmployeeManager manager = new EmployeeManager();
                            manager.AddEmployee(EmployeeCreationUsername, EmployeeCreationPassword, hourlySalary, EmployeeCreationSelectedRole, EmployeeCreationSelectedDepartment.DepartmentId, workHours, true);
                            message = "Sucessfully added new employee to the system!";
                            EmployeeCreationUsername = "";
                            EmployeeCreationPassword = "";
                            EmployeeCreationSalary = "";
                            EmployeeCreationSelectedDepartment = null;
                            EmployeeCreationWorkhours = "";

                            RefreshEmployeeList();
                        }
                        catch (Exception ex) { message = ex.Message; }
                    }
                }
                else message = "Invalid numeric input. Please check for any mistakes and try again.";
            }

            if (this.MessageEvent != null) this.MessageEvent(message);
        }

        private bool UsernameValidation(string input)
        {
            Regex regEx = new Regex(@"^(?=.{3,20}$)(?![_.])(?!.*[_.]{2})[a-zA-Z0-9._]+(?<![_.])$");
            return (input != null) ? regEx.IsMatch(input) : false;
        }

        private bool CanAddEmployee(object commandParameter)
        {
            return !string.IsNullOrEmpty(EmployeeCreationUsername) && !string.IsNullOrEmpty(EmployeeCreationPassword)
                && !string.IsNullOrEmpty(EmployeeCreationSalary) && !string.IsNullOrEmpty(EmployeeCreationWorkhours)
                && EmployeeCreationSelectedDepartment != null;
        }

        private void ClearModifyEmployeeSelected_Event(object commandParameter) => SelectedEmployee = null;
        private bool CanClearSelectedEmployee(object commandParameter) => SelectedEmployee != null;

        private void SelectedEmployeeFillControls()
        {
            if(SelectedEmployee != null)
            {
                this.SelectedEmployeeFirstName = SelectedEmployee.FirstName;
                this.SelectedEmployeeLastName = SelectedEmployee.LastName;
                this.SelectedEmployeeNationality = SelectedEmployee.Nationality;
                this.SelectedEmployeePhoneNumber = SelectedEmployee.PhoneNumber;
                this.SelectedEmployeeIsFemale = SelectedEmployee.Sex;
                this.SelectedEmployeeSalary = SelectedEmployee.SalaryHourlyRate.ToString();
                this.SelectedEmployeeAddress = SelectedEmployee.Address;
                this.SelectedEmployeeEmail = SelectedEmployee.Email;
                this.SelectedEmployeeBirthdate = SelectedEmployee.DateOfBirth;
            }
        }

        private void UpdateEmployee_Event(object commandParameter)
        {
            string message = "";

            if (SelectedEmployee != null)
            {
                try
                {
                    SelectedEmployee.FirstName = SelectedEmployeeFirstName;
                    SelectedEmployee.LastName = SelectedEmployeeLastName;
                    SelectedEmployee.Nationality = SelectedEmployeeNationality;
                    SelectedEmployee.PhoneNumber = SelectedEmployeePhoneNumber;
                    SelectedEmployee.Sex = SelectedEmployeeIsFemale;
                    SelectedEmployee.SalaryHourlyRate = Decimal.Round(Decimal.Parse(SelectedEmployeeSalary), 2);
                    SelectedEmployee.Address = SelectedEmployeeAddress;
                    SelectedEmployee.Email = SelectedEmployeeEmail;
                    SelectedEmployee.DateOfBirth = SelectedEmployeeBirthdate;

                    EmployeeDatabaseHandler.UpdateDatabaseEntry(SelectedEmployee);
                    RefreshEmployeeList();

                    message = "Successfully updated employee personal information.";
                }
                catch (Exception ex) { message = ex.Message; }
            }
            else message = "Please select an employee and try again.";

            if (this.MessageEvent != null) this.MessageEvent(message); 
        }

        private void RemoveEmployee_Event(object commandParameter)
        {
            string message = "";

            if (SelectedEmployee != null)
            {
                try
                {
                    if (LoggedInUser.role > SelectedEmployee.Role)
                    {
                        EmployeeDatabaseHandler.RemoveFromDatabase(SelectedEmployee.UserID);
                        this.SelectedEmployee = null;
                        RefreshEmployeeList();
                        
                        message = "Employee successfully removed from the system.";
                    }
                    else message = "Can only remove employees with a lower role than you!";
                }
                catch (Exception ex) { message = ex.Message; }
            }
            else message = "Please select an employee and try again.";

            if (this.MessageEvent != null) this.MessageEvent(message);
        }

        private bool CanUseButton(object commandParameter) => true;
    }
}
