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
    public partial class WorkshiftUC : UserControl
    {
        private Employee employee;

        public static string shiftOneStart;
        public static string shiftTwoStart;
        public static string shiftThreeStart;
        public static string shiftThreeEnd;

        private DateTime date;
        private int?[] statusIndex;
        private int? selectedWorkshiftIndex;

        public Employee Employee
        {
            get { return this.employee; }
        }


        public WorkshiftUC(Employee employee, DateTime date)
        {
            InitializeComponent();
            this.employee = employee;
            this.date = date;
            panelDateWrapper.Visible = false;
            lblName.Text = employee.Name;
            lblShiftStart.Text = shiftOneStart;
            lblShiftMidpointOne.Text = shiftTwoStart;
            lblShiftMidpointTwo.Text = shiftThreeStart;
            lblShiftEnd.Text = shiftThreeEnd;
            statusIndex = new int?[3];
            this.selectedWorkshiftIndex = null;

            if (date.Date <= DateTime.Now.Date) rightClickMenu.Enabled = false;
            if ((int)LoggedInUser.role != (int)Role.Worker)
            {
                panelShiftOne.ContextMenuStrip = panelShiftTwo.ContextMenuStrip = panelShiftThree.ContextMenuStrip = rightClickMenu;
            }
            else if (LoggedInUser.userID == employee.UserID) panelShiftOne.ContextMenuStrip = panelShiftTwo.ContextMenuStrip = panelShiftThree.ContextMenuStrip = depotRequestMenu;
        }

        //Methods
        public void ShowHeader() { panelDateWrapper.Visible = true; }

        private int? GetWorkshiftIndex(string objectName)
        {
            int? index = null;
            switch (objectName)
            {
                case "panelShiftOne": index = 0; break;
                case "panelShiftTwo": index = 1; break;
                case "panelShiftThree": index = 2; break;
            }
            return index;
        }

        private void SetColor(int index, Color color)
        {
            switch (index)
            {
                case 0: panelShiftOne.BackColor = color; break;
                case 1: panelShiftTwo.BackColor = color; break;
                case 2: panelShiftThree.BackColor = color; break;
            }
        }

        public void ClearColor(int index) { SetColor(index, SystemColors.Control); }

        public void SetAvailable(int index) { SetColor(index, Color.PaleGreen); }

        public void SetMissed(int index) { SetColor(index, Color.Firebrick); }

        public void SetUnavailable(int index) { SetColor(index, Color.Gray); }

        public void SetPending(int index) { SetColor(index, Color.Yellow); }

        public void SetStatus(int status, int index)
        {
            if(index < statusIndex.Length && index >= 0)
            {
                switch (status)
                {
                    case -1: ClearColor(index); statusIndex[index] = null; break;
                    case 0: SetAvailable(index); statusIndex[index] = status; break;
                    case 1: SetPending(index); statusIndex[index] = status; break;
                    case 2: SetUnavailable(index); statusIndex[index] = status; break;
                    case 3: SetMissed(index); statusIndex[index] = status; break;
                    default: SetAvailable(index); statusIndex[index] = 0; break;
                }
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

        private void ChangeWorkshiftStatus(int status, int workshiftIndex)
        {
            using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand($"DELETE FROM workshifts WHERE userID=@userid AND date = @date AND workshift = @workshift", conn))
                {
                    cmd.Parameters.AddWithValue("@userid", this.employee.UserID);
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
                    cmd.Parameters.AddWithValue("@userid", this.employee.UserID);
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

        private void setAvailableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedWorkshiftIndex != null)
            {
                ChangeWorkshiftStatus(0, (int)selectedWorkshiftIndex);
            }
        }

        private void setUnavailableToolStripMenuItem_Click(object sender, EventArgs e)
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
                        cmd.Parameters.AddWithValue("@userid", this.employee.UserID);
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

        private void depotRequestMenu_Opened(object sender, EventArgs e)
        {
            selectedWorkshiftIndex = GetWorkshiftIndex((sender as ContextMenuStrip).SourceControl.Name);
            if (statusIndex[(int)selectedWorkshiftIndex] != 0) toolStripRequestCancelation.Enabled = false;
            else toolStripRequestCancelation.Enabled = true;
        }

        private void toolStripRequestCancelation_Click(object sender, EventArgs e)
        {
            if (selectedWorkshiftIndex != null)
            {
                ChangeWorkshiftStatus(1, (int)selectedWorkshiftIndex);
            }
        }

        private void toolStripApproveRequest_Click(object sender, EventArgs e)
        {
            if (selectedWorkshiftIndex != null)
            {
                ChangeWorkshiftStatus(2, (int)selectedWorkshiftIndex);
            }
        }

        private void toolStripDeclineRequest_Click(object sender, EventArgs e)
        {
            if (selectedWorkshiftIndex != null)
            {
                ChangeWorkshiftStatus(0, (int)selectedWorkshiftIndex);
            }
        }
    }
}
