using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Restaurant.Data
{
    public enum EntityState
    {
        Deleted = -1,
        Modified = 0,
        Added = 1,
        Unchanged = 2
    }

    public interface IEntity
    {
        EntityState EntityState { get; set; }
    }

    [DataContract]
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
