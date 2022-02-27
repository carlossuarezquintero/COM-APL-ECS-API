using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Store.Dominio.Entidades.OrdenCompra
{
    public enum EstadoOrden
    {
        [EnumMember(Value ="Pendiente")]
        Pendiente,
        [EnumMember(Value = "El pago fue recibido")]
        PagoRecibido,
        [EnumMember(Value = "El pago tuvo errores ")]
        PagoFallo
    }
}
