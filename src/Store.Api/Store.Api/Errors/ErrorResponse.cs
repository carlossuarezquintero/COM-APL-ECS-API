using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Api.Errors
{
    public  class ErrorResponse
    {
        public ErrorResponse(int statuscode, string mensaje=null)
        {
            Status = statuscode;
            Mensaje = mensaje ?? Obtenermensajedefecto(statuscode);
        }

        private string Obtenermensajedefecto(int statuscode)
        {
            return statuscode switch{
                        400 =>  "El request enviado tiene errores",
                        401 =>  "No tienes autorizacion para este recurso",
                        404 =>  "El recurso no se encontro disponible",
                        500 =>  "Error en el servidor",
                        _   => null,
                     };
        }
        public int Status { get; set; }
        public string Mensaje { get; set; }
    }
}
