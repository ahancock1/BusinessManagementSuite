using Com.Framework.DataAccess.Services;

namespace Com.Framework.Service
{
    public abstract class BaseService
    {
        protected readonly GenericService Service;

        protected BaseService() : this(new GenericService()) { }

        protected BaseService(GenericService service)
        {
            Service = service;
        }
    }
}
