using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.DataModels
{
    public enum EntityState
    {
        Unchanged,
        Added,
        Modified,
        Deleted
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

        [NotMapped]
        private EntityState entityState;
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
