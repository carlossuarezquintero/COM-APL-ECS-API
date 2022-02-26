using Store.Dominio.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repositorios.Interfaces
{
    public interface IGenericRepositorio<T> where T : EntidadBase
    {
        Task<T> ObtenerporIdAsync(int id);
        Task<IReadOnlyList<T>> ObtenertodoAsync();
    }
}
