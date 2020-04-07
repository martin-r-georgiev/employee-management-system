namespace Sem2IntroProjectWaterfall0._1
{
    partial class WorkshiftCells
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
            this.lblShiftOne = new System.Windows.Forms.Label();
            this.lblShiftTwo = new System.Windows.Forms.Label();
            this.lblShiftThree = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblShiftOne
            // 
            this.lblShiftOne.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblShiftOne.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblShiftOne.Location = new System.Drawing.Point(0, 0);
            this.lblShiftOne.Name = "lblShiftOne";
            this.lblShiftOne.Size = new System.Drawing.Size(33, 22);
            this.lblShiftOne.TabIndex = 0;
            // 
            // lblShiftTwo
            // 
            this.lblShiftTwo.BackColor = System.Drawing.SystemColors.Control;
            this.lblShiftTwo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblShiftTwo.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblShiftTwo.Location = new System.Drawing.Point(33, 0);
            this.lblShiftTwo.Name = "lblShiftTwo";
            this.lblShiftTwo.Size = new System.Drawing.Size(33, 22);
            this.lblShiftTwo.TabIndex = 1;
            // 
            // lblShiftThree
            // 
            this.lblShiftThree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblShiftThree.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblShiftThree.Location = new System.Drawing.Point(66, 0);
            this.lblShiftThree.Name = "lblShiftThree";
            this.lblShiftThree.Size = new System.Drawing.Size(33, 22);
            this.lblShiftThree.TabIndex = 2;
            // 
            // WorkshiftCells
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.lblShiftThree);
            this.Controls.Add(this.lblShiftTwo);
            this.Controls.Add(this.lblShiftOne);
            this.MinimumSize = new System.Drawing.Size(100, 22);
            this.Name = "WorkshiftCells";
            this.Size = new System.Drawing.Size(100, 22);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblShiftOne;
        private System.Windows.Forms.Label lblShiftTwo;
        private System.Windows.Forms.Label lblShiftThree;
    }
}
