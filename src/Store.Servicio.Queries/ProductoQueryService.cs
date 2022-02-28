using Servicio.Comun.Coleccion;
using Servicio.Comun.Mapeo;
using Store.Dominio.Entidades;
using Store.Repositorios.Interfaces;
using Store.Servicio.Queries.Dto;
using Store.Servicio.Queries.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Servicio.Queries
{
    public class ProductoQueryService : IProductoQueryService
    {
        private readonly IProductoRepositorio _iproductoRepositorio;
        private readonly IGenericRepositorio<Producto> _genericRepositorio;
        public ProductoQueryService(IProductoRepositorio iproductoRepositorio, IGenericRepositorio<Producto> genericRepositorio)
        {
            _iproductoRepositorio = iproductoRepositorio;
            _genericRepositorio = genericRepositorio;
        }


        /// <summary>
        /// Obtiene los productos por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Producto> ObtenerProductoIdAsync(int id)
        {
            return (await _iproductoRepositorio.ObtenerProductoIdAsync(id));
        }

        /// <summary>
        /// Obtiene todos los productos
        /// </summary>
        /// <returns></returns>
        public async Task<DatosColeccion<ProductoDto>> ObtenerProductosAsync(int pagina, int registros, IEnumerable<int> productos = null)
        {

            var collection = await _iproductoRepositorio.ObtenerProductosAsync(pagina, registros, productos);
             
            return collection.MapTo<DatosColeccion<ProductoDto>>();
        }
    }
}
