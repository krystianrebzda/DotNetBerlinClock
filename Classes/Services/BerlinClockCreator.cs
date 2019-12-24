using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BerlinClock.Classes.Services.Interfaces;

namespace BerlinClock.Classes.Services
{
    public class BerlinClockCreator : IBerlinClockCreator
    {
        private const int timeCount = 3;
        private const int hoursCount = 5;
        private const int minuteCount = 5;

        private readonly IFiveMinuteRow fiveMinuteRow;

        public BerlinClockCreator() : this(new FiveMinuteRow())
        {

        }

        private BerlinClockCreator(IFiveMinuteRow fiveMinuteRow)
        {
            this.fiveMinuteRow = fiveMinuteRow;
        }

        private StringBuilder berlinClockBuilder;

        public string Create(int[] timeValues)
        {
            if (!timeValues.Length.Equals(timeCount))
                throw new Exception("Number of values are not enough to create correct Berlin clock");

            berlinClockBuilder = new StringBuilder();

            CreateMainLamp(timeValues[(int)TimeValues.Seconds]);
            CreateTimesRows(timeValues[(int)TimeValues.Hours], timeValues[(int)TimeValues.Minutes]);

            return berlinClockBuilder.ToString();
        }

        private void CreateMainLamp(int valueSeconds)
        {
            berlinClockBuilder.Append(valueSeconds % 2 == 0 ? (char)Light.Yellow : (char)Light.Off);
            berlinClockBuilder.Append(Environment.NewLine);
        }

        private void CreateTimesRows(int valueHours, int valueMinutes)
        {
            var result = string.Empty;
            var timeCreator = new TimeCreator(new TimeCreator(new TimeCreator(new TimeCreator(null))));
            berlinClockBuilder.Append(timeCreator.Create(valueHours / hoursCount, result, (char)Light.Red, (char)Light.Off));
            berlinClockBuilder.Append(Environment.NewLine);
            berlinClockBuilder.Append(timeCreator.Create(valueHours % hoursCount, result, (char)Light.Red, (char)Light.Off));
            berlinClockBuilder.Append(Environment.NewLine);
            berlinClockBuilder.Append(fiveMinuteRow.Create(valueMinutes / minuteCount));
            berlinClockBuilder.Append(Environment.NewLine);
            berlinClockBuilder.Append(timeCreator.Create(valueMinutes % minuteCount, result, (char)Light.Yellow, (char)Light.Off));
        }
    }
}
