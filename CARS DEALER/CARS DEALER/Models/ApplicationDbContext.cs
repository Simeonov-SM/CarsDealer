using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CARS_DEALER.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
   

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

      

      


        public System.Data.Entity.DbSet<CARS_DEALER.Models.Coupe> Coupes { get; set; }

        public System.Data.Entity.DbSet<CARS_DEALER.Models.Doors> Doors { get; set; }

        public System.Data.Entity.DbSet<CARS_DEALER.Models.Engine> Engines { get; set; }

        public System.Data.Entity.DbSet<CARS_DEALER.Models.GearBox> GearBoxes { get; set; }

        public System.Data.Entity.DbSet<CARS_DEALER.Models.Post> Posts { get; set; }

        public System.Data.Entity.DbSet<CARS_DEALER.Models.Area> Areas { get; set; }

        public System.Data.Entity.DbSet<CARS_DEALER.Models.Brand> Brands { get; set; }

        public System.Data.Entity.DbSet<CARS_DEALER.Models.BrandModel> BrandModels { get; set; }
    }
}