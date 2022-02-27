using MediatR;
using Microsoft.AspNetCore.Mvc;
using Store.Dominio.Entidades;
using Store.Servicio.EventHandler.Command.Carrito;
using Store.Servicio.Queries.Interfaces;
using System.Threading.Tasks;

namespace Store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarritoCompraController : ControllerBase
    {
        private readonly ICarritoCompraQueryService _carritoCompraQueryServices;
        private readonly IMediator _mediator;

        public CarritoCompraController(ICarritoCompraQueryService carritoCompraQueryServices, IMediator mediator)
        {
            _carritoCompraQueryServices = carritoCompraQueryServices;
            _mediator = mediator;

        }

        /// <summary>
        /// Este metodo obtiene un carrito de compra y si es primera vez que toma el carrito crea uno
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<CarritoCompra>> ObtenerCarritoPorId(string id)
        {
            var carrito = await _carritoCompraQueryServices.ObtenerCarritoCompraAsync(id);

            return Ok(carrito ?? new CarritoCompra(id));
        }

        /// <summary>
        /// Este metodo permite ir agregando productos al carrito y actualizando el carrito
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]

        public async Task<ActionResult<CarritoCompra>> ActualizarCarritoCompra(CarritoComandoCrear command)
        {
            var carritoactualizado = await _mediator.Send(command);
            return Ok(carritoactualizado);
        }

        [HttpDelete]
        public async Task EliminarCarritoCompra(CarritoComandoEliminar command)
        {
             await _mediator.Send(command);

        }



    }
}
