using System;

namespace GroceryCo.Model
{
    public abstract class Entity : IComparable<Entity>
    {
        public const string ID = "Id";

        public Guid Id { get; protected set; }

        public int CompareTo(Entity other)
        {
            if (IsPersistent())
            {
                return Id.CompareTo(other.Id);
            }
            return 0;
        }

        private bool IsPersistent()
        {
            return (Id != Guid.Empty);
        }
    }
}
