using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Com.Framework.Data
{
    [DataContract]
    public enum PaymentMethodType
    {
        [EnumMember]
        Primary
    }

    [DataContract]
    public class PaymentDetails
    {
        [DataMember]
        public int PaymentDetailsID { get; set; }


        // TODO add details
    }

    [DataContract]
    public class PaymentMethod : BaseEntity
    {
        #region Keys

        [DataMember]
        public int PaymentMethodID { get; set; }

        [DataMember]
        public int EmployeeID { get; set; }

        [DataMember]
        public PaymentMethodType PaymentMethodType { get; set; }

        #endregion

        #region Properties



        #endregion


        #region Navigation Properties

        protected virtual Employee Employee { get; set; }

        #endregion
    }
}
