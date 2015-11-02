using Com.Framework.DataAccess.Services;

using Microsoft.AspNet.SignalR.Hubs;

namespace Com.Framework.Hubs
{
    public interface ITestHub
    {
        void SendMessage(string name, string message);
    }

    [HubName("TestHub")]
    public class TestHub : ServiceHub<ITestHub>
    {

        #region SingalR Implemented Methods

        public void SendMessage(string name, string message)
        {
            Clients.All.SendMessage(name, message);

        }

        #endregion
    }
}
