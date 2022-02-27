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
    public class CarritoCompraQueryService : ICarritoCompraQueryService
    {
        private readonly ICarritoCompraRepositorio _carritoCompraRepositorio;
        public CarritoCompraQueryService(ICarritoCompraRepositorio carritoCompraRepositorio) 
        { 
            _carritoCompraRepositorio = carritoCompraRepositorio;
        }

        /// <summary>
        /// Obtiene un Carrito
        /// </summary>
        /// <param name="carritoid"></param>
        /// <returns></returns>
        public async Task<CarritoCompra> ObtenerCarritoCompraAsync(string carritoid)
        {
           return await _carritoCompraRepositorio.ObtenerCarritoCompraAsync(carritoid);
       
        }
    }
}
