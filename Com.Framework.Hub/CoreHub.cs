using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace Com.Framework.Hubs
{
    [HubName("CoreHub")]
    public class CoreHub : Hub
    {
        /// <summary>
        /// Must be called to establish a connection
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Task JoinGroup(string name)
        {
            return Groups.Add(Context.ConnectionId, name);
        }

        /// <summary>
        /// Called when the browser is closed
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Task LeaveGroup(string name)
        {
            return Groups.Remove(Context.ConnectionId, name);
        }

        public override Task OnConnected()
        {
            string name = Context.User.Identity.Name;

            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {

            return base.OnDisconnected(stopCalled);
        }

        public override Task OnReconnected()
        {

            return base.OnReconnected();
        }
    }
}
