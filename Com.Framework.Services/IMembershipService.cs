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
        Task<AddLoginResponse> AddLoginAsync(AddLoginRequest request);

        [OperationContract]
        Task<CreateResponse> CreateAsync(CreateRequest request);

        [OperationContract]
        Task<CreateIdentityResponse> CreateIdentityAsync(CreateIdentityRequest request);

        [OperationContract]
        Task<ChangePasswordResponse> ChangePasswordAsync(ChangePasswordRequest request);

        [OperationContract]
        Task<LoginResponse> LoginAsync(LoginRequest request);

        [OperationContract]
        Task<RemoveLoginResponse> RemoveLoginAsync(RemoveLoginRequest request);

        [OperationContract]
        Task<FindByIdResponse> FindByIdAsync(FindByIdRequest request);

        [OperationContract]
        Task<LoginExternalResponse> LoginExternalAsync(LoginExternalRequest request);

        [OperationContract]
        Task<GetLoginsResponse> GetLoginsAsync(GetLoginsRequest request);

        [OperationContract]
        Task<SignInResponse> SignInAsync(SignInRequest request);
    }
}
