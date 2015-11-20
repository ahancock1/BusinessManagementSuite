using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Com.Framework.Services.Views
{
    [DataContract]
    public class UserView
    {
        [Required]
        [DataMember]
        public Guid Id { get; set; }

        [Required]
        [DataMember]
        public string UserName { get; set; }

        [Required]
        [DataMember]
        public string FirstName { get; set; }

        [Required]
        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string PasswordHash { get; set; }

        [DataMember]
        public string Country { get; set; }

        [DataMember]
        public IList<CODECorp.WcfIdentity.DataContract.Views.Claim.ClaimView> Claims { get; set; }

        [DataMember]
        public IList<CODECorp.WcfIdentity.DataContract.Views.Role.RoleView> Roles { get; set; }

        [DataMember]
        public IList<CODECorp.WcfIdentity.DataContract.Views.Login.LoginView> Logins { get; set; }
    }
}