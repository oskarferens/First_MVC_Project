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
        public DbSet<Language> LanguageList { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>().HasData(new Person { Id = 1, Name = "Oskar F", CityId = 1, PhoneNumber = "031 123 345" });
            modelBuilder.Entity<Person>().HasData(new Person { Id = 2, Name = "Ronnie Coleman", CityId = 2, PhoneNumber = "0976 123 321" });

            modelBuilder.Entity<Country>().HasData(new Country { Id = 1, CountryName = "Sweden", Capital = "Stockholm", });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 2, CountryName = "USA", Capital = "Washington", });

            modelBuilder.Entity<City>().HasData(new City { Id = 1, CountryName = "Sweden", CityName = "Stockholm", });
            modelBuilder.Entity<City>().HasData(new City { Id = 2, CountryName = "USA", CityName = "Los Angeles", });

            modelBuilder.Entity<Language>().HasData(new Language { LanguageId = 1, Name = "Swedish" });
            modelBuilder.Entity<Language>().HasData(new Language { LanguageId = 2, Name = "English" });
            modelBuilder.Entity<Language>().HasData(new Language { LanguageId = 3, Name = "Polish" });
            modelBuilder.Entity<Language>().HasData(new Language { LanguageId = 4, Name = "Tagalog" });
        }

    }
}
