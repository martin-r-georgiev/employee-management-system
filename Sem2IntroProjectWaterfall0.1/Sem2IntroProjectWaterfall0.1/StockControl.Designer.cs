namespace Sem2IntroProjectWaterfall0._1
{
    partial class StockControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblStockName = new System.Windows.Forms.Label();
            this.lblThreshold = new System.Windows.Forms.Label();
            this.lblCurrentAmount = new System.Windows.Forms.Label();
            this.btnIncrease = new System.Windows.Forms.Button();
            this.btnDecrease = new System.Windows.Forms.Button();
            this.tbCurrentAmount = new System.Windows.Forms.TextBox();
            this.tbThreshold = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblStockName
            // 
            this.lblStockName.AutoSize = true;
            this.lblStockName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStockName.ForeColor = System.Drawing.Color.Black;
            this.lblStockName.Location = new System.Drawing.Point(3, 13);
            this.lblStockName.Name = "lblStockName";
            this.lblStockName.Size = new System.Drawing.Size(115, 24);
            this.lblStockName.TabIndex = 1;
            this.lblStockName.Text = "DVD Players";
            // 
            // lblThreshold
            // 
            this.lblThreshold.AutoSize = true;
            this.lblThreshold.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThreshold.ForeColor = System.Drawing.Color.Black;
            this.lblThreshold.Location = new System.Drawing.Point(248, 30);
            this.lblThreshold.Name = "lblThreshold";
            this.lblThreshold.Size = new System.Drawing.Size(13, 13);
            this.lblThreshold.TabIndex = 4;
            this.lblThreshold.Text = "8";
            this.lblThreshold.DoubleClick += new System.EventHandler(this.lblThreshold_DoubleClick);
            // 
            // lblCurrentAmount
            // 
            this.lblCurrentAmount.AutoSize = true;
            this.lblCurrentAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentAmount.ForeColor = System.Drawing.Color.Black;
            this.lblCurrentAmount.Location = new System.Drawing.Point(212, 13);
            this.lblCurrentAmount.Name = "lblCurrentAmount";
            this.lblCurrentAmount.Size = new System.Drawing.Size(30, 24);
            this.lblCurrentAmount.TabIndex = 3;
            this.lblCurrentAmount.Text = "15";
            this.lblCurrentAmount.DoubleClick += new System.EventHandler(this.lblCurrentAmount_DoubleClick);
            // 
            // btnIncrease
            // 
            this.btnIncrease.ForeColor = System.Drawing.Color.Black;
            this.btnIncrease.Location = new System.Drawing.Point(270, 0);
            this.btnIncrease.Name = "btnIncrease";
            this.btnIncrease.Size = new System.Drawing.Size(30, 25);
            this.btnIncrease.TabIndex = 5;
            this.btnIncrease.Text = "+";
            this.btnIncrease.UseVisualStyleBackColor = true;
            this.btnIncrease.Click += new System.EventHandler(this.btnIncrease_Click);
            // 
            // btnDecrease
            // 
            this.btnDecrease.ForeColor = System.Drawing.Color.Black;
            this.btnDecrease.Location = new System.Drawing.Point(270, 24);
            this.btnDecrease.Name = "btnDecrease";
            this.btnDecrease.Size = new System.Drawing.Size(30, 25);
            this.btnDecrease.TabIndex = 6;
            this.btnDecrease.Text = "-";
            this.btnDecrease.UseVisualStyleBackColor = true;
            this.btnDecrease.Click += new System.EventHandler(this.btnDecrease_Click);
            // 
            // tbCurrentAmount
            // 
            this.tbCurrentAmount.ForeColor = System.Drawing.Color.Black;
            this.tbCurrentAmount.Location = new System.Drawing.Point(141, 13);
            this.tbCurrentAmount.Name = "tbCurrentAmount";
            this.tbCurrentAmount.Size = new System.Drawing.Size(33, 20);
            this.tbCurrentAmount.TabIndex = 7;
            this.tbCurrentAmount.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tbCurrentAmount_MouseDoubleClick);
            // 
            // tbThreshold
            // 
            this.tbThreshold.ForeColor = System.Drawing.Color.Black;
            this.tbThreshold.Location = new System.Drawing.Point(180, 27);
            this.tbThreshold.Name = "tbThreshold";
            this.tbThreshold.Size = new System.Drawing.Size(26, 20);
            this.tbThreshold.TabIndex = 8;
            this.tbThreshold.Visible = false;
            this.tbThreshold.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tbThreshold_MouseDoubleClick);
            // 
            // StockControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Yellow;
            this.Controls.Add(this.tbThreshold);
            this.Controls.Add(this.tbCurrentAmount);
            this.Controls.Add(this.btnIncrease);
            this.Controls.Add(this.btnDecrease);
            this.Controls.Add(this.lblThreshold);
            this.Controls.Add(this.lblCurrentAmount);
            this.Controls.Add(this.lblStockName);
            this.Name = "StockControl";
            this.Size = new System.Drawing.Size(300, 50);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStockName;
        private System.Windows.Forms.Label lblThreshold;
        private System.Windows.Forms.Label lblCurrentAmount;
        private System.Windows.Forms.Button btnIncrease;
        private System.Windows.Forms.Button btnDecrease;
        private System.Windows.Forms.TextBox tbCurrentAmount;
        private System.Windows.Forms.TextBox tbThreshold;
    }
}
