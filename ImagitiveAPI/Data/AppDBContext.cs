using ImagitiveAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace ImagitiveAPI.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
            
        }
        public DbSet<ImagitiveAPI.Models.UserDBModel> Users => Set<ImagitiveAPI.Models.UserDBModel>();
        public DbSet<ImagitiveAPI.Models.ArtworkDBModel> Artworks => Set<ImagitiveAPI.Models.ArtworkDBModel>();
        public DbSet<ImagitiveAPI.Models.RatingDBModel> Ratings => Set<ImagitiveAPI.Models.RatingDBModel>();
        public DbSet<ImagitiveAPI.Models.TagDBModel> Tags => Set<ImagitiveAPI.Models.TagDBModel>();
        public DbSet<ImagitiveAPI.Models.ReasonDBModel> Reasons => Set<ImagitiveAPI.Models.ReasonDBModel>();
        public DbSet<ImagitiveAPI.Models.ReportDBModel> Reports => Set<ImagitiveAPI.Models.ReportDBModel>();
        public DbSet<ImagitiveAPI.Models.RegionDBModel> Regions => Set<ImagitiveAPI.Models.RegionDBModel>();
        public DbSet<ImagitiveAPI.Models.ArtworkTagDBModel> ArtworkTags => Set<ImagitiveAPI.Models.ArtworkTagDBModel>();
        public DbSet<ImagitiveAPI.Models.UserRoleDBModelcs> UserRoles => Set<ImagitiveAPI.Models.UserRoleDBModelcs>();
        public DbSet<ImagitiveAPI.Models.ArtworkViewDBModel> ArtworkViews => Set<ImagitiveAPI.Models.ArtworkViewDBModel>();
        public DbSet<ImagitiveAPI.Models.RoleDBModel> Roles => Set<ImagitiveAPI.Models.RoleDBModel>();
        public DbSet<ImagitiveAPI.Models.UserActionsDBModel> UserActions => Set<ImagitiveAPI.Models.UserActionsDBModel>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<ArtworkTagDBModel>()
                .HasKey(at => new { at.ArtworkId, at.TagId });

            modelBuilder.Entity<UserRoleDBModelcs>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });

            modelBuilder.Entity<RatingDBModel>()
                .HasKey(ar => new
                {
                    ar.ArtworkId,
                    ar.UserId
                });


        }

    }
}
