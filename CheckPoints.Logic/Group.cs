using System;
using System.Collections.Generic;
using System.Linq;

namespace CheckPoints.Logic
{
    public class Group : Entity
    {
        private readonly List<CheckPoint> _checkPoints;

        public Set Set { get; }

        public Name Name { get; }

        public int Position { get; internal set; }

        public IReadOnlyList<CheckPoint> CheckPoints => _checkPoints;

        protected Group() { }

        internal Group(Set set, Name name, int position)
        {
            Set = set ?? throw new ArgumentNullException(nameof(set));
            Name = name ?? throw new ArgumentNullException(nameof(name));
            if (position < 1) throw new ArgumentOutOfRangeException(nameof(position));
            Position = position;

            _checkPoints = new List<CheckPoint>();
        }

        public bool AddCheckPoint(Name name, int position)
        {
            if (_checkPoints.Any(cp => cp.Name == name))
                return false;

            _checkPoints.Add(new CheckPoint(this, name, position));

            return true;
        }
    }
}
