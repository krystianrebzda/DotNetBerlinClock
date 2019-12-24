using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BerlinClock.Classes.Services.Interfaces;

namespace BerlinClock.Classes.Services
{
    public class TimeParser : ITimeParser
    {
        private readonly char delimiterCharacter = ':';

        public int[] Parser(string time)
        {
            if (!CheckTimeCorrectFormat(time))
                throw new Exception("Time wrong format!. It doesn't contain character ':'");

            return ParseTimesValues(time.Split(new char[] { delimiterCharacter}, StringSplitOptions.RemoveEmptyEntries));
        }

        private int[] ParseTimesValues(string[] timesValues)
        {
            var values = new List<int>();

            foreach (var value in timesValues)
            {
                if (int.TryParse(value, out var result))
                    values.Add(result);
                else
                    throw new Exception("Value is not number!");
            }

            return values.ToArray();
        }

        private bool CheckTimeCorrectFormat(string time)
        {
            return time.Contains(delimiterCharacter);
        }
    }
}
