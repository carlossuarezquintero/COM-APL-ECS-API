using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Servicio.Queries.Dto
{
    public class ProductoDto
    {
  
        public int ProductoId { get; set; }

        public int Stock { get; set; }

        public int MarcaId { get; set; }

        public string MarcaNombre { get; set; }

        public int CategoriaId { get; set; }

        public string CategoriaNombre { get; set; }

    
        public decimal Precio { get; set; }

        public string Imagen { get; set; }
    }
}
