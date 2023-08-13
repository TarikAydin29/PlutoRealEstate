using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RealEstate.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace RealEstate.DAL.Concrete
{
    public class Context : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<AppUser>().Property(user => user.Id).ValueGeneratedOnAdd();



            var adminRoleId = Guid.NewGuid();
            builder.Entity<AppRole>().HasData(new AppRole
            {
                Id = adminRoleId,
                Name = "Admin",
                NormalizedName = "ADMIN"
            });

            var agentRoleId = Guid.NewGuid();
            builder.Entity<AppRole>().HasData(new AppRole
            {
                Id = agentRoleId,
                Name = "Agent",
                NormalizedName = "AGENT"
            });
            var customerRoleId = Guid.NewGuid();
            builder.Entity<AppRole>().HasData(new AppRole
            {
                Id = customerRoleId,
                Name = "Customer",
                NormalizedName = "CUSTOMER"
            });

            var hasher = new PasswordHasher<AppUser>();
            var adminUser = new AppUser
            {
                Id = Guid.NewGuid(),
                UserName = "admin1",
                NormalizedUserName = "ADMIN1",
                Email = "admin@example.com",
                NormalizedEmail = "ADMIN@EXAMPLE.COM",
                EmailConfirmed = true,
                Name = "Bill",
                Surname = "Gates",
                PhoneNumber = "123456789",
                ImageUrl = "bb.jpg",
                ConfirmCode = null,
                PasswordHash = hasher.HashPassword(null, "1234aA#")
            };

            builder.Entity<AppUser>().HasData(adminUser);


            builder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = adminRoleId,
                UserId = adminUser.Id
            });
        }


        public DbSet<Property> Properties { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<PropertyStatus> PropertyStatuses { get; set; }
        public DbSet<sehir> sehir { get; set; }
        public DbSet<mahalle> mahalle { get; set; }
        public DbSet<sokak_cadde> sokak_cadde { get; set; }
        public DbSet<ilce> ilce { get; set; }
        public DbSet<PropertyPhoto> PropertyPhotos { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
    }
}
