using System.Runtime.Serialization;

namespace Com.Framework.Data
{
    [DataContract]
    public class EmployeeGroup : Entity
    {
        [DataMember]
        public int EmployeeGroupNameID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }
    }
}