﻿using System;
using Com.Framework.Data;
using Com.Framework.DataAccess.Services;
using Com.Framework.Network;
using Com.Framework.Network.Packets;

/// <summary>
/// 
///  Wont be using this anymore, will be using SignalR
/// 
/// </summary>
namespace Com.Framework.Listeners
{
    public interface IGenericPacketHandler<T> where T : BaseEntity
    {
        void RequestPacketReceived(Connection connection, NetRequest<T> packet);

        void RequestSinglePacketReceived(Connection connection, NetRequestSingle<T> packet);

        void UpdatePacketReceived(Connection connection, NetUpdate<T> packet);
    }


    public class GenericPacketHandler<T> : PacketHandler, IGenericPacketHandler<T> where T : BaseEntity
    {
        private readonly IGenericService service;

        public GenericPacketHandler(Server server = null)
            : base(server)
        {
            service = new GenericService();

            // Register packets
            Register<NetRequest<T>>(RequestPacketReceived);
            Register<NetRequestSingle<T>>(RequestSinglePacketReceived);
            Register<NetUpdate<T>>(UpdatePacketReceived);
        }

        /// <summary>
        /// Processes a packet request and returns all data matching the search criteria
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="packet"></param>
        public virtual void RequestPacketReceived(Connection connection, NetRequest<T> packet)
        {
            if (String.IsNullOrEmpty(packet.Where))
            {
                // No search critera so send all data
                connection.Send(new NetResponse<T>
                {
                    //Items = service.All<T>().ToArray()
                });
            }
            else
            {
                // Send data by using where criteria
                connection.Send(new NetResponse<T>
                {
                    //Items = service.All<T>(packet.Where).ToArray()
                });
            }
        }

        /// <summary>
        /// Processes a single request and returns the first or default value matching the search criteria
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="packet"></param>
        public virtual void RequestSinglePacketReceived(Connection connection, NetRequestSingle<T> packet)
        {
            connection.Send(new NetResponseSingle<T>
            {
                //Item = service.Get<T>(packet.Where)
            });
        }

        /// <summary>
        /// Processes and update packet and updates the database with the new record
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="packet"></param>
        public virtual void UpdatePacketReceived(Connection connection, NetUpdate<T> packet)
        {
            service.Update(packet.Items);
        }
    }
}
