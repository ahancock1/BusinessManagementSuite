using Com.Framework.DataAccess;
using Com.Framework.DataAccess.Services;
using Com.Framework.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Com.Framework.Services
{
    public abstract class BaseService
    {
        protected readonly GenericService Service;

        protected BaseService() : this(new GenericService()) { }

        protected BaseService(GenericService service)
        {
            Service = service;

            CreateUserManager();
        }

        /// <summary>
        /// Create an instance of the user manager, inject the OpenAccessUserStore and the Telerik Context and finally the UserValidator
        /// </summary>
        protected void CreateUserManager()
        {
            UserManager<AspNetUser> manager = new UserManager<AspNetUser>(new UserStore<AspNetUser>(new DataContext()));

            manager.UserValidator = new UserValidator<AspNetUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = false
            };

            UserManager = manager;
        }

        public UserManager<AspNetUser> UserManager { get; private set; }
    }
}
