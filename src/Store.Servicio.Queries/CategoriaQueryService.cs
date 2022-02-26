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
    public class CategoriaQueryService :ICategoriaQueryService
    {
        private readonly IGenericRepositorio<Categoria> _genericRepositorio;
        public CategoriaQueryService(IGenericRepositorio<Categoria> genericRepositorio)
        {
            _genericRepositorio=genericRepositorio;
        }



        /// <summary>
        /// Obtiene las categorias por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Categoria> ObtenerCategoriaIdAsync(int id)
        {
            return (await _genericRepositorio.ObtenerporIdAsync(id));
        }

        /// <summary>
        /// Obtiene todos las categorias
        /// </summary>
        /// <returns></returns>
        public async Task<IReadOnlyList<Categoria>> ObtenerCategoriaAsync()
        {
            return (await _genericRepositorio.ObtenertodoAsync());
        }

    }
}
