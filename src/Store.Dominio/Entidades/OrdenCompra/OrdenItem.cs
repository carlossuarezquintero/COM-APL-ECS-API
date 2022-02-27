using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Dominio.Entidades.OrdenCompra
{

    public class OrdenItem
    {
        public OrdenItem()
        {

        }
        public OrdenItem(ProductoItemOrdenado itemOrdenado, decimal precio, int cantidad)
        {
            ItemOrdenado = itemOrdenado;
            Precio = precio;
            Cantidad = cantidad;
        }

        public int OrdenItemId { get; set; }
        public ProductoItemOrdenado ItemOrdenado { get; set; }

        public decimal Precio { get; set; }

        public int Cantidad { get; set; }
    }
}
