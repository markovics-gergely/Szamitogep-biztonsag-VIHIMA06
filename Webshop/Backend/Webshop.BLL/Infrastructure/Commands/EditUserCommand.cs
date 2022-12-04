using Webshop.BLL.Infrastructure.DataTransferObjects;
using MediatR;

namespace Webshop.BLL.Infrastructure.Commands
{
    public class EditUserCommand : IRequest<bool>
    {
        public EditUserDto DTO { get; set; }

        public EditUserCommand(EditUserDto dto)
        {
            DTO = dto;
        }
    }
}
