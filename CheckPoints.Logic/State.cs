using System;
using System.Collections.Generic;
using System.Linq;

namespace CheckPoints.Logic
{
    public class State : Entity
    {
        private readonly List<State> _transitions;

        public CheckPoint CheckPoint { get; }

        public Name Name { get; }

        public Percent Percent { get; }

        public IReadOnlyList<State> Transitions => _transitions;

        protected State() { }

        internal State(CheckPoint checkPoint, Name name, Percent percent)
        {
            CheckPoint = checkPoint ?? throw new ArgumentNullException(nameof(checkPoint));
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Percent = percent ?? throw new ArgumentNullException(nameof(name));

            _transitions = new List<State>();
        }

        public bool CanChangeTo(State state)
        {
            return state != this &&
                   state.CheckPoint == CheckPoint &&
                  (state.Percent > Percent || Transitions.Contains(state));
        }

        protected override Type GetRealType() => typeof(State);
    }
}
