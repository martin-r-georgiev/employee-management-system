namespace Sem2IntroProjectWaterfall0._1
{
    partial class EmployeeControl
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
            this.lblEmployee = new System.Windows.Forms.Label();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblEmployee
            // 
            this.lblEmployee.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEmployee.AutoEllipsis = true;
            this.lblEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployee.Location = new System.Drawing.Point(0, 0);
            this.lblEmployee.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmployee.Name = "lblEmployee";
            this.lblEmployee.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.lblEmployee.Size = new System.Drawing.Size(417, 28);
            this.lblEmployee.TabIndex = 0;
            this.lblEmployee.Text = "FirstName LastName (Username)";
            this.lblEmployee.MouseClick += new System.Windows.Forms.MouseEventHandler(this.EmployeeControl_MouseClick);
            this.lblEmployee.MouseEnter += new System.EventHandler(this.EmployeeControl_MouseEnter);
            this.lblEmployee.MouseLeave += new System.EventHandler(this.EmployeeControl_MouseLeave);
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoEllipsis = true;
            this.lblDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepartment.Location = new System.Drawing.Point(0, 30);
            this.lblDepartment.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(417, 22);
            this.lblDepartment.TabIndex = 1;
            this.lblDepartment.Text = "DepartmentName";
            this.lblDepartment.MouseClick += new System.Windows.Forms.MouseEventHandler(this.EmployeeControl_MouseClick);
            this.lblDepartment.MouseEnter += new System.EventHandler(this.EmployeeControl_MouseEnter);
            this.lblDepartment.MouseLeave += new System.EventHandler(this.EmployeeControl_MouseLeave);
            // 
            // EmployeeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.Controls.Add(this.lblDepartment);
            this.Controls.Add(this.lblEmployee);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "EmployeeControl";
            this.Size = new System.Drawing.Size(417, 55);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.EmployeeControl_MouseClick);
            this.MouseEnter += new System.EventHandler(this.EmployeeControl_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.EmployeeControl_MouseLeave);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblEmployee;
        private System.Windows.Forms.Label lblDepartment;
    }
}
