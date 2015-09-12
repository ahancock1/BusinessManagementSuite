using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Com.Framework.Common.Extensions;
using Com.Framework.Data.Core;

namespace Com.Framework.Data
{
    [DataContract]
    public class Premise : Entity
    {
        [DataMember]
        public int PremiseID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string Url { get; set; }

        [DataMember]
        public string CountryCode { get; set; }

        [DataMember]
        public string Currency { get; set; }

        [DataMember]
        public DateTime Created { get; set; }

        [DataMember]
        public DateTime Modified { get; set; }

        [DataMember]
        public string ApiKey { get; set; }

        [DataMember]
        public ICollection<Address> Addresses { get; set; }

        [DataMember]
        public ICollection<PhoneNumber> PhoneNumbers { get; set; }

        [DataMember]
        public ICollection<Email> EmailAddresses { get; set; }

        [DataMember]
        public ICollection<Hours> OpenHours { get; set; }

        public ICollection<Review> Reviews { get; set; }

        [DataMember]
        public ICollection<PaymentMethod> PaymentMethods { get; set; }

        [DataMember]
        public float Rating { get; set; }

        // TODO: This needs to be updated when a new review is added
        public float ReviewRating { get; set; }

        protected virtual Organisation Organisation { get; set; }

        public PremiseType PremiseType { get; set; }

        [DataMember]
        public ICollection<Employee> Employees { get; set; }

        [DataMember]
        public ICollection<Department> Departments { get; set; }

        [DataMember]
        public ICollection<EmployeeGroup> EnployeeGroups { get; set; }

        public bool IsOpenNow
        {
            get
            {
                return
                    OpenHours.First(
                        h => h.DayOfWeek == (int)DateTime.Now.DayOfWeek && DateTime.Now.TimeOfDay.IsBetween(h.From, h.To)) !=
                    null;
            }
        }

        public bool IsOpen(DayOfWeek dayOfWeek, DateTime? dateTime = null)
        {
            return dateTime == null
                ? OpenHours.First(h => h.DayOfWeek == (int)dayOfWeek) != null
                : OpenHours.First(h => h.DayOfWeek == (int)dayOfWeek && dateTime.Value.TimeOfDay.IsBetween(h.From, h.To)) != null;
        }
    }
}
