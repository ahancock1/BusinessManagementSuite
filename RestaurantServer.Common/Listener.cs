using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RestaurantServer.Common
{
    public interface IListener
    {
        void Connected(Connection connection);

        void Disconnected(Connection connection);

        void Received(Connection connection, object o);
    }

    public abstract class Listener : IListener
    {
        public abstract void Connected(Connection connection);

        public abstract void Disconnected(Connection connection);

        public abstract void Received(Connection connection, object o);
    }
}
