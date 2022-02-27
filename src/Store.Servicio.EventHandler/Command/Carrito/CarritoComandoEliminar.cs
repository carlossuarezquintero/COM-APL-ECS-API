using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Servicio.EventHandler.Command.Carrito
{
    public class CarritoComandoEliminar : IRequest<bool>
    {
        public string CarritoCompraId { get; set; }
    }
}
