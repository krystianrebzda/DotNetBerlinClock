using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BerlinClock.Classes.Services.Interfaces;

namespace BerlinClock.Classes.Services
{
    public class TimeCreator : ITimeCreator
    {
        public ITimeCreator Successor { get; set; }

        public TimeCreator(ITimeCreator hoursCreator)
        {
            Successor = hoursCreator;
        }

        public string Create(int number, string result, char colorOn, char colorOff)
        {
            if (number > 0)
                result += colorOn;
            else
                result += colorOff;

            number -= 1;

            if (Successor != null)
                result = Successor.Create(number, result, colorOn, colorOff);

            return result;
        }
    }
}
