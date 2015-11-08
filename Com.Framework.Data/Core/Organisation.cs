using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Com.Framework.Data
{
    [DataContract]
    public class Organisation : AuditableEntity<long>
    {
        #region Keys
        //[DataMember]
        //public int OrganisationID { get; set; }

        [DataMember]
        public int ImageID { get; set; }

        #endregion

        #region Properties
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string LegalName { get; set; }

        [DataMember]
        public string Code { get; set; }

        [DataMember]
        public bool? PaysTax { get; set; }

        [DataMember]
        public OrganisationType OrganisationType { get; set; }

        [DataMember]
        public string ApiKey { get; set; }

        [DataMember]
        public OrganisationStatus OrganisationStatus { get; set; }

        [DataMember]
        public OrganisationCategory OrganisationCategory { get; set; }

        [DataMember]
        public string TaxNumber { get; set; }

        [DataMember]
        public int? FinancialYearEndDay { get; set; }

        [DataMember]
        public int? FinancialYearEndMonth { get; set; }

        [DataMember]
        public string CountryCode { get; set; }

        [DataMember]
        public ICollection<Hours> OpenHours { get; set; }

        [DataMember]
        public ICollection<Address> Addresses { get; set; }

        [DataMember]
        public ICollection<PhoneNumber> PhoneNumbers { get; set; }

        [DataMember]
        public ICollection<ExternalLink> ExternalLinks { get; set; }

        [DataMember]
        public Image Image { get; set; }

        [JsonIgnore]
        public ICollection<Premise> Premises { get; set; }

        #endregion

        public Organisation()
        {
            OpenHours = new List<Hours>();
            Addresses = new List<Address>();
            PhoneNumbers = new List<PhoneNumber>();
            ExternalLinks = new List<ExternalLink>();
            Premises = new List<Premise>();

            Image = Image.DefaultImage();
            ImageID = Image.ImageID;
        }
    }
}
