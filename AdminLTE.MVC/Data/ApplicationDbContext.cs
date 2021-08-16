using System;
using System.Collections.Generic;
using System.Text;
using AdminLTE.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AdminLTE.MVC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<LocalCommunity> LocalCommunities { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            IdentityRole role = new IdentityRole
            {
                Name = ENV.AdminRole,
                NormalizedName = ENV.AdminRole.ToUpper()
            };
            IdentityUser user = new IdentityUser
            {
                Email = ENV.AdminEmail,
                UserName = ENV.AdminEmail,
                NormalizedEmail = ENV.AdminEmail.ToUpper(),
                NormalizedUserName = ENV.AdminEmail.ToUpper(),
                PasswordHash = "AQAAAAEAACcQAAAAEGzUEbebHpUZpIWko1xKd65/QOl5QcL+W9pJDRvN1TWnRm15EZBsXYwdrJcj46rFjQ==",
            };

            builder.Entity<IdentityRole>().HasData(role);

            builder.Entity<IdentityUser>().HasData(user);

            var userRole = new IdentityUserRole<string>() { RoleId = role.Id, UserId = user.Id };
            builder.Entity<IdentityUserRole<string>>().HasData(userRole);
        }
    }
}
