using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sem2IntroProjectWaterfall0._1
{
    public partial class WorkshiftUC : UserControl
    {
        public static string shiftOneStart;
        public static string shiftTwoStart;
        public static string shiftThreeStart;
        public static string shiftThreeEnd;

        public WorkshiftUC(string Name)
        {
            InitializeComponent();
            panelDateWrapper.Visible = false;
            lblName.Text = Name;
            lblShiftStart.Text = shiftOneStart;
            lblShiftMidpointOne.Text = shiftTwoStart;
            lblShiftMidpointTwo.Text = shiftThreeStart;
            lblShiftEnd.Text = shiftThreeEnd;
        }

        //Methods
        public void ShowHeader() { panelDateWrapper.Visible = true; }

        private void SetColor(int index, Color color)
        {
            switch (index)
            {
                case 0: panelShiftOne.BackColor = color; break;
                case 1: panelShiftTwo.BackColor = color; break;
                case 2: panelShiftThree.BackColor = color; break;
            }
        }

        public void SetAvailable(int index) { SetColor(index, Color.PaleGreen); }

        public void SetMissed(int index) { SetColor(index, Color.Firebrick); }

        public void SetUnavailable(int index) { SetColor(index, Color.Gray); }

        public void SetPending(int index) { SetColor(index, Color.Yellow); }

        public void SetStatus(int status, int index)
        {
            switch(status)
            {
                case 0: SetAvailable(index); break;
                case 1: SetPending(index); break;
                case 2: SetUnavailable(index); break;
                case 3: SetMissed(index); break;
                default: SetAvailable(index); break;
            }
        }
    }
}
