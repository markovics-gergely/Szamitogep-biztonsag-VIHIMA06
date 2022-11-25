using Webshop.BLL.Infrastructure.DataTransferObjects;
using MediatR;

namespace Webshop.BLL.Infrastructure.Commands
{
    public class CreateUserCommand : IRequest<bool>
    {
        public RegisterUserDTO DTO { get; set; }

        public CreateUserCommand(RegisterUserDTO dto)
        {
            DTO = dto;
        }
    }
}
