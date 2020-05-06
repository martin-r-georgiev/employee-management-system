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
            this.lblEmployee.AutoSize = true;
            this.lblEmployee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployee.Location = new System.Drawing.Point(7, 5);
            this.lblEmployee.Name = "lblEmployee";
            this.lblEmployee.Size = new System.Drawing.Size(222, 15);
            this.lblEmployee.TabIndex = 0;
            this.lblEmployee.Text = "FirstName LastName (Username)";
            this.lblEmployee.MouseClick += new System.Windows.Forms.MouseEventHandler(this.EmployeeControl_MouseClick);
            this.lblEmployee.MouseEnter += new System.EventHandler(this.EmployeeControl_MouseEnter);
            this.lblEmployee.MouseLeave += new System.EventHandler(this.EmployeeControl_MouseLeave);
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepartment.Location = new System.Drawing.Point(7, 24);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(106, 15);
            this.lblDepartment.TabIndex = 1;
            this.lblDepartment.Text = "DepartmentName";
            this.lblDepartment.MouseClick += new System.Windows.Forms.MouseEventHandler(this.EmployeeControl_MouseClick);
            this.lblDepartment.MouseEnter += new System.EventHandler(this.EmployeeControl_MouseEnter);
            this.lblDepartment.MouseLeave += new System.EventHandler(this.EmployeeControl_MouseLeave);
            // 
            // EmployeeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.lblDepartment);
            this.Controls.Add(this.lblEmployee);
            this.Name = "EmployeeControl";
            this.Size = new System.Drawing.Size(313, 43);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.EmployeeControl_MouseClick);
            this.MouseEnter += new System.EventHandler(this.EmployeeControl_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.EmployeeControl_MouseLeave);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEmployee;
        private System.Windows.Forms.Label lblDepartment;
    }
}
