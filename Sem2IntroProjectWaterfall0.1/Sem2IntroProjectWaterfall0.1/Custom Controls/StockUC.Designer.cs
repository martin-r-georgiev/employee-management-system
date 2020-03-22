namespace Sem2IntroProjectWaterfall0._1
{
    partial class StockUC
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
            this.customInstaller1 = new MySql.Data.MySqlClient.CustomInstaller();
            this.tbThreshold = new System.Windows.Forms.TextBox();
            this.tbCurrentAmount = new System.Windows.Forms.TextBox();
            this.btnIncrease = new System.Windows.Forms.Button();
            this.btnDecrease = new System.Windows.Forms.Button();
            this.lblThreshold = new System.Windows.Forms.Label();
            this.lblCurrentAmount = new System.Windows.Forms.Label();
            this.lblStockName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbThreshold
            // 
            this.tbThreshold.Location = new System.Drawing.Point(228, 28);
            this.tbThreshold.Name = "tbThreshold";
            this.tbThreshold.Size = new System.Drawing.Size(28, 20);
            this.tbThreshold.TabIndex = 16;
            this.tbThreshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbThreshold.Visible = false;
            this.tbThreshold.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbThreshold_KeyDown);
            // 
            // tbCurrentAmount
            // 
            this.tbCurrentAmount.Location = new System.Drawing.Point(190, 9);
            this.tbCurrentAmount.Name = "tbCurrentAmount";
            this.tbCurrentAmount.Size = new System.Drawing.Size(35, 20);
            this.tbCurrentAmount.TabIndex = 15;
            this.tbCurrentAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbCurrentAmount.Visible = false;
            this.tbCurrentAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbCurrentAmount_KeyDown);
            // 
            // btnIncrease
            // 
            this.btnIncrease.Location = new System.Drawing.Point(266, 1);
            this.btnIncrease.Name = "btnIncrease";
            this.btnIncrease.Size = new System.Drawing.Size(30, 25);
            this.btnIncrease.TabIndex = 11;
            this.btnIncrease.Text = "+";
            this.btnIncrease.UseVisualStyleBackColor = true;
            this.btnIncrease.Click += new System.EventHandler(this.btnIncrease_Click);
            // 
            // btnDecrease
            // 
            this.btnDecrease.Location = new System.Drawing.Point(266, 25);
            this.btnDecrease.Name = "btnDecrease";
            this.btnDecrease.Size = new System.Drawing.Size(30, 25);
            this.btnDecrease.TabIndex = 13;
            this.btnDecrease.Text = "-";
            this.btnDecrease.UseVisualStyleBackColor = true;
            this.btnDecrease.Click += new System.EventHandler(this.btnDecrease_Click);
            // 
            // lblThreshold
            // 
            this.lblThreshold.AutoSize = true;
            this.lblThreshold.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThreshold.Location = new System.Drawing.Point(231, 31);
            this.lblThreshold.Name = "lblThreshold";
            this.lblThreshold.Size = new System.Drawing.Size(13, 13);
            this.lblThreshold.TabIndex = 14;
            this.lblThreshold.Text = "8";
            this.lblThreshold.DoubleClick += new System.EventHandler(this.lblThreshold_DoubleClick);
            // 
            // lblCurrentAmount
            // 
            this.lblCurrentAmount.AutoSize = true;
            this.lblCurrentAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentAmount.Location = new System.Drawing.Point(195, 7);
            this.lblCurrentAmount.Name = "lblCurrentAmount";
            this.lblCurrentAmount.Size = new System.Drawing.Size(30, 24);
            this.lblCurrentAmount.TabIndex = 12;
            this.lblCurrentAmount.Text = "15";
            this.lblCurrentAmount.DoubleClick += new System.EventHandler(this.lblCurrentAmount_DoubleClick);
            // 
            // lblStockName
            // 
            this.lblStockName.AutoSize = true;
            this.lblStockName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStockName.Location = new System.Drawing.Point(4, 16);
            this.lblStockName.Name = "lblStockName";
            this.lblStockName.Size = new System.Drawing.Size(115, 24);
            this.lblStockName.TabIndex = 10;
            this.lblStockName.Text = "DVD Players";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(168, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Threshold:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(140, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Current:";
            // 
            // StockUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Yellow;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbThreshold);
            this.Controls.Add(this.tbCurrentAmount);
            this.Controls.Add(this.btnIncrease);
            this.Controls.Add(this.btnDecrease);
            this.Controls.Add(this.lblThreshold);
            this.Controls.Add(this.lblCurrentAmount);
            this.Controls.Add(this.lblStockName);
            this.Name = "StockUC";
            this.Size = new System.Drawing.Size(300, 50);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MySql.Data.MySqlClient.CustomInstaller customInstaller1;
        private System.Windows.Forms.TextBox tbThreshold;
        private System.Windows.Forms.TextBox tbCurrentAmount;
        private System.Windows.Forms.Button btnIncrease;
        private System.Windows.Forms.Button btnDecrease;
        private System.Windows.Forms.Label lblThreshold;
        private System.Windows.Forms.Label lblCurrentAmount;
        private System.Windows.Forms.Label lblStockName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
