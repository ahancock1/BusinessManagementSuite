using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Com.Framework.Services.Views
{
    [DataContract]
    public class RoleView
    {
        [DataMember]
        public Guid Id { get; set; }

        [Required]
        [DataMember]
        public string Name { get; set; }
    }
}