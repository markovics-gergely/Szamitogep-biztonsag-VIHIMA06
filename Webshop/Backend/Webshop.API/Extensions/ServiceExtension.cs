using Webshop.BLL.Stores.Implementations;
using Webshop.BLL.Stores.Interfaces;
using Webshop.BLL.Infrastructure.Commands;
using Webshop.BLL.Infrastructure;
using Webshop.BLL.Infrastructure.Queries;
using Webshop.BLL.Infrastructure.ViewModels;
using MediatR;
using Webshop.DAL.Repository.Implementations;
using Webshop.DAL.Repository.Interfaces;
using Webshop.DAL.UnitOfWork.Interfaces;
using Webshop.DAL.UnitOfWork.Implementations;

namespace Webshop.API.Extensions
{
    /// <summary>
    /// Helper class for adding services
    /// </summary>
    public static class ServiceExtension
    {
        /// <summary>
        /// Add services for dependency injections
        /// </summary>
        /// <param name="services"></param>
        public static void AddServiceExtensions(this IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddTransient<IUserStore, UserStore>();
            services.AddTransient<IRequestHandler<CreateUserCommand, bool>, UserCommandHandler>();
            services.AddTransient<IRequestHandler<EditUserCommand, bool>, UserCommandHandler>();
            services.AddTransient<IRequestHandler<EditUserRoleCommand, Unit>, UserCommandHandler>();

            services.AddTransient<IRequestHandler<GetActualUserIdQuery, string?>, UserQueryHandler>();
            services.AddTransient<IRequestHandler<GetUserQuery, ProfileWithNameViewModel>, UserQueryHandler>();
            services.AddTransient<IRequestHandler<GetProfileQuery, ProfileViewModel>, UserQueryHandler>();
            services.AddTransient<IRequestHandler<GetFullProfileQuery, ProfileWithNameViewModel>, UserQueryHandler>();
            services.AddTransient<IRequestHandler<GetUsersByRoleQuery, IEnumerable<UserNameViewModel>>, UserQueryHandler>();

            services.AddTransient<IRequestHandler<GetCaffDownloadQuery, byte[]>, CaffQueryHandler>();
            services.AddTransient<IRequestHandler<GetCaffDetailsQuery, CaffDetailsViewModel>, CaffQueryHandler>();
            services.AddTransient<IRequestHandler<GetCaffListQuery, EnumerableWithTotalViewModel<CaffListViewModel>>, CaffQueryHandler>();
            services.AddTransient<IRequestHandler<GetBoughtCaffsQuery, EnumerableWithTotalViewModel<CaffListViewModel>>, CaffQueryHandler>();

            services.AddTransient<IRequestHandler<RemoveCommentCommand, Unit>, CaffCommandHandler>();
            services.AddTransient<IRequestHandler<PostCommentCommand, Unit>, CaffCommandHandler>();
            services.AddTransient<IRequestHandler<UploadCaffCommand, Guid>, CaffCommandHandler>();
            services.AddTransient<IRequestHandler<DeleteCaffCommand, Unit>, CaffCommandHandler>();
            services.AddTransient<IRequestHandler<BuyCaffCommand, Unit>, CaffCommandHandler>();
            services.AddTransient<IRequestHandler<EditCaffDataCommand, Unit>, CaffCommandHandler>();

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IFileRepository, FileRepository>();
        }
    }
}
