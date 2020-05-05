using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Sem2IntroProjectWaterfall0._1
{
    public partial class WorkshiftCells : UserControl
    {
        private DateTime date;
        private string employeeID;
        private int? selectedWorkshiftIndex;
        private int?[] statusIndex;

        public WorkshiftCells(DateTime date, string employeeID)
        {
            InitializeComponent();
            this.date = date;
            this.employeeID = employeeID;
            this.selectedWorkshiftIndex = null;
            this.statusIndex = new int?[3];

            if (date.Date <= DateTime.Now.Date)
            {
                rightClickMenu.Enabled = false;
                depotRequestMenu.Enabled = false;
            }

            if((int)LoggedInUser.role != (int)Role.Worker)
            {
                lblShiftOne.ContextMenuStrip = lblShiftTwo.ContextMenuStrip = lblShiftThree.ContextMenuStrip = rightClickMenu;
            }
            else if (LoggedInUser.userID == employeeID) lblShiftOne.ContextMenuStrip = lblShiftTwo.ContextMenuStrip = lblShiftThree.ContextMenuStrip = depotRequestMenu;
        }

        private int? GetWorkshiftIndex(string objectName)
        {
            int? index = null;
            switch(objectName)
            {
                case "lblShiftOne": index = 0; break;
                case "lblShiftTwo": index = 1; break;
                case "lblShiftThree": index = 2; break;
            }
            return index;
        }

        private void SetColor(int index, Color color)
        {
            switch (index)
            {
                case 0: lblShiftOne.BackColor = color; break;
                case 1: lblShiftTwo.BackColor = color; break;
                case 2: lblShiftThree.BackColor = color; break;
            }
            
            if (date.Date < DateTime.Now.Date)
            {
                switch (index)
                {
                    case 0: lblShiftOne.BackColor = ColorControls.Blend(color, Color.DimGray, 0.5); break;
                    case 1: lblShiftTwo.BackColor = ColorControls.Blend(color, Color.DimGray, 0.5); break;
                    case 2: lblShiftThree.BackColor = ColorControls.Blend(color, Color.DimGray, 0.5); break;
                }       
            }
        }

        public void ClearColor(int index)
        {
            SetColor(index, SystemColors.Control);
            
        }
        public void SetAvailable(int index)
        {
            SetColor(index, Color.PaleGreen);
        }
        public void SetMissed(int index)
        {
            SetColor(index, Color.Firebrick);
        }
        public void SetUnavailable(int index) 
        { 
            SetColor(index, Color.Gray);
        }

        public void SetPending(int index)
        { 
            SetColor(index, Color.Yellow);

        }

        public void SetStatus(int status, int index)
        {
            switch (status)
            {
                case -1: ClearColor(index); statusIndex[index] = null; break;
                case 0: SetAvailable(index); statusIndex[index] = 0; break;
                case 1: SetPending(index); statusIndex[index] = 1; break;
                case 2: SetUnavailable(index); statusIndex[index] = 2; break;
                case 3: SetMissed(index); statusIndex[index] = 3; break;
                default: SetAvailable(index); statusIndex[index] = 0; break;
            }
        }

        private void ChangeWorkshiftStatus(int status, int workshiftIndex)
        {
            using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand($"DELETE FROM workshifts WHERE userID=@userid AND date = @date AND workshift = @workshift", conn))
                {
                    cmd.Parameters.AddWithValue("@userid", this.employeeID);
                    cmd.Parameters.AddWithValue("@date", this.date.Date);
                    cmd.Parameters.AddWithValue("@workshift", workshiftIndex);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                conn.Close();
            }

            using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand($"INSERT IGNORE INTO workshifts (userID, date, workshift, status) VALUES (@userid, @date, @workshift, @status)", conn))
                {
                    cmd.Parameters.AddWithValue("@userid", this.employeeID);
                    cmd.Parameters.AddWithValue("@date", this.date.Date);
                    cmd.Parameters.AddWithValue("@workshift", workshiftIndex);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                conn.Close();
            }
            SetStatus(status, workshiftIndex);
        }

        private void toolStripSetAvailable_Click(object sender, EventArgs e)
        {
            if (selectedWorkshiftIndex != null)
            {
                ChangeWorkshiftStatus(0, (int)selectedWorkshiftIndex);
            }
        }

        private void toolStripSetUnavailable_Click(object sender, EventArgs e)
        {
            if (selectedWorkshiftIndex != null)
            {
                ChangeWorkshiftStatus(2, (int)selectedWorkshiftIndex);
            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedWorkshiftIndex != null)
            {
                using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand($"DELETE FROM workshifts WHERE userID=@userid AND date = @date AND workshift = @workshift", conn))
                    {
                        cmd.Parameters.AddWithValue("@userid", this.employeeID);
                        cmd.Parameters.AddWithValue("@date", this.date.Date);
                        cmd.Parameters.AddWithValue("@workshift", selectedWorkshiftIndex);
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                    conn.Close();
                }
                SetStatus(-1, (int)selectedWorkshiftIndex);
            }
        }

        private void rightClickMenu_Opened(object sender, EventArgs e)
        {
            selectedWorkshiftIndex = GetWorkshiftIndex((sender as ContextMenuStrip).SourceControl.Name);
            int index = (int)selectedWorkshiftIndex;
            if (statusIndex[index] != 1)
            {
                toolStripApproveRequest.Visible = false;
                toolStripDeclineRequest.Visible = false;
                toolStripSetAvailable.Visible = true;
                toolStripSetUnavailable.Visible = true;
            }
            else
            {
                toolStripApproveRequest.Visible = true;
                toolStripDeclineRequest.Visible = true;
                toolStripSetAvailable.Visible = false;
                toolStripSetUnavailable.Visible = false;
            }

            if (statusIndex[index] == null || statusIndex[index] == 1) clearToolStripMenuItem.Visible = false;
            else clearToolStripMenuItem.Visible = true;
        }

        private void depotRequestMenu_Opened(object sender, EventArgs e)
        {
            selectedWorkshiftIndex = GetWorkshiftIndex((sender as ContextMenuStrip).SourceControl.Name);
            if (statusIndex[(int)selectedWorkshiftIndex] != 0) toolStripRequestCancelation.Enabled = false;
            else toolStripRequestCancelation.Enabled = true;
        }

        private void requestCancelationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedWorkshiftIndex != null)
            {
                ChangeWorkshiftStatus(1, (int)selectedWorkshiftIndex);
                RescheduleNotification.AddNotification(this.employeeID, this.date, (int)selectedWorkshiftIndex);
            }
        }

        private void toolStripApproveRequest_Click(object sender, EventArgs e)
        {
            if (selectedWorkshiftIndex != null)
            {
                ChangeWorkshiftStatus(2, (int)selectedWorkshiftIndex);
                RescheduleNotification selectedNotification = new RescheduleNotification(this.employeeID, this.date, (int)selectedWorkshiftIndex);
                selectedNotification.RemoveNotification();
            }

        }

        private void toolStripDeclineRequest_Click(object sender, EventArgs e)
        {
            if (selectedWorkshiftIndex != null)
            {
                ChangeWorkshiftStatus(0, (int)selectedWorkshiftIndex);
                RescheduleNotification selectedNotification = new RescheduleNotification(this.employeeID, this.date, (int)selectedWorkshiftIndex);
                selectedNotification.RemoveNotification();
            }
        }
    }
}
