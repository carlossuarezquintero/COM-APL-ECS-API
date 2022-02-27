using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Dominio.Entidades.OrdenCompra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Persistencia.Configuracion
{
    public class OrdenCompraConfiguracion
    {
        public void Configure(EntityTypeBuilder<OrdenCompras> builder)
        {
            builder.OwnsOne(o => o.DireccionEnvio, x =>
            {
                x.WithOwner();
            });


            builder.Property(s => s.Status)
                .HasConversion(
                    o => o.ToString(),
                    o => (EstadoOrden)Enum.Parse(typeof(EstadoOrden), o)
                );

            builder.HasMany(o => o.OrderItems).WithOne().OnDelete(DeleteBehavior.Cascade);

            builder.Property(o => o.Subtotal)
                .HasColumnType("decimal(18,2)");

        }
    }
}
