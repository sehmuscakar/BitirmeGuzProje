
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete.Context
{
    public class ProjeContext : IdentityDbContext<AppUser, AppRole,int>
    {


        public DbSet<ContactCompany> ContactCompanies { get; set; }
        public DbSet<Hero> Heroes { get; set; }
        public DbSet<BusinessModule> BusinessModules { get; set; }

        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuCategory> MenuCategories { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<PostContact> PostContacts { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<Team> Teams { get; set; }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)// overide on yaz gelir
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-PBFD0LU;  database=BitirmeGuz; integrated security=true; TrustServerCertificate=true");
        }

        protected override void OnModelCreating(ModelBuilder builder) // fluent api ile ilişkilerimiz yapılandırdık.
        {
            builder.Entity<ContactCompany>(entity =>
            {

                entity.HasOne(x => x.AppUser).WithMany(x => x.contactCompanies).HasForeignKey(x => x.AppUserId);
            });

            builder.Entity<Hero>(entity =>
            {

                entity.HasOne(x => x.AppUser).WithMany(x => x.Heroes).HasForeignKey(x => x.AppUserId);
            });

            builder.Entity<BusinessModule>(entity =>
            {

                entity.HasOne(x => x.AppUser).WithMany(x => x.BusinessModules).HasForeignKey(x => x.AppUserId);
            });
            builder.Entity<Menu>(entity =>
            {

                entity.HasOne(x => x.AppUser).WithMany(x => x.Menus).HasForeignKey(x => x.AppUserId);
                entity.HasOne(x => x.MenuCategory).WithMany(x => x.Menus).HasForeignKey(x => x.MenuCategoryId);
            });
            builder.Entity<MenuCategory>(entity =>
            {

                entity.HasOne(x => x.AppUser).WithMany(x => x.MenuCategories).HasForeignKey(x => x.AppUserId);
            });
            builder.Entity<Service>(entity =>
            {
                entity.HasOne(x => x.AppUser).WithMany(x => x.Services).HasForeignKey(x => x.AppUserId);
            });
            builder.Entity<Gallery>(entity =>
            {
                entity.HasOne(x => x.AppUser).WithMany(x => x.Galleries).HasForeignKey(x => x.AppUserId);
            });
            builder.Entity<Team>(entity =>
            {
                entity.HasOne(x => x.AppUser).WithMany(x => x.Teams).HasForeignKey(x => x.AppUserId);
            });
            base.OnModelCreating(builder);
        }

    }
}
