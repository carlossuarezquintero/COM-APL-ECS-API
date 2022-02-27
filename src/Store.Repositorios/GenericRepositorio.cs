using Microsoft.EntityFrameworkCore;
using Store.Dominio.Base;
using Store.Persistencia;
using Store.Repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repositorios
{
    public class GenericRepositorio<T> : IGenericRepositorio<T> where T : EntidadBase
    {
        private readonly ApplicationDbContext _context;
        public GenericRepositorio(ApplicationDbContext context)
        {
            _context = context;

        }

        public async Task<int> Actualizar(T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Agregar(T entity)
        {
            _context.Set<T>().Add(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<T> ObtenerporIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ObtenertodoAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }
    }
}
