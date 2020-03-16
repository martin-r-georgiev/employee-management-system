namespace Sem2IntroProjectWaterfall0._1
{
    partial class EmployeeManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeManagement));
            this.btnBack = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gbAssignUser = new System.Windows.Forms.GroupBox();
            this.btnAssignUser = new System.Windows.Forms.Button();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblHouseUnit2 = new System.Windows.Forms.Label();
            this.cmbAssignUnitList = new System.Windows.Forms.ComboBox();
            this.cmbAssignUserList = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnRemoveUser = new System.Windows.Forms.Button();
            this.cmbUserList = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.cmbHouseUnits = new System.Windows.Forms.ComboBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.tbFirstName = new System.Windows.Forms.TextBox();
            this.btnAddNewTenant = new System.Windows.Forms.Button();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblHouseUnit = new System.Windows.Forms.Label();
            this.tbLastName = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tbDepartmentCreateName = new System.Windows.Forms.TextBox();
            this.tbDepartmentCreateAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCreateNewDepartment = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cbEmployeeAssign = new System.Windows.Forms.ComboBox();
            this.cbDepartmentAssign = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnAssignEmployee = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.cbDepartmentRemove = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cbDepartmentEdit = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.tbDepartmentEditAddress = new System.Windows.Forms.TextBox();
            this.tbDepartmentEditName = new System.Windows.Forms.TextBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.gbAssignUser.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(12, 12);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(40, 38);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(58, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(706, 424);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.gbAssignUser);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(698, 398);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Employees";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // gbAssignUser
            // 
            this.gbAssignUser.Controls.Add(this.btnAssignUser);
            this.gbAssignUser.Controls.Add(this.lblUser);
            this.gbAssignUser.Controls.Add(this.lblHouseUnit2);
            this.gbAssignUser.Controls.Add(this.cmbAssignUnitList);
            this.gbAssignUser.Controls.Add(this.cmbAssignUserList);
            this.gbAssignUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbAssignUser.Location = new System.Drawing.Point(386, 218);
            this.gbAssignUser.Margin = new System.Windows.Forms.Padding(2);
            this.gbAssignUser.Name = "gbAssignUser";
            this.gbAssignUser.Padding = new System.Windows.Forms.Padding(2);
            this.gbAssignUser.Size = new System.Drawing.Size(307, 174);
            this.gbAssignUser.TabIndex = 24;
            this.gbAssignUser.TabStop = false;
            this.gbAssignUser.Text = "Assign employee to Department";
            // 
            // btnAssignUser
            // 
            this.btnAssignUser.BackColor = System.Drawing.Color.Transparent;
            this.btnAssignUser.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAssignUser.BackgroundImage")));
            this.btnAssignUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAssignUser.FlatAppearance.BorderSize = 0;
            this.btnAssignUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAssignUser.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAssignUser.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnAssignUser.Location = new System.Drawing.Point(14, 121);
            this.btnAssignUser.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAssignUser.Name = "btnAssignUser";
            this.btnAssignUser.Size = new System.Drawing.Size(279, 36);
            this.btnAssignUser.TabIndex = 17;
            this.btnAssignUser.Text = "Assign employee";
            this.btnAssignUser.UseVisualStyleBackColor = false;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(11, 41);
            this.lblUser.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(59, 13);
            this.lblUser.TabIndex = 18;
            this.lblUser.Text = "Employee: ";
            // 
            // lblHouseUnit2
            // 
            this.lblHouseUnit2.AutoSize = true;
            this.lblHouseUnit2.Location = new System.Drawing.Point(11, 81);
            this.lblHouseUnit2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHouseUnit2.Name = "lblHouseUnit2";
            this.lblHouseUnit2.Size = new System.Drawing.Size(65, 13);
            this.lblHouseUnit2.TabIndex = 17;
            this.lblHouseUnit2.Text = "Department:";
            // 
            // cmbAssignUnitList
            // 
            this.cmbAssignUnitList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAssignUnitList.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbAssignUnitList.FormattingEnabled = true;
            this.cmbAssignUnitList.Location = new System.Drawing.Point(115, 75);
            this.cmbAssignUnitList.Margin = new System.Windows.Forms.Padding(2);
            this.cmbAssignUnitList.Name = "cmbAssignUnitList";
            this.cmbAssignUnitList.Size = new System.Drawing.Size(176, 28);
            this.cmbAssignUnitList.TabIndex = 1;
            // 
            // cmbAssignUserList
            // 
            this.cmbAssignUserList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAssignUserList.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbAssignUserList.FormattingEnabled = true;
            this.cmbAssignUserList.Location = new System.Drawing.Point(74, 35);
            this.cmbAssignUserList.Margin = new System.Windows.Forms.Padding(2);
            this.cmbAssignUserList.Name = "cmbAssignUserList";
            this.cmbAssignUserList.Size = new System.Drawing.Size(221, 28);
            this.cmbAssignUserList.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnRemoveUser);
            this.groupBox1.Controls.Add(this.cmbUserList);
            this.groupBox1.Location = new System.Drawing.Point(387, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(307, 131);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Remove employee from database";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 38);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Employee:";
            // 
            // btnRemoveUser
            // 
            this.btnRemoveUser.BackColor = System.Drawing.Color.Transparent;
            this.btnRemoveUser.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRemoveUser.BackgroundImage")));
            this.btnRemoveUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRemoveUser.FlatAppearance.BorderSize = 0;
            this.btnRemoveUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveUser.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnRemoveUser.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnRemoveUser.Location = new System.Drawing.Point(73, 73);
            this.btnRemoveUser.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRemoveUser.Name = "btnRemoveUser";
            this.btnRemoveUser.Size = new System.Drawing.Size(221, 36);
            this.btnRemoveUser.TabIndex = 13;
            this.btnRemoveUser.Text = "Remove employee";
            this.btnRemoveUser.UseVisualStyleBackColor = false;
            // 
            // cmbUserList
            // 
            this.cmbUserList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUserList.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbUserList.FormattingEnabled = true;
            this.cmbUserList.Location = new System.Drawing.Point(75, 31);
            this.cmbUserList.Margin = new System.Windows.Forms.Padding(4);
            this.cmbUserList.Name = "cmbUserList";
            this.cmbUserList.Size = new System.Drawing.Size(221, 28);
            this.cmbUserList.TabIndex = 14;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.tbUsername);
            this.groupBox2.Controls.Add(this.lblUsername);
            this.groupBox2.Controls.Add(this.lblPassword);
            this.groupBox2.Controls.Add(this.cmbHouseUnits);
            this.groupBox2.Controls.Add(this.tbPassword);
            this.groupBox2.Controls.Add(this.lblFirstName);
            this.groupBox2.Controls.Add(this.tbFirstName);
            this.groupBox2.Controls.Add(this.btnAddNewTenant);
            this.groupBox2.Controls.Add(this.lblLastName);
            this.groupBox2.Controls.Add(this.lblHouseUnit);
            this.groupBox2.Controls.Add(this.tbLastName);
            this.groupBox2.Location = new System.Drawing.Point(18, 15);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(363, 377);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Create a new employee";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 292);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Salary:";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(112, 284);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(194, 27);
            this.textBox1.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 248);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Role:";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(111, 244);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(194, 28);
            this.comboBox1.TabIndex = 16;
            // 
            // tbUsername
            // 
            this.tbUsername.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbUsername.Location = new System.Drawing.Point(112, 38);
            this.tbUsername.Margin = new System.Windows.Forms.Padding(2);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(194, 27);
            this.tbUsername.TabIndex = 1;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(16, 38);
            this.lblUsername.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(58, 13);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "Username:";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(13, 81);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(56, 13);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "Password:";
            // 
            // cmbHouseUnits
            // 
            this.cmbHouseUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHouseUnits.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbHouseUnits.FormattingEnabled = true;
            this.cmbHouseUnits.Location = new System.Drawing.Point(110, 203);
            this.cmbHouseUnits.Margin = new System.Windows.Forms.Padding(2);
            this.cmbHouseUnits.Name = "cmbHouseUnits";
            this.cmbHouseUnits.Size = new System.Drawing.Size(194, 28);
            this.cmbHouseUnits.TabIndex = 15;
            // 
            // tbPassword
            // 
            this.tbPassword.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbPassword.Location = new System.Drawing.Point(112, 79);
            this.tbPassword.Margin = new System.Windows.Forms.Padding(2);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(194, 27);
            this.tbPassword.TabIndex = 3;
            this.tbPassword.UseSystemPasswordChar = true;
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(13, 126);
            this.lblFirstName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(60, 13);
            this.lblFirstName.TabIndex = 4;
            this.lblFirstName.Text = "First Name:";
            // 
            // tbFirstName
            // 
            this.tbFirstName.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbFirstName.Location = new System.Drawing.Point(112, 122);
            this.tbFirstName.Margin = new System.Windows.Forms.Padding(2);
            this.tbFirstName.Name = "tbFirstName";
            this.tbFirstName.Size = new System.Drawing.Size(194, 27);
            this.tbFirstName.TabIndex = 5;
            // 
            // btnAddNewTenant
            // 
            this.btnAddNewTenant.BackColor = System.Drawing.Color.Transparent;
            this.btnAddNewTenant.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddNewTenant.BackgroundImage")));
            this.btnAddNewTenant.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddNewTenant.FlatAppearance.BorderSize = 0;
            this.btnAddNewTenant.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewTenant.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddNewTenant.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnAddNewTenant.Location = new System.Drawing.Point(112, 324);
            this.btnAddNewTenant.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddNewTenant.Name = "btnAddNewTenant";
            this.btnAddNewTenant.Size = new System.Drawing.Size(194, 36);
            this.btnAddNewTenant.TabIndex = 10;
            this.btnAddNewTenant.Text = "Add employee";
            this.btnAddNewTenant.UseVisualStyleBackColor = false;
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(13, 167);
            this.lblLastName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(61, 13);
            this.lblLastName.TabIndex = 6;
            this.lblLastName.Text = "Last Name:";
            // 
            // lblHouseUnit
            // 
            this.lblHouseUnit.AutoSize = true;
            this.lblHouseUnit.Location = new System.Drawing.Point(12, 206);
            this.lblHouseUnit.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHouseUnit.Name = "lblHouseUnit";
            this.lblHouseUnit.Size = new System.Drawing.Size(65, 13);
            this.lblHouseUnit.TabIndex = 8;
            this.lblHouseUnit.Text = "Department:";
            // 
            // tbLastName
            // 
            this.tbLastName.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbLastName.Location = new System.Drawing.Point(112, 163);
            this.tbLastName.Margin = new System.Windows.Forms.Padding(2);
            this.tbLastName.Name = "tbLastName";
            this.tbLastName.Size = new System.Drawing.Size(194, 27);
            this.tbLastName.TabIndex = 7;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnEdit);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.label15);
            this.tabPage2.Controls.Add(this.tbDepartmentEditAddress);
            this.tabPage2.Controls.Add(this.tbDepartmentEditName);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.cbDepartmentEdit);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.cbDepartmentRemove);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.btnAssignEmployee);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.cbDepartmentAssign);
            this.tabPage2.Controls.Add(this.cbEmployeeAssign);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.btnCreateNewDepartment);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.tbDepartmentCreateAddress);
            this.tabPage2.Controls.Add(this.tbDepartmentCreateName);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(698, 398);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Departments";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tbDepartmentCreateName
            // 
            this.tbDepartmentCreateName.Location = new System.Drawing.Point(15, 66);
            this.tbDepartmentCreateName.Name = "tbDepartmentCreateName";
            this.tbDepartmentCreateName.Size = new System.Drawing.Size(169, 20);
            this.tbDepartmentCreateName.TabIndex = 0;
            // 
            // tbDepartmentCreateAddress
            // 
            this.tbDepartmentCreateAddress.Location = new System.Drawing.Point(15, 112);
            this.tbDepartmentCreateAddress.Multiline = true;
            this.tbDepartmentCreateAddress.Name = "tbDepartmentCreateAddress";
            this.tbDepartmentCreateAddress.Size = new System.Drawing.Size(169, 61);
            this.tbDepartmentCreateAddress.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(172, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Create New Department";
            // 
            // btnCreateNewDepartment
            // 
            this.btnCreateNewDepartment.Location = new System.Drawing.Point(15, 189);
            this.btnCreateNewDepartment.Name = "btnCreateNewDepartment";
            this.btnCreateNewDepartment.Size = new System.Drawing.Size(169, 23);
            this.btnCreateNewDepartment.TabIndex = 4;
            this.btnCreateNewDepartment.Text = "Create";
            this.btnCreateNewDepartment.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(75, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Address";
            // 
            // cbEmployeeAssign
            // 
            this.cbEmployeeAssign.FormattingEnabled = true;
            this.cbEmployeeAssign.Location = new System.Drawing.Point(15, 286);
            this.cbEmployeeAssign.Name = "cbEmployeeAssign";
            this.cbEmployeeAssign.Size = new System.Drawing.Size(169, 21);
            this.cbEmployeeAssign.TabIndex = 3;
            // 
            // cbDepartmentAssign
            // 
            this.cbDepartmentAssign.FormattingEnabled = true;
            this.cbDepartmentAssign.Location = new System.Drawing.Point(15, 332);
            this.cbDepartmentAssign.Name = "cbDepartmentAssign";
            this.cbDepartmentAssign.Size = new System.Drawing.Size(169, 21);
            this.cbDepartmentAssign.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 228);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(172, 39);
            this.label7.TabIndex = 7;
            this.label7.Text = "Assign an employee to another department";
            // 
            // btnAssignEmployee
            // 
            this.btnAssignEmployee.Location = new System.Drawing.Point(15, 359);
            this.btnAssignEmployee.Name = "btnAssignEmployee";
            this.btnAssignEmployee.Size = new System.Drawing.Size(169, 23);
            this.btnAssignEmployee.TabIndex = 8;
            this.btnAssignEmployee.Text = "Assign";
            this.btnAssignEmployee.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(67, 270);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Employee";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(67, 316);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "Department";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(296, 317);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 13);
            this.label10.TabIndex = 13;
            this.label10.Text = "Department";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(244, 360);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(169, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Remove";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // cbDepartmentRemove
            // 
            this.cbDepartmentRemove.FormattingEnabled = true;
            this.cbDepartmentRemove.Location = new System.Drawing.Point(244, 333);
            this.cbDepartmentRemove.Name = "cbDepartmentRemove";
            this.cbDepartmentRemove.Size = new System.Drawing.Size(169, 21);
            this.cbDepartmentRemove.TabIndex = 11;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(254, 286);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(150, 16);
            this.label11.TabIndex = 14;
            this.label11.Text = "Remove Department";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(266, 18);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(119, 16);
            this.label12.TabIndex = 17;
            this.label12.Text = "Edit Department";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(297, 50);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(62, 13);
            this.label13.TabIndex = 16;
            this.label13.Text = "Department";
            // 
            // cbDepartmentEdit
            // 
            this.cbDepartmentEdit.FormattingEnabled = true;
            this.cbDepartmentEdit.Location = new System.Drawing.Point(245, 66);
            this.cbDepartmentEdit.Name = "cbDepartmentEdit";
            this.cbDepartmentEdit.Size = new System.Drawing.Size(169, 21);
            this.cbDepartmentEdit.TabIndex = 15;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(305, 141);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(45, 13);
            this.label14.TabIndex = 21;
            this.label14.Text = "Address";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(305, 94);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(35, 13);
            this.label15.TabIndex = 20;
            this.label15.Text = "Name";
            // 
            // tbDepartmentEditAddress
            // 
            this.tbDepartmentEditAddress.Location = new System.Drawing.Point(245, 158);
            this.tbDepartmentEditAddress.Multiline = true;
            this.tbDepartmentEditAddress.Name = "tbDepartmentEditAddress";
            this.tbDepartmentEditAddress.Size = new System.Drawing.Size(169, 61);
            this.tbDepartmentEditAddress.TabIndex = 19;
            // 
            // tbDepartmentEditName
            // 
            this.tbDepartmentEditName.Location = new System.Drawing.Point(245, 112);
            this.tbDepartmentEditName.Name = "tbDepartmentEditName";
            this.tbDepartmentEditName.Size = new System.Drawing.Size(169, 20);
            this.tbDepartmentEditName.TabIndex = 18;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(245, 244);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(169, 23);
            this.btnEdit.TabIndex = 22;
            this.btnEdit.Text = "Confirm";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // EmployeeManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 438);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnBack);
            this.Name = "EmployeeManagement";
            this.Text = "EmployeeManagement";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.gbAssignUser.ResumeLayout(false);
            this.gbAssignUser.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox gbAssignUser;
        private System.Windows.Forms.Button btnAssignUser;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblHouseUnit2;
        private System.Windows.Forms.ComboBox cmbAssignUnitList;
        private System.Windows.Forms.ComboBox cmbAssignUserList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnRemoveUser;
        private System.Windows.Forms.ComboBox cmbUserList;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.ComboBox cmbHouseUnits;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox tbFirstName;
        private System.Windows.Forms.Button btnAddNewTenant;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblHouseUnit;
        private System.Windows.Forms.TextBox tbLastName;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnCreateNewDepartment;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbDepartmentCreateAddress;
        private System.Windows.Forms.TextBox tbDepartmentCreateName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnAssignEmployee;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbDepartmentAssign;
        private System.Windows.Forms.ComboBox cbEmployeeAssign;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tbDepartmentEditAddress;
        private System.Windows.Forms.TextBox tbDepartmentEditName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cbDepartmentEdit;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cbDepartmentRemove;
        private System.Windows.Forms.Button btnEdit;
    }
}