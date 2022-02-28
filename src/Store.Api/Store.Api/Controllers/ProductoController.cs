using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Servicio.Comun.Coleccion;
using Store.Api.Errors;
using Store.Dominio.Entidades;
using Store.Servicio.EventHandler.Command.Productos;
using Store.Servicio.Queries.Dto;
using Store.Servicio.Queries.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly ILogger<ProductoController> _logger;
        private readonly IProductoQueryService _iproductoQueryService;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ProductoController(IProductoQueryService iproductoQueryService, ILogger<ProductoController> logger, IMapper mapper, IMediator mediator)
        {
            _iproductoQueryService = iproductoQueryService;
            _logger = logger;
            _mapper = mapper;
            _mediator= mediator;
    }

        /// <summary>
        /// Obtiene todos los productos
        /// </summary>
        /// <param name="pagina"></param>
        /// <param name="registros"></param>
        /// <param name="ids"></param>
        /// <returns></returns>
        
        [HttpGet]
        public async Task<ActionResult<DatosColeccion<ProductoDto>>> ObtenerProductos(int pagina = 1, int registros = 10, string? ids = null)
        {
            IEnumerable<int> productoslist = null;

            if (!string.IsNullOrEmpty(ids))
            {
                productoslist = ids.Split(',').Select(x => Convert.ToInt32(x));
            }

            var productos = await _iproductoQueryService.ObtenerProductosAsync(pagina, registros, productoslist);
            return Ok(productos);
             
        }

        /// <summary>
        /// Obtiene un producto por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductoDto>> ObtenerProductosId(int id)
        {
            var producto = await _iproductoQueryService.ObtenerProductoIdAsync(id);

            if (producto == null)
            {
                return NotFound(new ErrorResponse(404,"No se encontro el producto "));
            }

            return _mapper.Map<Producto, ProductoDto>(producto);

        }

        /// <summary>
        /// Crear un producto
        /// </summary>
        [Authorize(Roles = "ADMIN")]
        [HttpPost]
        public async Task<IActionResult> crear(ProductoComandoCrear command)
        {
            var id = await _mediator.Send(command);

            if (id == 0)
            {
                return NotFound(new ErrorResponse(404, "No se pudo crear el producto "));
            }

            return Ok(id);
        }

        /// <summary>
        /// Actualizar producto
        /// </summary>
        [Authorize(Roles = "ADMIN")]
        [HttpPatch]
        public async Task<IActionResult> Actualizar(ProductoComandoActualizar command)
        {

            var respuesta = await _mediator.Send(command);
            if (respuesta==0) { return BadRequest("No se puedo crear el producto"); }
            return Ok();

        }


    }
}
