using Customer.Services.ContactAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Customer.Services.ContactAPI.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }

        public DbSet<Contact> Contacts { get; set; }
    }
}
