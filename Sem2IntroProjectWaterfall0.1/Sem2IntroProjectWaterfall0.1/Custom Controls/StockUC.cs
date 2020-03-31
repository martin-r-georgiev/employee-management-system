using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sem2IntroProjectWaterfall0._1
{
    public partial class StockUC : UserControl
    {
        StockItem selectedItem;
        public StockUC(StockItem item)
        {
            InitializeComponent();
            selectedItem = item;
            this.lblStockName.Text = item.Name;
            this.lblCurrentAmount.Text = item.CurrentAmount.ToString();
            this.lblThreshold.Text = item.Threshold.ToString();
            if (selectedItem.CurrentAmount < selectedItem.Threshold) lblCurrentAmount.ForeColor = Color.Red;
            else lblCurrentAmount.ForeColor = Color.Black;
        }

        private void btnDecrease_Click(object sender, EventArgs e)
        {
            if (selectedItem.CurrentAmount > 0)
            {

                if (lblCurrentAmount.Visible)
                {
                    selectedItem.CurrentAmount--;
                    this.lblCurrentAmount.Text = selectedItem.CurrentAmount.ToString();
                }
                else
                {
                    if (int.TryParse(tbCurrentAmount.Text, out int amount))
                    {
                        if (amount > 0)
                        {
                            amount--;
                            this.selectedItem.CurrentAmount = amount;
                            tbCurrentAmount.Text = selectedItem.CurrentAmount.ToString();
                        }
                        else
                        {
                            selectedItem.CurrentAmount--;
                            this.tbCurrentAmount.Text = selectedItem.CurrentAmount.ToString();
                        }
                    }
                    else MessageBox.Show("Please enter a valid value");             
                }
                if (selectedItem.CurrentAmount < selectedItem.Threshold) lblCurrentAmount.ForeColor = Color.Red;
                else lblCurrentAmount.ForeColor = Color.Black;
            }
            else MessageBox.Show("Current ammount cannot be negative!");
        }

        private void btnIncrease_Click(object sender, EventArgs e)
        {
            if (lblCurrentAmount.Visible)
            {
                selectedItem.CurrentAmount++;
                this.lblCurrentAmount.Text = selectedItem.CurrentAmount.ToString();
            }
            else
            {
                if (int.TryParse(tbCurrentAmount.Text, out int ammount))
                {
                    if (ammount >= 0)
                    {
                        ammount++;
                        selectedItem.CurrentAmount = ammount;
                        this.tbCurrentAmount.Text = selectedItem.CurrentAmount.ToString();
                    } else
                    {
                        selectedItem.CurrentAmount++;
                        this.tbCurrentAmount.Text = selectedItem.CurrentAmount.ToString();
                    }
                }
                else MessageBox.Show("Please enter a valid value!");
            }
            if (selectedItem.CurrentAmount < selectedItem.Threshold) lblCurrentAmount.ForeColor = Color.Red;
            else lblCurrentAmount.ForeColor = Color.Black;
        }

        private void lblCurrentAmount_DoubleClick(object sender, EventArgs e)
        {
            this.lblCurrentAmount.Visible = false;
            this.tbCurrentAmount.Visible = true;
            this.tbCurrentAmount.Text = selectedItem.CurrentAmount.ToString();
        }

        private void lblThreshold_DoubleClick(object sender, EventArgs e)
        {
            this.lblThreshold.Visible = false;
            this.tbThreshold.Visible = true;
            this.tbThreshold.Text = selectedItem.Threshold.ToString();
        }

        private void tbCurrentAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (int.TryParse(this.tbCurrentAmount.Text, out int currentAmmount))
                {
                    if (currentAmmount >= 0)
                    {
                        this.selectedItem.CurrentAmount = currentAmmount;
                        this.lblCurrentAmount.Visible = true;
                        this.tbCurrentAmount.Visible = false;
                        this.lblCurrentAmount.Text = selectedItem.CurrentAmount.ToString();
                        if (selectedItem.CurrentAmount < selectedItem.Threshold) lblCurrentAmount.ForeColor = Color.Red;
                        else lblCurrentAmount.ForeColor = Color.Black;
                    }
                    else MessageBox.Show("Please enter a positive value");
                }
                else MessageBox.Show("Please enter a valid value");
            }
        }

        private void tbThreshold_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (int.TryParse(tbThreshold.Text, out int threshold))
                {
                    if (threshold >= 0)
                    {
                        this.selectedItem.Threshold = Convert.ToInt32(tbThreshold.Text);
                        this.lblThreshold.Visible = true;
                        this.tbThreshold.Visible = false;
                        this.lblThreshold.Text = selectedItem.Threshold.ToString();
                        if (selectedItem.CurrentAmount < selectedItem.Threshold) lblCurrentAmount.ForeColor = Color.Red;
                        else lblCurrentAmount.ForeColor = Color.Black;
                    }
                    else MessageBox.Show("Please enter a positive value");
                }
                else MessageBox.Show("Please enter a valid value");
            }
        }
    }
}
