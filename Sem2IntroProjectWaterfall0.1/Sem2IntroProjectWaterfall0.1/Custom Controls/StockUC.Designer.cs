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
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.panelControls = new System.Windows.Forms.Panel();
            this.panelAmount = new System.Windows.Forms.Panel();
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelControls.SuspendLayout();
            this.panelAmount.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbThreshold
            // 
            this.tbThreshold.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbThreshold.Location = new System.Drawing.Point(131, 33);
            this.tbThreshold.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbThreshold.Name = "tbThreshold";
            this.tbThreshold.Size = new System.Drawing.Size(40, 22);
            this.tbThreshold.TabIndex = 16;
            this.tbThreshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbThreshold.Visible = false;
            this.tbThreshold.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbThreshold_KeyDown);
            // 
            // tbCurrentAmount
            // 
            this.tbCurrentAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCurrentAmount.Location = new System.Drawing.Point(80, 10);
            this.tbCurrentAmount.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbCurrentAmount.Name = "tbCurrentAmount";
            this.tbCurrentAmount.Size = new System.Drawing.Size(49, 22);
            this.tbCurrentAmount.TabIndex = 15;
            this.tbCurrentAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbCurrentAmount.Visible = false;
            this.tbCurrentAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbCurrentAmount_KeyDown);
            // 
            // btnIncrease
            // 
            this.btnIncrease.BackColor = System.Drawing.Color.LightBlue;
            this.btnIncrease.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnIncrease.FlatAppearance.BorderColor = System.Drawing.Color.CadetBlue;
            this.btnIncrease.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SlateGray;
            this.btnIncrease.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue;
            this.btnIncrease.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIncrease.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIncrease.Location = new System.Drawing.Point(0, 0);
            this.btnIncrease.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnIncrease.Name = "btnIncrease";
            this.btnIncrease.Size = new System.Drawing.Size(50, 34);
            this.btnIncrease.TabIndex = 11;
            this.btnIncrease.Text = "+";
            this.btnIncrease.UseVisualStyleBackColor = false;
            this.btnIncrease.Click += new System.EventHandler(this.btnIncrease_Click);
            // 
            // btnDecrease
            // 
            this.btnDecrease.BackColor = System.Drawing.Color.LightBlue;
            this.btnDecrease.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnDecrease.FlatAppearance.BorderColor = System.Drawing.Color.CadetBlue;
            this.btnDecrease.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SlateGray;
            this.btnDecrease.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue;
            this.btnDecrease.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDecrease.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDecrease.Location = new System.Drawing.Point(0, 31);
            this.btnDecrease.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDecrease.Name = "btnDecrease";
            this.btnDecrease.Size = new System.Drawing.Size(50, 34);
            this.btnDecrease.TabIndex = 13;
            this.btnDecrease.Text = "-";
            this.btnDecrease.UseCompatibleTextRendering = true;
            this.btnDecrease.UseVisualStyleBackColor = false;
            this.btnDecrease.Click += new System.EventHandler(this.btnDecrease_Click);
            // 
            // lblThreshold
            // 
            this.lblThreshold.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblThreshold.AutoSize = true;
            this.lblThreshold.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThreshold.Location = new System.Drawing.Point(140, 36);
            this.lblThreshold.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblThreshold.Name = "lblThreshold";
            this.lblThreshold.Size = new System.Drawing.Size(16, 17);
            this.lblThreshold.TabIndex = 14;
            this.lblThreshold.Text = "8";
            this.lblThreshold.DoubleClick += new System.EventHandler(this.lblThreshold_DoubleClick);
            // 
            // lblCurrentAmount
            // 
            this.lblCurrentAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurrentAmount.AutoSize = true;
            this.lblCurrentAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentAmount.Location = new System.Drawing.Point(83, 7);
            this.lblCurrentAmount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCurrentAmount.Name = "lblCurrentAmount";
            this.lblCurrentAmount.Size = new System.Drawing.Size(39, 29);
            this.lblCurrentAmount.TabIndex = 12;
            this.lblCurrentAmount.Text = "15";
            this.lblCurrentAmount.DoubleClick += new System.EventHandler(this.lblCurrentAmount_DoubleClick);
            // 
            // lblStockName
            // 
            this.lblStockName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblStockName.AutoEllipsis = true;
            this.lblStockName.AutoSize = true;
            this.lblStockName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStockName.Location = new System.Drawing.Point(6, 17);
            this.lblStockName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStockName.MinimumSize = new System.Drawing.Size(150, 0);
            this.lblStockName.Name = "lblStockName";
            this.lblStockName.Size = new System.Drawing.Size(150, 29);
            this.lblStockName.TabIndex = 10;
            this.lblStockName.Text = "DVD Players";
            this.lblStockName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 17);
            this.label1.TabIndex = 17;
            this.label1.Text = "Threshold:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 14);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 17);
            this.label2.TabIndex = 18;
            this.label2.Text = "Current:";
            // 
            // panelSidebar
            // 
            this.panelSidebar.BackColor = System.Drawing.Color.LightBlue;
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(10, 65);
            this.panelSidebar.TabIndex = 19;
            // 
            // panelControls
            // 
            this.panelControls.Controls.Add(this.btnIncrease);
            this.panelControls.Controls.Add(this.btnDecrease);
            this.panelControls.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControls.Location = new System.Drawing.Point(400, 0);
            this.panelControls.MaximumSize = new System.Drawing.Size(100, 65);
            this.panelControls.MinimumSize = new System.Drawing.Size(50, 65);
            this.panelControls.Name = "panelControls";
            this.panelControls.Size = new System.Drawing.Size(50, 65);
            this.panelControls.TabIndex = 20;
            // 
            // panelAmount
            // 
            this.panelAmount.AutoSize = true;
            this.panelAmount.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelAmount.Controls.Add(this.label2);
            this.panelAmount.Controls.Add(this.lblCurrentAmount);
            this.panelAmount.Controls.Add(this.lblThreshold);
            this.panelAmount.Controls.Add(this.tbCurrentAmount);
            this.panelAmount.Controls.Add(this.label1);
            this.panelAmount.Controls.Add(this.tbThreshold);
            this.panelAmount.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelAmount.Location = new System.Drawing.Point(200, 0);
            this.panelAmount.MinimumSize = new System.Drawing.Size(200, 65);
            this.panelAmount.Name = "panelAmount";
            this.panelAmount.Size = new System.Drawing.Size(200, 65);
            this.panelAmount.TabIndex = 21;
            // 
            // panelContent
            // 
            this.panelContent.AutoSize = true;
            this.panelContent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelContent.Controls.Add(this.lblStockName);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(10, 0);
            this.panelContent.MinimumSize = new System.Drawing.Size(185, 65);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(190, 65);
            this.panelContent.TabIndex = 22;
            // 
            // StockUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelAmount);
            this.Controls.Add(this.panelControls);
            this.Controls.Add(this.panelSidebar);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximumSize = new System.Drawing.Size(0, 65);
            this.MinimumSize = new System.Drawing.Size(450, 65);
            this.Name = "StockUC";
            this.Size = new System.Drawing.Size(450, 65);
            this.panelControls.ResumeLayout(false);
            this.panelAmount.ResumeLayout(false);
            this.panelAmount.PerformLayout();
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
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
        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Panel panelControls;
        private System.Windows.Forms.Panel panelAmount;
        private System.Windows.Forms.Panel panelContent;
    }
}
