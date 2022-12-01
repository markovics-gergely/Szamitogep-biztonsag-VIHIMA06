using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Webshop.BLL.Infrastructure.Queries
{
    public class GetCaffDownloadQuery : IRequest<byte[]>
    {
        public Guid CaffId { get; set; }

        public ClaimsPrincipal User { get; set; }

        public GetCaffDownloadQuery(Guid caffId, ClaimsPrincipal user)
        {
            CaffId = caffId;
            User = user;
        }
    }
}
