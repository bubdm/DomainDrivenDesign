using System;
using System.Collections.Generic;

namespace Joska.DomainDrivenDesign.Common
{
    /// <summary>
    /// Represents an object defined by its unique identity.
    /// </summary>
    public abstract class Entity<TKey, TIdentity> : IEquatable<Entity<TKey, TIdentity>>
        where TIdentity : Identity<TKey>, new()
        where TKey : IComparable, new()
    {
        /// <summary>
        /// Identity of the entity.
        /// </summary>
        public TIdentity Identity { get; } = new TIdentity();

        public bool Equals(Entity<TKey, TIdentity> other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return EqualityComparer<TIdentity>.Default.Equals(Identity, other.Identity);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            return Equals((Entity<TKey, TIdentity>) obj);
        }

        public override int GetHashCode()
        {
            return EqualityComparer<TIdentity>.Default.GetHashCode(Identity);
        }

        public static bool operator ==(Entity<TKey, TIdentity> left, Entity<TKey, TIdentity> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Entity<TKey, TIdentity> left, Entity<TKey, TIdentity> right)
        {
            return !Equals(left, right);
        }

        public override string ToString()
        {
            return $"[Entity {GetType().Name} Id: {Identity}]";
        }
    }
}