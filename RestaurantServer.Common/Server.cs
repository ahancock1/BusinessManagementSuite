using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantServer.Common
{
    public interface ISever
    {
        
        void SendToAll(object o);

        void SendToAllExcept(object o, params int[] id);
    }

    public class Server
    {

        public Server()
        {
            

        }
    }
}
