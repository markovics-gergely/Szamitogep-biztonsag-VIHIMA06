using Webshop.BLL.Infrastructure.DataTransferObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Webshop.BLL.Infrastructure.Commands
{
    public class UploadCaffCommand : IRequest<Guid>
    {
        public UploadCaffDTO Dto { get; set; }

        public ClaimsPrincipal User { get; set; }

        public UploadCaffCommand(UploadCaffDTO dto, ClaimsPrincipal user)
        {
            Dto = dto;
            User = user;
        }
    }
}
