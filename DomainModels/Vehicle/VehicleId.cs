using Automagic.DomainModels.Core;

namespace Automagic.DomainModels.Vehicle
{
    public sealed class VehicleId : Text
    {
        
        public VehicleId(string value) : base(value)
        {
            value.EnsureStringSpecified("Specify a vehicle id.", typeof(VehicleId));
        }
    }
}