using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.DataModels.Management.Floor
{
    [Serializable]
    public class Section : Entity
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