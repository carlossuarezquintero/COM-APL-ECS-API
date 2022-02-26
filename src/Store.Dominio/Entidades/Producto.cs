using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Dominio.Entidades
{
    public class Producto
    {
        //Código del producto, Nombre del producto, Descripción breve del  producto, Precio, imagen del producto)
        public int ProductoId { get; set; }

        public int Codigo { get; set; }
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public int Stock { get; set; }

        [Column(TypeName="decimal(18,2)")]
        public decimal Precio { get; set; }

        public string Imagen { get; set; }

    }
}
