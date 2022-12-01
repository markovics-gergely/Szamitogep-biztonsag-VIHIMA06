using Webshop.BLL.Infrastructure.DataTransferObjects;
using MediatR;

namespace Webshop.BLL.Infrastructure.Commands
{
    public class EditUserRoleCommand : IRequest
    {
        public EditUserRoleDTO DTO { get; set; }

        public EditUserRoleCommand(EditUserRoleDTO dto)
        {
            DTO = dto;
        }
    }
}
