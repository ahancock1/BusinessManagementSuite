using Microsoft.AspNet.SignalR;

namespace Com.Framework.Hubs
{
    public interface IChatHub
    {
        void SendMessage(string name, string message);
    }

    public class Chathub : Hub<IChatHub>
    {

        public void SendMessage(string to, string from, string message)
        {
            Clients.Group(to).SendMessage(from, message);
        }
    }
}
