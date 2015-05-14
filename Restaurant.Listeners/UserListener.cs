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
            // Create data access
            service = new UserService();

            // Register packets to listen for
            Register<NetUserCreate>(CreateUser);
            Register<NetUserDelete>(DeleteUser);
            Register<NetUserUpdate>(UpdateUser);
            Register<NetUserRequest>(RequestUser);
        }

        public void RequestUser(Connection connection, INetPacket packet)
        {
            // TODO refine this
            if (((NetUserRequest)packet).Username == null)
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
                    User = service.GetByUsername(((NetUserRequest)packet).Username)
                });
            }
        }

        public void DeleteUser(Connection connection, INetPacket packet)
        {
            service.Delete(((NetUserDelete)packet).ID);
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
