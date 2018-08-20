namespace Automagic.DomainModels.Core
{
    public class MilesMeasurement : Measurement
    {
        public MilesMeasurement(decimal value, Unit unit) : base(value, unit)
        {
            value.EnsureValueWithinRange(0, decimal.MaxValue, "Measurement value cannot be less than zero.", typeof(MilesMeasurement), null);
        }
    }
}
