using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Com.Framework.Data
{
    public enum EntityState
    {
        Deleted = -1,
        Modified = 0,
        Added = 1,
        Unchanged = 2
    }

    public interface IBaseEntity
    {
        EntityState EntityState { get; set; }
    }

    public interface IEntity<T> : IBaseEntity
    {
        T Id { get; set; }
    }

    //    [DataContract]
    //    public abstract class BaseEntity : IBaseEntity
    //    {
    //        [NotMapped]
    //        public EntityState EntityState { get; set; }
    //
    //        protected BaseEntity()
    //        {
    //            EntityState = EntityState.Added;
    //        }
    //    }

    [DataContract]
    public abstract class Entity<T> : IEntity<T>
    {
        [DataMember]
        [Key]
        public virtual T Id { get; set; }

        [NotMapped]
        public EntityState EntityState { get; set; }
    }

    public interface IAuditableEntity
    {
        DateTime CreatedDate { get; set; }

        string CreatedBy { get; set; }

        DateTime ModifiedDate { get; set; }

        string ModifiedBy { get; set; }
    }

    [DataContract]
    public abstract class AuditableEntity<T> : Entity<T>, IAuditableEntity
    {
        [DataMember]
        [ScaffoldColumn(false)]
        public DateTime CreatedDate { get; set; }

        [DataMember]
        [MaxLength(256)]
        [ScaffoldColumn(false)]
        public string CreatedBy { get; set; }

        [DataMember]
        [ScaffoldColumn(false)]
        public DateTime ModifiedDate { get; set; }

        [DataMember]
        [MaxLength(256)]
        [ScaffoldColumn(false)]
        public string ModifiedBy { get; set; }
    }
}
