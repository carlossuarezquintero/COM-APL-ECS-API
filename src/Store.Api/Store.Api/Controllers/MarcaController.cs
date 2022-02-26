using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Store.Api.Errors;
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
    public class MarcaController : ControllerBase
    {
        private readonly ILogger<MarcaController> _logger;
        private readonly IMarcaQueryService _imarcaQueryService;

        public MarcaController(IMarcaQueryService iMarcaQueryService, ILogger<MarcaController> logger)
        {
            _imarcaQueryService = iMarcaQueryService;
            _logger = logger;
        }


        /// <summary>
        /// Obtiene todas las marcas
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public async Task<ActionResult<List<Marca>>> ObtenerMarcas()
        {
            var marcas = await _imarcaQueryService.ObtenerMarcaAsync();
            return Ok(marcas);
        }

        /// <summary>
        /// Obtiene una marca por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> ObtenermarcasId(int id)
        {
            var marca = await _imarcaQueryService.ObtenerMarcaIdAsync(id);
            if (marca == null)
            {
                return NotFound(new ErrorResponse(404, "No se encontro el registro "));
            }
            return Ok(marca);
        }

    }
}
