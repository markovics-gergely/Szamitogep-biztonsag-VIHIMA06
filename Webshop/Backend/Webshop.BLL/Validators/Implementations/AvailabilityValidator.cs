using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Webshop.BLL.Validators.Interfaces;
using Webshop.DAL.Domain;

namespace Webshop.BLL.Validators.Implementations
{
    public class AvailabilityValidator : IValidator
    {
        private readonly Caff _caff;

        public AvailabilityValidator(Caff caff)
        {
            _caff = caff;
        }

        public bool Validate()
        {
            return _caff.BoughtBy == null;
        }
    }
}
