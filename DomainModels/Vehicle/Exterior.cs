using Automagic.DomainModels.Core;

namespace Automagic.DomainModels.Vehicle
{
    public class Exterior : ValueObject<Exterior>
    {
        public Color Color { get; }

        public Exterior(): this(Colors.Unknown)
        {
            
        }

        public Exterior(Color color)
        {
            Color = color;
        }

        protected override HashCode CalculateHashCode()
        {
            return new HashCodeBuilder().Add(Color).Build();
        }

        protected override bool DoEqualityCheck(Exterior a, Exterior b)
        {
            return a.Color == b.Color;
        }
    }
}
