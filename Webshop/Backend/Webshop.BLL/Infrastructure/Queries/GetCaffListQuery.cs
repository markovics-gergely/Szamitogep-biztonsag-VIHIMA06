using Webshop.BLL.Infrastructure.DataTransferObjects;
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
    public class GetCaffListQuery : IRequest<EnumerableWithTotalViewModel<CaffListViewModel>>
    {
        public GetCaffsDTO Dto { get; set; }

        public ClaimsPrincipal User { get; set; }

        public Guid? UserId { get; set; }

        public GetCaffListQuery(GetCaffsDTO dto, ClaimsPrincipal user, Guid? userId = null)
        {
            UserId = userId;
            Dto = dto;
            User = user;
        }
    }
}
