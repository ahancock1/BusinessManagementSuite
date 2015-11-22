using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using Com.Framework.Services.Views;

namespace Com.Framework.Services.Extensions
{
    public static class ClaimExtensions
    {
        public static ClaimIdentityView ToView(this ClaimsIdentity identity)
        {
            ClaimIdentityView view = new ClaimIdentityView
            {
                Name = identity.Name,
                NameClaimType = identity.NameClaimType,

                RoleClaimType = identity.RoleClaimType
            };

            foreach (Claim claim in identity.Claims)
            {
                view.ClaimViews.Add(claim.ToView());
            }

            return view;
        }

        public static ClaimView ToView(this Claim claim)
        {
            return new ClaimView
            {
                Type = claim.Type,
                Value = claim.Value,
                ValueType = claim.ValueType
            };
        }
    }
}