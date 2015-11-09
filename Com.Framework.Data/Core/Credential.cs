using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;

namespace Com.Framework.Data
{
    [DataContract]
    public class Credential : Entity<long>
    {
        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public virtual User User { get; set; }


        public Credential()
        {

        }

        public static byte[] Hash(string value, string salt)
        {
            return Hash(value, Encoding.Default.GetBytes(salt));
        }

        public static byte[] Hash(string value, byte[] salt)
        {
            return new Rfc2898DeriveBytes(value, salt, 10000).GetBytes(25);
        }

        public bool Confirm(string password)
        {
            return PasswordHash.SequenceEqual(Hash(password, PasswordSalt));
        }
    }
}