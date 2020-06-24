using DocumentFormat.OpenXml.Bibliography;
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
                this._updateEmployeeCommand.InvokeCanExecuteChanged();
                this._removeEmployeeCommand.InvokeCanExecuteChanged();
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

        public DateTime? SelectedEmployeeBirthdateLimit => DateTime.Now.AddYears(-16);

        #endregion

        #region # Department Creation Variables + Properties

        private string _departmentCreationName;
        private string _departmentCreationAddress;

        public string DepartmentCreationName
        {
            get => this._departmentCreationName;
            set
            {
                this._departmentCreationName = value;
                OnPropertyChanged();
                this._addDepartmentCommand.InvokeCanExecuteChanged();
            }
        }

        public string DepartmentCreationAddress
        {
            get => this._departmentCreationAddress;
            set
            {
                this._departmentCreationAddress = value;
                OnPropertyChanged();
                this._addDepartmentCommand.InvokeCanExecuteChanged();
            }
        }

        #endregion

        #region # Department Modify Variables + Properties

        private Department _departmentModifySelectedDepartment;
        private string _departmentModifyName;
        private string _departmentModifyAddress;

        private Employee _departmentModifySelectedEmployee;

        public Department DepartmentModifySelectedDepartment
        {
            get => this._departmentModifySelectedDepartment;
            set
            {
                this._departmentModifySelectedDepartment = value;
                SelectedDepartmentFillControls();
                this._updateDepartmentCommand.InvokeCanExecuteChanged();
                this._removeDepartmentCommand.InvokeCanExecuteChanged(); 
                OnPropertyChanged();
                OnPropertyChanged("DepartmentModifyEmployees");
            }
        }

        public string DepartmentModifyName
        {
            get => this._departmentModifyName;
            set
            {
                this._departmentModifyName = value;
                OnPropertyChanged();
            }
        }

        public string DepartmentModifyAddress
        {
            get => this._departmentModifyAddress;
            set
            {
                this._departmentModifyAddress = value;
                OnPropertyChanged();
            }
        }

        public List<Employee> DepartmentModifyEmployees
        {
            get
            {
                if (DepartmentModifySelectedDepartment != null) return Employees.FindAll(e => e.DepartmentID != DepartmentModifySelectedDepartment.DepartmentId);
                else return new List<Employee>();
            }
        }

        public Employee DepartmentModifySelectedEmployee
        {
            get => this._departmentModifySelectedEmployee;
            set
            {
                this._departmentModifySelectedEmployee = value;
                OnPropertyChanged();
                this._assignEmployeeToDepartmentCommand.InvokeCanExecuteChanged();
            }
        }

        #endregion

        #region # Stock Creation Variables + Properties

        private string _stockCreationName;

        public string StockCreationName
        {
            get => this._stockCreationName;
            set
            {
                this._stockCreationName = value;
                OnPropertyChanged();
                this._addStockItemCommand.InvokeCanExecuteChanged();
            }
        }

        #endregion

        #region # Stock Add/Remove Item Variables + Properties

        private StockItem _stockItemSelectedItem;
        private Department _stockItemSelectedDepartment;
        private string _stockItemCurrentAmount;
        private string _stockItemThreshold;
        private bool _stockItemRemoveCompletely;

        public StockItem StockItemSelectedItem
        {
            get => this._stockItemSelectedItem;
            set
            {
                this._stockItemSelectedItem = value;
                OnPropertyChanged();
                SelectedStockItemFillControls();
                this._updateStockItemCommand.InvokeCanExecuteChanged();
                this._removeStockItemCommand.InvokeCanExecuteChanged();
            }
        }

        public Department StockItemSelectedDepartment
        {
            get => this._stockItemSelectedDepartment;
            set
            {
                this._stockItemSelectedDepartment = value;
                OnPropertyChanged();
                SelectedStockItemFillControls();
                this._updateStockItemCommand.InvokeCanExecuteChanged();
                this._removeStockItemCommand.InvokeCanExecuteChanged();
            }
        }

        public string StockItemCurrentAmount
        {
            get => this._stockItemCurrentAmount;
            set
            {
                this._stockItemCurrentAmount = value;
                OnPropertyChanged();
            }
        }

        public string StockItemThreshold
        {
            get => this._stockItemThreshold;
            set
            {
                this._stockItemThreshold = value;
                OnPropertyChanged();
            }
        }

        public bool StockItemRemoveCompletely
        {
            get => this._stockItemRemoveCompletely;
            set
            {
                this._stockItemRemoveCompletely = value;
                OnPropertyChanged();
                this._removeStockItemCommand.InvokeCanExecuteChanged();
            }
        }

        #endregion

        //Combobox Data
        private List<Employee> _employees;
        private List<Department> _departments;
        private List<EmployeeRole> _roles;
        private List<StockItem> _stockItems;

        public List<Employee> Employees
        {
            get => this._employees;
            private set
            {
                this._employees = value;
                OnPropertyChanged();
                OnPropertyChanged("DepartmentModifyEmployees");
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

        public List<StockItem> StockItems
        {
            get => this._stockItems;
            set
            {
                this._stockItems = value;
                OnPropertyChanged();
            }
        }

        public delegate void MessageHandler(string message);
        public event MessageHandler MessageEvent;

        private readonly DelegateCommand _addEmployeeCommand;

        private readonly DelegateCommand _clearModifyEmployeeSelectedCommand;
        private readonly DelegateCommand _updateEmployeeCommand;
        private readonly DelegateCommand _removeEmployeeCommand;

        private readonly DelegateCommand _addDepartmentCommand;

        private readonly DelegateCommand _assignEmployeeToDepartmentCommand;
        private readonly DelegateCommand _updateDepartmentCommand;
        private readonly DelegateCommand _removeDepartmentCommand;

        private readonly DelegateCommand _addStockItemCommand;

        private readonly DelegateCommand _updateStockItemCommand;
        private readonly DelegateCommand _removeStockItemCommand;

        public ICommand AddEmployee => this._addEmployeeCommand;
        public ICommand ClearModifyEmployeeSelected => this._clearModifyEmployeeSelectedCommand;
        public ICommand UpdateEmployee => this._updateEmployeeCommand;
        public ICommand RemoveEmployee => this._removeEmployeeCommand;
        public ICommand AddDepartment => this._addDepartmentCommand;
        public ICommand AssignEmployeeToDepartment => this._assignEmployeeToDepartmentCommand;
        public ICommand UpdateDepartment => this._updateDepartmentCommand;
        public ICommand RemoveDepartment => this._removeDepartmentCommand;
        public ICommand AddStockItem => this._addStockItemCommand;
        public ICommand UpdateStockItem => this._updateStockItemCommand;
        public ICommand RemoveStockItem => this._removeStockItemCommand;

        public ManagementViewModel()
        {
            this._addEmployeeCommand = new DelegateCommand(AddEmployee_Event, CanAddEmployee);
            this._clearModifyEmployeeSelectedCommand = new DelegateCommand(ClearModifyEmployeeSelected_Event, CanClearSelectedEmployee);
            this._updateEmployeeCommand = new DelegateCommand(UpdateEmployee_Event, CanModifyEmployeeButtons);
            this._removeEmployeeCommand = new DelegateCommand(RemoveEmployee_Event, CanModifyEmployeeButtons);
            this._addDepartmentCommand = new DelegateCommand(AddDepartment_Event, CanAddDepartment);
            this._assignEmployeeToDepartmentCommand = new DelegateCommand(AssignEmployeeToDepartment_Event, CanAssignEmployeeToDepartment);
            this._updateDepartmentCommand = new DelegateCommand(UpdateDepartment_Event, CanUseModifyDepartmentButtons);
            this._removeDepartmentCommand = new DelegateCommand(RemoveDepartment_Event, CanUseModifyDepartmentButtons);
            this._addStockItemCommand = new DelegateCommand(AddStockItem_Event, CanAddStockItem);
            this._updateStockItemCommand = new DelegateCommand(UpdateStockItem_Event, CanModifyStockItem);
            this._removeStockItemCommand = new DelegateCommand(RemoveStockItem_Event, CanRemoveStockItem);

            this.CreateDepartmentPanelVisible = true;
            this.AddItemPanelVisible = true;

            RefreshDepartmentList();
            RefreshEmployeeList();
            RefreshStockList();
            RefreshRolesList();
            
        }

        private void RefreshEmployeeList() => this.Employees = EmployeeDatabaseHandler.GetAllEmployees(true);
        private void RefreshDepartmentList() => this.Departments = DepartmentManager.GetAllDepartments(true);
        private void RefreshStockList() => this.StockItems = StockItemDatabaseHandler.ListAllItemsFromStockItem();

        private void RefreshRolesList()
        {
            this.Roles = new List<EmployeeRole>();

            foreach (EmployeeRole role in Enum.GetValues(typeof(EmployeeRole)))
            {
                if (role < LoggedInUser.role || LoggedInUser.role == EmployeeRole.Owner) this.Roles.Add(role);
            }
        }

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
                    else if (workHours > 60) message = "Work hours maximum for an employee is 60 hours.";
                    else if (hourlySalary < 0) message = "Employee salary must be a positive value";
                    else if (EmployeeCreationSelectedDepartment == null) message = "Please select a department and try again.";
                    else if (!EmployeeDatabaseHandler.IsUniqueUsername(EmployeeCreationUsername)) message = "This username is already taken. Please choose another one and try again.";
                    else
                    {
                        try
                        {
                            EmployeeManager manager = new EmployeeManager();
                            Employee ToAdd= manager.AddEmployee(EmployeeCreationUsername, EmployeeCreationPassword, hourlySalary, EmployeeCreationSelectedRole, EmployeeCreationSelectedDepartment.DepartmentId, workHours, true);
                            HistoryLog.AddToHistoryLog(ToAdd);
                            message = "Sucessfully added new employee to system.";                         
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

        private void ClearModifyEmployeeSelected_Event(object commandParameter)
        {
            if (SelectedEmployee != null)
            {
                this.SelectedEmployeeFirstName = null;
                this.SelectedEmployeeLastName = null;
                this.SelectedEmployeeNationality = null;
                this.SelectedEmployeePhoneNumber = null;
                this.SelectedEmployeeSalary = null;
                this.SelectedEmployeeIsMale = null;
                this.SelectedEmployeeIsFemale = null;
                this.SelectedEmployeeAddress = null;
                this.SelectedEmployeeEmail = null;
                this.SelectedEmployeeBirthdate = null;
                this.SelectedEmployee = null;
            }     
        }

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
                    SelectedEmployee.FirstName = (!string.IsNullOrEmpty(SelectedEmployeeFirstName)) ? SelectedEmployeeFirstName : null;
                    SelectedEmployee.LastName = (!string.IsNullOrEmpty(SelectedEmployeeLastName)) ? SelectedEmployeeLastName : null;
                    SelectedEmployee.Nationality = (!string.IsNullOrEmpty(SelectedEmployeeNationality)) ? SelectedEmployeeNationality : null;
                    SelectedEmployee.PhoneNumber = (!string.IsNullOrEmpty(SelectedEmployeePhoneNumber)) ? SelectedEmployeePhoneNumber : null;
                    SelectedEmployee.Sex = SelectedEmployeeIsFemale;
                    SelectedEmployee.SalaryHourlyRate = (!string.IsNullOrEmpty(SelectedEmployeeSalary)) ? Decimal.Round(Decimal.Parse(SelectedEmployeeSalary), 2) : 0;
                    SelectedEmployee.Address = (!string.IsNullOrEmpty(SelectedEmployeeAddress)) ? SelectedEmployeeAddress : null;
                    SelectedEmployee.Email = (!string.IsNullOrEmpty(SelectedEmployeeEmail)) ? SelectedEmployeeEmail : null;
                    SelectedEmployee.DateOfBirth = (SelectedEmployeeBirthdate.HasValue) ? SelectedEmployeeBirthdate : null;

                    EmployeeDatabaseHandler.UpdateDatabaseEntry(SelectedEmployee);
                    HistoryLog.UpdateHistoryLog(SelectedEmployee);
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
                        HistoryLog.UpdateHistoryLogDeleted(SelectedEmployee.UserID);
                        this.SelectedEmployeeFirstName = null;
                        this.SelectedEmployeeLastName = null;
                        this.SelectedEmployeeNationality = null;
                        this.SelectedEmployeePhoneNumber = null;
                        this.SelectedEmployeeSalary = null;
                        this.SelectedEmployeeIsMale = null;
                        this.SelectedEmployeeIsFemale = null;
                        this.SelectedEmployeeAddress = null;
                        this.SelectedEmployeeEmail = null;
                        this.SelectedEmployeeBirthdate = null;
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

        private bool CanModifyEmployeeButtons(object commandParameter) => (SelectedEmployee != null) ? true : false;

        private void AddDepartment_Event(object commandParameter)
        {
            string message = "";

            if (!string.IsNullOrEmpty(DepartmentCreationName) && !string.IsNullOrEmpty(DepartmentCreationAddress))
            {
                try
                {
                    DepartmentManager.AddDepartment(DepartmentCreationName, DepartmentCreationAddress);
                    DepartmentCreationName = "";
                    DepartmentCreationAddress = "";

                    message = "Successfully added new department to system.";
                }
                catch (Exception ex) { message = ex.Message; }
                finally { RefreshDepartmentList(); }
            }
            else message = "Please fill all required fields and try again.";

            if (this.MessageEvent != null) this.MessageEvent(message);
        }

        private bool CanAddDepartment(object commandParameter) => !string.IsNullOrEmpty(DepartmentCreationName) && !string.IsNullOrEmpty(DepartmentCreationAddress);

        private void SelectedDepartmentFillControls()
        {
            if (DepartmentModifySelectedDepartment != null)
            {
                this.DepartmentModifyName = DepartmentModifySelectedDepartment.Name;
                this.DepartmentModifyAddress = DepartmentModifySelectedDepartment.Address;
            }
        }

        private void AssignEmployeeToDepartment_Event(object commandParameter)
        {
            string message = "";

            try
            {
                if (DepartmentModifySelectedEmployee != null)
                {
                    DepartmentModifySelectedDepartment.AssignEmployeeTo(DepartmentModifySelectedEmployee, DepartmentModifySelectedDepartment.DepartmentId);

                    message = $"Successfully moved {DepartmentModifySelectedEmployee.FullName} to {DepartmentModifySelectedDepartment.Name}";
                }
            }
            catch (Exception ex) { message = ex.Message; }
            finally { DepartmentModifySelectedEmployee = null; SelectedEmployee = null; RefreshEmployeeList(); }

            if (this.MessageEvent != null) this.MessageEvent(message);
        }

        private bool CanAssignEmployeeToDepartment(object commandParameter) => (DepartmentModifySelectedEmployee != null) ? true : false;

        private void UpdateDepartment_Event(object commandParameter)
        {
            if (DepartmentModifySelectedDepartment != null)
            {
                string message = "";

                if (!string.IsNullOrEmpty(DepartmentModifyName) && !string.IsNullOrEmpty(DepartmentModifyAddress))
                {
                    try
                    {
                        DepartmentManager.UpdateDepartment(DepartmentModifySelectedDepartment.DepartmentId, DepartmentModifyName, DepartmentModifyAddress);
                        DepartmentModifyName = "";
                        DepartmentModifyAddress = "";

                        message = "Successfully updated department information.";
                    }
                    catch (Exception ex) { message = ex.Message; }
                    finally { DepartmentModifySelectedDepartment = null; RefreshDepartmentList(); }
                }
                else message = "Please fill all required fields and try again.";

                if (this.MessageEvent != null) this.MessageEvent(message);
            }
        }

        private void RemoveDepartment_Event(object commandParameter)
        {
            if(DepartmentModifySelectedDepartment != null)
            {
                string message = "";

                try
                {
                    if (DepartmentModifySelectedDepartment.Employees.Exists(e => e.Role == LoggedInUser.role))
                    {
                        message = "Cannot remove a department if there is someone in it with the same or higher role than you. Please contact the owner!";
                    }
                    else
                    {
                        DepartmentManager.RemoveFromDatabase(DepartmentModifySelectedDepartment);
                        DepartmentModifyName = "";
                        DepartmentModifyAddress = "";

                        message = $"Department '{DepartmentModifySelectedDepartment.Name}' has successfully been removed from the system.";
                    }
                }
                catch (Exception ex) { message = ex.Message; }
                finally { DepartmentModifySelectedDepartment = null; EmployeeCreationSelectedDepartment = null; RefreshDepartmentList(); }

                if (this.MessageEvent != null) this.MessageEvent(message);
            }
        }

        private bool CanUseModifyDepartmentButtons(object commandParameter) => (DepartmentModifySelectedDepartment != null) ? true : false;

        private void AddStockItem_Event(object commandParameter)
        {
            string message = "";

            if (!string.IsNullOrEmpty(StockCreationName))
            {
                try
                {
                    StockItemDatabaseHandler.AddStockItem(StockCreationName);
                    message = $"Successfully added item '{StockCreationName}' to system.";
                    StockCreationName = "";
                    RefreshStockList();
                }
                catch (Exception ex) { message = ex.Message; }
            }
            else message = "Please fill all required fields and try again.";

            if (this.MessageEvent != null) this.MessageEvent(message);
        }

        private void SelectedStockItemFillControls()
        {
            if (StockItemSelectedItem != null && StockItemSelectedDepartment != null)
            {
                StockItem item = StockItemDatabaseHandler.GetStockItemFromDepartment(StockItemSelectedItem.StockID, StockItemSelectedDepartment.DepartmentId);

                this.StockItemCurrentAmount = (item != null) ? item.CurrentAmount.ToString() : "0";
                this.StockItemThreshold = (item != null) ? item.Threshold.ToString() : "0";            
            }
        }

        private bool CanAddStockItem(object commandParameter) => !string.IsNullOrEmpty(StockCreationName);

        private void UpdateStockItem_Event(object commandParameter)
        {
            string message = "";

            if (StockItemSelectedDepartment != null && StockItemSelectedItem != null)
            {
                if (Int32.TryParse(StockItemCurrentAmount, out int currentAmount) && Int32.TryParse(StockItemThreshold, out int threshold))
                {
                    if (currentAmount >= 0 && threshold >= 0)
                    {
                        try
                        {
                            StockItemSelectedItem.DepartmentID = StockItemSelectedDepartment.DepartmentId;
                            StockItemSelectedItem.CurrentAmount = currentAmount;
                            StockItemSelectedItem.Threshold = threshold;
                            StockItemDatabaseHandler.AddStockItemToStock(StockItemSelectedItem);
                            message = $"Successfully updated item entry for department '{StockItemSelectedDepartment.Name}'";
                            ClearStockItemSelection();
                        }
                        catch (Exception ex) { message = ex.Message; }
                    }
                    else message = "An item's current amount & threshold can only be positive values.";
                }
                else message = "Invalid item current amount and/or threshold values. Please check for any mistakes and try again.";
            }
            else message = "Please select an item and a department and try again.";

            if (this.MessageEvent != null) this.MessageEvent(message);
        }

        private void RemoveStockItem_Event(object commandParameter)
        {
            string message = "";

            if (StockItemSelectedItem != null)
            {
                if(StockItemRemoveCompletely == false)
                {
                    if (StockItemSelectedDepartment != null)
                    {
                        try
                        {
                            StockItemDatabaseHandler.RemoveStockItemFromDepartment(StockItemSelectedItem, StockItemSelectedDepartment.DepartmentId);
                            message = $"Successfully removed item entry from department '{StockItemSelectedDepartment.Name}'";
                        }
                        catch (Exception ex) { message = ex.Message; }
                    }
                    else message = "Please select an item and a department and try again.";
                }
                else
                {
                    try
                    {
                        StockItemDatabaseHandler.RemoveStockItemGlobally(StockItemSelectedItem);
                        message = $"Item '{StockItemSelectedItem.Name}' has been removed from the system.";
                    }
                    catch (Exception ex) { message = ex.Message; }
                }
                ClearStockItemSelection();
            }
            else message = "Please select an item and try again.";

            if (this.MessageEvent != null) this.MessageEvent(message);
        }

        private void ClearStockItemSelection()
        {
            this.StockItemSelectedDepartment = null;
            this.StockItemSelectedItem = null;
            this.StockItemCurrentAmount = "";
            this.StockItemThreshold = "";
            this.StockItemRemoveCompletely = false;
            RefreshStockList();
        }

        private bool CanModifyStockItem(object commandParameter) => (StockItemSelectedDepartment != null && StockItemSelectedDepartment != null) ? true : false;

        private bool CanRemoveStockItem(object commandParameter)
        {
            if(StockItemRemoveCompletely == true) return (StockItemSelectedItem != null) ? true : false;
            else return (StockItemSelectedItem != null && StockItemSelectedDepartment != null) ? true : false;
        }
    }
}
