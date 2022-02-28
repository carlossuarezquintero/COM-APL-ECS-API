using Servicio.Comun.Coleccion;
using Store.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repositorios.Interfaces
{
    public interface IProductoRepositorio
    {
        Task<Producto> ObtenerProductoIdAsync(int id);

        Task<DatosColeccion<ProductoStore>> ObtenerProductosAsync(int pagina, int registros, IEnumerable<int> productos = null);
    }
}
