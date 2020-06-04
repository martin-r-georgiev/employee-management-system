using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApplicationWPF.Workshifts_Backend
{
    interface IWorkshifts
    {
        int? GetWorkshiftIndex(string objectName);
        void ChangeWorkshiftStatus(int status, int workshiftIndex);
    }
}
