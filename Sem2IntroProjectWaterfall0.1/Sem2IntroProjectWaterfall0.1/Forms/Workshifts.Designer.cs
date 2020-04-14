﻿namespace Sem2IntroProjectWaterfall0._1
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
            this.btnToggleView = new System.Windows.Forms.Button();
            this.btnChangePreferences = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(16, 15);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(100, 29);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblDate
            // 
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(513, 37);
            this.lblDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(347, 25);
            this.lblDate.TabIndex = 22;
            this.lblDate.Text = "<Placeholder> - <Placeholder>";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPreviousDay
            // 
            this.btnPreviousDay.Location = new System.Drawing.Point(868, 37);
            this.btnPreviousDay.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPreviousDay.Name = "btnPreviousDay";
            this.btnPreviousDay.Size = new System.Drawing.Size(35, 28);
            this.btnPreviousDay.TabIndex = 23;
            this.btnPreviousDay.Text = "<";
            this.btnPreviousDay.UseVisualStyleBackColor = true;
            this.btnPreviousDay.Click += new System.EventHandler(this.btnPreviousDay_Click);
            // 
            // btnNextDay
            // 
            this.btnNextDay.Location = new System.Drawing.Point(911, 37);
            this.btnNextDay.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnNextDay.Name = "btnNextDay";
            this.btnNextDay.Size = new System.Drawing.Size(35, 28);
            this.btnNextDay.TabIndex = 24;
            this.btnNextDay.Text = ">";
            this.btnNextDay.UseVisualStyleBackColor = true;
            this.btnNextDay.Click += new System.EventHandler(this.btnNextDay_Click);
            // 
            // flpWorkshifts
            // 
            this.flpWorkshifts.AutoSize = true;
            this.flpWorkshifts.Location = new System.Drawing.Point(16, 69);
            this.flpWorkshifts.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flpWorkshifts.MaximumSize = new System.Drawing.Size(949, 460);
            this.flpWorkshifts.Name = "flpWorkshifts";
            this.flpWorkshifts.Size = new System.Drawing.Size(949, 460);
            this.flpWorkshifts.TabIndex = 25;
            // 
            // btnToggleView
            // 
            this.btnToggleView.Location = new System.Drawing.Point(16, 535);
            this.btnToggleView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnToggleView.Name = "btnToggleView";
            this.btnToggleView.Size = new System.Drawing.Size(152, 26);
            this.btnToggleView.TabIndex = 26;
            this.btnToggleView.Text = "Toggle Daily view";
            this.btnToggleView.UseVisualStyleBackColor = true;
            this.btnToggleView.Click += new System.EventHandler(this.btnToggleView_Click);
            // 
            // btnChangePreferences
            // 
            this.btnChangePreferences.Location = new System.Drawing.Point(175, 535);
            this.btnChangePreferences.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnChangePreferences.Name = "btnChangePreferences";
            this.btnChangePreferences.Size = new System.Drawing.Size(167, 28);
            this.btnChangePreferences.TabIndex = 28;
            this.btnChangePreferences.Text = "Change Preferences";
            this.btnChangePreferences.UseVisualStyleBackColor = true;
            this.btnChangePreferences.Click += new System.EventHandler(this.btnChangePreferences_Click);
            // 
            // Workshifts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 574);
            this.Controls.Add(this.btnChangePreferences);
            this.Controls.Add(this.btnToggleView);
            this.Controls.Add(this.flpWorkshifts);
            this.Controls.Add(this.btnNextDay);
            this.Controls.Add(this.btnPreviousDay);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.btnBack);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
        private System.Windows.Forms.Button btnToggleView;
        private System.Windows.Forms.Button btnChangePreferences;
    }
}