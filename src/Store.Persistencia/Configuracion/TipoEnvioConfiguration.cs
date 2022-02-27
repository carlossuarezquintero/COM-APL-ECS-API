using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Dominio.Entidades.OrdenCompra;

namespace Store.Persistencia.Configuracion
{
    public class TipoEnvioConfiguration : IEntityTypeConfiguration<TipoEnvio>
    {
        public void Configure(EntityTypeBuilder<TipoEnvio> builder)
        {
            builder.Property(t => t.Precio)
                .HasColumnType("decimal(18,2)");
        }
    }
}
