using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Restaurant.Data.Management.Floor
{
    [DataContract]
    public class Section : Entity
    {
        [Key, DataMember]
        public int SectionID { get; set; }

        [DataMember]
        public string Name { get; set; }

        public virtual SectionType SectionType { get; set; }

        public virtual ICollection<Table> Tables { get; set; }
    }

    [DataContract]
    public class SectionType : Entity
    {
        [Key, DataMember]
        public int SectionTypeID { get; set; }

        [DataMember]
        public string Name { get; set; }
    }
}