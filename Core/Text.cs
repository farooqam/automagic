using System;

namespace Automagic.DomainModels.Core
{
    public abstract class Text : ValueObject<Text>
    {
        public string Value { get; }

        protected Text(string value)
        {
            Value = value;
        }

        protected override HashCode CalculateHashCode()
        {
            return new HashCode(Value.ToLowerInvariant().GetHashCode());
        }

        protected override bool DoEqualityCheck(Text a, Text b)
        {
            return string.Compare(a.Value, b.Value, StringComparison.InvariantCultureIgnoreCase) == 0;
        }
    }
}
