using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Com.Framework.Data
{
    [DataContract]
    public class TerminalCredential : Credential
    {
        [Key, DataMember]
        public int TerminalCredentialID { get; set; }

        [DataMember]
        public string Passcode { get; set; }

        protected virtual Employee Employee { get; set; }
    }
}