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
        void Stop();

        bool Running { get; }

        void Start();

        void Connected(Connection connection);

        void Disconnected(Connection connection);

        void Received(Connection connection, object o);
    }

    public abstract class Listener : IListener
    {
        private Thread thread;

        public void Stop()
        {
            if (thread == null) return;

            if (thread.IsAlive)
            {
                thread.Abort();
            }
        }

        public bool Running
        {
            get { return thread != null && thread.IsAlive; }
        }

        public void Start()
        {
            thread = new Thread(() =>
            {
                // TODO implement listening logic
   

            });
            thread.Start();
        }

        public abstract void Connected(Connection connection);

        public abstract void Disconnected(Connection connection);

        public void Received(Connection connection, object o)
        {
            throw new NotImplementedException();
        }
    }
}
