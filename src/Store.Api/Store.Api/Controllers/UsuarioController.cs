using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Store.Api.Errors;
using Store.Api.Extensions;
using Store.Dominio.Entidades;
using Store.Servicio.EventHandler.Command;
using Store.Servicio.Queries.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly ILogger<Usuario> _logger;
        private readonly SignInManager<Usuario> _signInManager;
        private readonly UserManager<Usuario> _userManager;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public UsuarioController(ILogger<Usuario> logger,
            SignInManager<Usuario> signInManager,
            IMediator mediator, UserManager<Usuario> userManager,
            IMapper mapper)
        {
            _logger = logger;
            _signInManager = signInManager;
            _mediator = mediator;
            _userManager = userManager;
            _mapper = mapper;
        }

        /// <summary>
        /// Inicio de sesión
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        

        [HttpPost("autenticacion")]
        public async Task<IActionResult> Authentication(UsuarioComandoLogear command)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(command);

                if (!result.Succeeded)
                {
                    return Unauthorized(new ErrorResponse(401, "Los datos ingresados no son validos "));
                }

                return Ok(result);
            }

            return BadRequest();
        }

        /// <summary>
        /// Crear Usuario
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        
        [HttpPost("creacion")]
        public async Task<IActionResult> Create(UsuarioComandoCrear command)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(command);

                if (!result.Succeeded)
                {
                    return Unauthorized(new ErrorResponse(400, "Los datos ingresados no son validos "));
                }

                return Ok(result);
            }

            return BadRequest();
        }


        /// <summary>
        ///  Decifra el token y obtiene los datos del usuario 
        /// </summary>
        /// <returns></returns>
        
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<UsuarioDto>> ObtenerUsuario()
        {

            var usuario = await _userManager.BuscarUsuarioAsync(HttpContext.User);

            return new UsuarioDto
            {
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Email = usuario.Email,
                Username = usuario.UserName
            };

        }

        /// <summary>
        ///  Valida si un email ya existe en la base de datos
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>

        [HttpGet("emailvalido")]

        public async Task<ActionResult<bool>> ValidarEmail([FromQuery]String email)
        {
            var usuario = await _userManager.FindByEmailAsync(email);

            if (usuario == null) return false;

            return true;

        }

        /// <summary>
        /// Decifra el token y obtiene la direccion
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet("direccion")]
        public async Task<ActionResult<DireccionDto>> ObtenerDireccion()
        {

            var usuario = await _userManager.BuscarUsuarioCondireccionAsync(HttpContext.User);

            return _mapper.Map<Direccion,DireccionDto>(usuario.Direccion);
        }

        /// <summary>
        /// Actualizar direccion
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [Authorize]
        [HttpPut("direccion")]
        public async Task<ActionResult<DireccionDto>> Actualizardireccion(DireccionDto direccion)
        {
            var usuario = await _userManager.BuscarUsuarioCondireccionAsync(HttpContext.User);
            usuario.Direccion= _mapper.Map<DireccionDto, Direccion>(direccion);
            var resultado = await  _userManager.UpdateAsync(usuario);

            if (resultado.Succeeded) return Ok(_mapper.Map<Direccion, DireccionDto>(usuario.Direccion));

            return BadRequest("No se puedo actualizar la dirección del ususario");

        }

    }


}
