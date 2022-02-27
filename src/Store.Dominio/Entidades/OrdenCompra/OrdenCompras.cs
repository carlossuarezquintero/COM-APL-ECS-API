using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Dominio.Entidades.OrdenCompra
{
    public class OrdenCompras
    {
        public OrdenCompras()
        {

        }
        public OrdenCompras(string compradorEmail, Direccion direccionEnvio, TipoEnvio tipoEnvio, IReadOnlyList<OrdenItem> orderItems, decimal subtotal)
        {
            CompradorEmail = compradorEmail;
            DireccionEnvio = direccionEnvio;
            TipoEnvio = tipoEnvio;
            OrderItems = orderItems;
            Subtotal = subtotal;
        }

        public string CompradorEmail { get; set; }
        public DateTimeOffset OrdenCompraFecha { get; set; } = DateTimeOffset.Now;
        public Direccion DireccionEnvio { get; set; }
        public TipoEnvio TipoEnvio { get; set; }

        public IReadOnlyList<OrdenItem> OrderItems { get; set; }

        public decimal Subtotal { get; set; }

        public EstadoOrden Status { get; set; } = EstadoOrden.Pendiente;

        public string PagoIntentoId { get; set; }

        public decimal GetTotal()
        {
            return Subtotal + TipoEnvio.Precio;
        }

    }
}
