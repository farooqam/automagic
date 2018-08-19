using System;
using Automagic.DomainModels.Core;

namespace Automagic.DomainModels.Vehicle
{
    public class Interior : ValueObject<Interior>
    {
        protected override HashCode CalculateHashCode()
        {
            throw new NotImplementedException();
        }

        protected override bool DoEqualityCheck(Interior a, Interior b)
        {
            return true;
        }
    }
}
