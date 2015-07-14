using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.Design;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Restaurant.Data
{
    public enum EntityState : byte
    {
        Unchanged = 2,
        Added = 1,
        Modified = 0,
        Deleted = -1
    }

    public interface IEntity
    {
        EntityState EntityState { get; set; }
    }

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



    public abstract class EntityBase<TKey>
    {
        [DataMember]
        public TKey Key { get; set; }
    }

    [DataContract]
    public class Entity2 : EntityBase<Guid>
    {
        


    }

    public interface IEntityPersistence<out TEntity, in TKey>
    {
        TEntity GetByKey(TKey key);
    }

//    public class Persistence : IEntityPersistence<Entity>
//    {
//
//
//    }

    [ServiceContract]
    public interface IService<T> where T : Entity
    {
        [OperationContract]
        IList<T> All();

        [OperationContract]
        IList<T> All(string where, params string[] include);

        [OperationContract]
        IList<T> All(Func<T, bool> where, params Expression<Func<T, object>>[] include);

        [OperationContract]
        T Get(string where, params string[] include);

        [OperationContract]
        T Get(Func<T, bool> where, params Expression<Func<T, object>>[] include);

        [OperationContract]
        bool Update(params T[] items);
    }

//    public abstract class ServiceBase<T> : IService<T> where T : Entity
//    {
//
//
//    
//    }
//
//    public class Service : ServiceBase<Entity>
//    {
//        // This constructor sets the appropriate 
//        // persistence instance for the entity 
//        // being exposed by this service. 
//        public Service()
//        {
//            Persistence = new Persistence();
//        } 
//        // All the business rules for the entity 
//        // is handled in the ServiceBase class! }
//
//    }

}
