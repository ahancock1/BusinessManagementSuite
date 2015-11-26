using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Com.Framework.Models;
using Com.Framework.Services.Extensions;
using Com.Framework.Services.Messages;
using Com.Framework.Services.Messages.Membership;
using Microsoft.AspNet.Identity;

namespace Com.Framework.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class MembershipService : BaseService, IMembershipService
    {
        /// <summary>
        /// Add a Login to an existing user. 
        /// </summary>
        /// <param name="request">Instance of AddLoginRequest</param>
        /// <returns>Instance of AddLoginResponse</returns>
        public async Task<AddLoginResponse> AddLoginAsync(AddLoginRequest request)
        {
            AddLoginResponse response = new AddLoginResponse();

            try
            {
                IdentityResult result =
                    await
                        UserManager.AddLoginAsync(request.UserId.ToString(),
                            new UserLoginInfo(request.LoginProvider, request.ProviderKey));

                if (!result.Succeeded)
                {
                    response.AddErrors(result.Errors);
                    response.Success = false;
                }
                else
                {
                    response.Success = false;
                }

            }
            catch (Exception e)
            {
                response.Success = false;
                response.AddErrors(e.Message);
            }

            return response;
        }

        /// <summary>
        /// Create a user without or without a password and return a ClaimsIdentity representing the user created.
        /// </summary>
        /// <param name="request">Instance of CreateRequest</param>
        /// <returns>Instance of CreateResponse</returns>
        public async Task<CreateResponse> CreateAsync(CreateRequest request)
        {
            CreateResponse response = new CreateResponse();

            try
            {
                AspNetUser user = new AspNetUser
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    UserName = request.UserName,
                    Discriminator = "ApplicationUser"
                };

                IdentityResult result;

                if (!String.IsNullOrWhiteSpace(request.Password))
                {
                    result = await UserManager.CreateAsync(user, request.Password);
                }
                else
                {
                    result = await UserManager.CreateAsync(user);
                }

                if (result.Succeeded)
                {
                    string authType = request.AuthenticationType.ToString();
                    ClaimsIdentity identity = await UserManager.CreateIdentityAsync(user, authType);

                    response.UserId = new Guid(identity.GetUserId());
                    response.ClaimIdentity = identity.ToView();
                    response.Success = true;
                }

            }
            catch (Exception e)
            {
                response.Success = false;
                response.AddErrors(e.Message);
            }

            return response;
        }

        /// <summary>
        /// Create a ClaimsIdentity representing an existing user.
        /// </summary>
        /// <param name="request">Instance of CreateRequest</param>
        /// <returns>Instance of CreateResponse</returns>
        public async Task<CreateIdentityResponse> CreateIdentityAsync(CreateIdentityRequest request)
        {
            CreateIdentityResponse response = new CreateIdentityResponse();

            try
            {
                string authType = request.AuthenticationType.ToString();

                AspNetUser user = await UserManager.FindByNameAsync(request.UserName);
                ClaimsIdentity identity = await UserManager.CreateIdentityAsync(user, authType);
                response.ClaimIdentityView = identity.ToView();
                response.Success = true;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.AddErrors(e.Message);
            }

            return response;
        }

        /// <summary>
        /// Change Password for an existing user.
        /// </summary>
        /// <param name="request">Instance of ChangePasswordRequest</param>
        /// <returns>Instance of ChangePasswordResponse</returns>
        public async Task<ChangePasswordResponse> ChangePasswordAsync(ChangePasswordRequest request)
        {
            ChangePasswordResponse response = new ChangePasswordResponse();

            try
            {
                IdentityResult result =
                    await
                        UserManager.ChangePasswordAsync(request.UserId.ToString(), request.OldPassword,
                            request.NewPassword);

                if (!result.Succeeded)
                {
                    response.Success = false;
                    response.AddErrors(response.Errors);
                }
                else
                {
                    response.Success = true;
                }
            }
            catch (Exception e)
            {
                response.Success = false;
                response.AddErrors(e.Message);
            }

            return response;
        }

        /// <summary>
        /// Login by UserName and Password and return ClaimsIdentity representing the logged in user.
        /// </summary>
        /// <param name="request">Instance of LoginRequest</param>
        /// <returns>Instance of LoginResponse</returns>
        public async Task<LoginResponse> LoginAsync(LoginRequest request)
        {
            LoginResponse response = new LoginResponse();

            try
            {
                AspNetUser user = await UserManager.FindAsync(request.UserName, request.Password);

                IdentityResult validation = await UserManager.PasswordValidator.ValidateAsync(request.Password);

                if (validation.Succeeded)
                {
                    ClaimsIdentity identity = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
                    response.ClaimIdentity = identity.ToView();
                    response.Success = true;
                }
                else
                {
                    response.AddErrors(validation.Errors);
                }
            }
            catch (Exception e)
            {
                response.Success = false;
                response.AddErrors(e.Message);
            }

            return response;
        }

        /// <summary>
        /// Remove associated login by LoginProvider and ProviderKey
        /// </summary>
        /// <param name="request">Instance of RemoveLoginRequest</param>
        /// <returns>Instance of RemoveLoginResponse</returns>
        public async Task<RemoveLoginResponse> RemoveLoginAsync(RemoveLoginRequest request)
        {
            RemoveLoginResponse response = new RemoveLoginResponse();

            try
            {
                IdentityResult result = await UserManager.RemoveLoginAsync(request.UserId.ToString(), new UserLoginInfo(request.LoginProvider, request.ProviderKey));

                if (!result.Succeeded)
                {
                    response.AddErrors(response.Errors);
                    response.Success = false;
                }
                else
                {
                    response.Success = true;
                }

            }
            catch (Exception e)
            {
                response.Success = false;
                response.AddErrors(e.Message);
            }

            return response;
        }

        /// <summary>
        /// Find User by Id and return View of User
        /// </summary>
        /// <param name="request">Instance of FindByIdRequest</param>
        /// <returns>Instance of FindByIdResponse</returns>
        public FindByIdResponse FindById(FindByIdRequest request)
        {
            FindByIdResponse response = new FindByIdResponse();

            try
            {
                AspNetUser result = UserManager.FindById(request.UserId.ToString());
                response.UserView = result.ToView();
                response.Success = true;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Errors.Add(e.Message);
            }

            return response;
        }

        /// <summary>
        /// Find User by Id and return View of User Async version
        /// </summary>
        /// <param name="request">Instance of FindByIdRequest</param>
        /// <returns>Instance of FindByIdResponse</returns>
        public async Task<FindByIdResponse> FindByIdAsync(FindByIdRequest request)
        {
            FindByIdResponse response = new FindByIdResponse();

            try
            {

                AspNetUser result = await UserManager.FindByIdAsync(request.UserId.ToString());
                response.UserView = result.ToView();
                response.Success = true;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Errors.Add(e.Message);
            }

            return response;
        }

        /// <summary>
        /// Login User by external provider and return ClaimsIdentity
        /// </summary>
        /// <param name="request">Instance of LoginExternalRequest</param>
        /// <returns>Instance of LoginExternalResponse</returns>
        public async Task<LoginExternalResponse> LoginExternalAsync(LoginExternalRequest request)
        {
            LoginExternalResponse response = new LoginExternalResponse();

            try
            {
                string authType = request.AuthenticationType.ToString();

                AspNetUser user = await UserManager.FindAsync(new UserLoginInfo(request.LoginProvider, request.ProviderKey));
                ClaimsIdentity identity = await UserManager.CreateIdentityAsync(user, authType);

                response.ClaimIdentity = identity.ToView();
                response.Success = true;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Errors.Add(e.Message);
            }

            return response;
        }

        /// <summary>
        /// Get all external associated Logins for User
        /// </summary>
        /// <param name="request">Instance of GetLoginsRequest</param>
        /// <returns>Instance of GetLoginsResponse</returns>
        public GetLoginsResponse GetLogins(GetLoginsRequest request)
        {
            GetLoginsResponse response = new GetLoginsResponse();

            try
            {
                IList<UserLoginInfo> result = UserManager.GetLogins(request.UserId.ToString());
                response.LinkedAccounts = result.ToViewList();
                response.Success = true;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Errors.Add(e.Message);
            }

            return response;
        }

        /// <summary>
        /// Get all external associated Logins for User Async
        /// </summary>
        /// <param name="request">Instance of GetLoginsRequest</param>
        /// <returns>Instance of GetLoginsResponse</returns>
        public async Task<GetLoginsResponse> GetLoginsAsync(GetLoginsRequest request)
        {
            GetLoginsResponse response = new GetLoginsResponse();

            try
            {
                IList<UserLoginInfo> result = await UserManager.GetLoginsAsync(request.UserId.ToString());
                response.LinkedAccounts = result.ToViewList();
                response.Success = true;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Errors.Add(e.Message);
            }

            return response;
        }


        /// <summary>
        /// Add a password to a given user if they dont have one
        /// </summary>
        /// <param name="request">Instance of GetLoginsRequest</param>
        /// <returns>Instance of GetLoginsResponse</returns>
        public async Task<AddPasswordResponse> AddPasswordAsync(AddPasswordRequest request)
        {
            AddPasswordResponse response = new AddPasswordResponse();

            try
            {
                IdentityResult result = await UserManager.AddPasswordAsync(request.UserId.ToString(), request.NewPassword);

                if (!result.Succeeded)
                {
                    foreach (string item in response.Errors)
                        response.Errors.Add(item);

                    response.Success = false;
                }
                else
                {
                    response.Success = true;
                }
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Errors.Add(e.Message);
            }

            return response;
        }
    }
}
