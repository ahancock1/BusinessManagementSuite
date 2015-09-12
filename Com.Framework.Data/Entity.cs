using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Com.Framework.Data
{
    public enum EntityState
    {
        Deleted = -1,
        Modified = 0,
        Added = 1,
        Unchanged = 2
    }

    [DataContract]
    public abstract class Entity
    {
        [NotMapped, DataMember]
        public EntityState EntityState { get; set; }
    }
}
