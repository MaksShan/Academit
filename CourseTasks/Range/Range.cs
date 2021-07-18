using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Range
{
    class Range
    {
        public double From { get; private set; }
        public double To { get; private set; }


        public Range(double from, double to)
        {
            From = from;
            To = to;
        }

        public double GetRange()
        {
            return To - From;
        }

        public bool IsInside(double number)
        {
            return number >= From && number <= To;
        }

        private bool isCrossing = true;
        public Range GetCrossingInterval(Range range2)
        {
            if (From < range2.To && To > range2.From)
            {
                double newFrom = Math.Max(From, range2.From);
                double newTo = Math.Min(To, range2.To);

                return new Range(newFrom, newTo);
            }

            isCrossing = false;

            return null;
        }

        public Range[] GetCombinedInterval(Range range2)
        {
            if (From <= range2.To && To >= range2.From)
            {
                double newFrom = Math.Min(From, range2.From);
                double newTo = Math.Max(To, range2.To);

                return new Range[] { new Range(newFrom, newTo) };
            }

            if (From <= range2.From)
            {
                return new Range[] { new Range(From, To), new Range(range2.From, range2.To) };
            }

            return new Range[] { new Range(range2.From, range2.To), new Range(From, To) };
        }

        public Range[] GetIntervalDifference(Range range2)
        {
            if (range2.From <= From && range2.To >= To) // равны или 2 больше 1
            {
                return null;
            }

            if (!isCrossing) // если не пересекаются
            {
                return new Range[] { new Range(From, To) };
            }

            if (From < range2.From && To > range2.To) // если второй внутри первого
            {
                return new Range[] { new Range(From, range2.From - 1), new Range(range2.To + 1, To) };
            }

            if (From < range2.From && To < range2.To) // если второй пересекает справа
            {
                return new Range[] { new Range(From, range2.From - 1) };
            }

            if (From > range2.From && To > range2.To) // если второй пересекает слева
            {
                return new Range[] { new Range(range2.To + 1, To) };
            }

            return new Range[] { new Range(From, range2.From), new Range(range2.To, To) };
        }
    }
}