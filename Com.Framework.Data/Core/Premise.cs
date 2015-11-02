using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Com.Framework.Common.Extensions;
using Com.Framework.Data.Core;
using Com.Framework.Data.Restaurants.Menus;
using Newtonsoft.Json;

namespace Com.Framework.Data
{
    [DataContract]
    public class Premise : BaseEntity
    {
        #region Keys
        [DataMember]
        public int PremiseID { get; set; }

        [DataMember]
        public int OrganisationID { get; set; }

        #endregion

        #region Properties
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
        public string ApiKey { get; set; }

        [DataMember]
        public ICollection<Address> Addresses { get; set; }

        [DataMember]
        public ICollection<PhoneNumber> PhoneNumbers { get; set; }

        [DataMember]
        public ICollection<Email> EmailAddresses { get; set; }

        [DataMember]
        public ICollection<Hours> OpenHours { get; set; }

        [DataMember]
        public ICollection<PaymentMethod> PaymentMethods { get; set; }

        [DataMember]
        public float Rating { get; set; }

        // TODO: This needs to be updated when a new review is added
        [DataMember]
        public float ReviewRating { get; set; }

        [DataMember]
        public PremiseType PremiseType { get; set; }

        [DataMember]
        public ICollection<Employee> Employees { get; set; }

        [DataMember]
        public ICollection<Department> Departments { get; set; }

        [DataMember]
        public ICollection<EmployeeGroup> EmployeeGroups { get; set; }

        [DataMember]
        public ICollection<MenuCategory> MenuCategories { get; set; }

        #endregion

        #region Navigation Properties

        [JsonIgnore]
        protected virtual Organisation Organisation { get; set; }

        [JsonIgnore]
        protected virtual ICollection<Review> Reviews { get; set; }

        #endregion


        public Premise()
        {
            Addresses = new List<Address>();
            PhoneNumbers = new List<PhoneNumber>();
            EmailAddresses = new List<Email>();
            OpenHours = new List<Hours>();
            Employees = new List<Employee>();
            Departments = new List<Department>();
            EmployeeGroups = new List<EmployeeGroup>();
            MenuCategories = new List<MenuCategory>();

        }

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
