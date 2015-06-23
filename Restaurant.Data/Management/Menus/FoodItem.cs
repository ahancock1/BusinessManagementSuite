using System;
using System.Collections.Generic;

namespace Restaurant.Data.Management.Menus
{
    [Serializable]
    public class Allergy
    {
        public int AllergyID { get; set; }

        public string Name { get; set; }


    }

    
    [Serializable]
    public class FoodItem : MenuItem
    {
        public List<Allergy> Allergies { get; set; } 


        
        public FoodItem()
        {

        }
    }
}