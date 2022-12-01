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
    public class UploaderValidator : IValidator
    {
        private readonly Caff _caff;

        private readonly ClaimsPrincipal _user;

        public UploaderValidator(Caff caff, ClaimsPrincipal user)
        {
            _caff = caff;
            _user = user;
        }

        public bool Validate()
        {
            return _caff.Uploader.Id == Guid.Parse(_user.GetUserIdFromJwt());
        }
    }
}
