using System;

namespace Restaurant.DataModels
{
    [Serializable]
    public class DrinkItem : Item
    {
        public DrinkType DrinkType { get; set; }

        public float AlcoholVolume { get; set; }

        public string Description { get; set; }


        public DrinkItem()
        {
        }

        public bool IsAlcoholic
        {
            get { return Math.Abs(AlcoholVolume) <= 0; }
        }
    }
}