namespace Automagic.DomainModels.Core
{
    public abstract class ValueObject<T> where T : class 
    {
        protected abstract HashCode CalculateHashCode();
        protected abstract bool DoEqualityCheck(ValueObject<T> a, ValueObject<T> b);

        public override int GetHashCode()
        {
            return CalculateHashCode().Value;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((ValueObject<T>)obj);
        }

        public bool Equals(ValueObject<T> other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return DoEqualityCheck(this, other);
        }

        public static bool operator ==(ValueObject<T> a, ValueObject<T> b)
        {
            return Equals(a, b);
        }

        public static bool operator !=(ValueObject<T> a, ValueObject<T> b)
        {
            return !(a == b);
        }
    }
}
