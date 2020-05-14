namespace Sem2IntroProjectWaterfall0._1
{
    partial class StatisticsForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cbStatistic = new System.Windows.Forms.ComboBox();
            this.gbGeneralStat = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbGender = new System.Windows.Forms.Label();
            this.lbGenderWorker = new System.Windows.Forms.Label();
            this.lbGenderManager = new System.Windows.Forms.Label();
            this.lbGenderAdmin = new System.Windows.Forms.Label();
            this.Age = new System.Windows.Forms.GroupBox();
            this.lbAge = new System.Windows.Forms.Label();
            this.lbAgeWorker = new System.Windows.Forms.Label();
            this.lbAgeManager = new System.Windows.Forms.Label();
            this.lbAgeAdmin = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbSalary = new System.Windows.Forms.Label();
            this.lbSalaryWorker = new System.Windows.Forms.Label();
            this.lbSalaryAdmin = new System.Windows.Forms.Label();
            this.lbSalaryManager = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbHours = new System.Windows.Forms.Label();
            this.lbHoursAdmin = new System.Windows.Forms.Label();
            this.lbHoursWorker = new System.Windows.Forms.Label();
            this.lbHoursManager = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.gbGeneralStat.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.Age.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Bottom;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(0, 38);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(695, 446);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            this.chart1.Visible = false;
            // 
            // cbStatistic
            // 
            this.cbStatistic.FormattingEnabled = true;
            this.cbStatistic.Items.AddRange(new object[] {
            "Employee distribution per department",
            "Employees distribution per role",
            "Items usage per deparment",
            "Day preference for employees\t",
            "Shift preference for employees",
            "General Statistics"});
            this.cbStatistic.Location = new System.Drawing.Point(12, 12);
            this.cbStatistic.Name = "cbStatistic";
            this.cbStatistic.Size = new System.Drawing.Size(250, 21);
            this.cbStatistic.TabIndex = 8;
            this.cbStatistic.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // gbGeneralStat
            // 
            this.gbGeneralStat.Controls.Add(this.groupBox3);
            this.gbGeneralStat.Controls.Add(this.Age);
            this.gbGeneralStat.Controls.Add(this.groupBox2);
            this.gbGeneralStat.Controls.Add(this.groupBox1);
            this.gbGeneralStat.Location = new System.Drawing.Point(0, 39);
            this.gbGeneralStat.Name = "gbGeneralStat";
            this.gbGeneralStat.Size = new System.Drawing.Size(695, 445);
            this.gbGeneralStat.TabIndex = 9;
            this.gbGeneralStat.TabStop = false;
            this.gbGeneralStat.Text = "General Statistics";
            this.gbGeneralStat.Enter += new System.EventHandler(this.gbGeneralStat_Enter);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lbGender);
            this.groupBox3.Controls.Add(this.lbGenderWorker);
            this.groupBox3.Controls.Add(this.lbGenderManager);
            this.groupBox3.Controls.Add(this.lbGenderAdmin);
            this.groupBox3.Location = new System.Drawing.Point(340, 35);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(343, 165);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Gender Distribution";
            // 
            // lbGender
            // 
            this.lbGender.AutoSize = true;
            this.lbGender.Location = new System.Drawing.Point(6, 31);
            this.lbGender.Name = "lbGender";
            this.lbGender.Size = new System.Drawing.Size(88, 13);
            this.lbGender.TabIndex = 1;
            this.lbGender.Text = "Male and Female";
            // 
            // lbGenderWorker
            // 
            this.lbGenderWorker.AutoSize = true;
            this.lbGenderWorker.Location = new System.Drawing.Point(6, 64);
            this.lbGenderWorker.Name = "lbGenderWorker";
            this.lbGenderWorker.Size = new System.Drawing.Size(88, 13);
            this.lbGenderWorker.TabIndex = 5;
            this.lbGenderWorker.Text = "Male and Female";
            // 
            // lbGenderManager
            // 
            this.lbGenderManager.AutoSize = true;
            this.lbGenderManager.Location = new System.Drawing.Point(6, 99);
            this.lbGenderManager.Name = "lbGenderManager";
            this.lbGenderManager.Size = new System.Drawing.Size(88, 13);
            this.lbGenderManager.TabIndex = 6;
            this.lbGenderManager.Text = "Male and Female";
            // 
            // lbGenderAdmin
            // 
            this.lbGenderAdmin.AutoSize = true;
            this.lbGenderAdmin.Location = new System.Drawing.Point(6, 128);
            this.lbGenderAdmin.Name = "lbGenderAdmin";
            this.lbGenderAdmin.Size = new System.Drawing.Size(88, 13);
            this.lbGenderAdmin.TabIndex = 7;
            this.lbGenderAdmin.Text = "Male and Female";
            // 
            // Age
            // 
            this.Age.Controls.Add(this.lbAge);
            this.Age.Controls.Add(this.lbAgeWorker);
            this.Age.Controls.Add(this.lbAgeManager);
            this.Age.Controls.Add(this.lbAgeAdmin);
            this.Age.Location = new System.Drawing.Point(31, 35);
            this.Age.Name = "Age";
            this.Age.Size = new System.Drawing.Size(303, 165);
            this.Age.TabIndex = 17;
            this.Age.TabStop = false;
            this.Age.Text = "Age Distribution";
            // 
            // lbAge
            // 
            this.lbAge.AutoSize = true;
            this.lbAge.Location = new System.Drawing.Point(6, 31);
            this.lbAge.Name = "lbAge";
            this.lbAge.Size = new System.Drawing.Size(69, 13);
            this.lbAge.TabIndex = 0;
            this.lbAge.Text = "Average Age";
            // 
            // lbAgeWorker
            // 
            this.lbAgeWorker.AutoSize = true;
            this.lbAgeWorker.Location = new System.Drawing.Point(6, 64);
            this.lbAgeWorker.Name = "lbAgeWorker";
            this.lbAgeWorker.Size = new System.Drawing.Size(69, 13);
            this.lbAgeWorker.TabIndex = 2;
            this.lbAgeWorker.Text = "Average Age";
            // 
            // lbAgeManager
            // 
            this.lbAgeManager.AutoSize = true;
            this.lbAgeManager.Location = new System.Drawing.Point(6, 99);
            this.lbAgeManager.Name = "lbAgeManager";
            this.lbAgeManager.Size = new System.Drawing.Size(69, 13);
            this.lbAgeManager.TabIndex = 3;
            this.lbAgeManager.Text = "Average Age";
            // 
            // lbAgeAdmin
            // 
            this.lbAgeAdmin.AutoSize = true;
            this.lbAgeAdmin.Location = new System.Drawing.Point(6, 128);
            this.lbAgeAdmin.Name = "lbAgeAdmin";
            this.lbAgeAdmin.Size = new System.Drawing.Size(69, 13);
            this.lbAgeAdmin.TabIndex = 4;
            this.lbAgeAdmin.Text = "Average Age";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbSalary);
            this.groupBox2.Controls.Add(this.lbSalaryWorker);
            this.groupBox2.Controls.Add(this.lbSalaryAdmin);
            this.groupBox2.Controls.Add(this.lbSalaryManager);
            this.groupBox2.Location = new System.Drawing.Point(340, 250);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(343, 165);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Salary";
            // 
            // lbSalary
            // 
            this.lbSalary.AutoSize = true;
            this.lbSalary.Location = new System.Drawing.Point(15, 31);
            this.lbSalary.Name = "lbSalary";
            this.lbSalary.Size = new System.Drawing.Size(79, 13);
            this.lbSalary.TabIndex = 8;
            this.lbSalary.Text = "Average Salary";
            // 
            // lbSalaryWorker
            // 
            this.lbSalaryWorker.AutoSize = true;
            this.lbSalaryWorker.Location = new System.Drawing.Point(15, 64);
            this.lbSalaryWorker.Name = "lbSalaryWorker";
            this.lbSalaryWorker.Size = new System.Drawing.Size(79, 13);
            this.lbSalaryWorker.TabIndex = 9;
            this.lbSalaryWorker.Text = "Average Salary";
            // 
            // lbSalaryAdmin
            // 
            this.lbSalaryAdmin.AutoSize = true;
            this.lbSalaryAdmin.Location = new System.Drawing.Point(15, 128);
            this.lbSalaryAdmin.Name = "lbSalaryAdmin";
            this.lbSalaryAdmin.Size = new System.Drawing.Size(79, 13);
            this.lbSalaryAdmin.TabIndex = 11;
            this.lbSalaryAdmin.Text = "Average Salary";
            // 
            // lbSalaryManager
            // 
            this.lbSalaryManager.AutoSize = true;
            this.lbSalaryManager.Location = new System.Drawing.Point(15, 99);
            this.lbSalaryManager.Name = "lbSalaryManager";
            this.lbSalaryManager.Size = new System.Drawing.Size(79, 13);
            this.lbSalaryManager.TabIndex = 10;
            this.lbSalaryManager.Text = "Average Salary";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbHours);
            this.groupBox1.Controls.Add(this.lbHoursAdmin);
            this.groupBox1.Controls.Add(this.lbHoursWorker);
            this.groupBox1.Controls.Add(this.lbHoursManager);
            this.groupBox1.Location = new System.Drawing.Point(31, 250);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(303, 165);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hours Worked";
            // 
            // lbHours
            // 
            this.lbHours.AutoSize = true;
            this.lbHours.Location = new System.Drawing.Point(18, 31);
            this.lbHours.Name = "lbHours";
            this.lbHours.Size = new System.Drawing.Size(78, 13);
            this.lbHours.TabIndex = 12;
            this.lbHours.Text = "Average Hours";
            // 
            // lbHoursAdmin
            // 
            this.lbHoursAdmin.AutoSize = true;
            this.lbHoursAdmin.Location = new System.Drawing.Point(18, 128);
            this.lbHoursAdmin.Name = "lbHoursAdmin";
            this.lbHoursAdmin.Size = new System.Drawing.Size(78, 13);
            this.lbHoursAdmin.TabIndex = 15;
            this.lbHoursAdmin.Text = "Average Hours";
            // 
            // lbHoursWorker
            // 
            this.lbHoursWorker.AutoSize = true;
            this.lbHoursWorker.Location = new System.Drawing.Point(18, 64);
            this.lbHoursWorker.Name = "lbHoursWorker";
            this.lbHoursWorker.Size = new System.Drawing.Size(78, 13);
            this.lbHoursWorker.TabIndex = 13;
            this.lbHoursWorker.Text = "Average Hours";
            // 
            // lbHoursManager
            // 
            this.lbHoursManager.AutoSize = true;
            this.lbHoursManager.Location = new System.Drawing.Point(18, 99);
            this.lbHoursManager.Name = "lbHoursManager";
            this.lbHoursManager.Size = new System.Drawing.Size(78, 13);
            this.lbHoursManager.TabIndex = 14;
            this.lbHoursManager.Text = "Average Hours";
            // 
            // StatisticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 484);
            this.Controls.Add(this.gbGeneralStat);
            this.Controls.Add(this.cbStatistic);
            this.Controls.Add(this.chart1);
            this.Name = "StatisticsForm";
            this.Text = "StatisticsForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StatisticsForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.gbGeneralStat.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.Age.ResumeLayout(false);
            this.Age.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ComboBox cbStatistic;
        private System.Windows.Forms.GroupBox gbGeneralStat;
        private System.Windows.Forms.Label lbSalaryAdmin;
        private System.Windows.Forms.Label lbSalaryManager;
        private System.Windows.Forms.Label lbSalaryWorker;
        private System.Windows.Forms.Label lbSalary;
        private System.Windows.Forms.Label lbGenderAdmin;
        private System.Windows.Forms.Label lbGenderManager;
        private System.Windows.Forms.Label lbGenderWorker;
        private System.Windows.Forms.Label lbAgeAdmin;
        private System.Windows.Forms.Label lbAgeManager;
        private System.Windows.Forms.Label lbAgeWorker;
        private System.Windows.Forms.Label lbGender;
        private System.Windows.Forms.Label lbAge;
        private System.Windows.Forms.Label lbHoursAdmin;
        private System.Windows.Forms.Label lbHoursManager;
        private System.Windows.Forms.Label lbHoursWorker;
        private System.Windows.Forms.Label lbHours;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox Age;
    }
}