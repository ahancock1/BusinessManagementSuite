using System.ServiceModel;
using System.Threading.Tasks;
using Com.Framework.Services.Messages;
using Com.Framework.Services.Messages.Membership;

namespace Com.Framework.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IMembershipService : IService
    {
        [OperationContract]
        Task<LoginResponse> SignInAsync(LoginRequest request);

        [OperationContract]
        Task<CreateResponse> CreateAsync(CreateRequest request);
    }
}
