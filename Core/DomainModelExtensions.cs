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
    }
}
