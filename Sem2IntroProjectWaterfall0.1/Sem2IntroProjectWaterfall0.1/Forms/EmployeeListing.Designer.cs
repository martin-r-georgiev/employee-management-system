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
            this.btnBack = new System.Windows.Forms.Button();
            this.tbEmployeeName = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
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
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.btnStatistics = new System.Windows.Forms.Button();
            this.pnlEmployees = new System.Windows.Forms.FlowLayoutPanel();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.cbDepartments = new System.Windows.Forms.ComboBox();
            this.panel4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(16, 15);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(100, 47);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // tbEmployeeName
            // 
            this.tbEmployeeName.Location = new System.Drawing.Point(649, 26);
            this.tbEmployeeName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbEmployeeName.Name = "tbEmployeeName";
            this.tbEmployeeName.Size = new System.Drawing.Size(260, 22);
            this.tbEmployeeName.TabIndex = 0;
            this.tbEmployeeName.TextChanged += new System.EventHandler(this.tbEmployeeName_TextChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(919, 24);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(68, 28);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.DarkCyan;
            this.panel4.Controls.Add(this.groupBox3);
            this.panel4.Controls.Add(this.groupBox2);
            this.panel4.Controls.Add(this.groupBox1);
            this.panel4.Controls.Add(this.pictureBox3);
            this.panel4.Location = new System.Drawing.Point(16, 69);
            this.panel4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(601, 470);
            this.panel4.TabIndex = 6;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblEmployeeWorkingSince);
            this.groupBox3.Controls.Add(this.lblEmployeeSalary);
            this.groupBox3.Controls.Add(this.lblEmployeeAttendance);
            this.groupBox3.Controls.Add(this.lblEmployeeRole);
            this.groupBox3.Location = new System.Drawing.Point(369, 174);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(215, 293);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Other";
            // 
            // lblEmployeeWorkingSince
            // 
            this.lblEmployeeWorkingSince.AutoSize = true;
            this.lblEmployeeWorkingSince.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployeeWorkingSince.Location = new System.Drawing.Point(8, 160);
            this.lblEmployeeWorkingSince.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmployeeWorkingSince.Name = "lblEmployeeWorkingSince";
            this.lblEmployeeWorkingSince.Size = new System.Drawing.Size(120, 20);
            this.lblEmployeeWorkingSince.TabIndex = 15;
            this.lblEmployeeWorkingSince.Text = "Working since:";
            // 
            // lblEmployeeSalary
            // 
            this.lblEmployeeSalary.AutoSize = true;
            this.lblEmployeeSalary.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployeeSalary.Location = new System.Drawing.Point(8, 117);
            this.lblEmployeeSalary.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmployeeSalary.Name = "lblEmployeeSalary";
            this.lblEmployeeSalary.Size = new System.Drawing.Size(61, 20);
            this.lblEmployeeSalary.TabIndex = 4;
            this.lblEmployeeSalary.Text = "Salary:";
            // 
            // lblEmployeeAttendance
            // 
            this.lblEmployeeAttendance.AutoSize = true;
            this.lblEmployeeAttendance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployeeAttendance.Location = new System.Drawing.Point(8, 74);
            this.lblEmployeeAttendance.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmployeeAttendance.Name = "lblEmployeeAttendance";
            this.lblEmployeeAttendance.Size = new System.Drawing.Size(136, 20);
            this.lblEmployeeAttendance.TabIndex = 5;
            this.lblEmployeeAttendance.Text = "Attendance: 56%";
            // 
            // lblEmployeeRole
            // 
            this.lblEmployeeRole.AutoSize = true;
            this.lblEmployeeRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployeeRole.Location = new System.Drawing.Point(8, 31);
            this.lblEmployeeRole.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmployeeRole.Name = "lblEmployeeRole";
            this.lblEmployeeRole.Size = new System.Drawing.Size(53, 20);
            this.lblEmployeeRole.TabIndex = 14;
            this.lblEmployeeRole.Text = "Role: ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblEmployeeAddress);
            this.groupBox2.Controls.Add(this.lblEmployeeEmail);
            this.groupBox2.Controls.Add(this.lblEmployeePhone);
            this.groupBox2.Location = new System.Drawing.Point(252, 21);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(332, 145);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Contact Info";
            // 
            // lblEmployeeAddress
            // 
            this.lblEmployeeAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployeeAddress.Location = new System.Drawing.Point(8, 81);
            this.lblEmployeeAddress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmployeeAddress.Name = "lblEmployeeAddress";
            this.lblEmployeeAddress.Size = new System.Drawing.Size(313, 60);
            this.lblEmployeeAddress.TabIndex = 9;
            this.lblEmployeeAddress.Text = "Address:  ";
            // 
            // lblEmployeeEmail
            // 
            this.lblEmployeeEmail.AutoSize = true;
            this.lblEmployeeEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployeeEmail.Location = new System.Drawing.Point(11, 20);
            this.lblEmployeeEmail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmployeeEmail.Name = "lblEmployeeEmail";
            this.lblEmployeeEmail.Size = new System.Drawing.Size(61, 20);
            this.lblEmployeeEmail.TabIndex = 10;
            this.lblEmployeeEmail.Text = "Email: ";
            // 
            // lblEmployeePhone
            // 
            this.lblEmployeePhone.AutoSize = true;
            this.lblEmployeePhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployeePhone.Location = new System.Drawing.Point(11, 50);
            this.lblEmployeePhone.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmployeePhone.Name = "lblEmployeePhone";
            this.lblEmployeePhone.Size = new System.Drawing.Size(125, 20);
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
            this.groupBox1.Location = new System.Drawing.Point(17, 174);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(339, 293);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Personal Details";
            // 
            // lblEmployeeName
            // 
            this.lblEmployeeName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployeeName.Location = new System.Drawing.Point(8, 31);
            this.lblEmployeeName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmployeeName.Name = "lblEmployeeName";
            this.lblEmployeeName.Size = new System.Drawing.Size(323, 43);
            this.lblEmployeeName.TabIndex = 3;
            this.lblEmployeeName.Text = "Name: ";
            // 
            // lblEmployeeDepartment
            // 
            this.lblEmployeeDepartment.AutoSize = true;
            this.lblEmployeeDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployeeDepartment.Location = new System.Drawing.Point(8, 74);
            this.lblEmployeeDepartment.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmployeeDepartment.Name = "lblEmployeeDepartment";
            this.lblEmployeeDepartment.Size = new System.Drawing.Size(119, 25);
            this.lblEmployeeDepartment.TabIndex = 1;
            this.lblEmployeeDepartment.Text = "Department:";
            // 
            // lblEmployeeGender
            // 
            this.lblEmployeeGender.AutoSize = true;
            this.lblEmployeeGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployeeGender.Location = new System.Drawing.Point(8, 160);
            this.lblEmployeeGender.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmployeeGender.Name = "lblEmployeeGender";
            this.lblEmployeeGender.Size = new System.Drawing.Size(88, 25);
            this.lblEmployeeGender.TabIndex = 13;
            this.lblEmployeeGender.Text = "Gender: ";
            // 
            // lblEmployeeNationality
            // 
            this.lblEmployeeNationality.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployeeNationality.Location = new System.Drawing.Point(8, 203);
            this.lblEmployeeNationality.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmployeeNationality.Name = "lblEmployeeNationality";
            this.lblEmployeeNationality.Size = new System.Drawing.Size(323, 59);
            this.lblEmployeeNationality.TabIndex = 8;
            this.lblEmployeeNationality.Text = "Nationality: ";
            // 
            // lblEmployeeAge
            // 
            this.lblEmployeeAge.AutoSize = true;
            this.lblEmployeeAge.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployeeAge.Location = new System.Drawing.Point(8, 117);
            this.lblEmployeeAge.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmployeeAge.Name = "lblEmployeeAge";
            this.lblEmployeeAge.Size = new System.Drawing.Size(64, 25);
            this.lblEmployeeAge.TabIndex = 12;
            this.lblEmployeeAge.Text = "Age:  ";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Sem2IntroProjectWaterfall0._1.Properties.Resources._20667482_young_harbor_container_depot_worker;
            this.pictureBox3.Location = new System.Drawing.Point(17, 21);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(227, 145);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            // 
            // btnStatistics
            // 
            this.btnStatistics.Location = new System.Drawing.Point(124, 15);
            this.btnStatistics.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStatistics.Name = "btnStatistics";
            this.btnStatistics.Size = new System.Drawing.Size(107, 47);
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
            this.pnlEmployees.Location = new System.Drawing.Point(625, 69);
            this.pnlEmployees.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlEmployees.Name = "pnlEmployees";
            this.pnlEmployees.Size = new System.Drawing.Size(450, 470);
            this.pnlEmployees.TabIndex = 7;
            this.pnlEmployees.WrapContents = false;
            // 
            // btnShowAll
            // 
            this.btnShowAll.Location = new System.Drawing.Point(995, 24);
            this.btnShowAll.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(80, 28);
            this.btnShowAll.TabIndex = 8;
            this.btnShowAll.Text = "Show All";
            this.btnShowAll.UseVisualStyleBackColor = true;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // cbDepartments
            // 
            this.cbDepartments.FormattingEnabled = true;
            this.cbDepartments.Location = new System.Drawing.Point(480, 24);
            this.cbDepartments.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbDepartments.Name = "cbDepartments";
            this.cbDepartments.Size = new System.Drawing.Size(160, 24);
            this.cbDepartments.TabIndex = 9;
            this.cbDepartments.Visible = false;
            this.cbDepartments.DropDown += new System.EventHandler(this.cbDepartments_DropDown);
            this.cbDepartments.SelectedIndexChanged += new System.EventHandler(this.cbDepartments_SelectedIndexChanged);
            // 
            // EmployeeListing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1089, 554);
            this.Controls.Add(this.cbDepartments);
            this.Controls.Add(this.btnShowAll);
            this.Controls.Add(this.pnlEmployees);
            this.Controls.Add(this.btnStatistics);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.tbEmployeeName);
            this.Controls.Add(this.btnBack);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "EmployeeListing";
            this.Text = "EmployeeListing";
            this.panel4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.TextBox tbEmployeeName;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label lblEmployeeAttendance;
        private System.Windows.Forms.Label lblEmployeeSalary;
        private System.Windows.Forms.Label lblEmployeeName;
        private System.Windows.Forms.Label lblEmployeeDepartment;
        private System.Windows.Forms.Button btnStatistics;
        private System.Windows.Forms.FlowLayoutPanel pnlEmployees;
        private System.Windows.Forms.Button btnShowAll;
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
    }
}