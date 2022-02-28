using Servicio.Comun.Coleccion;
using Store.Dominio.Entidades;
using Store.Servicio.Queries.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Servicio.Queries.Interfaces
{
    public interface IProductoQueryService
    {
         Task<Producto> ObtenerProductoIdAsync(int id);
        Task<DatosColeccion<ProductoDto>> ObtenerProductosAsync(int pagina, int registros, IEnumerable<int> productos = null);
    }
}
