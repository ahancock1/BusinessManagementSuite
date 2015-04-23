using System;
using RestaurantServer.Data.DataModel;
using RestaurantServer.Data.Network;
using RestaurantServer.Data.Packets;
using RestaurantServer.Data.Services;

namespace RestaurantServer.Data.Listeners
{
    public class UserListener : Listener
    {
        private readonly UserService service;

        public UserListener()
        {
            service = new UserService();
        }
        
        public override void Received(Connection connection, object o)
        {
            if (o is INetUser)
            {
                Console.WriteLine("User data received: {0}", o.GetType().Name);
                if (o is NetRequestUser)
                {
                    connection.Send(new NetResponseUser
                    {
                        User = service.GetById(((NetRequestUser)o).UserID)
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
                            Users = service.GetAll()
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
                    service.Create(((NetAddUser) o).User);
                    Console.WriteLine("User inserted {0}", ((NetAddUser)o).User);
                    return;
                }
                if (o is NetUpdateUser)
                {
                    service.Update(((NetUpdateUser)o).User);
                    return;
                }
                if (o is NetDeleteUser)
                {
                    service.Delete(((NetDeleteUser) o).UserID);
                    return;
                }
            }
        }
    }
}
