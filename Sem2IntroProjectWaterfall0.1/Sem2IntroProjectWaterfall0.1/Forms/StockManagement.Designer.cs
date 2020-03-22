namespace Sem2IntroProjectWaterfall0._1
{
    partial class StockManagement
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnBack = new System.Windows.Forms.Button();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.btnShowRestock = new System.Windows.Forms.Button();
            this.pnlStocks = new System.Windows.Forms.FlowLayoutPanel();
            this.cbDepartments = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(12, 18);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(45, 20);
            this.btnBack.TabIndex = 0;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(63, 18);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(192, 20);
            this.tbSearch.TabIndex = 2;
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            // 
            // btnShowRestock
            // 
            this.btnShowRestock.Location = new System.Drawing.Point(261, 18);
            this.btnShowRestock.Name = "btnShowRestock";
            this.btnShowRestock.Size = new System.Drawing.Size(57, 20);
            this.btnShowRestock.TabIndex = 4;
            this.btnShowRestock.Text = "Restock";
            this.btnShowRestock.UseVisualStyleBackColor = true;
            this.btnShowRestock.Click += new System.EventHandler(this.btnShowRestock_Click);
            // 
            // pnlStocks
            // 
            this.pnlStocks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.pnlStocks.Location = new System.Drawing.Point(12, 79);
            this.pnlStocks.Name = "pnlStocks";
            this.pnlStocks.Size = new System.Drawing.Size(306, 390);
            this.pnlStocks.TabIndex = 5;
            // 
            // cbDepartments
            // 
            this.cbDepartments.FormattingEnabled = true;
            this.cbDepartments.Location = new System.Drawing.Point(82, 43);
            this.cbDepartments.Margin = new System.Windows.Forms.Padding(2);
            this.cbDepartments.Name = "cbDepartments";
            this.cbDepartments.Size = new System.Drawing.Size(173, 21);
            this.cbDepartments.TabIndex = 25;
            this.cbDepartments.DropDown += new System.EventHandler(this.CbDepartments_DropDown);
            this.cbDepartments.SelectedIndexChanged += new System.EventHandler(this.CbDepartments_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Department:";
            // 
            // StockManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 481);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbDepartments);
            this.Controls.Add(this.pnlStocks);
            this.Controls.Add(this.btnShowRestock);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.btnBack);
            this.Name = "StockManagement";
            this.Text = "StockManagement";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StockManagement_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Button btnShowRestock;
        private System.Windows.Forms.FlowLayoutPanel pnlStocks;
        private System.Windows.Forms.ComboBox cbDepartments;
        private System.Windows.Forms.Label label1;
    }
}