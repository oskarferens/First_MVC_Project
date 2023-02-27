using First_MVC_App.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace First_MVC_App.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
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

            modelBuilder.Entity<Person>().HasData(new Person { Id = "1", Name = "Oskar F", CityId = 1, PhoneNumber = "031 123 345" });
            modelBuilder.Entity<Person>().HasData(new Person { Id = "2", Name = "Ronnie C", CityId = 2, PhoneNumber = "0976 123 321" });
            modelBuilder.Entity<Person>().HasData(new Person { Id = "3", Name = "Niklas A", CityId = 3, PhoneNumber = "846 346 836" });

            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 1, CountryName = "Sweden" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 2, CountryName = "USA" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 3, CountryName = "Germany" });

            modelBuilder.Entity<City>().HasData(new City { CityId = 1, CityName = "Stockholm", CountryId = 1 });
            modelBuilder.Entity<City>().HasData(new City { CityId = 2, CityName = "Los Angeles", CountryId = 2 });
            modelBuilder.Entity<City>().HasData(new City { CityId = 3, CityName = "Berlin", CountryId = 3 });

            modelBuilder.Entity<Language>().HasData(new Language { LanguageId = 1, Name = "Swedish" });
            modelBuilder.Entity<Language>().HasData(new Language { LanguageId = 2, Name = "English" });
            modelBuilder.Entity<Language>().HasData(new Language { LanguageId = 3, Name = "Polish" });
            modelBuilder.Entity<Language>().HasData(new Language { LanguageId = 4, Name = "Tagalog" });

            modelBuilder.Entity<Person>()
               .HasMany(x => x.LanguageList)
               .WithMany(x => x.PeopleList)
               .UsingEntity(j => j.HasData(
               new { PeopleListId = 1, LanguageListLanguageId = 1 },
               new { PeopleListId = 1, LanguageListLanguageId = 4 },
               new { PeopleListId = 1, LanguageListLanguageId = 3 },
               new { PeopleListId = 2, LanguageListLanguageId = 2 },
               new { PeopleListId = 2, LanguageListLanguageId = 3 },
               new { PeopleListId = 3, LanguageListLanguageId = 1 },
               new { PeopleListId = 3, LanguageListLanguageId = 2 }
               ));

            string adminRoleId = Guid.NewGuid().ToString();
            string userRoleId = Guid.NewGuid().ToString();
            string userId = Guid.NewGuid().ToString();

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = adminRoleId, Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = userRoleId, Name = "User", NormalizedName = "USER" }
                );

            PasswordHasher<ApplicationUser> hasher = new PasswordHasher<ApplicationUser>();

            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser { Id = userId, Email = "admin@admin.com", NormalizedEmail = "ADMIN@ADMIN.COM", UserName = "admin@admin.com", NormalizedUserName = "ADMIN@ADMIN.COM", FirstName = "Mark", LastName = "SockerBerg", BirthDate = "1995-01-01", PasswordHash = hasher.HashPassword(null, "password") }
                );

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { RoleId = adminRoleId, UserId = userId }
                );
        }

    }
}
