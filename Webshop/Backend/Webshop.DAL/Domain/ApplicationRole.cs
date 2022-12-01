using Microsoft.AspNetCore.Identity;

namespace Webshop.DAL.Domain
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        public string Description { get; set; } = string.Empty;
    }
}
