using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Servicio.EventHandler.Command.Productos
{
    public class ProductoComandoActualizar : IRequest<int>
    {
        public int ProductoId { get; set; }
        public int Stock { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int MarcaId { get; set; }

        public int Codigo { get; set; }

        public int CategoriaId { get; set; }

        public decimal Precio { get; set; }

        public string Imagen { get; set; }
    }
}
