using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MediaBazaarApplicationWPF
{
    public class WorkshiftsManager
    {
        //Instance variable(s)
        protected string _userID;
        protected DateTime _date;
        protected int? _selectedWorkshiftIndex;
        protected int?[] _statusIndex;

        protected Panel _workshiftOneCell;
        protected Panel _workshiftTwoCell;
        protected Panel _workshiftThreeCell;

        //Properties
        public string UserID
        {
            get => this._userID;
            private set { this._userID = value; }
        }

        public DateTime Date
        {
            get => this._date;
            private set { this._date = value; }
        }

        public int? SelectedWorkshiftIndex
        {
            get { return this._selectedWorkshiftIndex; }
            set
            {
                if ((value >= 0 && value <= 2) || value == null) this._selectedWorkshiftIndex = value;
                else throw new IndexOutOfRangeException("Workshifts: Selected workshift index is out of range.");
            }
        }

        public int?[] StatusIndex => this._statusIndex;

        public Panel WorkshiftOneCell
        {
            get => this._workshiftOneCell;
            set { this._workshiftOneCell = value; }
        }
        public Panel WorkshiftTwoCell
        {
            get => this._workshiftTwoCell;
            set { this._workshiftTwoCell = value; }
        }
        public Panel WorkshiftThreeCell
        {
            get => this._workshiftThreeCell;
            set { this._workshiftThreeCell = value; }
        }

        //Contructor(s)
        public WorkshiftsManager(DateTime date, string userID)
        {
            this.Date = date;
            this.UserID = userID;
            this.SelectedWorkshiftIndex = null;
            this._statusIndex = new int?[3];

            _workshiftOneCell = null;
            _workshiftTwoCell = null;
            _workshiftThreeCell = null;
        }

        public void SetWorkshiftPanels(Panel cellOne, Panel cellTwo, Panel cellThree)
        {
            this.WorkshiftOneCell = cellOne;
            this.WorkshiftTwoCell = cellTwo;
            this.WorkshiftThreeCell = cellThree;
        }

        public void SetStatus(int status, int index)
        {
            switch (status)
            {
                case -1: ClearColor(index); _statusIndex[index] = null; break;
                case 0: SetAvailable(index); _statusIndex[index] = 0; break;
                case 1: SetPending(index); _statusIndex[index] = 1; break;
                case 2: SetUnavailable(index); _statusIndex[index] = 2; break;
                case 3: SetMissed(index); _statusIndex[index] = 3; break;
                default: SetAvailable(index); _statusIndex[index] = 0; break;
            }
        }

        public void SetColor(int index, Color color)
        {
            SolidColorBrush brush = new SolidColorBrush(color);

            switch (index)
            {
                case 0: WorkshiftOneCell.Background = brush; break;
                case 1: WorkshiftTwoCell.Background = brush; break;
                case 2: WorkshiftThreeCell.Background = brush; break;
            }

            if (Date.Date < DateTime.Now.Date)
            {
                brush = new SolidColorBrush(ColorControls.Blend(color, Colors.DimGray, 0.5));

                switch (index)
                {
                    case 0: WorkshiftOneCell.Background = brush; break;
                    case 1: WorkshiftTwoCell.Background = brush; break;
                    case 2: WorkshiftThreeCell.Background = brush; break;
                }
            }
        }

        public void ClearColor(int index) { SetColor(index, SystemColors.ControlColor); }

        public void SetAvailable(int index) { SetColor(index, Colors.PaleGreen); }

        public void SetMissed(int index) { SetColor(index, Colors.Firebrick); }

        public void SetUnavailable(int index) { SetColor(index, Colors.Gray); }

        public void SetPending(int index) { SetColor(index, Colors.Yellow); }
    }
}
