using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Dominio.Entidades.OrdenCompra;

namespace Store.Persistencia.Configuracion
{
    public class OrdenItemConfiguration : IEntityTypeConfiguration<OrdenItem>
    {
        public void Configure(EntityTypeBuilder<OrdenItem> builder)
        {
            builder.OwnsOne(i => i.ItemOrdenado, x => { x.WithOwner(); });

            builder.Property(i => i.Precio)
                .HasColumnType("decimal(18,2)");

        }
    }
}
