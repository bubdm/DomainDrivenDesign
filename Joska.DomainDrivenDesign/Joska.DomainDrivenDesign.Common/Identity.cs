using System;
using System.Collections.Generic;

namespace Joska.DomainDrivenDesign.Common
{
    /// <summary>
    ///     Represents unique identificator of an entity
    /// </summary>
    /// <typeparam name="T">Type of internal identity value</typeparam>
    public class Identity<T> : IEquatable<Identity<T>> where T : IComparable, new()
    {
        public T Value { get; private set; }

        public bool Equals(Identity<T> other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return EqualityComparer<T>.Default.Equals(Value, other.Value);
        }

        /// <summary>
        /// Controls access to internal value of identity. Identity can be set only once (possibly when rehydrating or creating
        /// new entity).
        /// Types default value is used to represent an uninitialized entity. Default value will not be accepted as an identity value.
        /// An unexpected behavior may occure when an entity with uninitialized identity is placed in a hashtable or related structure.
        /// An identity is expected to be set as soon as possible.
        /// </summary>
        public void Set(T value)
        {
            if (value.Equals(default(T)))
            {
                throw new InvalidOperationException(
                    "Value is default value of underlying identity type. Unable to set this value");
            }

            if (!Value.Equals(default(T)))
            {
                throw new InvalidOperationException(
                     $"Unable to set identity. Identity has been already set to {Value}. This can happen once.");
            }

            Value = value;
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

            return Equals((Identity<T>) obj);
        }

        public override int GetHashCode()
        {
            // ReSharper disable once NonReadonlyMemberInGetHashCode
            return EqualityComparer<T>.Default.GetHashCode(Value);
        }

        public static bool operator ==(Identity<T> left, Identity<T> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Identity<T> left, Identity<T> right)
        {
            return !Equals(left, right);
        }

        public override string ToString()
        {
            return $"[Identity: {Value}]";
        }
    }
}