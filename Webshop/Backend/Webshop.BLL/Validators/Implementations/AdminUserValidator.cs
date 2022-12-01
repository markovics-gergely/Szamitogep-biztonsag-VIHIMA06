using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Webshop.BLL.Validators.Interfaces;
using Webshop.DAL.Types;

namespace Webshop.BLL.Validators.Implementations
{
    public class AdminUserValidator : IValidator
    {
        private readonly ClaimsPrincipal _user;

        public AdminUserValidator(ClaimsPrincipal user)
        {
            _user = user;
        }

        public bool Validate()
        {
            return _user.IsInRole(RoleTypes.Admin);
        }
    }
}
