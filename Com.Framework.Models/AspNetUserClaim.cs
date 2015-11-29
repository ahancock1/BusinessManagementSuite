using System.ComponentModel.DataAnnotations;
using Com.Framework.Data;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Com.Framework.Models
{
    public class AspNetUserClaim : IdentityUserClaim, IBaseEntity
    {
        public string ClaimType { get; set; }

        public string ClaimValue { get; set; }

        [StringLength(128)]
        [Required()]
        public string UserId { get; set; }

        public virtual AspNetUser User { get; set; }

        public EntityState EntityState { get; set; }
    }
}
