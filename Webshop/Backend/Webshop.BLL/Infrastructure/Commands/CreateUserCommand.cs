using Webshop.BLL.Infrastructure.DataTransferObjects;
using MediatR;

namespace Webshop.BLL.Infrastructure.Commands
{
    public class CreateUserCommand : IRequest<bool>
    {
        public RegisterUserDto DTO { get; set; }

        public CreateUserCommand(RegisterUserDto dto)
        {
            DTO = dto;
        }
    }
}
