using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Com.Framework.Services.Views
{
    [DataContract]
    public class ClaimView
    {

        [DataMember]
        public string Type { get; set; }

        [DataMember]
        public string Value { get; set; }

        [DataMember]
        public string ValueType { get; set; }

    }
}