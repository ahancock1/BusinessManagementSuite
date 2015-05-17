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

    public abstract class Entity
    {
        [NotMapped]
        public EntityState EntityState { get; set; }
    }
}
