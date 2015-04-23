using System;
using System.Collections.Generic;
using RestaurantServer.Data.DataModel;

namespace RestaurantServer.Data.Packets
{
    public interface INetUser
    {
    }

    // TODO implement a generic response

    [Serializable]
    public class NetAddUser : INetUser
    {
        public User User { get; set; }
    }

    [Serializable]
    public class NetRequestUser : INetUser
    {
        public int UserID { get; set; }

        public int UserName { get; set; }
    }

    [Serializable]
    public class NetRequestUsers : INetUser
    {
        public User User { get; set; }
    }

    [Serializable]
    public class NetDeleteUser : INetUser
    {
        public int UserID { get; set; }
    }

    [Serializable]
    public class NetResponseUser : INetUser
    {
        public User User { get; set; }
    }
    
    [Serializable]
    public class NetUpdateUser : INetUser
    {
        public User User { get; set; }
    }

    [Serializable]
    public class NetResponseUsers : INetUser
    {
        public IEnumerable<User> Users { get; set; }
    }
}
