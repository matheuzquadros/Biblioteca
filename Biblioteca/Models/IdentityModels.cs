using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Biblioteca.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Exemplar> Exemplares { get; set; }
        public DbSet<Book> Books { get; set; }

        public DbSet<Cliente> Users { get; set; }

        public DbSet<Categoria> Category { get; set; }

        //public System.Data.Entity.DbSet<Biblioteca.Models.Cliente> Clientes { get; set; }
    }
}