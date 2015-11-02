using System.Runtime.Serialization;

namespace Com.Framework.Data
{
    [DataContract]
    public class PremiseType : BaseEntity
    {
        [DataMember]
        public int PremiseTypeID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }
    }
}