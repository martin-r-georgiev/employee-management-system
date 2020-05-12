using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Sem2IntroProjectWaterfall0._1
{
    interface IWorkshifts
    {
        int? GetWorkshiftIndex(string objectName);

        void SetColor(int index, Color color);
        void ClearColor(int index);
        void SetAvailable(int index);
        void SetMissed(int index);
        void SetUnavailable(int index);
        void SetPending(int index);
        void SetStatus(int status, int index);

        void ChangeWorkshiftStatus(int status, int workshiftIndex);
    }
}
