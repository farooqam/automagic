namespace Automagic.DomainModels.Core
{
    public sealed class Unit : ValueObject<Unit>
    {
        public UnitAbbreviation Abbreviation { get; }

        internal Unit(UnitAbbreviation abbreviation)
        {
            Abbreviation = abbreviation;
        }

        protected override HashCode CalculateHashCode()
        {
            return new HashCode(Abbreviation.GetHashCode());
        }

        protected override bool DoEqualityCheck(Unit a, Unit b)
        {
            return a.Abbreviation == b.Abbreviation;
        }
    }

    public sealed class Units
    {
        public static Unit Miles = new Unit(new UnitAbbreviation("mi"));
    }

}
