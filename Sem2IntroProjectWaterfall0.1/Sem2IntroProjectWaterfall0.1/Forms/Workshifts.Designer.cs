namespace Sem2IntroProjectWaterfall0._1
{
    partial class Workshifts
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
            this.lblDate = new System.Windows.Forms.Label();
            this.btnPreviousDay = new System.Windows.Forms.Button();
            this.btnNextDay = new System.Windows.Forms.Button();
            this.flpWorkshifts = new System.Windows.Forms.FlowLayoutPanel();
            this.btnWeekly = new System.Windows.Forms.Button();
            this.btnDaily = new System.Windows.Forms.Button();
            this.btnChangePreferences = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(12, 12);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 38);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblDate
            // 
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(385, 30);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(260, 20);
            this.lblDate.TabIndex = 22;
            this.lblDate.Text = "<Placeholder> - <Placeholder>";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPreviousDay
            // 
            this.btnPreviousDay.Location = new System.Drawing.Point(651, 30);
            this.btnPreviousDay.Name = "btnPreviousDay";
            this.btnPreviousDay.Size = new System.Drawing.Size(26, 23);
            this.btnPreviousDay.TabIndex = 23;
            this.btnPreviousDay.Text = "<";
            this.btnPreviousDay.UseVisualStyleBackColor = true;
            this.btnPreviousDay.Click += new System.EventHandler(this.btnPreviousDay_Click);
            // 
            // btnNextDay
            // 
            this.btnNextDay.Location = new System.Drawing.Point(683, 30);
            this.btnNextDay.Name = "btnNextDay";
            this.btnNextDay.Size = new System.Drawing.Size(26, 23);
            this.btnNextDay.TabIndex = 24;
            this.btnNextDay.Text = ">";
            this.btnNextDay.UseVisualStyleBackColor = true;
            this.btnNextDay.Click += new System.EventHandler(this.btnNextDay_Click);
            // 
            // flpWorkshifts
            // 
            this.flpWorkshifts.AutoSize = true;
            this.flpWorkshifts.Location = new System.Drawing.Point(12, 56);
            this.flpWorkshifts.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.flpWorkshifts.MaximumSize = new System.Drawing.Size(712, 374);
            this.flpWorkshifts.Name = "flpWorkshifts";
            this.flpWorkshifts.Size = new System.Drawing.Size(712, 374);
            this.flpWorkshifts.TabIndex = 25;
            // 
            // btnWeekly
            // 
            this.btnWeekly.Location = new System.Drawing.Point(12, 435);
            this.btnWeekly.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnWeekly.Name = "btnWeekly";
            this.btnWeekly.Size = new System.Drawing.Size(59, 21);
            this.btnWeekly.TabIndex = 26;
            this.btnWeekly.Text = "Weekly";
            this.btnWeekly.UseVisualStyleBackColor = true;
            this.btnWeekly.Click += new System.EventHandler(this.btnWeekly_Click);
            // 
            // btnDaily
            // 
            this.btnDaily.Location = new System.Drawing.Point(76, 435);
            this.btnDaily.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDaily.Name = "btnDaily";
            this.btnDaily.Size = new System.Drawing.Size(59, 21);
            this.btnDaily.TabIndex = 27;
            this.btnDaily.Text = "Daily";
            this.btnDaily.UseVisualStyleBackColor = true;
            this.btnDaily.Click += new System.EventHandler(this.btnDaily_Click);
            // 
            // btnChangePreferences
            // 
            this.btnChangePreferences.Location = new System.Drawing.Point(140, 435);
            this.btnChangePreferences.Name = "btnChangePreferences";
            this.btnChangePreferences.Size = new System.Drawing.Size(125, 23);
            this.btnChangePreferences.TabIndex = 28;
            this.btnChangePreferences.Text = "Change Preferences";
            this.btnChangePreferences.UseVisualStyleBackColor = true;
            this.btnChangePreferences.Click += new System.EventHandler(this.btnChangePreferences_Click);
            // 
            // Workshifts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 466);
            this.Controls.Add(this.btnChangePreferences);
            this.Controls.Add(this.btnDaily);
            this.Controls.Add(this.btnWeekly);
            this.Controls.Add(this.flpWorkshifts);
            this.Controls.Add(this.btnNextDay);
            this.Controls.Add(this.btnPreviousDay);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.btnBack);
            this.Name = "Workshifts";
            this.Text = "Workshifts";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Button btnPreviousDay;
        private System.Windows.Forms.Button btnNextDay;
        private System.Windows.Forms.FlowLayoutPanel flpWorkshifts;
        private System.Windows.Forms.Button btnWeekly;
        private System.Windows.Forms.Button btnDaily;
        private System.Windows.Forms.Button btnChangePreferences;
    }
}