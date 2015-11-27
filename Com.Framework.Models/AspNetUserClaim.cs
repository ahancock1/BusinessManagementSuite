using System.ComponentModel.DataAnnotations;
using Com.Framework.Data;

namespace Com.Framework.Models
{
    public class AspNetUserClaim : Entity<long>
    {
        public string ClaimType { get; set; }

        public string ClaimValue { get; set; }

        [StringLength(128)]
        [Required()]
        public string UserId { get; set; }

        public virtual AspNetUser User { get; set; }
    }
}
