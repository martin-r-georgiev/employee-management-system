using MediaBazaarApplicationWPF.UserControls;
using MediaBazaarApplicationWPF.ViewModels;
using MediaBazaarApplicationWPF.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MediaBazaarApplicationWPF
{
    class StockViewModel : BaseViewModel
    {
        private readonly RestockCommand _restockCommand;
        public ICommand Restock => _restockCommand;

        private List<Department> _departments;
        public List<Department> Departments => this._departments;
        private Department _selectedDepartment;

        public Department SelectedDepartment
        {
            get { return _selectedDepartment; }
            set {
                _selectedDepartment = value;
                BtnRestockContent = "Restock";
                RefreshInventory(value.DepartmentId);
                OnPropertyChanged();
            }
        }
        private string _searchContent;

        public string SearchContent
        {
            get { return _searchContent; }
            set
            { 
                _searchContent = value;
                if (BtnRestockContent == "All stock")
                    BtnRestockContent = "Restock";
                Stocks.Clear();
                foreach (StockItem s in CurrentInventory)
                    if (s.Name.ToLower().Contains(value.ToLower()))
                        Stocks.Add(new StockControl(s));
                OnPropertyChanged(); 
            }
        }

        private string _btnRestockContent;

        public string BtnRestockContent
        {
            get { return _btnRestockContent; }
            set { _btnRestockContent = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<StockControl> _stocks;
        public ObservableCollection<StockControl> Stocks => this._stocks;

        private List<StockItem> currentInventory;
        public List<StockItem> CurrentInventory
        {
            get => this.currentInventory;
            set
            {
                this.currentInventory = value;
                OnPropertyChanged();
            }
        }
        private bool cbDepartmentsVisible, lblDepartmentsVisible;

        public bool LblDepartmentsVisible
        {
            get => this.lblDepartmentsVisible;
            private set
            {
                this.lblDepartmentsVisible = value;
                OnPropertyChanged();
            }
        }

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
                cbDepartmentsVisible = false;
                lblDepartmentsVisible = false;
            } else
            {
                cbDepartmentsVisible = true;
                lblDepartmentsVisible = true;
            }
        }

        void RefreshInventory(string depId)
        {
            this.CurrentInventory = StockItemDatabaseHandler.GetAllStockFromDepartment(depId);
            Stocks.Clear();
            foreach (StockItem s in currentInventory) Stocks.Add(new StockControl(s));
        }

        public StockViewModel()
        {
            _departments = DepartmentManager.GetAllDepartments(false);
            _stocks = new ObservableCollection<StockControl>();
            RefreshInventory(LoggedInUser.departmentID);
            RefreshGUI();
            _restockCommand = new RestockCommand(this);
            BtnRestockContent = "Restock";
        }
	}
}
