using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Dominio.Entidades
{
    public class CarritoItem
    {
        public int CarritoItemId { get; set; }

        public string Producto { get; set; }

        public decimal Precio { get; set; }

        public int Stock { get; set; }

        public string Imagen { get; set; }

       public string Marca { get; set; }

       public string Categoria { get; set; }
    }
}
