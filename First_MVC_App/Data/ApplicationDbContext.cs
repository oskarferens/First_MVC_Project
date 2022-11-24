using First_MVC_App.Models;
using Microsoft.EntityFrameworkCore;

namespace First_MVC_App.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options)
        {

        }

        public DbSet<Person> PeopleList { get; set; }
        public DbSet<City> CityList { get; set; }
        public DbSet<Country> CountryList { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>().HasData(new Person { Id = 1, Name = "Oskar F", City = "Göteborg", PhoneNumber = "031 123 345" });
            modelBuilder.Entity<Person>().HasData(new Person { Id = 2, Name = "Ronnie Coleman", City = "Los Angeles", PhoneNumber = "0976 123 321" });

            modelBuilder.Entity<Country>().HasData(new Country { Id = 1, CountryName = "Sweden", Capital = "Stockholm", });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 2, CountryName = "USA", Capital = "Washington", });

            modelBuilder.Entity<City>().HasData(new City { Id = 1, CountryName = "Sweden", CityName = "Stockholm", });
            modelBuilder.Entity<City>().HasData(new City { Id = 2, CountryName = "USA", CityName = "Los Angeles", });
        }

    }
}
