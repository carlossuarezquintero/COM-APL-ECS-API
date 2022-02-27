using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Store.Dominio.Entidades;
using Store.Persistencia;
using Store.Servicio.EventHandler.Command;
using Store.Servicio.EventHandler.Responses;
using Store.Servicio.Queries.Dto;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Store.Servicio.EventHandler.Handler
{
    public class UsuarioEventHandler : IRequestHandler<UsuarioComandoLogear, IdentityAccess>, IRequestHandler<UsuarioComandoCrear, IdentityResult>
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;
        private readonly SeguridadDbContext _context;
        private readonly IConfiguration _configuration;
       


        public UsuarioEventHandler(SeguridadDbContext context, SignInManager<Usuario> signInManager, UserManager<Usuario> userManager,IConfiguration configuration)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
            _configuration=configuration;

    }

        public async Task<IdentityAccess> Handle(UsuarioComandoLogear request, CancellationToken cancellationToken)
        {
            var result = new IdentityAccess();

            var user = await _context.Users.SingleAsync(x => x.Email == request.Email);
            var response = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

            if (response.Succeeded)
            {
                result.Succeeded = true;
                await GenerateToken(user, result);
            }

            return result;
        }

        public async Task<IdentityResult> Handle(UsuarioComandoCrear request, CancellationToken cancellationToken)
        {
            var entry = new Usuario
            {
                UserName = request.UserName,
                Nombre = request.Nombre,
                Apellido = request.Apellido,
                Email = request.Email,

            };

            return await _userManager.CreateAsync(entry, request.Password);
        }


        private async Task GenerateToken(Usuario user, IdentityAccess identity)
        {
            var secretKey = _configuration["SecretKey"];
            var key = Encoding.ASCII.GetBytes(secretKey);

            var roles = await _userManager.GetRolesAsync(user);
            string auxrol = null;
            if (!roles.IsNullOrEmpty()) {  auxrol = roles[0]; }

            bool roladmin = roles.Contains("ADMIN") ? true : false;
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.Nombre),
                new Claim(ClaimTypes.Surname, user.Apellido),
                new Claim(ClaimTypes.Role,auxrol)
            };



            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var createdToken = tokenHandler.CreateToken(tokenDescriptor);

            identity.AccessToken = tokenHandler.WriteToken(createdToken);
        }
    }
}
