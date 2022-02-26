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
    /// <summary>
    /// Controlador de categorias
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ILogger<CategoriaController> _logger;
        private readonly ICategoriaQueryService _icategoriaQueryService;

        public CategoriaController(ICategoriaQueryService icategoriaQueryService, ILogger<CategoriaController> logger)
        {
            _icategoriaQueryService = icategoriaQueryService;
            _logger=logger;
        }

        /// <summary>
        /// Obtiene todas las categorias
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public async Task<ActionResult<List<Categoria>>> ObtenerMarcas()
        {
            var categorias = await _icategoriaQueryService.ObtenerCategoriaAsync();
            return Ok(categorias);
        }

        /// <summary>
        /// Obtiene una categoria por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Categoria>>> ObtenerMarcaId(int id)
        {
            var categoria = await _icategoriaQueryService.ObtenerCategoriaIdAsync(id);
            return Ok(categoria);
        }


    }
}
