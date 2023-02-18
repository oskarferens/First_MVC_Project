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
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Person> People { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Language> Languages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Person>().HasData(
                new Person { PersonId = 1, Name = "Mark Twain", PhoneNumber = "234562356", CityId = 1 },
                new Person { PersonId = 2, Name = "Daniel Tomsson", PhoneNumber = "235623562345", CityId = 2 },
                new Person { PersonId = 3, Name = "Niklas Björk", PhoneNumber = "0733456023", CityId = 3 },
                new Person { PersonId = 4, Name = "Andrea Lind", PhoneNumber = "3245624566", CityId = 4 },
                new Person { PersonId = 5, Name = "Kelly Rowland", PhoneNumber = "78567856785", CityId = 5 }
                );

            modelBuilder.Entity<City>().HasData(
                new City { CityName = "Göteborg", CityId = 1, CountryId = 1 },
                new City { CityName = "Stockholm", CityId = 2, CountryId = 1 },
                new City { CityName = "Malmö", CityId = 3, CountryId = 1 },
                new City { CityName = "Helsinki", CityId = 4, CountryId = 2 },
                new City { CityName = "Copenhagen", CityId = 5, CountryId = 3 }
                );

            modelBuilder.Entity<Country>().HasData(
                new Country { CountryId = 1, CountryName = "Sweden" },
                new Country { CountryId = 2, CountryName = "Finland" },
                new Country { CountryId = 3, CountryName = "Denmark" },
                new Country { CountryId = 4, CountryName = "Norway" },
                new Country { CountryId = 5, CountryName = "Iceland" }
                );

            modelBuilder.Entity<Language>().HasData(
                new Language { LanguageName = "Swedish", LanguageId = 1 },
                new Language { LanguageName = "English", LanguageId = 2 },
                new Language { LanguageName = "Norwegian", LanguageId = 3 },
                new Language { LanguageName = "Danish", LanguageId = 4 },
                new Language { LanguageName = "Finnish", LanguageId = 5 }
                );


            modelBuilder.Entity<Person>().HasKey(p => p.PersonId);
            modelBuilder.Entity<City>().HasKey(c => c.CityId);
            modelBuilder.Entity<Country>().HasKey(c => c.CountryId);
            modelBuilder.Entity<Language>().HasKey(l => l.LanguageId);

            modelBuilder.Entity<Person>().HasOne(p => p.City).WithMany(c => c.People).HasForeignKey(x => x.CityId);
            modelBuilder.Entity<City>().HasOne(c => c.Country).WithMany(c => c.Cities).HasForeignKey(x => x.CountryId);

            modelBuilder.Entity<Person>()
                .HasMany(l => l.Languages)
                .WithMany(p => p.People)
                .UsingEntity(j => j.HasData(
                    new { PeoplePersonId = 1, LanguagesLanguageId = 1 },
                    new { PeoplePersonId = 1, LanguagesLanguageId = 2 },
                    new { PeoplePersonId = 2, LanguagesLanguageId = 1 },
                    new { PeoplePersonId = 2, LanguagesLanguageId = 3 },
                    new { PeoplePersonId = 3, LanguagesLanguageId = 1 },
                    new { PeoplePersonId = 4, LanguagesLanguageId = 4 },
                    new { PeoplePersonId = 4, LanguagesLanguageId = 2 },
                    new { PeoplePersonId = 5, LanguagesLanguageId = 1 },
                    new { PeoplePersonId = 5, LanguagesLanguageId = 5 }
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
                new ApplicationUser { Id = userId, Email = "admin@admin.com", NormalizedEmail = "ADMIN@ADMIN.COM", UserName = "admin@admin.com", NormalizedUserName = "ADMIN@ADMIN.COM", FirstName = "Admin", LastName = "Adminsson", BirthDate = "2000-01-01", PasswordHash = hasher.HashPassword(null, "password") }
                );

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { RoleId = adminRoleId, UserId = userId }
                );
        }
    }
}