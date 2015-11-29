using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Com.Framework.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Com.Framework.Models
{
    public class AspNetUserRole : Entity<long>, IRole<long>
    {
        [Required]
        public string Name { get; set; }

        public virtual ICollection<AspNetUser> Users { get; set; }

    }
}
