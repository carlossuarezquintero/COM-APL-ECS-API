using Store.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Servicio.Queries.Interfaces
{
    public interface ICategoriaQueryService
    {
        Task<Categoria> ObtenerCategoriaIdAsync(int id);
        Task<IReadOnlyList<Categoria>> ObtenerCategoriaAsync();
    }
}
