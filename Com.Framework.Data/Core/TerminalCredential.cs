using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Com.Framework.Data
{
    [DataContract]
    public class TerminalCredential : Entity<long>
    {
        //[Key, ForeignKey("Employee"), DataMember]
        public int TerminalCredentialID { get; set; }

        [DataMember]
        public string Passcode { get; set; }

        public virtual Employee Employee { get; set; }
    }
}