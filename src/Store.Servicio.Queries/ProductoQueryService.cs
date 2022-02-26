using Store.Dominio.Entidades;
using Store.Repositorios.Interfaces;
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
        public async Task<IReadOnlyList<Producto>> ObtenerProductosAsync()
        {
            return (await _iproductoRepositorio.ObtenerProductosAsync());
        }
    }
}
