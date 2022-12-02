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

            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 1, CountryName = "Sweden" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 2, CountryName = "USA" });

            modelBuilder.Entity<City>().HasData(new City { CityId = 1, CityName = "Stockholm", CountryId = 1 });
            modelBuilder.Entity<City>().HasData(new City { CityId = 2, CityName = "Los Angeles", CountryId = 2 });

            modelBuilder.Entity<Language>().HasData(new Language { LanguageId = 1, Name = "Swedish" });
            modelBuilder.Entity<Language>().HasData(new Language { LanguageId = 2, Name = "English" });
            modelBuilder.Entity<Language>().HasData(new Language { LanguageId = 3, Name = "Polish" });
            modelBuilder.Entity<Language>().HasData(new Language { LanguageId = 4, Name = "Tagalog" });

            modelBuilder.Entity<Person>()
               .HasMany(x => x.LanguageList)
               .WithMany(x => x.PeopleList)
               .UsingEntity(j => j.HasData(
               new { PeopleListId = 1, LanguageListLanguageId = 1 },
               new { PeopleListId = 2, LanguageListLanguageId = 2 },
               new { PeopleListId = 2, LanguageListLanguageId = 3 }

               ));
        }
    }
}
