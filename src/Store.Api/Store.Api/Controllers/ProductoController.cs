using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Store.Dominio.Entidades;
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

        public ProductoController(IProductoQueryService iproductoQueryService, ILogger<ProductoController> logger)
        {
            _iproductoQueryService = iproductoQueryService;
            _logger = logger;
        }

        /// <summary>
        /// Obtiene todos los productos
        /// </summary>
        /// <returns></returns>
        
        [HttpGet]
        public async Task<ActionResult<List<Producto>>> ObtenerProductos()
        {
            var productos = await _iproductoQueryService.ObtenerProductosAsync();
            return Ok(productos);
        }

        /// <summary>
        /// Obtiene un producto por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Producto>>> ObtenerProductosId(int id)
        {
            var producto = await _iproductoQueryService.ObtenerProductoIdAsync(id);
            return Ok(producto);
        }

    }
}
