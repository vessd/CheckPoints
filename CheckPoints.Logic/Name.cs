using CheckPoints.Logic.Common;
using System;

namespace CheckPoints.Logic
{
    public class Name : ValueObject<Name>
    {
        private readonly string _name;

        protected Name() { }

        public Name(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            _name = name;
        }

        protected override bool EqualsCore(Name other)
        {
            return _name == other._name;
        }

        protected override int GetHashCodeCore()
        {
            return _name.GetHashCode();
        }

        public override string ToString()
        {
            return _name;
        }

        /*public static implicit operator string (Name name) => name._name;*/
    }
}
