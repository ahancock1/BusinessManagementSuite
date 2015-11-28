using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Globalization;
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
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            if (claim == null)
            {
                throw new ArgumentNullException("claim");
            }

            foreach (AspNetUserClaim c in user.AspNetClaims.Where(u => u.ClaimValue == claim.Value && u.ClaimType == claim.Type).ToList())
            {
                user.AspNetClaims.Remove(c);
            }

            return Task.FromResult(0);
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

            AspNetUserClaim userClaim = new AspNetUserClaim
            {
                UserId = user.Id,
                ClaimType = claim.Type,
                ClaimValue = claim.Value
            };
            user.AspNetClaims.Add(userClaim);

            return Task.FromResult(0);
        }

        public Task AddToRoleAsync(AspNetUser user, string roleName)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            if (String.IsNullOrWhiteSpace(roleName))
            {
                throw new ArgumentException("roleName");
            }

            AspNetUserRole userRole = Service.Get<AspNetUserRole>(r => r.Name == roleName);

            if (userRole == null)
            {
                // throw exception
                throw new Exception("role not found");
            }

            user.AspNetRoles.Add(userRole);
            return Task.FromResult(0);
        }

        public Task RemoveFromRoleAsync(AspNetUser user, string roleName)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            if (String.IsNullOrWhiteSpace(roleName))
            {
                throw new ArgumentNullException("roleName");
            }

            AspNetUserRole userRole = user.AspNetRoles.SingleOrDefault(r => r.Name == roleName);

            if (userRole != null)
            {
                user.AspNetRoles.Remove(userRole);
            }

            return Task.FromResult(0);
        }

        public Task<IList<string>> GetRolesAsync(AspNetUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            return Task.FromResult<IList<string>>(Service.All<AspNetUserRole>().Select(u => u.Name).ToList());
        }

        public Task<bool> IsInRoleAsync(AspNetUser user, string roleName)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            if (String.IsNullOrWhiteSpace(roleName))
            {
                throw new ArgumentException("roleName");
            }

            return
                Task.FromResult(
                    Service.Get<AspNetUserRole>(r => r.Name == roleName && r.Users.Any(u => u.Id == user.Id),
                        r => r.Users) != null);
        }

        public Task SetSecurityStampAsync(AspNetUser user, string stamp)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            user.SecurityStamp = stamp;

            return Task.FromResult(0);
        }

        public Task<string> GetSecurityStampAsync(AspNetUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            return Task.FromResult(user.SecurityStamp);
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
                LoginProvider = login.LoginProvider
            };
            user.AspNetLogins.Add(userLogin);

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
                user.AspNetLogins.Remove(userLogin);
            }

            return Task.FromResult(0);
        }

        public Task<IList<UserLoginInfo>> GetLoginsAsync(AspNetUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            return Task.FromResult<IList<UserLoginInfo>>(user.AspNetLogins.Select(u => new UserLoginInfo(u.LoginProvider, u.ProviderKey)).ToList());
        }

        public Task<AspNetUser> FindAsync(UserLoginInfo login)
        {
            if (login == null)
            {
                throw new ArgumentNullException("login");
            }

            AspNetUserLogin userLogin =
                Service.Get<AspNetUserLogin>(
                    u => u.LoginProvider == login.ProviderKey && u.ProviderKey == login.ProviderKey, u => u.AspNetUser);

            if (userLogin == null)
            {
                return null;
            }

            return
                Task.FromResult(Service.Get<AspNetUser>(u => u.Id == userLogin.AspNetUser.Id, u => u.AspNetLogins,
                    u => u.AspNetClaims));
        }

        public Task<IList<Claim>> GetClaimsAsync(AspNetUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            return Task.FromResult<IList<Claim>>(user.AspNetClaims.Select(c => new Claim(c.ClaimType, c.ClaimValue)).ToList());
        }
    }
}
