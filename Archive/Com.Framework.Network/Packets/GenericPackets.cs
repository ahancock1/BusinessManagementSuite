using System;
using Com.Framework.Data;

namespace Com.Framework.Network.Packets
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
    public class NetRequest<T> : INetPacket where T : BaseEntity
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
    public class NetRequestSingle<T> : INetPacket where T : BaseEntity
    {
        public string Where { get; set; }

        public NetRequestSingle(string where = "")
        {
            Where = where;
        }
    }

    /// <summary>
    /// Serialisable packet for a response to a NetRequest packet. Returns an 
    /// array of items specified by T.
    /// </summary>
    /// <typeparam name="T">Type of data concerned</typeparam>
    [Serializable]
    public class NetResponse<T> : INetPacket where T : BaseEntity
    {
        public T[] Items { get; set; }
    }

    /// <summary>
    /// Serialisable packet for a single response to a NetRequestSinle packet.
    /// Returns a single instance of T.
    /// </summary>
    /// <typeparam name="T">Type of data concerned</typeparam>
    [Serializable]
    public class NetResponseSingle<T> : INetPacket where T : BaseEntity
    {
        public T Item { get; set; }
    }

    /// <summary>
    /// Serialisable packet for an update request to insert, update or delete
    /// data specified by T.
    /// </summary>
    /// <typeparam name="T">Type of data concerned</typeparam>
    [Serializable]
    public class NetUpdate<T> : INetPacket where T : BaseEntity
    {
        public T[] Items { get; set; }
    }

    /// <summary>
    /// Serialisable packet for a reponse code to an NetUpdate packet.
    /// </summary>
    /// <typeparam name="T">Type of data concerned</typeparam>
    [Serializable]
    public class NetResponseCode<T> : INetPacket where T : BaseEntity
    {
        public NetResponseCode Response { get; set; }
    }
}
