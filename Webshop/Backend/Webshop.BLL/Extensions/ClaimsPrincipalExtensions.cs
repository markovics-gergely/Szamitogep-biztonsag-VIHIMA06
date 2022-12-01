﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Webshop.BLL.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserIdFromJwt(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.Claims.First(x => x.Type == "sub").Value;
        }

        public static string GetUserRoleFromJwt(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.Claims.First(x => x.Type == "role").Value;
        }
    }
}
