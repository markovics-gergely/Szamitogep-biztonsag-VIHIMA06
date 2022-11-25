using Webshop.BLL.Infrastructure.DataTransferObjects;
using MediatR;

namespace Webshop.BLL.Infrastructure.Commands
{
    public class EditUserCommand : IRequest<bool>
    {
        public EditUserDTO DTO { get; set; }

        public EditUserCommand(EditUserDTO dto)
        {
            DTO = dto;
        }
    }
}
