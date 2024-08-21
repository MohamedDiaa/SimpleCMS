using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SimpleCMS.Model;

namespace SimpleCMS.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<SimpleCMS.Model.Menu> Menu { get; set; } = default!;
        public DbSet<MenuItem> MenuItem { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<SimpleCMS.Model.Menu>()
               .HasKey(x => x.Id);


            builder.Entity<SimpleCMS.Model.MenuItem>()
               .HasKey(x => x.Id);

            builder.Entity<SimpleCMS.Model.Menu>()
                .HasMany(m => m.Items)
                .WithOne(i => i.Menu)
                .HasForeignKey(i => i.MenuId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.Entity<Menu>()
                .HasOne(m => m.Owner)
                .WithMany(u => u.Menus)
                .HasForeignKey(m => m.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.Entity<ApplicationUser>()
                .HasData(
                new ApplicationUser { 
            
                    UserName = "Mohamed Alwakil",
                    Email = "mdalwakil@outlook.com",
                    PasswordHash = "xxxxxxx"
            }
                );

            /*
            builder.Entity<Menu>()
                .HasData(
                new Menu { 
                    Title = "World Trips",
                    Description = "Blog about Traveling the world!",
                    OwnerId
                }
                );
        */
            }
    }
}
