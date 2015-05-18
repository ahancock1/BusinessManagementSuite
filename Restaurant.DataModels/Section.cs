using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.DataModels
{
    [Serializable]
    public class Section
    {
        public int SectionID { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Table> Tables { get; set; }


        public Section()
        {
            Name = String.Empty;
        }
    }
}