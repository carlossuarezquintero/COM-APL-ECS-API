using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Store.Api.Errors;
using Store.Dominio.Entidades;
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

        public ProductoController(IProductoQueryService iproductoQueryService, ILogger<ProductoController> logger, IMapper mapper)
        {
            _iproductoQueryService = iproductoQueryService;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Obtiene todos los productos
        /// </summary>
        /// <returns></returns>
        
        [HttpGet]
        public async Task<ActionResult<List<ProductoDto>>> ObtenerProductos()
        {
            var productos = await _iproductoQueryService.ObtenerProductosAsync();
            return Ok(_mapper.Map<IReadOnlyList<Producto>, IReadOnlyList<ProductoDto>>(productos));
             
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

    }
}
