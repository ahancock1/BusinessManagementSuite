using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Com.Framework.Data
{
    [DataContract]
    public class Credential : Entity
    {
        [Key, ForeignKey("User")]
        public int CredentialID { get; set; }

        public string PasswordHash { get; set; }

        public string PasswordSalt { get; set; }

        public virtual User User { get; set; }
    }
}