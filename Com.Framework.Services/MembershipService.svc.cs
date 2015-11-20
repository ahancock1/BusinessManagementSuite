using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using Com.Framework.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Com.Framework.Services
{
    public class SignInRequest
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public bool RememberMe { get; set; }

        public bool ShouldLockout { get; set; }
    }

    public class CreateRequest
    {
        public AspNetUser User { get; set; }

        public string Password { get; set; }
    }

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class MembershipService : BaseService, IMembershipService
    {
        public async Task<SignInStatus> SignInAsync(SignInRequest request)
        {
            return await Task.FromResult(SignInStatus.Failure);
        }

        public async Task<IdentityResult> CreateAsync(CreateRequest request)
        {
            return await Task.FromResult(IdentityResult.Failed("not implemented"));
        }
    }
}
