using System;
using System.Security.Cryptography.X509Certificates;

namespace RestaurantServer.Data.Network
{
    public interface IListener
    {
        void Connected(Connection connection);

        void Disconnected(Connection connection);

        void Received(Connection connection, object o);
    }

    public class Listener : IListener
    {
        public virtual void Connected(Connection connection)
        {
            Console.WriteLine("Connected: {0}", connection);
        }

        public virtual void Disconnected(Connection connection)
        {
            Console.WriteLine("Disconnected: {0}", connection);
        }

        public virtual void Received(Connection connection, object o)
        {
            Console.WriteLine("Data received: {0}", o.GetType().Name);
        }
    }
    
    public class UserListener : Listener
    {
        public override void Received(Connection connection, object o)
        {
            if (o is IUserMessage)
            {
                Console.WriteLine("User data received: {0}", o.GetType().Name);
            }
        }
    }

    public class KitchenListener : Listener
    {
        public override void Received(Connection connection, object o)
        {
            if (o is INetKitchenMessage)
            {
                
            }
        }
    }

    public class FloorListener : Listener
    {
        
    }

    public class BarListener : Listener
    {
        public override void Received(Connection connection, object o)
        {
            if (o is INetBarMessage)
            {

            }
        }
    }
 }
