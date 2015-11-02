using Microsoft.AspNet.SignalR;
using Com.Framework.DataAccess.Services;

namespace Com.Framework.Hubs
{
    public abstract class ServiceHub<T> : Hub<T> where T : class
    {
        protected readonly IGenericService Service;

        protected ServiceHub() : this(new GenericService()) { }

        protected ServiceHub(IGenericService service)
        {
            Service = service;
        }
    }

    public abstract class ServiceHub : Hub
    {
        protected readonly IGenericService Service;

        protected ServiceHub() : this(new GenericService()) { }

        protected ServiceHub(IGenericService service)
        {
            Service = service;
        }
    }
}
