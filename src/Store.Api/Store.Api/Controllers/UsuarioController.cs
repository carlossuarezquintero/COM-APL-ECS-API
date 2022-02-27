using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Store.Api.Errors;
using Store.Api.Extensions;
using Store.Dominio.Entidades;
using Store.Servicio.EventHandler.Command;
using Store.Servicio.EventHandler.Command.Usuarios;
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
        private readonly IPasswordHasher<Usuario> _passwordHasher;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UsuarioController(ILogger<Usuario> logger,
            SignInManager<Usuario> signInManager,
            IMediator mediator, UserManager<Usuario> userManager,
            IMapper mapper, IPasswordHasher<Usuario> passwordHasher,
             RoleManager<IdentityRole> roleManager)
        {
            _logger = logger;
            _signInManager = signInManager;
            _mediator = mediator;
            _userManager = userManager;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
            _roleManager = roleManager;
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
        public async Task<IActionResult> Crear(UsuarioComandoCrear command)
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
        ///  Actualizar Usuarios
        /// </summary>
        /// <returns></returns>
        /// 
        [Authorize]
        [HttpPatch("actualizar")]
        public async Task<ActionResult<UsuarioDto>> Actualizar(UsuarioComandoActualizar command)
        {

            var usuario = await _userManager.FindByIdAsync(command.id);
            if (usuario == null)
            {
                return NotFound(new ErrorResponse(400, "El usuario no existe"));
            }

            usuario.Nombre = command.Nombre;
            usuario.Apellido = command.Apellido;
            usuario.Imagen = command.Imagen;

            if (!string.IsNullOrEmpty(command.Password))
            {
                usuario.PasswordHash = _passwordHasher.HashPassword(usuario, command.Password);
            }

            var resultado = await _userManager.UpdateAsync(usuario);

            if (!resultado.Succeeded)
            {
                return NotFound(new ErrorResponse(400, "No se pudo actualizar el usuario"));
            }


            return new UsuarioDto
            {
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Email = usuario.Email,
                Username = usuario.UserName,
                Imagen = usuario.Imagen
            };





        }
        /// <summary>
        ///  Decifra el token y obtiene los datos del usuario 
        /// </summary>
        /// <returns></returns>

        [Authorize]
        [HttpGet("usuario/{id}")]
        public async Task<ActionResult<UsuarioDto>> ObtenerUsuariobyid(string id)
        {

            var usuario = await _userManager.FindByIdAsync(id);
            if (usuario == null)
            {
                return NotFound(new ErrorResponse(400, "El usuario no existe"));
            }

            var roles = await _userManager.GetRolesAsync(usuario);
            string auxrol = null; bool admin = false;
            if (!roles.IsNullOrEmpty()) { auxrol = roles[0]; if (auxrol == "ADMIN") { admin = true; } }
            return new UsuarioDto
            {
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Email = usuario.Email,
                Username = usuario.UserName,
                Admin = admin,
                Role = auxrol
            };

        }



        [Authorize]
        [HttpGet]
        public async Task<ActionResult<UsuarioDto>> ObtenerUsuario()
        {

            var usuario = await _userManager.BuscarUsuarioAsync(HttpContext.User);
            var roles = await _userManager.GetRolesAsync(usuario);
            string auxrol = null;bool admin = false;
            if (!roles.IsNullOrEmpty()) { auxrol = roles[0]; if (auxrol == "ADMIN") { admin = true; } }
            return new UsuarioDto
            {
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Email = usuario.Email,
                Username = usuario.UserName,
                Admin = admin,
                Role = auxrol
            };

        }

        /// <summary>
        ///  Asignar rol a un usuario
        /// </summary>
        /// <param name="id"></param>
        /// <param name="roleparam"></param>
        /// <returns></returns>
        [Authorize(Roles = "ADMIN")]
        [HttpPut("role")]
        public async Task<ActionResult<UsuarioDto>> Actualizarol( RoleDto roleParam)
        {
            var role = await _roleManager.FindByNameAsync(roleParam.Nombre);
            if (role == null)
            {
                return NotFound(new ErrorResponse(404, "El role no existe"));
            }

            var usuario = await _userManager.FindByIdAsync(roleParam.Id);
            if (usuario == null)
            {
                return NotFound(new ErrorResponse(404, "El usuario no existe"));
            }

            var usuarioDto = _mapper.Map<Usuario, UsuarioDto>(usuario);


            if (roleParam.Status)
            {

                var resultado = await _userManager.AddToRoleAsync(usuario, roleParam.Nombre);
                if (resultado.Succeeded)
                {
                    usuarioDto.Admin = true;
                    usuarioDto.Role = roleParam.Nombre;
                }

                if (resultado.Errors.Any())
                {
                    if (resultado.Errors.Where(x => x.Code == "UserAlreadyInRole").Any())
                    {
                        usuarioDto.Admin = true;
                    }
                }
            }
            else
            {

                var resultado = await _userManager.RemoveFromRoleAsync(usuario, roleParam.Nombre);
                if (resultado.Succeeded)
                {
                    usuarioDto.Admin = false;
                }
            }


            return usuarioDto;
        }


        /// <summary>
        ///  Valida si un email ya existe en la base de datos
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet("emailvalido")]

        public async Task<ActionResult<bool>> ValidarEmail([FromQuery] String email)
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

            return _mapper.Map<Direccion, DireccionDto>(usuario.Direccion);
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
            usuario.Direccion = _mapper.Map<DireccionDto, Direccion>(direccion);
            var resultado = await _userManager.UpdateAsync(usuario);

            if (resultado.Succeeded) return Ok(_mapper.Map<Direccion, DireccionDto>(usuario.Direccion));

            return BadRequest("No se puedo actualizar la dirección del ususario");

        }

    }


}
