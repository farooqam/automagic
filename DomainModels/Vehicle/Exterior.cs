using System;
using Automagic.DomainModels.Core;

namespace Automagic.DomainModels.Vehicle
{
    public class Exterior : ValueObject<Exterior>
    {
        protected override HashCode CalculateHashCode()
        {
            throw new NotImplementedException();
        }

        protected override bool DoEqualityCheck(Exterior a, Exterior b)
        {
            return true;
        }
    }
}
