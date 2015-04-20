using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantServer.Common
{
    public interface IServer : IDisposable
    {
        void Start();

        void Received(Connection connection, object o);
        
        void SendToAll(object o);

        void SendToAllExcept(object o, int id);

        void SendToAllExcept(object o, params int[] id);
    }

    public class Server : IServer
    {
        public List<Connection> Connections { get; set; }

        public Listener Listener { get; set; }

        public int Timeout { get; set; }

        

        public Server(int port)
        {
            Timeout = 250;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Start()
        {
            if (Listener != null)
            {
                Listener.Start();
            }
        }

        public void Received(Connection connection, object o)
        {

        }

        public void SendToAll(object o)
        {
            foreach (Connection connection in Connections)
            {
                connection.Send(o);
            }
        }

        public void SendToAllExcept(object o, int id)
        {
            foreach (Connection connection in Connections.Where(c => c.ID != id))
            {
                connection.Send(o);
            }
        }

        public void SendToAllExcept(object o, params int[] id)
        {
            throw new NotImplementedException();
        }

    }
}
