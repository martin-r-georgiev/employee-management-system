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
    public partial class NotificationUC : UserControl
    {
        RescheduleNotification notification;
        Employee employee;
        public NotificationUC(RescheduleNotification currentNotification)
        {
            InitializeComponent();
            this.notification = currentNotification;
            this.employee = new Employee(currentNotification.UserID,false);
            lblEmployeeName.Text = this.employee.FirstName + " " + this.employee.LastName;
            lblDate.Text = this.notification.Date.ToString("dd/MM/yyyy") + " ";
            switch (this.notification.WorkshiftIndex)
            {
                case 0: lblDate.Text += "Morning"; break;
                case 1: lblDate.Text += "Afternoon"; break;
                case 2: lblDate.Text += "Evening"; break;
            }
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            notification.UpdateWorkshift(2);
            notification.RemoveNotification();
            Dashboard pForm = (Dashboard)this.ParentForm;
            pForm.RefreshNotifications();
        }

        private void btnDeny_Click(object sender, EventArgs e)
        {
            notification.UpdateWorkshift(0);
            notification.RemoveNotification();
            Dashboard pForm = (Dashboard)this.ParentForm;
            pForm.RefreshNotifications();
        }
    }
}
