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

        public WorkshiftCells(DateTime date, string employeeID)
        {
            InitializeComponent();
            this.date = date;
            this.employeeID = employeeID;
            this.selectedWorkshiftIndex = null;

            if(date.Date <= DateTime.Now.Date) rightClickMenu.Enabled = false;
            if((int)LoggedInUser.role > (int)Role.Worker)
            {
                lblShiftOne.ContextMenuStrip = lblShiftTwo.ContextMenuStrip = lblShiftThree.ContextMenuStrip = rightClickMenu;
            }
            
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
        }

        public void ClearColor(int index) { SetColor(index, SystemColors.Control); }

        public void SetAvailable(int index) { SetColor(index, Color.PaleGreen); }

        public void SetMissed(int index) { SetColor(index, Color.Firebrick); }

        public void SetUnavailable(int index) { SetColor(index, Color.Gray); }

        public void SetPending(int index) { SetColor(index, Color.Yellow); }

        public void SetStatus(int status, int index)
        {
            switch (status)
            {
                case -1: ClearColor(index); break;
                case 0: SetAvailable(index); break;
                case 1: SetPending(index); break;
                case 2: SetUnavailable(index); break;
                case 3: SetMissed(index); break;
                default: SetAvailable(index); break;
            }
        }

        private void toolStripSetAvailable_Click(object sender, EventArgs e)
        {
            if (selectedWorkshiftIndex!=null)
            {
                using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand($"DELETE FROM workshifts WHERE userID=@userid AND date = @date AND workshift = @workshift", conn))
                    {
                        cmd.Parameters.AddWithValue("@userid", this.employeeID);
                        cmd.Parameters.AddWithValue("@date", this.date);
                        cmd.Parameters.AddWithValue("@workshift", selectedWorkshiftIndex);
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
                        cmd.Parameters.AddWithValue("@date", this.date);
                        cmd.Parameters.AddWithValue("@workshift", selectedWorkshiftIndex);
                        cmd.Parameters.AddWithValue("@status", 0);
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                    conn.Close();
                }
                SetStatus(0, (int)selectedWorkshiftIndex);
            }
        }

        private void toolStripSetUnavailable_Click(object sender, EventArgs e)
        {
            if (selectedWorkshiftIndex != null)
            {
                using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand($"DELETE FROM workshifts WHERE userID=@userid AND date = @date AND workshift = @workshift", conn))
                    {
                        cmd.Parameters.AddWithValue("@userid", this.employeeID);
                        cmd.Parameters.AddWithValue("@date", this.date);
                        cmd.Parameters.AddWithValue("@workshift", selectedWorkshiftIndex);
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
                        cmd.Parameters.AddWithValue("@date", this.date);
                        cmd.Parameters.AddWithValue("@workshift", selectedWorkshiftIndex);
                        cmd.Parameters.AddWithValue("@status", 2);
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                    conn.Close();
                }
                SetStatus(2, (int)selectedWorkshiftIndex);
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
                        cmd.Parameters.AddWithValue("@date", this.date);
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
        }
    }
}
