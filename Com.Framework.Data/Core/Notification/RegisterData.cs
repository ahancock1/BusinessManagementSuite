using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Com.Framework.Data.Core.Notification
{
    [DataContract]
    public class RegisterData
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string IpAddress { get; set; }
    }
}
