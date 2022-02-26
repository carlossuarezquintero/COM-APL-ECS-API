using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Dominio.Entidades
{
    public class Direccion
    {
        public int DireccionId { get; set; }

        public string Calle { get; set; }

        public string Ciudad { get; set; }

        public string Departamento { get; set; }

        public string CodigoPostal { get; set; }

        public string UsuarioId { get; set; }

        public Usuario Usuario { get; set; }


    }
}
