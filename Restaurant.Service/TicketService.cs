using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Restaurant.DataAccess.Services;
using Restaurant.Data.Management;
using Restaurant.Data.Management.Floor;

namespace Restaurant.Service
{
    [ServiceContract]
    public interface ITicketService
    {
        [OperationContract]
        IList<Ticket> GetByTable(Table table);
    }

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TicketService" in both code and config file together.
    public class TicketService : ITicketService
    {
        private readonly IGenericService service = new GenericService();

        public IList<Ticket> GetByTable(Table table)
        {
            return service.All<Ticket>(t => t.Table == table).ToList();
        }
    }
}
