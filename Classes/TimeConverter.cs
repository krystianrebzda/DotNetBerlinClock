using BerlinClock.Classes;
using BerlinClock.Classes.Services;
using BerlinClock.Classes.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        private readonly ITimeParser timeParser;
        private readonly IBerlinClockCreator berlinClockCreator;


        public TimeConverter() : this(new TimeParser(), new BerlinClockCreator())
        {

        }

        private TimeConverter(ITimeParser timeParser, IBerlinClockCreator berlinClockCreator)
        {
            this.timeParser = timeParser;
            this.berlinClockCreator = berlinClockCreator;
        }

        public string convertTime(string time)
        {
            return this.berlinClockCreator.Create(timeParser.Parser(time));
        }
    }
}
