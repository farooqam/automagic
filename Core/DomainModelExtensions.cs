using System;

namespace Automagic.DomainModels.Core
{
    public static class DomainModelExtensions
    {
        public static void EnsureStringSpecified(this string s, string messageWhenNotEnsured, Type root)
        {
            if (string.IsNullOrWhiteSpace(s)) throw new DomainModelException(root, messageWhenNotEnsured);
        }

        public static void EnsureValueObject<T>(this ValueObject<T> valueObject, string messageWhenNotEnsured, Type root, Type child) where T : class
        {
            if(valueObject == null) throw new DomainModelException(root, child, messageWhenNotEnsured);
        }

        public static void EnsureValueWithinRange<T>(
            this T value,
            T minInclusive, 
            T maxInclusive, 
            string messageWhenNotEnsured,
            Type root, 
            Type child) where T : IComparable<T>
        {
           if(value.CompareTo(minInclusive) < 0) throw new DomainModelException(root, child, messageWhenNotEnsured);
           if(value.CompareTo(maxInclusive) > 0) throw new DomainModelException(root, child, messageWhenNotEnsured);
        }
    }
}
