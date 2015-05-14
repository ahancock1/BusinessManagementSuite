using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace Restaurant.Network.Packets
{
    #region Framework Messages

    public interface INetPacket
    {
        
    }

    public interface INetMessage
    {

    }

    [Serializable]
    public class NetResponse : INetMessage
    {
        public string Message { get; set; }

        public NetResponse()
        {
            Message = String.Empty;
        }
    }

    [Serializable]
    public sealed class NetRegisterConnection : INetMessage
    {
        public int ConnectionID { get; set; }

        public string ConnectionName { get; set; }

        public NetRegisterConnection()
        {
            ConnectionName = String.Empty;
        }
    }

    [Serializable]
    public sealed class NetConnectionType : INetMessage
    {
        public int ConnectionType { get; set; }
    }

    [Serializable]
    public sealed class NetPing : INetMessage
    {
        public int PingID { get; set; }

        public bool IsReply { get; set; }
    }

    [Serializable]
    public sealed class NetAcceptConnection : INetMessage
    {
        public int ConnectionID { get; set; }
    }

    #endregion
}
