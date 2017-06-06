using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ParkAr.Models
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
        public DbSet<EstadoReserva> EstadoBoxes { get; set; }

        public DbSet<Box> Boxes { get; set; }

        public DbSet<Estacionamiento> Estacionamientos { get; set; }

        public DbSet<ValorCategoria> ValoresCategorias{ get; set; }

        public DbSet<CategoriaBox> CategoriasBox { get; set; }

        public DbSet<EstadoBox> EstadosBox { get; set; }

        public DbSet<Reserva> Reservas { get; set; }

        public DbSet<PagoReserva> PagoReservas { get; set; }

        public DbSet<Vehiculo> Vehiculos { get; set; }

        public DbSet<Cliente> Cientes { get; set; }

        public DbSet<TipoVehiculo> TipoVehiculos { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}