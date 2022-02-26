using Store.Repositorios.Interfaces;
using Store.Servicio.Queries.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Servicio.Queries
{
    public class ProductoQueryService : IProductQueryService
    {
        private readonly IProductoRepositorio _iproductoRepositorio;
        public ProductoQueryService(IProductoRepositorio iproductoRepositorio)
        {
            _iproductoRepositorio = iproductoRepositorio;
        }


    }
}
