using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Com.Framework.Data.Core
{
    [DataContract]
    public class Department : AuditableEntity<long>
    {
        [DataMember]
        public int DepartmentID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }


        public virtual ICollection<Employee> Employees { get; set; }

        public virtual ICollection<Premise> Premises { get; set; }


        public Department()
        {

        }
    }
}
