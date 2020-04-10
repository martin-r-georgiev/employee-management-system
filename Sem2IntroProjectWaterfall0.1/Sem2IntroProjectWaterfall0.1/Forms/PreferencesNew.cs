using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sem2IntroProjectWaterfall0._1
{
    public partial class PreferencesNew : Form
    {
        CheckBox[] allCbs;
        public PreferencesNew()
        {
            InitializeComponent();
            allCbs = new CheckBox[] {cbMonM, cbMonA, cbMonE, cbTueM, cbTueA, cbTueE, cbWedM, cbWedA, cbWedE, cbThursdayMorning,
                cbThursdayAfternoon, cbThursdayEvening, cbFridayMorning, cbFridayAfternoon, cbFridayEvening};
        }

        private void cbMon_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++) allCbs[i].Checked = cbMon.Checked;
        }

        private void cbTue_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 3; i < 6; i++) allCbs[i].Checked = cbTue.Checked;
        }

        private void cbWed_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 6; i < 9; i++) allCbs[i].Checked = cbWed.Checked;
        }

        private void cbThursday_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 9; i < 12; i++) allCbs[i].Checked = cbThursday.Checked;
        }

        private void cbFriday_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 12; i < 15; i++) allCbs[i].Checked = cbFriday.Checked;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            int shiftCount = 0;
            foreach (CheckBox cb in allCbs)
                if (cb.Checked) shiftCount++;
            if (shiftCount != 10) MessageBox.Show("Please pick 10 shifts to your preference", "Workshifts not enough", MessageBoxButtons.OK);
            else
            {
                MessageBox.Show("Succesfully picked preferences", "Preferences success", MessageBoxButtons.OK);

                //Code Here
                this.Close();
            }
        }
        //Still testing
        private void RefreshGUI(int checkBoxIndex, CheckBox mainCheckbox)
        {
            for (int i = checkBoxIndex; i < checkBoxIndex + 3; i++)
                if (allCbs[i].Checked)
                {
                    mainCheckbox.Checked = true;
                    return;
                }
            mainCheckbox.Checked = false;
        }

        private void cbMonM_CheckedChanged(object sender, EventArgs e)
        {
            int shiftCount = 0;
            foreach (CheckBox cb in allCbs)
                if (cb.Checked) shiftCount++;
            lblPreferences.Text = $"{shiftCount}/10";

            if (shiftCount < 10) lblPreferences.ForeColor = Color.FromArgb(192, 64, 0);
            else if (shiftCount > 10) lblPreferences.ForeColor = Color.Red;
            else lblPreferences.ForeColor = Color.Green;
        }
    }
}
