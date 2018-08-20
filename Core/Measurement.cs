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
            //TODO: refactor to Core.
            var hashCode = 385229220;
            hashCode = hashCode * -1521134295 + Value.GetHashCode();
            hashCode = hashCode * -1521134295 + Unit.GetHashCode();

            return new HashCode(hashCode);
        }

        protected override bool DoEqualityCheck(Measurement a, Measurement b)
        {
            return a.Value == b.Value &&
                   a.Unit == b.Unit;
        }
    }
}
