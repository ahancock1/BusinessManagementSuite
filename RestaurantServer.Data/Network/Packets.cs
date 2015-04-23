using System;

namespace RestaurantServer.Data.Network
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

    public interface INetKitchenMessage
    {
        
    }

    [Serializable]
    public class NetFoodOrder : INetKitchenMessage
    {
        
    }

    public class NetDrinkOrder : INetBarMessage
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
