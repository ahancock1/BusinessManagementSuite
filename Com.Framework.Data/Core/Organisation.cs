using System;
using System.Collections.Generic;

namespace Com.Framework.Data
{
    public class Organisation : Entity
    {
        public int OrganisationID { get; set; }

        public string Name { get; set; }

        public string LegalName { get; set; }

        public string Code { get; set; }

        public bool? PaysTax { get; set; }

        public OrganisationType OrganisationType { get; set; }

        public string ApiKey { get; set; }

        public OrganisationStatus OrganisationStatus { get; set; }

        public OrganisationCategory OrganisationCategory { get; set; }

        public string TaxNumber { get; set; }

        public int? FinancialYearEndDay { get; set; }

        public int? FinancialYearEndMonth { get; set; }

        public string CountryCode { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }

        public ICollection<Hours> OpenHours { get; set; }

        public ICollection<Address> Addresses { get; set; }

        public ICollection<PhoneNumber> PhoneNumbers { get; set; }

        public ICollection<ExternalLink> ExternalLinks { get; set; }

        public Image Image { get; set; }

        // EntityFramework relationships
        public virtual ICollection<Premise> Premises { get; set; }

    }
}
