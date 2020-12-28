using System;
using System.Collections.Generic;
using System.Linq;

namespace CheckPoints.Logic
{
    public class Document : Entity
    {
        private readonly List<Record> _records;

        public string Ident { get; }

        public Name Name { get; }

        public IReadOnlyList<Record> Records => _records;

        protected Document() { }

        public Document(string ident, Name name)
        {
            if (string.IsNullOrWhiteSpace(ident))
                throw new ArgumentNullException(nameof(ident));

            Ident = ident;
            Name = name ?? throw new ArgumentNullException(nameof(name)); ;

            _records = new List<Record>();
        }

        public bool SetState(State state, User user)
        {
            var currentState = Records.LastOrDefault(r => r.State.CheckPoint == state.CheckPoint)?.State;
            if (currentState == null || currentState.CanChangeTo(state))
            {
                _records.Add(new Record(this, state, user, DateTime.Now));
                return true;
            }
            return false;
        }

        public bool RevertLastState(CheckPoint checkPoint)
        {
            var record = Records.LastOrDefault(r => r.State.CheckPoint == checkPoint);
            if (record != null)
            {
                return _records.Remove(record);
            }
            return false;
        }
    }
}
