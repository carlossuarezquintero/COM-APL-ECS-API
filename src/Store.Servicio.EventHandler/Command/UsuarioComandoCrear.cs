using MediatR;
using Microsoft.AspNetCore.Identity;
using Store.Servicio.EventHandler.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Servicio.EventHandler.Command
{
    public class UsuarioComandoCrear : IRequest<IdentityResult>
    {
        public string UserName { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
