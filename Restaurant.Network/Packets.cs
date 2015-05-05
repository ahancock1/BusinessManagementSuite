using System;
using System.Collections.Generic;
using System.Linq;

namespace Restaurant.Network
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

    internal interface INetMessage
    {

    }

    [Serializable]
    internal class NetResponse : INetMessage
    {
        public string Message { get; set; }

        public NetResponse()
        {
            Message = String.Empty;
        }
    }

    [Serializable]
    internal sealed class NetRegisterConnection : INetMessage
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
    internal sealed class NetAcceptConnection : INetMessage
    {
        public int ConnectionID { get; set; }
    }

    [Serializable]
    internal sealed class NetCloseConnection : INetMessage
    {
        public int ConnectionID { get; set; }
    }

    #endregion
}
