using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Com.Framework.Services.Messages
{
    [DataContract]
    public abstract class BaseResponse
    {
        public BaseResponse()
        {
            this.Errors = new List<string>();
        }

        [DataMember]
        public bool Success { get; set; }

        [DataMember]
        public IList<string> Errors { get; set; }

        public void AddErrors(IEnumerable<string> ErrorList)
        {
            if (this.Errors != null)
            {
                foreach (string error in ErrorList)
                    this.Errors.Add(error);
            }
        }
    }
}