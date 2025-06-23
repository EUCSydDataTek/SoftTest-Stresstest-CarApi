using CarApi.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarApi.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }

        public DbSet<CarModel> CarModels { get; set; }

        public DbSet<Person> Persons { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseAsyncSeeding(async (context,__,_) => await ((AppDbContext)context).CreateDemoDataAsync(20));

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
