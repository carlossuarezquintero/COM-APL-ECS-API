using Microsoft.EntityFrameworkCore;
using Servicio.Comun.Coleccion;
using Servicio.Comun.Mapeo;
using Servicio.Comun.Paginacion;
using Store.Dominio.Entidades;
using Store.Persistencia;
using Store.Repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<DatosColeccion<ProductoStore>> ObtenerProductosAsync(int pagina, int registros, IEnumerable<int> productoslist = null)
        {

            var collection = await _context.ProductoStore.FromSqlRaw("select Productos.*,Categorias.Nombre as 'CategoriaNombre',Marcas.Nombre as 'marcaNombre'from Productos join Marcas on Marcas.Id = Productos.MarcaId join Categorias on Categorias.Id = Productos.CategoriaId").GetPagedAsync(pagina, registros); ;
            /*
            var collection = await _context.Productos
                           .Where(x => productoslist == null || productoslist.Contains(x.ProductoId))
                           .Include(p => p.Marca)
                           .Include(P => P.Categoria)
                           .OrderBy(x => x.ProductoId)
                           .GetPagedAsync(pagina,registros);
              */             

            return collection.MapTo<DatosColeccion<ProductoStore>>();
        }
    }
}
