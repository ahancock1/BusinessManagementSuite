using System;
using System.Runtime.Serialization;

namespace Com.Framework.Services.Messages
{
    [DataContract]
    public abstract class BaseView
    {
        //[NonSerialized]
        public DateTime Created { get; private set; }

        public BaseView()
        {
            Created = DateTime.UtcNow;
        }
    }
}
