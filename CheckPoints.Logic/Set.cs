using CheckPoints.Logic.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace CheckPoints.Logic
{
    public class Set : AggregateRoot
    {
        private readonly IList<Group> _groups;

        public virtual Project Project { get; protected set; }

        public virtual Name Name { get; protected set; }

        public virtual ReadOnlyCollection<Group> Groups => new ReadOnlyCollection<Group>(_groups);

        protected Set()
        {
            _groups = new List<Group>();
        }

        internal Set(Project project, Name name) : this()
        {
            Project = project ?? throw new ArgumentNullException(nameof(project));
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public virtual bool AddGroup(Name name, int position)
        {
            if (_groups.Any(cp => cp.Name == name))
                return false;

            _groups.Add(new Group(this, name, position));

            return true;
        }

        protected override Type GetRealType() => typeof(Set);
    }
}
