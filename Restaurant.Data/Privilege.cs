using System;
using System.Collections.Generic;

namespace Restaurant.DataModels
{
    public class Privilege
    {
        public int PrivilegeID { get; set; }

        public string Name { get; set; }

        public int ConnectionType { get; set; }

        public virtual ICollection<StaffMember> Members { get; set; } 


        public Privilege()
        {
            Name = String.Empty;
        }
    }
}