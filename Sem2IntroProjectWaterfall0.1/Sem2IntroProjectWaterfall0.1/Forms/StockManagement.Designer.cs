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
            this.pnlStocks.Location = new System.Drawing.Point(12, 48);
            this.pnlStocks.Name = "pnlStocks";
            this.pnlStocks.Size = new System.Drawing.Size(306, 390);
            this.pnlStocks.TabIndex = 5;
            // 
            // StockManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 450);
            this.Controls.Add(this.pnlStocks);
            this.Controls.Add(this.btnShowRestock);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.btnBack);
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
    }
}