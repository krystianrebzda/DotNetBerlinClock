using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BerlinClock.Classes.Services.Interfaces;

namespace BerlinClock.Classes.Services
{
    public class FiveMinuteRow : IFiveMinuteRow
    {
        private readonly int charactersInMinuteLine = 11;

        public string Create(int value)
        {
            StringBuilder fiveMinutesRow = new StringBuilder();
            for (int i = 1; i <= value; i++)
            {
                fiveMinutesRow.Append(i % 3 == 0 ? (char)Light.Red : (char)Light.Yellow);
            }

            for(int i= 0; i < (charactersInMinuteLine - value); i++)
            {
                fiveMinutesRow.Append((char)Light.Off);
            }

            return fiveMinutesRow.ToString();
        }
    }
}
