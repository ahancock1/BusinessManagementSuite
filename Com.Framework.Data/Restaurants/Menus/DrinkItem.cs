using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Com.Framework.Data.Restaurants.Menus
{
    [DataContract]
    public class DrinkItem : MenuItem
    {
        public DrinkType DrinkType { get; set; }

        public float AlcoholVolume { get; set; }


    }

    [DataContract]
    public class DrinkType
    {

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }
    }
}
