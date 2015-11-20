using System;
using System.Runtime.Serialization;

namespace Com.Framework.Services.Messages
{
    [DataContract]
    public abstract class BaseView
    {
        //[NonSerialized]
        public DateTime created { get; private set; };

        public BaseView()
        {
            created = DateTime.UtcNow;
        }
    }
}