using System;
using Restaurant.Data;

namespace Restaurant.Network.Packets
{
    [Serializable]
    public class NetMemberUpdate : INetPacket
    {
        public Member[] Members { get; set; }
    }

    [Serializable]
    public class NetMembersResponse : INetPacket
    {
        public Member[] Members { get; set; }
    }

    [Serializable]
    public class NetMemberResponse : INetPacket
    {
        public Member Member { get; set; }
    }

    [Serializable]
    public class NetMemberRequest : INetPacket
    {
        public string Where { get; set; }
    }

    [Serializable]
    public class NetMembersRequest : INetPacket
    {
        public string Where { get; set; }
    }
}
