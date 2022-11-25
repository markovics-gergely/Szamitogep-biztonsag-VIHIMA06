using Webshop.BLL.MappingProfiles;

namespace Webshop.API.Extensions
{
    /// <summary>
    /// Manage automapper configurations
    /// </summary>
    public static class AutoMapperExtension
    {
        /// <summary>
        /// Add automapper profile configurations
        /// </summary>
        /// <param name="services"></param>
        public static void AddAutoMapperExtensions(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(UserProfile), typeof(CaffProfile), typeof(ListProfile));
        }
    }
}
