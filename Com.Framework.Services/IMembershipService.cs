using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Com.Framework.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IMembershipService : IService
    {
        [OperationContract]
        Task<SignInStatus> SignInAsync(SignInRequest request);

        [OperationContract]
        Task<IdentityResult> CreateAsync(CreateRequest request);

    }
}
