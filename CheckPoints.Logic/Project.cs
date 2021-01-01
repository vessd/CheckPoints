using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CheckPoints.Logic
{
    public class Project : AggregateRoot
    {
        private readonly IList<Set> _sets;

        public virtual Name Name { get; protected set; }

        public virtual ReadOnlyCollection<Set> Sets => new ReadOnlyCollection<Set>(_sets);

        protected Project()
        {
            _sets = new List<Set>();
        }

        public Project(Name name) : this()
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        protected override Type GetRealType() => typeof(Project);
    }
}
