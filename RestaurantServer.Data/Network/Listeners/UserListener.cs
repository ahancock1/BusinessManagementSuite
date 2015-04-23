using System;
using RestaurantServer.Data.DataModel;
using RestaurantServer.Data.Packets;
using RestaurantServer.Data.Services;

namespace RestaurantServer.Data.Network.Listeners
{
    public class UserListener : Listener
    {
        public UserService Service = new UserService();
        
        public override void Received(Connection connection, object o)
        {
            if (o is INetUser)
            {
                Console.WriteLine("User data received: {0}", o.GetType().Name);
                if (o is NetRequestUser)
                {
                    connection.Send(new NetResponseUser
                    {
                        User = Service.GetById(((NetRequestUser)o).UserID)
                    });
                    return;
                }
                if (o is NetRequestUsers)
                {
                    User user = ((NetRequestUsers)o).User;
                    if (user == null)
                    {
                        connection.Send(new NetResponseUsers
                        {
                            Users = Service.GetAll()
                        });
                    }
                    else
                    {
                        // TODO Search users

                    }
                    return;
                }
                if (o is NetAddUser)
                {
                    Service.Create(((NetAddUser) o).User);
                    return;
                }
                if (o is NetUpdateUser)
                {
                    Service.Update(((NetUpdateUser)o).User);
                    return;
                }
                if (o is NetDeleteUser)
                {
                    Service.Delete(((NetDeleteUser) o).UserID);
                    return;
                }
            }
        }
    }
}
