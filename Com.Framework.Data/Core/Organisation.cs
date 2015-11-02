using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Com.Framework.Data
{
    [DataContract]
    public class Organisation : BaseEntity
    {
        #region Keys
        [DataMember]
        public int OrganisationID { get; set; }

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
            Premises = new List<Premise>();
            PhoneNumbers = new List<PhoneNumber>();
            Addresses = new List<Address>();
            OpenHours = new List<Hours>();
            ExternalLinks = new List<ExternalLink>();

            Image = Image.DefaultImage();
            ImageID = Image.ImageID;
        }
    }
}
