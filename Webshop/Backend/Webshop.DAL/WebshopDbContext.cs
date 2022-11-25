using Webshop.DAL.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Webshop.DAL
{
    public class WebshopDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public DbSet<ApplicationUser> ApplicationUsers => Set<ApplicationUser>();

        public DbSet<Ciff> Ciffs => Set<Ciff>();

        public DbSet<Caff> Caffs => Set<Caff>();

        public DbSet<Comment> Comments => Set<Comment>();


        public WebshopDbContext(DbContextOptions<WebshopDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>()
                .HasMany(e => e.Claims)
                .WithOne()
                .HasForeignKey(uc => uc.UserId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.Entity<ApplicationUser>()
                .HasMany(e => e.Logins)
                .WithOne()
                .HasForeignKey(uc => uc.UserId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.Entity<ApplicationUser>()
                .HasMany(e => e.Tokens)
                .WithOne()
                .HasForeignKey(uc => uc.UserId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.Entity<ApplicationUser>()
                .HasMany(e => e.UserRoles)
                .WithOne()
                .HasForeignKey(uc => uc.UserId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.Entity<ApplicationUser>()
                .HasMany(e => e.UploadedCaffs)
                .WithOne(e => e.Uploader);

            builder.Entity<ApplicationUser>()
                .HasMany(e => e.BoughtCaffs)
                .WithOne(e => e.BoughtBy)
                .IsRequired(false);

            builder.Entity<Caff>()
                .HasOne(e => e.Uploader)
                .WithMany(e => e.UploadedCaffs);

            builder.Entity<Comment>()
                .HasOne(e => e.CommentedCaff)
                .WithMany(e => e.Comments);

            builder.Entity<Comment>()
                .HasOne(e => e.Commenter)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
