using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;
using Com.Framework.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Com.Framework.Models
{
    // This class can't be used with the generic service because of ASP.NET stupid identity shit
    public partial class AspNetUser : IdentityUser
    {
        public virtual string PasswordHash { get; set; }

        public virtual string SecurityStamp { get; set; }

        [StringLength(128)]
        [Required()]
        public virtual string Discriminator { get; set; }

        [StringLength(500)]
        public virtual string LastName { get; set; }

        [StringLength(500)]
        public virtual string FirstName { get; set; }

        public virtual IList<AspNetUserLogin> AspNetUserLogins { get; set; }

        //        public virtual IList<AspNetUserClaim> AspNetUserClaims { get; set; }
        //
        //        public virtual IList<AspNetRole> AspNetRoles { get; set; }

    }
}
