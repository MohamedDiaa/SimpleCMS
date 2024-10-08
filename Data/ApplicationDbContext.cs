﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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


        
            builder.Entity<MenuItem>( i => 
                {
                   i.HasKey(i => i.Id);
                    
                }
                );


            builder.Entity<View>(v =>
                { 
                    v.HasKey(v => v.Id);

                    v.HasOne(i => i.MenuItem)
                    .WithOne(v => v.View)
                    .HasForeignKey<View>(v => v.MenuItemId);

                    v.HasMany(v => v.ContentBlocks)
                    .WithOne(c => c.View)
                    .HasForeignKey(c => c.ViewId);
                }
            );

            /*
            builder.Entity<ApplicationUser>()
                .HasData(
                    new ApplicationUser
                    {
                        UserName = "Mohamed Alwakil",
                        Email = "mdalwakil@outlook.com",
                        PasswordHash = "AQAAAAIAAYagAAAAEKcSVPaycPDTR7CoDQSmCZ8rwDHNgOEGXeAgtcYOUyhhvwYhq5B9tjFQj7PH9sh2cQ==",
                        EmailConfirmed = true,
                        TwoFactorEnabled = false
                    }
                );
         */
        }
        public DbSet<SimpleCMS.Model.View> View { get; set; } = default!;
    }
}
