using System;

namespace CheckPoints.Logic
{
    public class Percent : ValueObject<Percent>
    {
        private readonly float _percent;

        public Percent(float percent)
        {
            if (percent < 0 || percent > 1)
                throw new ArgumentOutOfRangeException(nameof(percent));

            _percent = percent;
        }

        protected override bool EqualsCore(Percent other)
        {
            return _percent == other._percent;
        }

        protected override int GetHashCodeCore()
        {
            return _percent.GetHashCode();
        }

        public override string ToString()
        {
            return _percent.ToString();
        }

        public static bool operator <(Percent a, Percent b)
        {
            return a?._percent < b?._percent;
        }

        public static bool operator >(Percent a, Percent b)
        {
            return a?._percent > b?._percent;
        }
    }
}
