using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Com.Framework.Data.Restaurants.Menus
{
    [DataContract]
    public class Menu : Entity<long>
    {
        #region Keys

        [DataMember]
        public int PremiseID { get; set; }

        #endregion

        #region Properties

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public bool Active { get; set; }

        [DataMember]
        public ICollection<MenuCategory> MenuCategories { get; set; }

        [DataMember]
        public ICollection<Hours> Hours { get; set; }

        [DataMember]
        public byte[] Code { get; set; }

        #endregion

        #region Navigation Properties

        protected virtual Premise Premise { get; set; }

        #endregion

        public Menu()
        {
            MenuCategories = new List<MenuCategory>();
            Hours = new List<Hours>();
        }
    }
}
