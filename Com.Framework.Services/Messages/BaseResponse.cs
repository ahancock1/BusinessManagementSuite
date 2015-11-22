using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Com.Framework.Services.Messages
{
    [DataContract]
    public abstract class BaseResponse
    {
        [DataMember]
        public bool Success { get; set; }

        [DataMember]
        public IList<string> Errors { get; set; }

        protected BaseResponse()
        {
            Errors = new List<string>();
        }

        public void AddErrors(IEnumerable<string> errors)
        {
            if (Errors != null)
            {
                foreach (string error in errors)
                    Errors.Add(error);
            }
        }

        public void AddErrors(params string[] errors)
        {
            AddErrors(errors.ToList());
        }
    }
}