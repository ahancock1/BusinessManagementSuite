using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Com.Framework.Data;
using Com.Framework.DataAccess;
using Com.Framework.DataAccess.Services;
using Com.Framework.Models;
using Microsoft.AspNet.Identity;
using EntityState = Com.Framework.Data.EntityState;

namespace Com.Framework.Services
{
    public class AppUserService : IUserStore<AspNetUser>, IUserPasswordStore<AspNetUser>, IUserClaimStore<AspNetUser>,
        IUserRoleStore<AspNetUser>, IUserSecurityStampStore<AspNetUser>, IUserLoginStore<AspNetUser>
    {
        //        public DataContext Context { get; set; }
        //
        //        public AppUserService(DataContext context)
        //        {
        //            if (context == null)
        //            {
        //                throw new ArgumentNullException("context");
        //            }
        //
        //            Context = context;
        //        }


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

        public IGenericService Service { get; set; }

        public AppUserService()
            : this(new GenericService())
        {

        }

        public AppUserService(IGenericService service)
        {
            Service = service;
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            // No need to dispose of anything
        }

        public Task CreateAsync(AspNetUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            user.EntityState = EntityState.Added;
            Service.UpdateAsync(user);

            return Task.FromResult(0);
        }

        public Task UpdateAsync(AspNetUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            user.EntityState = EntityState.Modified;
            Service.UpdateAsync(user);

            return Task.FromResult(0);
        }

        public Task DeleteAsync(AspNetUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            user.EntityState = EntityState.Deleted;
            Service.UpdateAsync(user);

            return Task.FromResult(0);
        }

        public Task<AspNetUser> FindByIdAsync(string userId)
        {
            return Task.FromResult(Service.Get<AspNetUser>(u => u.Id == userId, u => u.Logins, u => u.Roles, u => u.Claims));
        }

        public Task<AspNetUser> FindByNameAsync(string userName)
        {
            return Task.FromResult(Service.Get<AspNetUser>(u => u.UserName == userName, u => u.Logins, u => u.Roles, u => u.Claims));
        }

        public Task SetPasswordHashAsync(AspNetUser user, string passwordHash)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            user.PasswordHash = passwordHash;
            user.EntityState = EntityState.Modified;

            return Task.FromResult(0);
        }

        public Task<string> GetPasswordHashAsync(AspNetUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            return Task.FromResult(user.PasswordHash);
        }

        public Task<bool> HasPasswordAsync(AspNetUser user)
        {
            return Task.FromResult(user.PasswordHash != null);
        }

        public Task RemoveClaimAsync(AspNetUser user, Claim claim)
        {
            throw new NotImplementedException();
        }

        public Task AddClaimAsync(AspNetUser user, Claim claim)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            if (claim == null)
            {
                throw new ArgumentNullException("claim");
            }

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
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            if (login == null)
            {
                throw new ArgumentNullException("login");
            }

            AspNetUserLogin userLogin = new AspNetUserLogin
            {
                AspNetUser = user,
                ProviderKey = login.ProviderKey,
                LoginProvider = login.LoginProvider,
                EntityState = EntityState.Added
            };
            user.Logins.Add(userLogin);

            //            Service.UpdateAsync(userLogin);

            return Task.FromResult(0);
        }

        public Task RemoveLoginAsync(AspNetUser user, UserLoginInfo login)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            if (login == null)
            {
                throw new ArgumentNullException("login");
            }

            AspNetUserLogin userLogin = Service.Get<AspNetUserLogin>(u =>
            {
                if (u.LoginProvider != login.LoginProvider || u.AspNetUser == user)
                {
                    return false;
                }
                return u.ProviderKey == login.ProviderKey;
            });

            if (userLogin != null)
            {
                userLogin.EntityState = EntityState.Deleted;
                Service.UpdateAsync(userLogin);
            }

            return Task.FromResult(0);
        }

        public Task<IList<UserLoginInfo>> GetLoginsAsync(AspNetUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            // This has changed from origional code
            IList<UserLoginInfo> userLogins = new List<UserLoginInfo>();
            foreach (AspNetUserLogin login in Service.All<AspNetUser>(u => u.Id == user.Id, u => u.AspNetUserLogins).Select(u => u.AspNetUserLogins))
            {
                userLogins.Add(new UserLoginInfo(login.LoginProvider, login.ProviderKey));
            }

            return Task.FromResult<IList<UserLoginInfo>>(userLogins);
        }

        public Task<AspNetUser> FindAsync(UserLoginInfo login)
        {
            if (login == null)
            {
                throw new ArgumentNullException("login");
            }

            AspNetUserLogin userLogin =
                Service.Get<AspNetUserLogin>(
                    u => u.LoginProvider == login.LoginProvider && u.ProviderKey == login.ProviderKey, u => u.Logins, u => u.Roles, u => u.Claims));

            return Task.FromResult(userLogin != null ? userLogin.AspNetUser : null);
        }

        public Task<IList<Claim>> GetClaimsAsync(AspNetUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            IList<Claim> claims = new List<Claim>();
            foreach (AspNetUserClaim claim in user.AspNetUserClaims)
            {
                claims.Add(new Claim(claim.ClaimType, claim.ClaimValue));
            }

            return Task.FromResult<IList<Claim>>(claims);
        }
    }
}
