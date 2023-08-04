using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RealEstate.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
