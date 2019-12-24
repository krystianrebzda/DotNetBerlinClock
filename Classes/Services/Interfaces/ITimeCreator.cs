using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock.Classes.Services.Interfaces
{
    public interface ITimeCreator
    {
        ITimeCreator Successor { get; set; }

        string Create(int number, string result, char colorOn, char colorOff);
    }
}
