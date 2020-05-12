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
            this.components = new System.ComponentModel.Container();
            this.lblEmployee = new System.Windows.Forms.Label();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.lblLetter = new System.Windows.Forms.Label();
            this.roleTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelSidebar.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblEmployee
            // 
            this.lblEmployee.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEmployee.AutoEllipsis = true;
            this.lblEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployee.Location = new System.Drawing.Point(4, -1);
            this.lblEmployee.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmployee.Name = "lblEmployee";
            this.lblEmployee.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.lblEmployee.Size = new System.Drawing.Size(378, 30);
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
            this.lblDepartment.Location = new System.Drawing.Point(4, 27);
            this.lblDepartment.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(380, 27);
            this.lblDepartment.TabIndex = 1;
            this.lblDepartment.Text = "DepartmentName";
            this.lblDepartment.MouseClick += new System.Windows.Forms.MouseEventHandler(this.EmployeeControl_MouseClick);
            this.lblDepartment.MouseEnter += new System.EventHandler(this.EmployeeControl_MouseEnter);
            this.lblDepartment.MouseLeave += new System.EventHandler(this.EmployeeControl_MouseLeave);
            // 
            // panelSidebar
            // 
            this.panelSidebar.BackColor = System.Drawing.Color.GhostWhite;
            this.panelSidebar.Controls.Add(this.lblLetter);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Padding = new System.Windows.Forms.Padding(3);
            this.panelSidebar.Size = new System.Drawing.Size(32, 51);
            this.panelSidebar.TabIndex = 2;
            // 
            // lblLetter
            // 
            this.lblLetter.BackColor = System.Drawing.Color.DimGray;
            this.lblLetter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLetter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLetter.Location = new System.Drawing.Point(3, 3);
            this.lblLetter.Name = "lblLetter";
            this.lblLetter.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.lblLetter.Size = new System.Drawing.Size(26, 45);
            this.lblLetter.TabIndex = 0;
            this.lblLetter.Text = "A";
            this.lblLetter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLetter.MouseClick += new System.Windows.Forms.MouseEventHandler(this.EmployeeControl_MouseClick);
            this.lblLetter.MouseEnter += new System.EventHandler(this.EmployeeControl_MouseEnter);
            this.lblLetter.MouseLeave += new System.EventHandler(this.EmployeeControl_MouseLeave);
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.lblEmployee);
            this.panelContent.Controls.Add(this.lblDepartment);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(32, 0);
            this.panelContent.MinimumSize = new System.Drawing.Size(380, 53);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(381, 53);
            this.panelContent.TabIndex = 3;
            // 
            // EmployeeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelSidebar);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(450, 53);
            this.MinimumSize = new System.Drawing.Size(415, 53);
            this.Name = "EmployeeControl";
            this.Size = new System.Drawing.Size(413, 53);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.EmployeeControl_MouseClick);
            this.MouseEnter += new System.EventHandler(this.EmployeeControl_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.EmployeeControl_MouseLeave);
            this.panelSidebar.ResumeLayout(false);
            this.panelContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblEmployee;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Label lblLetter;
        private System.Windows.Forms.ToolTip roleTooltip;
        private System.Windows.Forms.Panel panelContent;
    }
}
