using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Servicio.EventHandler.Command.Usuarios
{
    public class UsuarioComandoActualizar : IRequest<int>
    {
        public string id { get; set; }
        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Password { get; set; }

        public string Imagen { get; set; }
    }
}
