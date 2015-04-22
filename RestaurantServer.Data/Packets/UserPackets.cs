using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantServer.Data.DataModel;

namespace RestaurantServer.Data.Packets
{
    public interface INetUser
    {
       
    }

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
    public class NetResponseUser : INetUser
    {
        public User User { get; set; }
    }
}
