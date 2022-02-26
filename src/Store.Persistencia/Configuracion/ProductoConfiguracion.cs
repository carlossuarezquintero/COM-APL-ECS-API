using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Persistencia.Configuracion
{
    public class ProductoConfiguracion
    {

        public ProductoConfiguracion(EntityTypeBuilder<Producto> entityBuilder)
        {
            

            entityBuilder.Property(x => x.Nombre).IsRequired().HasMaxLength(250);
            entityBuilder.Property(x => x.Descripcion).IsRequired().HasMaxLength(500);
            entityBuilder.Property(x => x.Imagen).HasMaxLength(1000);
            entityBuilder.Property(x => x.FechaCreacion).IsRequired();
            entityBuilder.HasOne(m => m.Marca).WithMany().HasForeignKey(p => p.MarcaId);
            entityBuilder.HasOne(c => c.Categoria).WithMany().HasForeignKey(p => p.CategoriaId);

        }
    }
}
