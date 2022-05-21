using Customer.Services.ContactAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Customer.Services.ContactAPI.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }


        //Create and store sample Data for testing purpose
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Contact>().HasData(new Contact
            {
                Id = 1,
                Email = "umer.waqar@live.com",
                PersonalNumber = "202218051234",
                Phone = "+46768351295"                
            });
            modelBuilder.Entity<Contact>().HasData(new Contact
            {
                Id = 2,
                Email = "john.doe@noreply.com",
                PersonalNumber = "201218051234",
                Phone = "+46769120000"
            });
            modelBuilder.Entity<Contact>().HasData(new Contact
            {
                Id = 3,
                Email = "chris.jericho@wwe.com",
                PersonalNumber = "201018051234",
                Phone = "+46760000000"
            });
        }
    }
}
