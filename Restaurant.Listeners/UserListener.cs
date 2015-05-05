using System.Linq;
using Restaurant.DataAccess.Services;
using Restaurant.Network;
using Restaurant.Network.Packets;

namespace Restaurant.Listeners
{
    public interface IUserListener
    {
        void RequestUser(Connection connection, INetPacket packet);

        void DeleteUser(Connection connection, INetPacket packet);

        void CreateUser(Connection connection, INetPacket packet);

        void UpdateUser(Connection connection, INetPacket packet);
    }

    public class UserListener : PacketHandler, IUserListener
    {
        private readonly IUserService service;

        public UserListener()
        {
            service = new UserService();

            Register<NetUserCreate>(CreateUser);
            Register<NetUserDelete>(DeleteUser);
            Register<NetUserUpdate>(UpdateUser);
            Register<NetUserRequest>(RequestUser);
        }

        public void RequestUser(Connection connection, INetPacket packet)
        {
            if (((NetUserRequest)packet).User == null)
            {
                connection.Send(new NetUsersResponse
                {
                    Users = service.GetAll().ToArray()
                });
            }
            else
            {
                connection.Send(new NetUserResponse
                {
                    User = service.GetByUsername(((NetUserRequest)packet).User.Username)
                });
            }
        }

        public void DeleteUser(Connection connection, INetPacket packet)
        {
            service.Delete(((NetUserDelete)packet).User.UserID);
        }

        public void CreateUser(Connection connection, INetPacket packet)
        {
            service.Create(((NetUserCreate)packet).User);
        }

        public void UpdateUser(Connection connection, INetPacket packet)
        {
            service.Update(((NetUserUpdate)packet).User);
        }
    }
}
