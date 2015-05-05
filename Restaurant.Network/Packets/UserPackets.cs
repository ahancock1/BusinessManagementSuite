using System;
using System.Collections.Generic;
using Restaurant.Data;

namespace Restaurant.Network.Packets
{
    [Serializable]
    public class NetUserCreate : INetPacket
    {
        public User User { get; set; }
    }

    [Serializable]
    public class NetUserDelete : INetPacket
    {
        public User User { get; set; }
    }

    [Serializable]
    public class NetUserUpdate : INetPacket
    {
        public User User { get; set; }
    }

    [Serializable]
    public class NetUserRequest : INetPacket
    {
        public User User { get; set; }
    }

    [Serializable]
    public class NetUsersResponse : INetPacket
    {
        public User[] Users { get; set; } 
    }

    [Serializable]
    public class NetUserResponse : INetPacket
    {
        public User User { get; set; }
    }
}
