using System;
using Restaurant.Data.Management.Staff;

namespace Restaurant.Data.Accounting
{
    [Serializable]
    public class Terminal : Entity
    {
        public int TerminalID { get; set; }

        public string Name { get; set; }

        public int Number { get; set; }

        public bool IsOnline { get; set; }

        public StaffMember StaffMember { get; set; }

        public Terminal()
        {
            

        }
    }
}
