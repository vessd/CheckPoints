using System;
using System.Collections.Generic;
using System.Linq;

namespace CheckPoints.Logic
{
    public class Group : AggregateRoot
    {
        public virtual Set Set { get; protected set; }

        public virtual Name Name { get; protected set; }

        public virtual int Position { get; protected set; }

        protected virtual IList<CheckPoint> CheckPoints { get; }

        protected Group()
        {
            CheckPoints = new List<CheckPoint>();
        }

        internal Group(Set set, Name name, int position) : this()
        {
            Set = set ?? throw new ArgumentNullException(nameof(set));
            Name = name ?? throw new ArgumentNullException(nameof(name));
            if (position < 1) throw new ArgumentOutOfRangeException(nameof(position));
            Position = position;
        }

        public virtual bool AddCheckPoint(Name name, int position)
        {
            if (CheckPoints.Any(cp => cp.Name == name))
                return false;

            CheckPoints.Add(new CheckPoint(this, name, position));

            return true;
        }

        protected override Type GetRealType() => typeof(Group);
    }
}
