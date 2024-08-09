using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleshoppingProyecto.Entidades
{
    public class ApplicationDbContext : DbContext
    {
        
        /// <summary>
        /// Activar solo este método para que sea implementado desde un Servicio
        /// </summary>
        /// <param name="options"></param>
        /// 
      
       public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        
        }
        
       
        /// <summary>
        /// Activar solo este método para las migraciones de la BD
        /// </summary>
        /// <param name="optionsBuilder"></param>
     /*  
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=TeleshoppingProyecto;Integrated Security=True;TrustServerCertificate=True;");
       
        }
     
     */
       
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Producto> Productos { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>()
                .Ignore(p => p.IsEditing);
                
        }

        public DbSet<Compra> Compras { get; set; }
        public DbSet<Orden> Ordenes { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<Queja> Quejas { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<TipoTransporte> TipoTransportes { get; set; }
        public DbSet<EmpresaTransporte> EmpresaTransportes { get; set; }
        public DbSet<Entrega> Entregas { get; set; }


    }
}
