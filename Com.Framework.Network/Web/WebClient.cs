using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using Com.Framework.Data.Pos;
using Com.Framework.Network.Packets;

namespace Com.Framework.Network.Web
{

    public interface IWebSocket
    {

        bool Connect();

    }



    public class WebClient : IWebSocket
    {
        private WebSocket socket { get; set; }



        public WebClient() : this(new ClientWebSocket())
        {

        }

        public WebClient(WebSocket socket)
        {

            this.socket = socket;

        }

        public void Send(INetPacket packet)
        {



        }

        public void Disconect()
        {



        }

        public bool Connect()
        {



            return false;
        }

        public void Close()
        {

        }
    }
}
