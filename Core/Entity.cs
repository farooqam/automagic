using System;

namespace Automagic.DomainModels.Core
{
    public abstract class Entity<TId> : IEquatable<Entity<TId>> where TId : IComparable<TId>
    {
        protected abstract HashCode CalculateHashCode();
        protected abstract bool DoEqualityCheck(TId a, TId b);

        public TId Id { get; }

        protected Entity(TId id)
        {
            Id = id;
        }

        public override int GetHashCode()
        {
            return CalculateHashCode().Value;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Entity<TId>)obj);
        }

        public bool Equals(Entity<TId> other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return DoEqualityCheck(Id, other.Id);
        }

        public static bool operator ==(Entity<TId> a, Entity<TId> b)
        {
            return Equals(a, b);
        }

        public static bool operator !=(Entity<TId> a, Entity<TId> b)
        {
            return !(a == b);
        }
    }
}
