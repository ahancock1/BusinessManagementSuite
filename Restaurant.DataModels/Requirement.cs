using System;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.DataModels
{
    [Serializable]
    public class Requirement : Entity
    {
        public int RequirementID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public Requirement()
        {
            Name = String.Empty;
            Description = String.Empty;
        }
    }
}
