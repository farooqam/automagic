using Automagic.DomainModels.Core;

namespace Automagic.DomainModels.Vehicle
{
    public class Color : Text
    {
        internal Color(string value) : base(value)
        {
        }
    }

    public static class Colors
    {
        public static Color Unknown = new Color("Unknown");
        public static Color Black = new Color("Black");
    }
}
