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


        
            builder.Entity<MenuItem>(
                i => {
                    i.HasKey(i => i.Id);

                    i.HasOne(i => i.View)
                    .WithOne(v => v.MenuItem)
                    .HasForeignKey<MenuItem>(i => i.ViewId);
                    });

            builder.Entity<View>(v =>
                { 
                    v.HasKey(v => v.Id);
                    v.HasMany(v => v.ContentBlocks)
                    .WithOne(c => c.View)
                    .HasForeignKey(c => c.ViewId);
                }
            );

         
        }
    }
}
