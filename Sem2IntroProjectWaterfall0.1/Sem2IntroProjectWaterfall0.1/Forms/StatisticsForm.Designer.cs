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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cbStatistic = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea4.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chart1.Legends.Add(legend4);
            this.chart1.Location = new System.Drawing.Point(12, 48);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(671, 424);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // cbStatistic
            // 
            this.cbStatistic.FormattingEnabled = true;
            this.cbStatistic.Items.AddRange(new object[] {
            "Emplyoee distribution per department",
            "Emplyoees distribution per role",
            "Items ussage per deparment",
            "Day preference",
            "Shift preference"});
            this.cbStatistic.Location = new System.Drawing.Point(12, 12);
            this.cbStatistic.Name = "cbStatistic";
            this.cbStatistic.Size = new System.Drawing.Size(250, 21);
            this.cbStatistic.TabIndex = 8;
            this.cbStatistic.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // StatisticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 484);
            this.Controls.Add(this.cbStatistic);
            this.Controls.Add(this.chart1);
            this.Name = "StatisticsForm";
            this.Text = "StatisticsForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StatisticsForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ComboBox cbStatistic;
    }
}