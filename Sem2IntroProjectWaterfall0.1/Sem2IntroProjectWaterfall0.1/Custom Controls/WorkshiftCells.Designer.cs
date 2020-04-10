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
            this.components = new System.ComponentModel.Container();
            this.lblShiftOne = new System.Windows.Forms.Label();
            this.lblShiftTwo = new System.Windows.Forms.Label();
            this.lblShiftThree = new System.Windows.Forms.Label();
            this.rightClickMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSetAvailable = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSetUnavailable = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rightClickMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblShiftOne
            // 
            this.lblShiftOne.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblShiftOne.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblShiftOne.Location = new System.Drawing.Point(0, 0);
            this.lblShiftOne.Name = "lblShiftOne";
            this.lblShiftOne.Size = new System.Drawing.Size(33, 30);
            this.lblShiftOne.TabIndex = 0;
            // 
            // lblShiftTwo
            // 
            this.lblShiftTwo.BackColor = System.Drawing.SystemColors.Control;
            this.lblShiftTwo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblShiftTwo.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblShiftTwo.Location = new System.Drawing.Point(33, 0);
            this.lblShiftTwo.Name = "lblShiftTwo";
            this.lblShiftTwo.Size = new System.Drawing.Size(33, 30);
            this.lblShiftTwo.TabIndex = 1;
            // 
            // lblShiftThree
            // 
            this.lblShiftThree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblShiftThree.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblShiftThree.Location = new System.Drawing.Point(66, 0);
            this.lblShiftThree.Name = "lblShiftThree";
            this.lblShiftThree.Size = new System.Drawing.Size(33, 30);
            this.lblShiftThree.TabIndex = 2;
            // 
            // rightClickMenu
            // 
            this.rightClickMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.rightClickMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSetAvailable,
            this.toolStripSetUnavailable,
            this.clearToolStripMenuItem});
            this.rightClickMenu.Name = "rightClickMenu";
            this.rightClickMenu.Size = new System.Drawing.Size(211, 104);
            this.rightClickMenu.Opened += new System.EventHandler(this.rightClickMenu_Opened);
            // 
            // toolStripSetAvailable
            // 
            this.toolStripSetAvailable.Name = "toolStripSetAvailable";
            this.toolStripSetAvailable.Size = new System.Drawing.Size(210, 24);
            this.toolStripSetAvailable.Text = "Set Available";
            this.toolStripSetAvailable.Click += new System.EventHandler(this.toolStripSetAvailable_Click);
            // 
            // toolStripSetUnavailable
            // 
            this.toolStripSetUnavailable.Name = "toolStripSetUnavailable";
            this.toolStripSetUnavailable.Size = new System.Drawing.Size(210, 24);
            this.toolStripSetUnavailable.Text = "Set Unavailable";
            this.toolStripSetUnavailable.Click += new System.EventHandler(this.toolStripSetUnavailable_Click);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
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
            this.Size = new System.Drawing.Size(100, 30);
            this.rightClickMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblShiftOne;
        private System.Windows.Forms.Label lblShiftTwo;
        private System.Windows.Forms.Label lblShiftThree;
        private System.Windows.Forms.ContextMenuStrip rightClickMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripSetAvailable;
        private System.Windows.Forms.ToolStripMenuItem toolStripSetUnavailable;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
    }
}
