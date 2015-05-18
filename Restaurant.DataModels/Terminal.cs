using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DataModels.Misc
{
    [Serializable]
    public class Terminal : Entity
    {
        public int TerminalID { get; set; }

        public string Name { get; set; }

        public int Number { get; set; }

        public bool IsOnline { get; set; }


        public Terminal()
        {
            

        }
    }
}
