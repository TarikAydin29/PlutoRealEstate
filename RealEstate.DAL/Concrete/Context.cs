using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RealEstate.Entities.Entities;

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
        public DbSet<PropertyPhoto> PropertyPhotos { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
    }
}
