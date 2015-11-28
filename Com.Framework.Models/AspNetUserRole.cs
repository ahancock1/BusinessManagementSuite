using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Framework.Data;

namespace Com.Framework.Models
{
    public class AspNetUserRole : Entity<long>
    {
        [Required]
        public string Name { get; set; }

        public virtual ICollection<AspNetUser> Users { get; set; }

    }
}
