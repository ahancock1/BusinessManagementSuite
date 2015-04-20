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
    public interface IConnection : IDisposable
    {
        void Send(object data);

        void Close();

        bool Connected { get; }
    }

    public class Connection : IConnection
    {
        public TcpClient Client;

        public NetworkStream Stream;

        public Listener Listener { get; set; }

        public int ID { get; set; }

        public string Name { get; set; }

        public Connection()
        {
            
        }

        public Connection(string hostName, int port)
        {
            Client = new TcpClient(hostName, port);
            Stream = Client.GetStream();
        }

        public void Send(object o)
        {
            if (o == null) throw new Exception("object cannot be null.");

            if (Stream == null) throw new Exception("Stream cannot be null.");

            if (Stream.CanWrite)
            {
                using (var memoryStream = new MemoryStream())
                {
                    (new BinaryFormatter()).Serialize(memoryStream, o);
                    Stream.Write(memoryStream.ToArray(), 0, (int)memoryStream.Length);
                }

                Console.WriteLine("Sent: {0}", o.GetType().Name);
            }
        }

        public void Read()
        {
            
        }

        public void Close()
        {
            Stream.Close();
            Client.Close();
        }

        public bool Connected
        {
            get { return Client.Connected; }
        }

        public override string ToString()
        {
            return Name ?? "Connection " + ID;
        }

        public void Dispose()
        {
            Close();
        }
    }
}
