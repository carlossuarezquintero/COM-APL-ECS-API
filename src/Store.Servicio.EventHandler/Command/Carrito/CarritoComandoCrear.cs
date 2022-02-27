using MediatR;
using Store.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Servicio.EventHandler.Command.Carrito
{
    public class CarritoComandoCrear : IRequest<CarritoCompra>
    {

        public string CarritoId { get; set; }

        public List<CarritoItem> Items { get; set; } = new List<CarritoItem>();
    }
}
