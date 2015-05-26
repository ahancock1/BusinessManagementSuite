using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DataModels.Management.Menus
{
    public class PortionItem : Item
    {
        public float PortionSize { get; set; }

        public float ProtionCost
        {
            get { return Cost*PortionSize; }
        }

    }
}
