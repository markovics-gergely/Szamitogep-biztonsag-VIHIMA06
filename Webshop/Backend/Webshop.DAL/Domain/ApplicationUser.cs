﻿using Microsoft.AspNetCore.Identity;

namespace Webshop.DAL.Domain
{
    /// <summary>
    /// Users of the application
    /// </summary>
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public virtual ICollection<IdentityUserClaim<Guid>> Claims { get; set; } = new List<IdentityUserClaim<Guid>>();
        public virtual ICollection<IdentityUserLogin<Guid>> Logins { get; set; } = new List<IdentityUserLogin<Guid>>();
        public virtual ICollection<IdentityUserToken<Guid>> Tokens { get; set; } = new List<IdentityUserToken<Guid>>();
        public virtual ICollection<IdentityUserRole<Guid>> UserRoles { get; set; } = new List<IdentityUserRole<Guid>>();

        public IList<Caff> UploadedCaffs { get; set; } = new List<Caff>();

        public IList<Caff> BoughtCaffs { get; set; } = new List<Caff>();

        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
