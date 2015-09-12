using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Com.Framework.Data.Core;

namespace Com.Framework.Data.Inventory
{
    [DataContract, Table("StockItems")]
    public class StockItem : Item
    {
        public int StockItemID { get; set; }
    }
}
