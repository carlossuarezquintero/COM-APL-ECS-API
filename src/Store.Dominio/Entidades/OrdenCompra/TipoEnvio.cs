using Store.Dominio.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Dominio.Entidades.OrdenCompra
{
    public class TipoEnvio : EntidadBase
    {
        public int TipoEnvioId { get; set; }
        public string DeliveruTime { get; set; }
        public decimal Precio { get; set; }
    }
}
