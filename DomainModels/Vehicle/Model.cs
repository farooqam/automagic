using Automagic.DomainModels.Core;

namespace Automagic.DomainModels.Vehicle
{
    public class Model : Text
    {
        public Model(string value) : base(value)
        {
            value.EnsureStringSpecified("Specify a model.", typeof(Model));
        }
    }
}
