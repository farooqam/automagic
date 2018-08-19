using System;
using System.Runtime.Serialization;

namespace Automagic.DomainModels.Core
{
    [Serializable]
    public sealed class DomainModelException : Exception
    {
        public Type Child { get; }
        public Type Root { get; }

        public DomainModelException(Type root, string message) : this(message)
        {
            Root = root;
        }

        public DomainModelException(Type root, Type child, string message) : this(root, message)
        {
            Child = child;
        }

        private DomainModelException(string message) : base(message)
        {
        }

        private DomainModelException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
