using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarWorkshopInfrastructure.Persistence
{
    public class CarWorkshopDbContext : IdentityDbContext
    {
        public CarWorkshopDbContext(DbContextOptions<CarWorkshopDbContext> options) : base(options)
        {

        }

        public DbSet<CarWorkshopDomain.Entities.CarWorkshop> CarWorkshops { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CarWorkshopDomain.Entities.CarWorkshop>()
                .OwnsOne(c => c.ContactDetails);
        }
    }
}
