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
            this.toolStripApproveRequest = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDeclineRequest = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSetAvailable = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSetUnavailable = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.depotRequestMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripRequestCancelation = new System.Windows.Forms.ToolStripMenuItem();
            this.rightClickMenu.SuspendLayout();
            this.depotRequestMenu.SuspendLayout();
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
            this.toolStripApproveRequest,
            this.toolStripDeclineRequest,
            this.toolStripSetAvailable,
            this.toolStripSetUnavailable,
            this.clearToolStripMenuItem});
            this.rightClickMenu.Name = "rightClickMenu";
            this.rightClickMenu.ShowImageMargin = false;
            this.rightClickMenu.Size = new System.Drawing.Size(164, 124);
            this.rightClickMenu.Opened += new System.EventHandler(this.rightClickMenu_Opened);
            // 
            // toolStripApproveRequest
            // 
            this.toolStripApproveRequest.Name = "toolStripApproveRequest";
            this.toolStripApproveRequest.Size = new System.Drawing.Size(163, 24);
            this.toolStripApproveRequest.Text = "Approve request";
            this.toolStripApproveRequest.Click += new System.EventHandler(this.toolStripApproveRequest_Click);
            // 
            // toolStripDeclineRequest
            // 
            this.toolStripDeclineRequest.Name = "toolStripDeclineRequest";
            this.toolStripDeclineRequest.Size = new System.Drawing.Size(163, 24);
            this.toolStripDeclineRequest.Text = "Decline request";
            this.toolStripDeclineRequest.Click += new System.EventHandler(this.toolStripDeclineRequest_Click);
            // 
            // toolStripSetAvailable
            // 
            this.toolStripSetAvailable.Name = "toolStripSetAvailable";
            this.toolStripSetAvailable.Size = new System.Drawing.Size(163, 24);
            this.toolStripSetAvailable.Text = "Set Available";
            this.toolStripSetAvailable.Click += new System.EventHandler(this.toolStripSetAvailable_Click);
            // 
            // toolStripSetUnavailable
            // 
            this.toolStripSetUnavailable.Name = "toolStripSetUnavailable";
            this.toolStripSetUnavailable.Size = new System.Drawing.Size(163, 24);
            this.toolStripSetUnavailable.Text = "Set Unavailable";
            this.toolStripSetUnavailable.Click += new System.EventHandler(this.toolStripSetUnavailable_Click);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(163, 24);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // depotRequestMenu
            // 
            this.depotRequestMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.depotRequestMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripRequestCancelation});
            this.depotRequestMenu.Name = "depotRequestMenu";
            this.depotRequestMenu.ShowImageMargin = false;
            this.depotRequestMenu.Size = new System.Drawing.Size(219, 56);
            this.depotRequestMenu.Opened += new System.EventHandler(this.depotRequestMenu_Opened);
            // 
            // toolStripRequestCancelation
            // 
            this.toolStripRequestCancelation.Name = "toolStripRequestCancelation";
            this.toolStripRequestCancelation.Size = new System.Drawing.Size(218, 24);
            this.toolStripRequestCancelation.Text = "Request shift cancelation";
            this.toolStripRequestCancelation.Click += new System.EventHandler(this.requestCancelationToolStripMenuItem_Click);
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
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(100, 22);
            this.Name = "WorkshiftCells";
            this.Size = new System.Drawing.Size(100, 30);
            this.rightClickMenu.ResumeLayout(false);
            this.depotRequestMenu.ResumeLayout(false);
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
        private System.Windows.Forms.ContextMenuStrip depotRequestMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripRequestCancelation;
        private System.Windows.Forms.ToolStripMenuItem toolStripApproveRequest;
        private System.Windows.Forms.ToolStripMenuItem toolStripDeclineRequest;
    }
}
