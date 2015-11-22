using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Com.Framework.Services.Views;

namespace Com.Framework.Services.Extensions
{
    public static class LoginExtensions
    {
        public static IList<LoginView> ToViewList(this IEnumerable<UserLoginInfo> userLoginInfoList)
        {
            List<LoginView> result = new List<LoginView>();

            foreach (UserLoginInfo item in userLoginInfoList)
                result.Add(item.ToView());

            return result;
        }

        public static LoginView ToView(this UserLoginInfo userLoginInfo)
        {
            return new LoginView()
            {
                LoginProvider = userLoginInfo.LoginProvider,
                ProviderKey = userLoginInfo.ProviderKey
            };
        }
    }
}