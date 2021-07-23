using System;

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

        public double GetLength()
        {
            return To - From;
        }

        public bool IsInside(double number)
        {
            return number >= From && number <= To;
        }

        public Range GetIntersection(Range range)
        {
            if (From < range.To && To > range.From)
            {
                return new Range(Math.Max(From, range.From), Math.Min(To, range.To));
            }

            return null;
        }

        public Range[] GetUnion(Range range)
        {
            if (From <= range.To && To >= range.From)
            {
                return new Range[] { new Range(Math.Min(From, range.From), Math.Max(To, range.To)) };
            }

            if (From <= range.From)
            {
                return new Range[] { new Range(From, To), new Range(range.From, range.To) };
            }

            return new Range[] { new Range(range.From, range.To), new Range(From, To) };
        }

        public Range[] GetDifference(Range range, bool isCrossing)
        {
            if (range.From <= From && range.To >= To) // равны или 2 больше 1
            {
                return new Range[] { };
            }

            if (!isCrossing) // если не пересекаются
            {
                return new Range[] { new Range(From, To) };
            }

            if (From < range.From && To < range.To) // если второй пересекает справа
            {
                if (To == range.From)
                {
                    return new Range[] { new Range(From, To) };
                }

                return new Range[] { new Range(From, range.From) };
            }

            if (From > range.From && To > range.To) // если второй пересекает слева
            {
                if (From == range.To)
                {
                    return new Range[] { new Range(From, To) };
                }

                return new Range[] { new Range(range.To, To) };
            }

            return new Range[] { new Range(From, range.From), new Range(range.To, To) }; //остается второй внутри первого
        }

        public override string ToString()
        {
            return $"({From}; {To})";
        }
    }
}