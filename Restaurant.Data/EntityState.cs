using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Data
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
        [NotMapped]
        public EntityState EntityState { get; set; }
    }
}
