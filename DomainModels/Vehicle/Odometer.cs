﻿using Automagic.DomainModels.Core;

namespace Automagic.DomainModels.Vehicle
{
    public sealed class Odometer : ValueObject<Odometer>
    {
        public Measurement Measurement { get; }

        public Odometer(Measurement measurement)
        {
            measurement.EnsureValueObject("Specify a measurement.", typeof(Odometer), typeof(Measurement));

            Measurement = measurement;
        }

        protected override HashCode CalculateHashCode()
        {
            return new HashCodeBuilder().Add(Measurement).Build();
        }

        protected override bool DoEqualityCheck(Odometer a, Odometer b)
        {
            return a.Measurement == b.Measurement;
        }
    }
}
