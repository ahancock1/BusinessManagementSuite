using System.Linq;
using Restaurant.Data;
using Restaurant.DataAccess.Services;
using Restaurant.Network;
using Restaurant.Network.Packets;

namespace Restaurant.Listeners
{
    public class TableListener : PacketHandler
    {
        private readonly IGenericService<Table> service;

        public TableListener(Server server = null) : base(server)
        {
            service = new GenericService<Table>();

            Register<NetTableRequest>(RequestTable);
            Register<NetTablesRequest>(RequestTables);
            Register<NetTableUpdate>(UpdateTable);
        }

        private void RequestTable(Connection connection, INetPacket packet)
        {
            connection.Send(new NetTableResponse
            {
                Table = service.Get(((NetTableRequest)packet).Where)
            });
        }

        private void RequestTables(Connection connection, INetPacket packet)
        {
            if (((NetTableRequest)packet).Where != null)
            {
                connection.Send(new NetTablesResponse
                {
                    Tables = service.GetAll(((NetTableRequest)packet).Where).ToArray()
                });
            }
            else
            {
                connection.Send(new NetTablesResponse
                {
                    Tables = service.GetAll().ToArray()
                });
            }
        }

        private void UpdateTable(Connection connection, INetPacket packet)
        {
            service.Update(((NetTableUpdate) packet).Tables);
        }
    }
}
