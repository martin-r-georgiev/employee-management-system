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

namespace MediaBazaarApplicationWPF.Views
{
    /// <summary>
    /// Interaction logic for StockControl.xaml
    /// </summary>
    public partial class StockControl : UserControl
    {
        StockItem selectedItem;
        public StockControl(StockItem item, string depName)
        {
            InitializeComponent();
            selectedItem = item;
            this.DptName.Text = depName;
            this.lblItemName.Text = item.Name;
            this.lblQuantity.Content = item.CurrentAmount.ToString();
            this.lblThreshold.Content = item.Threshold.ToString();
            AdjustColor();
        }
        void AdjustColor()
        {
            if (selectedItem.CurrentAmount < selectedItem.Threshold) lblQuantity.Foreground = Brushes.Red;
            else lblQuantity.Foreground = Brushes.Black;
        }
        private void btnDecrease_Click(object sender, RoutedEventArgs e)
        {
            if (selectedItem.CurrentAmount > 0)
            {

                if (lblQuantity.Visibility == Visibility.Visible)
                {
                    selectedItem.CurrentAmount--;
                    this.lblQuantity.Content = selectedItem.CurrentAmount.ToString();
                }
                else
                {
                    if (int.TryParse(tbQuantity.Text, out int amount))
                    {
                        if (amount > 0)
                        {
                            amount--;
                            this.selectedItem.CurrentAmount = amount;
                            tbQuantity.Text = selectedItem.CurrentAmount.ToString();
                        }
                        else
                        {
                            selectedItem.CurrentAmount--;
                            this.tbQuantity.Text = selectedItem.CurrentAmount.ToString();
                        }
                    }
                    else MessageBox.Show("Please enter a valid value");
                }
                AdjustColor();
                StockItemDatabaseHandler.UpdateStockItem(selectedItem);
            }
            else MessageBox.Show("Current ammount cannot be negative!");
        }

        private void btnIncrease_Click(object sender, RoutedEventArgs e)
        {
            if (lblQuantity.Visibility == Visibility.Visible)
            {
                selectedItem.CurrentAmount++;
                this.lblQuantity.Content = selectedItem.CurrentAmount.ToString();
            }
            else
            {
                if (int.TryParse(tbQuantity.Text, out int ammount))
                {
                    if (ammount >= 0)
                    {
                        ammount++;
                        selectedItem.CurrentAmount = ammount;
                        this.tbQuantity.Text = selectedItem.CurrentAmount.ToString();
                    }
                    else
                    {
                        selectedItem.CurrentAmount++;
                        this.tbQuantity.Text = selectedItem.CurrentAmount.ToString();
                    }
                }
                else MessageBox.Show("Please enter a valid value!");
            }
            AdjustColor();
            StockItemDatabaseHandler.UpdateStockItem(selectedItem);
        }

        private void lblQuantity_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (tbThreshold.Visibility == Visibility.Visible) 
            {
                Adjust(lblThreshold, tbThreshold);
            }

            this.lblQuantity.Visibility = Visibility.Hidden;
            this.tbQuantity.Visibility = Visibility.Visible;
            this.tbQuantity.Text = selectedItem.CurrentAmount.ToString();
        }

        private void lblThreshold_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (LoggedInUser.role != EmployeeRole.Worker)
            {
                if (tbQuantity.Visibility == Visibility.Visible)
                {
                    Adjust(lblQuantity, tbQuantity);
                }

                this.lblThreshold.Visibility = Visibility.Hidden;
                this.tbThreshold.Visibility = Visibility.Visible;
                this.tbThreshold.Text = selectedItem.Threshold.ToString();
                tbThreshold.Focus();
            }
            else MessageBox.Show("You cannot change the threshold, please contact a manager.");
        }

        private void tbQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Adjust(lblQuantity, tbQuantity);
            }
        }

        private void tbThreshold_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Adjust(lblThreshold, tbThreshold);
            }
        }

        void Adjust(Label label, TextBox tb)
        {
            string quantity = tb.Text;

            if (String.IsNullOrWhiteSpace(quantity)) quantity = "0";

            if (int.TryParse(quantity, out int number))
            {
                if (number >= 0)
                {
                    label.Visibility = Visibility.Visible;
                    tb.Visibility = Visibility.Hidden;
                    if (label == this.lblQuantity)
                    {
                        this.selectedItem.CurrentAmount = number;
                        label.Content = selectedItem.CurrentAmount.ToString();
                    }
                    else if (label == this.lblThreshold)
                    {
                        this.selectedItem.Threshold = number;
                        label.Content = selectedItem.Threshold.ToString();
                    }
                    AdjustColor();
                    StockItemDatabaseHandler.UpdateStockItem(selectedItem);
                }
                else MessageBox.Show("Please enter a positive value");
            }
            else MessageBox.Show("Please enter a valid value");
        }

    }
}

