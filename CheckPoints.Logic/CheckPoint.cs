using CheckPoints.Logic.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CheckPoints.Logic
{
    public class CheckPoint : AggregateRoot
    {
        private readonly List<State> _states;

        public Group Group { get; }

        public Name Name { get; }

        public int Position { get; }

        public IReadOnlyList<State> States => _states;

        protected CheckPoint() { }

        internal CheckPoint(Group group, Name name, int position)
        {
            Group = group ?? throw new ArgumentNullException(nameof(group));
            Name = name ?? throw new ArgumentNullException(nameof(name));
            if (position < 1) throw new ArgumentOutOfRangeException(nameof(position));
            Position = position;

            _states = new List<State>();
        }

        public bool AddState(Name name, Percent persent)
        {
            if (_states.Any(s => s.Percent == persent || s.Name == name))
                return false;

            _states.Add(new State(this, name, persent));

            return true;
        }

        protected override Type GetRealType() => typeof(CheckPoint);
    }
}
