using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoints.Logic
{
    public class Set : Entity
    {
        private readonly List<Group> _groups;

        public Name Name { get; }

        public IReadOnlyList<Group> Groups { get; }

        public Set(Name name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));

            _groups = new List<Group>();
        }

        public bool AddGroup(Name name, int position)
        {
            if (_groups.Any(cp => cp.Name == name))
                return false;

            _groups.Add(new Group(this, name, position));

            return true;
        }
    }
}
