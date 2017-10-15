using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.EnterpriseServices.CompensatingResourceManager;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using WheelOfFortune.Models.Domain;

namespace WheelOfFortune.Models
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

        [Required]
        [Display(Name = "User Photo")]
        public byte[] UserPhoto { get; set; }

//        [Required]
//        public virtual Balance Balance { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Spin> Spins { get; set; }

        public DbSet<Coupon> Coupons { get; set; }

        public DbSet<Balance> Balances { get; set; }

        public DbSet<Transaction> Transactions { get; set;}

        public DbSet<WheelConfiguration> WheelConfigurations { get; set; }



        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}