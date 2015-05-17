using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Data
{
    public enum Occurrence
    {
        None,
        Daily,
        Weekly,
        Yearly
    }

    [Serializable]
    public class Promotion
    {
        public int PromotionID { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public Occurrence Occurrence { get; set; }


        public Promotion()
        {
            
        }
    }
}
