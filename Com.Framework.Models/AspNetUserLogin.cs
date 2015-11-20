using System.ComponentModel.DataAnnotations;
using Com.Framework.Data;

namespace Com.Framework.Models
{
    public partial class AspNetUserLogin : Entity<long>
    {
        [StringLength(128)]
        [Required()]
        [Key()]
        public string LoginProvider { get; set; }

        [StringLength(128)]
        [Required()]
        [Key()]
        public string ProviderKey { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }

    }
}
