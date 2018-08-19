namespace Automagic.DomainModels.Core
{
    public abstract class ValueObject<T> where T : class 
    {
        protected abstract HashCode CalculateHashCode();
        protected abstract bool DoEqualityCheck(T a, T b);

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

            var valueObject = other as T;
            if (valueObject == null) return false;

            return DoEqualityCheck(this as T, valueObject);
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
