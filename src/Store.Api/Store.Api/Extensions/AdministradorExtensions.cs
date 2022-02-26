using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Store.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Store.Api.Extensions
{
    public static class AdministradorExtensions
    {
        public static async Task<Usuario> BuscarUsuarioCondireccionAsync(this UserManager<Usuario> input, ClaimsPrincipal usr)
        {
            var email = usr?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
            var usuario = await input.Users.Include(x => x.Direccion).SingleOrDefaultAsync(x => x.Email == email);
            return usuario;
        }

        public static async Task<Usuario> BuscarUsuarioAsync(this UserManager<Usuario> input, ClaimsPrincipal usr)
        {
            var email = usr?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
            var usuario = await input.Users.SingleOrDefaultAsync(x => x.Email == email);
            return usuario;
        }
    }
}
