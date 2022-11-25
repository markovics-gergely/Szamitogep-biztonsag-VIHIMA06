using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Webshop.BLL.Infrastructure.DataTransferObjects;

namespace Webshop.BLL.Infrastructure.Commands
{
    public class PostCommentCommand : IRequest<Unit>
    {
        public Guid CaffId { get; set; }

        public PostCommentDTO Dto { get; set; }

        public ClaimsPrincipal User { get; set; }

        public PostCommentCommand(Guid caffId, ClaimsPrincipal user, PostCommentDTO dto)
        {
            CaffId = caffId;
            User = user;
            Dto = dto;
        }
    }
}
