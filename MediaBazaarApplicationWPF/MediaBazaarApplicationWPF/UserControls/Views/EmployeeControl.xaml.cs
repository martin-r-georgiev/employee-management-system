using DocumentFormat.OpenXml.Drawing;
using MediaBazaarApplicationWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MediaBazaarApplicationWPF.UserControls.Views
{
    /// <summary>
    /// Interaction logic for EmployeeControl.xaml
    /// </summary>
    public partial class EmployeeControl : UserControl
    {
        private string _departmentName;
        private Employee _selectedEmployee;
        private EmployeeListingViewModel model;
        public Employee SelectedEmployee
        {
            get { return _selectedEmployee; }
            set {
                _selectedEmployee = value;
                LblFirstLetter.Text = value.Name.Substring(0, 1).ToUpper();
                switch (value.Role)
                {
                    case EmployeeRole.Admin: firstLetterBorder.Background = Brushes.YellowGreen; break;
                    case EmployeeRole.Owner: firstLetterBorder.Background = Brushes.Firebrick; break;
                    case EmployeeRole.Manager: firstLetterBorder.Background = Brushes.MediumPurple; break;
                    case EmployeeRole.Worker: firstLetterBorder.Background = Brushes.LightBlue; break;
                }
                LblName.Text = value.FullName;
            }
        }

        public string DepartmentName
        {
            get { return _departmentName; }
            set {
                _departmentName = value;
                LblDepartment.Text = value;
            }
        }

        public EmployeeControl(Employee selectedEmployee, string departmentName, EmployeeListingViewModel model)
        {
            InitializeComponent();
            this.SelectedEmployee = selectedEmployee;
            this.DepartmentName = departmentName;
            this.model = model;
        }

        private void LblDepartment_MouseEnter(object sender, MouseEventArgs e)
        {
           
            this.Background = Brushes.LightGray;
            
            //this.firstLetterBorder.Background = Brushes.LightGray;
            //this.panelSidebar.BackColor = Color.LightGray;
        }

        private void LblDepartment_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Background = Brushes.White;
            //this.firstLetterBorder.Background = Brushes.White;
        }

        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            model.RefreshGUI(SelectedEmployee, DepartmentName);
        }
    }
}
