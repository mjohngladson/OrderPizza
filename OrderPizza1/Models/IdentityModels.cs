using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace OrderPizza1.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Customer>().Property(n => n.Name).IsRequired();
            modelBuilder.Entity<Customer>().Property(a => a.Address).IsRequired();
            modelBuilder.Entity<Customer>().Property(z => z.Zip).IsRequired();
            modelBuilder.Entity<Customer>().Property(p => p.Phone).IsRequired();
            modelBuilder.Entity<Pizza>().Property(s => s.Size).IsRequired();
            modelBuilder.Entity<Pizza>().Property(x => x.Crust).IsRequired();
        }

        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<PizzaAttribute> PizzaAttributes { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}