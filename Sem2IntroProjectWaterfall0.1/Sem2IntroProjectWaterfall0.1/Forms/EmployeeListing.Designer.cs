namespace Sem2IntroProjectWaterfall0._1
{
    partial class EmployeeListing
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeListing));
            this.btnBack = new System.Windows.Forms.Button();
            this.tbEmployeeName = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblEmployeeWorkingSince = new System.Windows.Forms.Label();
            this.lblEmployeeSalary = new System.Windows.Forms.Label();
            this.lblEmployeeAttendance = new System.Windows.Forms.Label();
            this.lblEmployeeRole = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblEmployeeAddress = new System.Windows.Forms.Label();
            this.lblEmployeeEmail = new System.Windows.Forms.Label();
            this.lblEmployeePhone = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblEmployeeName = new System.Windows.Forms.Label();
            this.lblEmployeeDepartment = new System.Windows.Forms.Label();
            this.lblEmployeeGender = new System.Windows.Forms.Label();
            this.lblEmployeeNationality = new System.Windows.Forms.Label();
            this.lblEmployeeAge = new System.Windows.Forms.Label();
            this.pbxAvatar = new System.Windows.Forms.PictureBox();
            this.btnStatistics = new System.Windows.Forms.Button();
            this.pnlEmployees = new System.Windows.Forms.FlowLayoutPanel();
            this.cbDepartments = new System.Windows.Forms.ComboBox();
            this.btnHistoryLog = new System.Windows.Forms.Button();
            this.panel4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(12, 11);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 20);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // tbEmployeeName
            // 
            this.tbEmployeeName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbEmployeeName.ForeColor = System.Drawing.Color.DimGray;
            this.tbEmployeeName.Location = new System.Drawing.Point(594, 10);
            this.tbEmployeeName.Name = "tbEmployeeName";
            this.tbEmployeeName.Size = new System.Drawing.Size(213, 21);
            this.tbEmployeeName.TabIndex = 10;
            this.tbEmployeeName.TabStop = false;
            this.tbEmployeeName.Text = "Search for an employee here...";
            this.tbEmployeeName.TextChanged += new System.EventHandler(this.tbEmployeeName_TextChanged);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.Control;
            this.panel4.Controls.Add(this.groupBox3);
            this.panel4.Controls.Add(this.groupBox2);
            this.panel4.Controls.Add(this.groupBox1);
            this.panel4.Controls.Add(this.pbxAvatar);
            this.panel4.Location = new System.Drawing.Point(12, 37);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(451, 413);
            this.panel4.TabIndex = 6;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblEmployeeWorkingSince);
            this.groupBox3.Controls.Add(this.lblEmployeeSalary);
            this.groupBox3.Controls.Add(this.lblEmployeeAttendance);
            this.groupBox3.Controls.Add(this.lblEmployeeRole);
            this.groupBox3.Location = new System.Drawing.Point(277, 211);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(161, 194);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Other";
            // 
            // lblEmployeeWorkingSince
            // 
            this.lblEmployeeWorkingSince.AutoSize = true;
            this.lblEmployeeWorkingSince.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployeeWorkingSince.Location = new System.Drawing.Point(6, 130);
            this.lblEmployeeWorkingSince.Name = "lblEmployeeWorkingSince";
            this.lblEmployeeWorkingSince.Size = new System.Drawing.Size(96, 16);
            this.lblEmployeeWorkingSince.TabIndex = 15;
            this.lblEmployeeWorkingSince.Text = "Working since:";
            // 
            // lblEmployeeSalary
            // 
            this.lblEmployeeSalary.AutoSize = true;
            this.lblEmployeeSalary.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployeeSalary.Location = new System.Drawing.Point(6, 95);
            this.lblEmployeeSalary.Name = "lblEmployeeSalary";
            this.lblEmployeeSalary.Size = new System.Drawing.Size(50, 16);
            this.lblEmployeeSalary.TabIndex = 4;
            this.lblEmployeeSalary.Text = "Salary:";
            // 
            // lblEmployeeAttendance
            // 
            this.lblEmployeeAttendance.AutoSize = true;
            this.lblEmployeeAttendance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployeeAttendance.Location = new System.Drawing.Point(6, 60);
            this.lblEmployeeAttendance.Name = "lblEmployeeAttendance";
            this.lblEmployeeAttendance.Size = new System.Drawing.Size(108, 16);
            this.lblEmployeeAttendance.TabIndex = 5;
            this.lblEmployeeAttendance.Text = "Attendance: 56%";
            // 
            // lblEmployeeRole
            // 
            this.lblEmployeeRole.AutoSize = true;
            this.lblEmployeeRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployeeRole.Location = new System.Drawing.Point(6, 25);
            this.lblEmployeeRole.Name = "lblEmployeeRole";
            this.lblEmployeeRole.Size = new System.Drawing.Size(43, 16);
            this.lblEmployeeRole.TabIndex = 14;
            this.lblEmployeeRole.Text = "Role: ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblEmployeeAddress);
            this.groupBox2.Controls.Add(this.lblEmployeeEmail);
            this.groupBox2.Controls.Add(this.lblEmployeePhone);
            this.groupBox2.Location = new System.Drawing.Point(189, 52);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(249, 118);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Contact Info";
            // 
            // lblEmployeeAddress
            // 
            this.lblEmployeeAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployeeAddress.Location = new System.Drawing.Point(6, 66);
            this.lblEmployeeAddress.Name = "lblEmployeeAddress";
            this.lblEmployeeAddress.Size = new System.Drawing.Size(235, 49);
            this.lblEmployeeAddress.TabIndex = 9;
            this.lblEmployeeAddress.Text = "Address:  ";
            // 
            // lblEmployeeEmail
            // 
            this.lblEmployeeEmail.AutoSize = true;
            this.lblEmployeeEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployeeEmail.Location = new System.Drawing.Point(8, 16);
            this.lblEmployeeEmail.Name = "lblEmployeeEmail";
            this.lblEmployeeEmail.Size = new System.Drawing.Size(52, 16);
            this.lblEmployeeEmail.TabIndex = 10;
            this.lblEmployeeEmail.Text = "E-mail: ";
            // 
            // lblEmployeePhone
            // 
            this.lblEmployeePhone.AutoSize = true;
            this.lblEmployeePhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployeePhone.Location = new System.Drawing.Point(8, 41);
            this.lblEmployeePhone.Name = "lblEmployeePhone";
            this.lblEmployeePhone.Size = new System.Drawing.Size(101, 16);
            this.lblEmployeePhone.TabIndex = 11;
            this.lblEmployeePhone.Text = "Phone Number:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblEmployeeName);
            this.groupBox1.Controls.Add(this.lblEmployeeDepartment);
            this.groupBox1.Controls.Add(this.lblEmployeeGender);
            this.groupBox1.Controls.Add(this.lblEmployeeNationality);
            this.groupBox1.Controls.Add(this.lblEmployeeAge);
            this.groupBox1.Location = new System.Drawing.Point(12, 211);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(254, 194);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Personal Details";
            // 
            // lblEmployeeName
            // 
            this.lblEmployeeName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployeeName.Location = new System.Drawing.Point(6, 18);
            this.lblEmployeeName.Name = "lblEmployeeName";
            this.lblEmployeeName.Size = new System.Drawing.Size(242, 30);
            this.lblEmployeeName.TabIndex = 3;
            this.lblEmployeeName.Text = "Name: ";
            // 
            // lblEmployeeDepartment
            // 
            this.lblEmployeeDepartment.AutoSize = true;
            this.lblEmployeeDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployeeDepartment.Location = new System.Drawing.Point(6, 53);
            this.lblEmployeeDepartment.Name = "lblEmployeeDepartment";
            this.lblEmployeeDepartment.Size = new System.Drawing.Size(98, 20);
            this.lblEmployeeDepartment.TabIndex = 1;
            this.lblEmployeeDepartment.Text = "Department:";
            // 
            // lblEmployeeGender
            // 
            this.lblEmployeeGender.AutoSize = true;
            this.lblEmployeeGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployeeGender.Location = new System.Drawing.Point(6, 123);
            this.lblEmployeeGender.Name = "lblEmployeeGender";
            this.lblEmployeeGender.Size = new System.Drawing.Size(71, 20);
            this.lblEmployeeGender.TabIndex = 13;
            this.lblEmployeeGender.Text = "Gender: ";
            // 
            // lblEmployeeNationality
            // 
            this.lblEmployeeNationality.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployeeNationality.Location = new System.Drawing.Point(6, 158);
            this.lblEmployeeNationality.Name = "lblEmployeeNationality";
            this.lblEmployeeNationality.Size = new System.Drawing.Size(242, 27);
            this.lblEmployeeNationality.TabIndex = 8;
            this.lblEmployeeNationality.Text = "Nationality: ";
            // 
            // lblEmployeeAge
            // 
            this.lblEmployeeAge.AutoSize = true;
            this.lblEmployeeAge.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployeeAge.Location = new System.Drawing.Point(6, 95);
            this.lblEmployeeAge.Name = "lblEmployeeAge";
            this.lblEmployeeAge.Size = new System.Drawing.Size(50, 20);
            this.lblEmployeeAge.TabIndex = 12;
            this.lblEmployeeAge.Text = "Age:  ";
            // 
            // pbxAvatar
            // 
            this.pbxAvatar.Image = ((System.Drawing.Image)(resources.GetObject("pbxAvatar.Image")));
            this.pbxAvatar.Location = new System.Drawing.Point(12, 5);
            this.pbxAvatar.Name = "pbxAvatar";
            this.pbxAvatar.Size = new System.Drawing.Size(170, 200);
            this.pbxAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxAvatar.TabIndex = 0;
            this.pbxAvatar.TabStop = false;
            // 
            // btnStatistics
            // 
            this.btnStatistics.Location = new System.Drawing.Point(335, 12);
            this.btnStatistics.Name = "btnStatistics";
            this.btnStatistics.Size = new System.Drawing.Size(128, 20);
            this.btnStatistics.TabIndex = 6;
            this.btnStatistics.Text = "Show Statistics";
            this.btnStatistics.UseVisualStyleBackColor = true;
            this.btnStatistics.Click += new System.EventHandler(this.btnStatistics_Click);
            // 
            // pnlEmployees
            // 
            this.pnlEmployees.AutoScroll = true;
            this.pnlEmployees.BackColor = System.Drawing.Color.Silver;
            this.pnlEmployees.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlEmployees.Location = new System.Drawing.Point(469, 37);
            this.pnlEmployees.MinimumSize = new System.Drawing.Size(338, 382);
            this.pnlEmployees.Name = "pnlEmployees";
            this.pnlEmployees.Size = new System.Drawing.Size(338, 413);
            this.pnlEmployees.TabIndex = 7;
            this.pnlEmployees.WrapContents = false;
            // 
            // cbDepartments
            // 
            this.cbDepartments.FormattingEnabled = true;
            this.cbDepartments.Location = new System.Drawing.Point(469, 10);
            this.cbDepartments.Name = "cbDepartments";
            this.cbDepartments.Size = new System.Drawing.Size(121, 21);
            this.cbDepartments.TabIndex = 9;
            this.cbDepartments.Visible = false;
            this.cbDepartments.DropDown += new System.EventHandler(this.cbDepartments_DropDown);
            this.cbDepartments.SelectedIndexChanged += new System.EventHandler(this.cbDepartments_SelectedIndexChanged);
            // 
            // btnHistoryLog
            // 
            this.btnHistoryLog.Location = new System.Drawing.Point(210, 12);
            this.btnHistoryLog.Name = "btnHistoryLog";
            this.btnHistoryLog.Size = new System.Drawing.Size(117, 20);
            this.btnHistoryLog.TabIndex = 11;
            this.btnHistoryLog.Text = "Show History Log";
            this.btnHistoryLog.UseVisualStyleBackColor = true;
            this.btnHistoryLog.Click += new System.EventHandler(this.btnHistoryLog_Click);
            // 
            // EmployeeListing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 456);
            this.Controls.Add(this.btnHistoryLog);
            this.Controls.Add(this.cbDepartments);
            this.Controls.Add(this.pnlEmployees);
            this.Controls.Add(this.btnStatistics);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.tbEmployeeName);
            this.Controls.Add(this.btnBack);
            this.MaximumSize = new System.Drawing.Size(836, 495);
            this.MinimumSize = new System.Drawing.Size(836, 495);
            this.Name = "EmployeeListing";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EmployeeListing";
            this.Load += new System.EventHandler(this.EmployeeListing_Load);
            this.Click += new System.EventHandler(this.EmployeeListing_Click);
            this.panel4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAvatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.TextBox tbEmployeeName;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pbxAvatar;
        private System.Windows.Forms.Label lblEmployeeAttendance;
        private System.Windows.Forms.Label lblEmployeeSalary;
        private System.Windows.Forms.Label lblEmployeeName;
        private System.Windows.Forms.Label lblEmployeeDepartment;
        private System.Windows.Forms.Button btnStatistics;
        private System.Windows.Forms.FlowLayoutPanel pnlEmployees;
        private System.Windows.Forms.ComboBox cbDepartments;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblEmployeeRole;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblEmployeeAddress;
        private System.Windows.Forms.Label lblEmployeeEmail;
        private System.Windows.Forms.Label lblEmployeePhone;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblEmployeeGender;
        private System.Windows.Forms.Label lblEmployeeNationality;
        private System.Windows.Forms.Label lblEmployeeAge;
        private System.Windows.Forms.Label lblEmployeeWorkingSince;
        private System.Windows.Forms.Button btnHistoryLog;
    }
}