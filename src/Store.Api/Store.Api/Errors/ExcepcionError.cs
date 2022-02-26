using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Api.Errors
{
    public class ExcepcionError :ErrorResponse
    {
        public ExcepcionError(int statuscode,string mensaje = null,string detalles = null) : base(statuscode,mensaje)
        {
            Detalles = detalles;
        }

        public string Detalles { get; set; }
    }
}
