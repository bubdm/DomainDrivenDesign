using System;
using System.Collections.Generic;
using System.Linq;

namespace Joska.DomainDrivenDesign.Common
{
    /// <summary>
    ///     Represents an object defined by its immutable properties.
    /// </summary>
    /// <remarks>
    /// https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/implement-value-objects
    /// </remarks>
    public abstract class ValueObject : IEquatable<ValueObject>
    {
        public bool Equals(ValueObject other)
        {
            if (other == null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (GetType() != other.GetType())
            {
                return false;
            }

            using (var e1 = GetAttributes().GetEnumerator())
            using (var e2 = other.GetAttributes().GetEnumerator())
            {
                while (e1.MoveNext() && e2.MoveNext())
                {
                    // ReSharper disable once PossibleNullReferenceException
                    if (!e1.Current.Equals(e2.Current))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Provides attributes which define this object. Two object instances with the same attribute values are considered equal.
        /// Override this in inherited value object.
        /// </summary>
        /// <returns>Returns attribute values.</returns>
        
        protected abstract IEnumerable<object> GetAttributes();

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

            return Equals((ValueObject) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return GetAttributes().Aggregate(1187, (current, a) => current * a.GetHashCode());
            }
        }

        public static bool operator ==(ValueObject left, ValueObject right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ValueObject left, ValueObject right)
        {
            return !Equals(left, right);
        }
    }
}