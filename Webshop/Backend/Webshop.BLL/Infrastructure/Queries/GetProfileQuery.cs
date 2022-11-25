using Webshop.BLL.Infrastructure.ViewModels;
using MediatR;

namespace Webshop.BLL.Infrastructure.Queries
{
    public class GetProfileQuery : IRequest<ProfileViewModel>
    {
    }
}
