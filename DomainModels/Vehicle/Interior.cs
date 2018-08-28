using Automagic.DomainModels.Core;

namespace Automagic.DomainModels.Vehicle
{
    public sealed class Interior : ValueObject<Interior>
    {
        public Color Color { get; }

        public Interior(): this(Colors.Unknown)
        {
            
        }

        public Interior(Color color)
        {
            Color = color;
        }

        protected override HashCode CalculateHashCode()
        {
            return new HashCodeBuilder().Add(Color).Build();
        }

        protected override bool DoEqualityCheck(Interior a, Interior b)
        {
            return a.Color == b.Color;
        }
    }
}
