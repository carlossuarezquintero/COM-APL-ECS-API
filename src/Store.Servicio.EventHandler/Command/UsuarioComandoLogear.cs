using MediatR;
using Store.Servicio.EventHandler.Responses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Servicio.EventHandler.Command
{
    public class UsuarioComandoLogear : IRequest<IdentityAccess>
    {
        [Required(ErrorMessage = "El email es requerido"), EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
