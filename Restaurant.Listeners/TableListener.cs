using System.Linq;
using Restaurant.DataAccess.Services;
using Restaurant.Network;
using Restaurant.Network.Packets;

namespace Restaurant.Listeners
{
    public interface ITableListener
    {
        void RequestTable(Connection connection, INetPacket packet);

        void DeleteTable(Connection connection, INetPacket packet);

        void CreateTable(Connection connection, INetPacket packet);

        void UpdateTable(Connection connection, INetPacket packet);
    }

    public class TableListener : PacketHandler, ITableListener
    {
        private readonly ITableService service;

        public TableListener(Server server = null) : base(server)
        {
            service = new TableService();

            Register<NetTableCreate>(CreateTable);
            Register<NetTableDelete>(DeleteTable);
        }

        public void RequestTable(Connection connection, INetPacket packet)
        {
            NetTableRequest p = (NetTableRequest) packet;
            if (p.Number.HasValue)
            {
                connection.Send(new NetTableResponse
                {
                    Table = service.GetByNumber(p.Number.Value)
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

        public void DeleteTable(Connection connection, INetPacket packet)
        {
            service.Delete(((NetTableDelete) packet).ID);
        }

        public void CreateTable(Connection connection, INetPacket packet)
        {
            service.Create(((NetTableCreate) packet).Table);
        }

        public void UpdateTable(Connection connection, INetPacket packet)
        {
            service.Update(((NetTableUpdate) packet).Table);
        }
    }
}
