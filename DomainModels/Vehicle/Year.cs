﻿using System;
using Automagic.DomainModels.Core;

namespace Automagic.DomainModels.Vehicle
{
    public sealed class Year : ValueObject<Year>
    {
        public static short Min => 1981;
        public static short Max => (short)(DateTime.Now.Year + 1);
        public short Value { get; }
        

        public Year(short value)
        {
            value.EnsureValueWithinRange(Min, Max, $"Year must be between {Min} and {Max}.", typeof(Year), null);

            Value = value;
        }
        protected override HashCode CalculateHashCode()
        {
            return new HashCodeBuilder().Add(Value).Build();
        }

        protected override bool DoEqualityCheck(Year a, Year b)
        {
            return a.Value == b.Value;
        }
    }
}
