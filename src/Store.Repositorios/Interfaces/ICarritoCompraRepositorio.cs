using Store.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repositorios.Interfaces
{
    public interface ICarritoCompraRepositorio
    {
        Task<CarritoCompra> ObtenerCarritoCompraAsync(string carritoid);
        Task<CarritoCompra> ActualizarCarritoCompraAsync(CarritoCompra carritocompra);

        Task<bool> EliminarCarritoCompraAsync(string carritoId);
    }
}
