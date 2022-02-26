using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Persistencia.Configuracion
{
    public class CategoriaConfiguracion
    {
        public CategoriaConfiguracion(EntityTypeBuilder<Categoria> entityBuilder)
        {


            entityBuilder.Property(x => x.Nombre).IsRequired().HasMaxLength(250);
            entityBuilder.Property(x => x.Descripcion).IsRequired().HasMaxLength(500);
            entityBuilder.Property(x => x.FechaCreacion).IsRequired();


        }
    }
}
