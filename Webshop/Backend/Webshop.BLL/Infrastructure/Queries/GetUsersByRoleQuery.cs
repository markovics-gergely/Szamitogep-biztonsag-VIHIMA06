using Webshop.BLL.Infrastructure.ViewModels;
using MediatR;

namespace Webshop.BLL.Infrastructure.Queries
{
    public class GetUsersByRoleQuery : IRequest<IEnumerable<UserNameViewModel>>
    {
        public string Role { get; set; }

        public GetUsersByRoleQuery(string role)
        {
            Role = role;
        }
    }
}
