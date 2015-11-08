using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Com.Framework.Data.Core
{
    [DataContract]
    public class Item : AuditableEntity<long>
    {
        [DataMember]
        public int ItemID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        public ItemType ItemType { get; set; }


        protected virtual ICollection<Premise> Premises { get; set; }

    }

    [DataContract]
    public class ItemType
    {
        [DataMember]
        public int ItemTypeID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        protected virtual ICollection<Item> Items { get; set; }

        public ItemType()
        {
            Name = String.Empty;
        }
    }
}
