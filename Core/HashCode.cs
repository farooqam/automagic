namespace Automagic.DomainModels.Core
{
    public sealed class HashCode
    {
        public int Value { get; }

        public HashCode(int value)
        {
            Value = value;
        }
    }
}