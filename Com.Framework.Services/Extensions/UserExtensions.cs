using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Com.Framework.Models;
using Com.Framework.Services.Views;

namespace Com.Framework.Services.Extensions
{
    public static class UserExtensions
    {
        public static UserView ToView(this AspNetUser user)
        {
            return new UserView
            {
                Id = new Guid(user.Id),
                FirstName = user.FirstName,
                LastName = user.LastName,
                PasswordHash = user.PasswordHash,
                UserName = user.UserName
            };
        }

    }
}