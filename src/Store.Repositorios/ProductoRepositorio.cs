using Microsoft.EntityFrameworkCore;
using Store.Dominio.Entidades;
using Store.Persistencia;
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

        private readonly ApplicationDbContext _context;

        public ProductoRepositorio(ApplicationDbContext context)
        {
            _context = context;

        }

        /// <summary>
        /// Obtiene un producto por i
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Producto> ObtenerProductoIdAsync(int id)
        {
            return await _context.Productos
                    .Include(p => p.Marca)
                    .Include(P => P.Categoria)
                    .FirstOrDefaultAsync(p => p.ProductoId == id);
        }

        /// <summary>
        /// Obtiene todos los productos
        /// </summary>
        /// <returns></returns>
        public async Task<IReadOnlyList<Producto>> ObtenerProductosAsync()
        {
            return await _context.Productos
                    .Include(p => p.Marca)
                    .Include(P => P.Categoria)
                    .ToListAsync();
        }
    }
}
