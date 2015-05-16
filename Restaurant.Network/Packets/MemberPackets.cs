using System;
using System.Linq.Expressions;
using Restaurant.Data;

namespace Restaurant.Network.Packets
{
    [Serializable]
    public class NetMemberUpdate : INetPacket
    {
        public Member[] Members { get; set; }
    }

    [Serializable]
    public class NetMemberResponse : INetPacket
    {
        public Member[] Members { get; set; }
    }
    
    [Serializable]
    public class NetMembersRequest : INetPacket
    {
        public Expression<Func<Member, object>>[] Where { get; set; }
    }

    [Serializable]
    public class NetMemberRequestByUsername : INetPacket
    {
        public string Email { get; set; }
    }
}
