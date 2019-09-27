using System;
using System.Reflection;

namespace BackManager.Domain
{
    public class Entity : Entity<long>, IEntity
    {
    }

    public class Entity<TPrimaryKey> : IEntity<TPrimaryKey>
    {
        /// <summary>
        /// Desc:删除时间
        /// Default:
        /// Nullable:True
        /// </summary>           
        public DateTime? DeletedAt { get; set; }

        /// <summary>
        /// Desc:删除用户
        /// Default:
        /// Nullable:True
        /// </summary>           
        public long? DeleteUserId { get; set; }
        public int DeleteFlag { get; set; } = 0;

        public virtual TPrimaryKey ID { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Entity<TPrimaryKey>))
            {
                return false;
            }

            //Same instances must be considered as equal
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            var other = (Entity<TPrimaryKey>)obj;
            //Must have a IS-A relation of types or must be same type
            var typeOfThis = GetType();
            var typeOfOther = other.GetType();
            if (!typeOfThis.GetTypeInfo().IsAssignableFrom(typeOfOther) && !typeOfOther.GetTypeInfo().IsAssignableFrom(typeOfThis))
            {
                return false;
            }

            return ID.Equals(other.ID);
        }

        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }

        public static bool operator ==(Entity<TPrimaryKey> left, Entity<TPrimaryKey> right)
        {
            if (Equals(left, null))
            {
                return Equals(right, null);
            }

            return left.Equals(right);
        }

        public static bool operator !=(Entity<TPrimaryKey> left, Entity<TPrimaryKey> right)
        {
            return !(left == right);
        }
    }
}
