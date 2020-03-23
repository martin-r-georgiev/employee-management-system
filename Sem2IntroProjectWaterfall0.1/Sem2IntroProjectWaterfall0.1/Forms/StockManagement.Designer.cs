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
            this.btnBack.Location = new System.Drawing.Point(16, 22);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(60, 25);
            this.btnBack.TabIndex = 0;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(84, 22);
            this.tbSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(255, 22);
            this.tbSearch.TabIndex = 2;
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            // 
            // btnShowRestock
            // 
            this.btnShowRestock.Location = new System.Drawing.Point(348, 22);
            this.btnShowRestock.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnShowRestock.Name = "btnShowRestock";
            this.btnShowRestock.Size = new System.Drawing.Size(76, 25);
            this.btnShowRestock.TabIndex = 4;
            this.btnShowRestock.Text = "Restock";
            this.btnShowRestock.UseVisualStyleBackColor = true;
            this.btnShowRestock.Click += new System.EventHandler(this.btnShowRestock_Click);
            // 
            // pnlStocks
            // 
            this.pnlStocks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.pnlStocks.Location = new System.Drawing.Point(16, 97);
            this.pnlStocks.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlStocks.Name = "pnlStocks";
            this.pnlStocks.Size = new System.Drawing.Size(408, 480);
            this.pnlStocks.TabIndex = 5;
            // 
            // cbDepartments
            // 
            this.cbDepartments.FormattingEnabled = true;
            this.cbDepartments.Location = new System.Drawing.Point(109, 53);
            this.cbDepartments.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbDepartments.Name = "cbDepartments";
            this.cbDepartments.Size = new System.Drawing.Size(229, 24);
            this.cbDepartments.TabIndex = 25;
            this.cbDepartments.DropDown += new System.EventHandler(this.CbDepartments_DropDown);
            this.cbDepartments.SelectedIndexChanged += new System.EventHandler(this.CbDepartments_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 57);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 17);
            this.label1.TabIndex = 26;
            this.label1.Text = "Department:";
            // 
            // StockManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 592);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbDepartments);
            this.Controls.Add(this.pnlStocks);
            this.Controls.Add(this.btnShowRestock);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.btnBack);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "StockManagement";
            this.Text = "StockManagement";
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