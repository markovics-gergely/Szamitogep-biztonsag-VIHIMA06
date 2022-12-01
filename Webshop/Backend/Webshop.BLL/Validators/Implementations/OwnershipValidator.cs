using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Webshop.BLL.Extensions;
using Webshop.BLL.Validators.Interfaces;
using Webshop.DAL.Domain;

namespace Webshop.BLL.Validators.Implementations
{
    public class OwnershipValidator : IValidator
    {
        private readonly Caff _caff;

        private readonly ClaimsPrincipal _user;

        public OwnershipValidator(Caff caff, ClaimsPrincipal user)
        {
            _caff = caff;
            _user = user;
        }

        public bool Validate()
        {
            if (_caff.BoughtBy == null)
            {
                return false;
            }
            return _caff.BoughtBy.Id == Guid.Parse(_user.GetUserIdFromJwt());
        }
    }
}
