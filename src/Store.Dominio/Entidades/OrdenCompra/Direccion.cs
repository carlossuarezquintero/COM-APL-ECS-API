using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Dominio.Entidades.OrdenCompra
{
    public class Direccion
    {
        public Direccion()
        {
                
        }
        public Direccion(int direccionId, string calle, string ciudad, string departamento, string codigoPostal)
        {
            DireccionId = direccionId;
            Calle = calle;
            Ciudad = ciudad;
            Departamento = departamento;
            CodigoPostal = codigoPostal;
        }

        public int DireccionId { get; set; }

        public string Calle { get; set; }

        public string Ciudad { get; set; }

        public string Departamento { get; set; }

        public string CodigoPostal { get; set; }
    }
}
