using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Restaurant.Data.Management.Staff;

namespace Restaurant.Data
{
    [DataContract(Name = "UserCredential"), KnownType(typeof(Credential))]
    public class Credential : Entity
    {
        [Key, ForeignKey("User")]
        public int UserID { get; set; }

        // Hash the fuck out of this
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Password salt is required")]
        public string PasswordSalt { get; set; }

        [DataMember]
        public Privilege Privilege { get; set; }

        public virtual User User { get; set; }


        public Credential()
        {
            // Calculate password salt here

        }
    }
}
