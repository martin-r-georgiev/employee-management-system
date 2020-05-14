namespace Sem2IntroProjectWaterfall0._1
{
    partial class NotificationUC
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
            this.btnApprove = new System.Windows.Forms.Button();
            this.btnDeny = new System.Windows.Forms.Button();
            this.lblEmployeeName = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // btnApprove
            // 
            this.btnApprove.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApprove.Location = new System.Drawing.Point(124, 2);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(48, 23);
            this.btnApprove.TabIndex = 0;
            this.btnApprove.Text = "Yes";
            this.btnApprove.UseVisualStyleBackColor = true;
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            this.btnApprove.MouseEnter += new System.EventHandler(this.NotificationUC_MouseEnter);
            this.btnApprove.MouseLeave += new System.EventHandler(this.NotificationUC_MouseLeave);
            // 
            // btnDeny
            // 
            this.btnDeny.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeny.Location = new System.Drawing.Point(124, 26);
            this.btnDeny.Name = "btnDeny";
            this.btnDeny.Size = new System.Drawing.Size(48, 23);
            this.btnDeny.TabIndex = 1;
            this.btnDeny.Text = "No";
            this.btnDeny.UseVisualStyleBackColor = true;
            this.btnDeny.Click += new System.EventHandler(this.btnDeny_Click);
            this.btnDeny.MouseEnter += new System.EventHandler(this.NotificationUC_MouseEnter);
            this.btnDeny.MouseLeave += new System.EventHandler(this.NotificationUC_MouseLeave);
            // 
            // lblEmployeeName
            // 
            this.lblEmployeeName.AutoEllipsis = true;
            this.lblEmployeeName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployeeName.Location = new System.Drawing.Point(10, 8);
            this.lblEmployeeName.Name = "lblEmployeeName";
            this.lblEmployeeName.Size = new System.Drawing.Size(110, 17);
            this.lblEmployeeName.TabIndex = 2;
            this.lblEmployeeName.Text = "Ivan Zvezdev";
            this.lblEmployeeName.MouseEnter += new System.EventHandler(this.NotificationUC_MouseEnter);
            this.lblEmployeeName.MouseLeave += new System.EventHandler(this.NotificationUC_MouseLeave);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(10, 31);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(110, 13);
            this.lblDate.TabIndex = 4;
            this.lblDate.Text = "12.05.2020 Afternoon";
            this.lblDate.MouseEnter += new System.EventHandler(this.NotificationUC_MouseEnter);
            this.lblDate.MouseLeave += new System.EventHandler(this.NotificationUC_MouseLeave);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(10, 50);
            this.panel1.TabIndex = 5;
            this.panel1.MouseEnter += new System.EventHandler(this.NotificationUC_MouseEnter);
            this.panel1.MouseLeave += new System.EventHandler(this.NotificationUC_MouseLeave);
            // 
            // NotificationUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblEmployeeName);
            this.Controls.Add(this.btnDeny);
            this.Controls.Add(this.btnApprove);
            this.Name = "NotificationUC";
            this.Size = new System.Drawing.Size(175, 50);
            this.MouseEnter += new System.EventHandler(this.NotificationUC_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.NotificationUC_MouseLeave);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.Button btnDeny;
        private System.Windows.Forms.Label lblEmployeeName;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Panel panel1;
    }
}
