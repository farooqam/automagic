using Automagic.DomainModels.Core;

namespace Automagic.DomainModels.Vehicle
{
    public class Trim : Text
    {
        public Trim(string value) : base(value)
        {
            value.EnsureStringSpecified("Specify a trim.", typeof(Trim));
        }
    }
}
