using StackExchange.Redis;
using Store.Dominio.Entidades;
using Store.Repositorios.Interfaces;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace Store.Repositorios
{
    public class CarritoCompraRepositorio : ICarritoCompraRepositorio
    {
        private readonly IDatabase _database;

        public CarritoCompraRepositorio(IConnectionMultiplexer redis)
        {
            _database = redis.GetDatabase();

        }
        public async Task<CarritoCompra> ActualizarCarritoCompraAsync(CarritoCompra carritocompra)
        {

            var status = await _database.StringSetAsync(carritocompra.CarritoId,JsonSerializer.Serialize(carritocompra),TimeSpan.FromDays(30));
            if (!status) return null;

            return await ObtenerCarritoCompraAsync(carritocompra.CarritoId);
        }

        public async Task<bool> EliminarCarritoCompraAsync(string carritoId)
        {
            return await _database.KeyDeleteAsync(carritoId);
        }

        public async Task<CarritoCompra> ObtenerCarritoCompraAsync(string carritoid)
        {
            var data = await _database.StringGetAsync(carritoid);
            
             var x =    data.IsNullOrEmpty ? null : JsonSerializer.Deserialize<CarritoCompra>(data);
            return x;
        }
    }
}
