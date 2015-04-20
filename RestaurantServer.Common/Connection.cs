using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantServer.Common
{
    public interface IConnection
    {
        void Send(object data);

        void Close();
    }

    public class Connection : IConnection
    {
        private TcpClient client;

        private NetworkStream stream;

        public int ConnectionID { get; private set; }

        public string Name { get; set; }


        public Connection(string hostName, int port)
        {
            client = new TcpClient(hostName, port);
            stream = client.GetStream();
        }

        public void Send(object o)
        {
            if (stream.CanWrite)
            {
                using (var memoryStream = new MemoryStream())
                {
                    (new BinaryFormatter()).Serialize(memoryStream, o);
                    stream.Write(memoryStream.ToArray(),0,(int)memoryStream.Length);
                }
            }
        }

        public void Close()
        {
            stream.Close();
            client.Close();
        }
    }
}
