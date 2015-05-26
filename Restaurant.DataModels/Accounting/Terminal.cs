using System;
using Restaurant.DataModels.Management.Staff;

namespace Restaurant.DataModels.Accounting
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
