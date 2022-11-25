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
    public class RemoveCommentCommand : IRequest<Unit>
    {
        public Guid CaffId { get; set; }

        public RemoveCommentDTO Dto { get; set; }

        public ClaimsPrincipal User { get; set; }

        public RemoveCommentCommand(Guid caffId, ClaimsPrincipal user, RemoveCommentDTO dto)
        {
            CaffId = caffId;
            User = user;
            Dto = dto;
        }
    }
}
