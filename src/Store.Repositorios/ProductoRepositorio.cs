using Store.Dominio.Entidades;
using Store.Repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repositorios
{
    public class ProductoRepositorio : IProductoRepositorio
    {
        public Task<Producto> ObtenerProductoIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Producto>> ObtenerProductosAsync()
        {
            throw new NotImplementedException();
        }
    }
}
