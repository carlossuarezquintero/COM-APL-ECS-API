using Microsoft.EntityFrameworkCore;
using Store.Dominio.Entidades;
using Store.Dominio.Entidades.OrdenCompra;
using Store.Persistencia.Configuracion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Persistencia
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Producto> Productos { get; set; }

        public DbSet<Marca> Marcas { get; set; }

        public DbSet<Categoria> Categorias { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            ModelConfig(builder);
        }
        private void ModelConfig(ModelBuilder modelBuilder)
        {
            new ProductoConfiguracion(modelBuilder.Entity<Producto>());
            

        }
    }

}
