using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Data
{
    public enum EntityState : byte
    {
        Unchanged = 0,
        Added = 1,
        Modified = 0,
        Deleted = -1
    }

    public interface IEntity
    {
        EntityState EntityState { get; set; }
    }

    [Serializable]
    public abstract class Entity : IEntity
    {
        public DateTime LastUpdated { get; set; }

        protected Entity()
        {
            LastUpdated = DateTime.Now;
        }

        private EntityState entityState;
        [NotMapped]
        public EntityState EntityState
        {
            get { return entityState; }
            set
            {
                entityState = value;
                LastUpdated = DateTime.Now;
            }
        }
    }
}
