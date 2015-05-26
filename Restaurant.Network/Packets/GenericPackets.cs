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

    /// <summary>
    /// Serialisable packet for requesting multiple types of data specified by
    /// T and a where clause. Will return a NetResponse containing a list of data
    /// matching the where clause.
    /// </summary>
    /// <typeparam name="T">Type of data concerned</typeparam>
    [Serializable]
    public class NetRequest<T> : INetPacket where T : class, IEntity
    {
        public string Where { get; set; }
        
        public NetRequest(string where = "")
        {
            Where = where;
        } 
    }

    /// <summary>
    /// Serialisable packet for requesting a single instance of data specified
    /// by T and a where clause. Will return a NetResponseSingle packet with a
    /// matching first or default value.
    /// </summary>
    /// <typeparam name="T">Type of data concerned</typeparam>
    [Serializable]
    public class NetRequestSingle<T> : INetPacket where T : class, IEntity
    {
        public string Where { get; set; }

        public NetRequestSingle(string where = "")
        {
            Where = where;
        } 
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
