using System;
using System.Collections.Generic;
using System.Linq;

namespace Restaurant.Network.Packets
{
    #if DEBUG
    [Serializable]
    public abstract class NetMessage : INetPacket
    {
        public string Message { get; set; }
    }

    [Serializable]
    public class ClientMessage : NetMessage
    {
    }

    [Serializable]
    public class ServerMessage : NetMessage
    {
    }
    #endif
    
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

    [Serializable]
    public sealed class NetCloseConnection : INetMessage
    {
        public int ConnectionID { get; set; }
    }

    #endregion
}
