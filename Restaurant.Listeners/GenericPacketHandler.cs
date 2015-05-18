using System;
using System.Linq;
using Restaurant.DataModels;
using Restaurant.DataAccess.Services;
using Restaurant.Network;
using Restaurant.Network.Packets;

namespace Restaurant.Listeners
{
    public interface IGenericPacketHandler<T> where T : class, IEntity
    {
        void RequestPacketReceived(Connection connection, NetRequest<T> packet);

        void UpdatePacketReceived(Connection connection, NetUpdate<T> packet);
    }

    public class GenericPacketHandler<T> : PacketHandler, IGenericPacketHandler<T> where T : class, IEntity
    {
        private readonly IGenericService<T> service;

        public GenericPacketHandler(Server server = null) : base (server)
        {
            service = new GenericService<T>();

            Register<NetRequest<T>>(RequestPacketReceived);
            Register<NetRequestSingle<T>>(RequestSinglePacketReceived);
            Register<NetUpdate<T>>(UpdatePacketReceived);
        }

        public virtual void RequestPacketReceived(Connection connection, NetRequest<T> packet)
        {
            if (String.IsNullOrEmpty(packet.Where))
            {
                connection.Send(new NetResponse<T>
                {
                    Items = service.GetAll().ToArray()
                });
            }
            else
            {
                connection.Send(new NetResponse<T>
                {
                    Items = service.GetAll(packet.Where).ToArray()
                });
            }
        }

        public virtual void RequestSinglePacketReceived(Connection connection, NetRequestSingle<T> packet)
        {
            connection.Send(new NetResponseSingle<T>
            {
                Item = service.Get(packet.Where)
            });
        }

        public virtual void UpdatePacketReceived(Connection connection, NetUpdate<T> packet)
        {
            service.Update(packet.Items);
        }
    }
}
