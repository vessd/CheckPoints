using CheckPoints.Logic.Common;
using System;

namespace CheckPoints.Logic
{
    public class Record : Entity
    {
        public Document Document { get; }

        public State State { get; }

        public User User { get; }

        public DateTime DateCreated { get; }

        protected Record() { }

        internal Record(Document document, State state, User user, DateTime dateCreated)
        {
            Document = document ?? throw new ArgumentNullException(nameof(document));
            State = state ?? throw new ArgumentNullException(nameof(state));
            User = user ?? throw new ArgumentNullException(nameof(user));
            DateCreated = dateCreated;
        }

        protected override Type GetRealType() => typeof(Record);
    }
}
