using System;

namespace Core.Api
{
    public sealed class ModelError : IEquatable<ModelError>
    {
        public string Key { get; }
        public string Message { get; }

        public ModelError(string key, string message)
        {
            Key = key;
            Message = message;
        }

        public override bool Equals(object obj)
        {
            // ReSharper disable once BaseObjectEqualsIsObjectEquals
            return base.Equals(obj);
        }

        public bool Equals(ModelError other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return string.Compare(Key, other.Key, StringComparison.InvariantCultureIgnoreCase) == 0 &&
                   string.Compare(Message, other.Message, StringComparison.OrdinalIgnoreCase) == 0;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Key != null ? Key.GetHashCode() : 0) * 397) ^ (Message != null ? Message.GetHashCode() : 0);
            }
        }
    }
}
