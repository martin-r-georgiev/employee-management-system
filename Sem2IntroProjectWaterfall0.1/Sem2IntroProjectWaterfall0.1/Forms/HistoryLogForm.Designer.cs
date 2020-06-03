namespace Sem2IntroProjectWaterfall0._1
{
    partial class HistoryLogForm
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
            this.rtbxHistory = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rtbxHistory
            // 
            this.rtbxHistory.Location = new System.Drawing.Point(13, 12);
            this.rtbxHistory.Name = "rtbxHistory";
            this.rtbxHistory.ReadOnly = true;
            this.rtbxHistory.Size = new System.Drawing.Size(775, 426);
            this.rtbxHistory.TabIndex = 0;
            this.rtbxHistory.Text = "";
            this.rtbxHistory.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // HistoryLogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rtbxHistory);
            this.Name = "HistoryLogForm";
            this.Text = "HistoryLogForm";
            this.Load += new System.EventHandler(this.HistoryLogForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbxHistory;
    }
}