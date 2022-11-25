using Webshop.BLL.Infrastructure.ViewModels;
using MediatR;

namespace Webshop.BLL.Infrastructure.Queries
{
    public class GetUserQuery : IRequest<ProfileWithNameViewModel>
    {
        public string? Id { get; set; }

        public GetUserQuery(string? id)
        {
            Id = id;
        }
    }
}
