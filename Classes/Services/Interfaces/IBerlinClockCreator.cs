using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock.Classes.Services.Interfaces
{
    public interface IBerlinClockCreator
    {
        string Create(int[] timeValues);
    }
}
