using System;
using System.Collections.Generic;
using Restaurant.DataModels.Menus;

namespace Restaurant.DataModels
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