namespace Automagic.DomainModels.Core
{
    public abstract class Measurement : ValueObject<Measurement>
    {
        public decimal Value { get; }
        public Unit Unit { get; }

        protected Measurement(decimal value, Unit unit)
        {
            unit.EnsureValueObject("Specify the unit.", GetType(), typeof(Unit));

            Value = value;
            Unit = unit;
        }

        protected override HashCode CalculateHashCode()
        {
            return new HashCodeBuilder().Add(Value).Add(Unit).Build();
        }

        protected override bool DoEqualityCheck(Measurement a, Measurement b)
        {
            return a.Value == b.Value &&
                   a.Unit == b.Unit;
        }
    }
}
