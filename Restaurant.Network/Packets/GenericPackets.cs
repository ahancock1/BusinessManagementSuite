using System;
using Restaurant.DataModels;

namespace Restaurant.Network.Packets
{
    [Serializable]
    public enum NetResponseCode : byte
    {
        Error,
        Accepted,
        Refused
    }

    [Serializable]
    public class NetRequest<T> : INetPacket where T : class, IEntity
    {
        public string Where { get; set; }
    }

    [Serializable]
    public class NetRequestSingle<T> : INetPacket where T : class, IEntity
    {
        public string Where { get; set; }
    }

    [Serializable]
    public class NetResponse<T> : INetPacket where T : class, IEntity
    {
        public T[] Items { get; set; }
    }

    [Serializable]
    public class NetResponseSingle<T> : INetPacket where T : class, IEntity
    {
        public T Item { get; set; }
    }

    [Serializable]
    public class NetUpdate<T> : INetPacket where T : class, IEntity
    {
        public T[] Items { get; set; }
    }

    [Serializable]
    public class NetResponseCode<T> : INetPacket where T : class, IEntity
    {
        public NetResponseCode Response { get; set; }
    }

}
