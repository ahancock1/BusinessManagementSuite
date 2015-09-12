using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Com.Framework.Data.Core;

namespace Com.Framework.Data.Inventory
{
    [DataContract, Table("OrderItems")]
    public class OrderItem : Item
    {


    }
}
