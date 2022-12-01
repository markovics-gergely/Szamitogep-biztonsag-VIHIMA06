using Webshop.BLL.Infrastructure.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Webshop.BLL.Infrastructure.Queries
{
    public class GetCaffDetailsQuery : IRequest<CaffDetailsViewModel>
    {
        public Guid CaffId { get; set; }

        public ClaimsPrincipal User { get; set; }

        public GetCaffDetailsQuery(Guid caffId, ClaimsPrincipal user)
        {
            CaffId = caffId;
            User = user;
        }
    }
}
