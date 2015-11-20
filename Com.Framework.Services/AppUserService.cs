using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Com.Framework.Data;
using Com.Framework.Models;
using Microsoft.AspNet.Identity;

namespace Com.Framework.Services
{
    public class AppUserService : IUserStore<AspNetUser>, IUserPasswordStore<AspNetUser>, IUserClaimStore<AspNetUser>,
        IUserRoleStore<AspNetUser>, IUserSecurityStampStore<AspNetUser>, IUserLoginStore<AspNetUser>
    {


        //        public async Task<bool> AddLoginAsync(AspNetUser user, UserLoginInfo login)
        //        {
        //            if (user == null)
        //            {
        //                throw new ArgumentNullException("user");
        //            }
        //            if (login == null)
        //            {
        //                throw new ArgumentNullException("login");
        //            }
        //
        //            AspNetUserLogin identityUserLogin = new AspNetUserLogin
        //            {
        //                AspNetUser = user,
        //                ProviderKey = login.ProviderKey,
        //                LoginProvider = login.LoginProvider
        //            };
        //
        //            return await Service.UpdateAsync(identityUserLogin);
        //        }
        //
        //        public async Task<bool> RemoveLoginAsync(AspNetUser user, UserLoginInfo login)
        //        {
        //            if (user == null)
        //            {
        //                throw new ArgumentNullException("user");
        //            }
        //            if (login == null)
        //            {
        //                throw new ArgumentNullException("login");
        //            }
        //
        //            AspNetUserLogin userLogin =
        //                Service.Get<AspNetUserLogin>(u => u.LoginProvider == login.LoginProvider && u.AspNetUser == user);
        //
        //            if (userLogin == null) return await Task.FromResult(false);
        //
        //            userLogin.EntityState = EntityState.Deleted;
        //            return await Service.UpdateAsync(userLogin);
        //        }

        //        public Task<IList<UserLoginInfo>> GetLoginsAsync(AspNetUser user)
        //        {
        //            if (user == null)
        //            {
        //                throw new ArgumentNullException("user");
        //            }
        //
        //            IList<UserLoginInfo> userLoginsInfos =
        //                Service.All<AspNetUser>(u => u.Id == user.Id, u => u.AspNetUserLogins).Select(u => u.AspNetUserLogins).ToList();
        //
        //            List<UserLoginInfo> userLoginInfos = new List<UserLoginInfo>();
        //
        //            foreach (AspNetUserLogin login in user.AspNetUserLogins)
        //                userLoginInfos.Add(new UserLoginInfo(login.LoginProvider, login.ProviderKey));
        //
        //            return Task.FromResult<IList<UserLoginInfo>>(userLoginInfos);
        //        }
        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {


        }

        public Task CreateAsync(AspNetUser user)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(AspNetUser user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(AspNetUser user)
        {
            throw new NotImplementedException();
        }

        public Task<AspNetUser> FindByIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<AspNetUser> FindByNameAsync(string userName)
        {
            throw new NotImplementedException();
        }

        public Task SetPasswordHashAsync(AspNetUser user, string passwordHash)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetPasswordHashAsync(AspNetUser user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HasPasswordAsync(AspNetUser user)
        {
            throw new NotImplementedException();
        }

        public Task GetClaimsAsync(AspNetUser user)
        {
            throw new NotImplementedException();
        }

        public Task RemoveClaimAsync(AspNetUser user, Claim claim)
        {
            throw new NotImplementedException();
        }

        public Task AddClaimAsync(AspNetUser user, Claim claim)
        {
            throw new NotImplementedException();
        }

        public Task AddToRoleAsync(AspNetUser user, string roleName)
        {
            throw new NotImplementedException();
        }

        public Task RemoveFromRoleAsync(AspNetUser user, string roleName)
        {
            throw new NotImplementedException();
        }

        public Task<IList<string>> GetRolesAsync(AspNetUser user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsInRoleAsync(AspNetUser user, string roleName)
        {
            throw new NotImplementedException();
        }

        public Task SetSecurityStampAsync(AspNetUser user, string stamp)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetSecurityStampAsync(AspNetUser user)
        {
            throw new NotImplementedException();
        }

        public Task AddLoginAsync(AspNetUser user, UserLoginInfo login)
        {
            throw new NotImplementedException();
        }

        public Task RemoveLoginAsync(AspNetUser user, UserLoginInfo login)
        {
            throw new NotImplementedException();
        }

        public Task<IList<UserLoginInfo>> GetLoginsAsync(AspNetUser user)
        {
            throw new NotImplementedException();
        }

        public Task<AspNetUser> FindAsync(UserLoginInfo login)
        {
            throw new NotImplementedException();
        }

        Task<IList<Claim>> IUserClaimStore<AspNetUser, string>.GetClaimsAsync(AspNetUser user)
        {
            return GetClaimsAsync(user) as Task<IList<Claim>>;
        }
    }
}