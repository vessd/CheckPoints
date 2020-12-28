using System;

namespace CheckPoints.Logic
{
    public sealed class User : Entity
    {
        public Name Name { get; }

        public User(Name name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
    }
}
