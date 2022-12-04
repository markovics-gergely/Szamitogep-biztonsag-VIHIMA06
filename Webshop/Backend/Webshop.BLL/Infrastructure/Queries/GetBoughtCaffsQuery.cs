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
    public class GetBoughtCaffsQuery : IRequest<EnumerableWithTotalViewModel<CaffListViewModel>>
    {
        public GetCaffsDto Dto { get; set; }

        public ClaimsPrincipal User { get; set; }

        public GetBoughtCaffsQuery(GetCaffsDto dto, ClaimsPrincipal user)
        {
            Dto = dto;
            User = user;
        }
    }
}
