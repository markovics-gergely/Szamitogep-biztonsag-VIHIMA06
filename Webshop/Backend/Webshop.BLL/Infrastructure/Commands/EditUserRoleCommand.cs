using Webshop.BLL.Infrastructure.DataTransferObjects;
using MediatR;

namespace Webshop.BLL.Infrastructure.Commands
{
    public class EditUserRoleCommand : IRequest
    {
        public EditUserRoleDto DTO { get; set; }

        public EditUserRoleCommand(EditUserRoleDto dto)
        {
            DTO = dto;
        }
    }
}
