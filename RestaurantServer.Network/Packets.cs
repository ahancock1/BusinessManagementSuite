using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantServer.Network
{
    public interface IUserMessage
    {

    }

    [Serializable]
    public class NetUserRequest : IUserMessage
    {
        public int UserID { get; set; }
    }


    public interface INetBarMessage
    {

    }



    #region Framework Messages

    public interface INetMessage
    {

    }

    [Serializable]
    internal class NetResponse : INetMessage
    {
        public string Message { get; set; }

        public NetResponse()
        {
            Message = String.Empty;
        }
    }

    [Serializable]
    internal sealed class NetRegisterConnection : INetMessage
    {
        public int ConnectionID { get; set; }

        public string ConnectionName { get; set; }

        public NetRegisterConnection()
        {
            ConnectionName = String.Empty;
        }
    }

    [Serializable]
    public sealed class NetPing : INetMessage
    {
        public int PingID { get; set; }

        public bool IsReply { get; set; }
    }

    [Serializable]
    internal sealed class NetAcceptConnection : INetMessage
    {
        public int ConnectionID { get; set; }
    }

    [Serializable]
    internal sealed class NetCloseConnection : INetMessage
    {
        public int ConnectionID { get; set; }
    }

    #endregion
}
