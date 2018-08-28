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
        public static Color Beige = new Color("Beige");
        public static Color Black = new Color("Black");
        public static Color Blue = new Color("Blue");
        public static Color Brown = new Color("Brown");
        public static Color Gold = new Color("Gold");
        public static Color Gray = new Color("Gray");
        public static Color Green = new Color("Green");
        public static Color Orange = new Color("Orange");
        public static Color Purple = new Color("Purple");
        public static Color Red = new Color("Red");
        public static Color Silver = new Color("Silver");
        public static Color White = new Color("White");
        public static Color Yellow = new Color("Yellow");
    }
}
