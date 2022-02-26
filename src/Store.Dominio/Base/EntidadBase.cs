using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Dominio.Base
{
    public class EntidadBase
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public int Estado { get; set; }
        public DateTime FechaCreacion { get; set; }

        public DateTime? FechaActualizacion { get; set; }
    }
}
