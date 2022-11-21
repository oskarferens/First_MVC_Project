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

        public DbSet<Person> People { get; set; }
    }
}
