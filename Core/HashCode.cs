namespace Automagic.DomainModels.Core
{
    public sealed class HashCode
    {
        internal int Value { get; }

        internal HashCode(int value)
        {
            Value = value;
        }
    }

    public class HashCodeBuilder
    {
        internal int Value { get; private set; }

        public HashCodeBuilder()
        {
            Value = 385229220;
        }

        public HashCodeBuilder Add(object o)
        {
            Value = Value * -1521134295 + o.GetHashCode();
            return this;
        }

        public HashCode Build()
        {
            return new HashCode(Value);
        }
    }
    

}