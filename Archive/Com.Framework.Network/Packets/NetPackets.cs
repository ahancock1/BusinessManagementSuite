using System;

namespace Com.Framework.Network.Packets
{
    #region Framework Messages

    public interface INetPacket
    {

    }

    [Serializable]
    internal sealed class NetRegisterConnection
    {
        public int ConnectionID { get; set; }

        public string ConnectionName { get; set; }

        public NetRegisterConnection()
        {
            ConnectionName = String.Empty;
        }
    }

    [Serializable]
    internal sealed class NetConnectionType
    {
        public int ConnectionType { get; set; }
    }

    [Serializable]
    internal sealed class NetPing
    {
        public int PingID { get; set; }

        public bool IsReply { get; set; }
    }

    [Serializable]
    internal sealed class NetAcceptConnection
    {
        public int ConnectionID { get; set; }
    }

    #endregion
}
