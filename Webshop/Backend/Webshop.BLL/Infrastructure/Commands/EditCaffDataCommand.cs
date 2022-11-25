using Webshop.BLL.Infrastructure.DataTransferObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Webshop.BLL.Infrastructure.Commands
{
    public class EditCaffDataCommand : IRequest<Unit>
    {
        public Guid CaffId { get; set; }

        public EditCaffDTO Dto { get; set; }

        public ClaimsPrincipal User { get; set; }

        public EditCaffDataCommand(Guid caffId, EditCaffDTO dto, ClaimsPrincipal user)
        {
            CaffId = caffId;
            Dto = dto;
            User = user;
        }
    }
}
