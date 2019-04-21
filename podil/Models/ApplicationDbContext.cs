using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace podil.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Photo> Photos { get; set; }
        public DbSet<CategoryType> CategoryTypes { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}