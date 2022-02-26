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
    public class MarcaQueryService : IMarcaQueryService
    {
        private readonly IGenericRepositorio<Marca> _genericRepositorio;
        public MarcaQueryService(IGenericRepositorio<Marca> genericRepositorio)
        {
            _genericRepositorio = genericRepositorio;
        }

        /// <summary>
        /// Obtiene las Marcas por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Marca> ObtenerMarcaIdAsync(int id)
        {
            return (await _genericRepositorio.ObtenerporIdAsync(id));
        }

        /// <summary>
        /// Obtiene todas las Marcas
        /// </summary>
        /// <returns></returns>
        public async Task<IReadOnlyList<Marca>> ObtenerMarcaAsync()
        {
            return (await _genericRepositorio.ObtenertodoAsync());
        }

    }
}
