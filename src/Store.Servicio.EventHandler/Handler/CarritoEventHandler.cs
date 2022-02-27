using AutoMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using Store.Dominio.Entidades;
using Store.Repositorios.Interfaces;
using Store.Servicio.EventHandler.Command.Carrito;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Store.Servicio.EventHandler.Handler
{
    public class CarritoEventHandler : IRequestHandler<CarritoComandoCrear, CarritoCompra>,
        IRequestHandler<CarritoComandoEliminar,bool>
    {

        private readonly IConfiguration _configuration;
        private readonly ICarritoCompraRepositorio _carritoCompraRepositorio;
        private readonly IMapper _mapper;
        public CarritoEventHandler(ICarritoCompraRepositorio carritoCompraRepositorio, IConfiguration configuration, IMapper mapper)
        {
            _carritoCompraRepositorio = carritoCompraRepositorio;
            _configuration = configuration;
            _mapper = mapper;
        }
        public async Task<CarritoCompra> Handle(CarritoComandoCrear request, CancellationToken cancellationToken)
        {
            Console.WriteLine("s");
            CarritoCompra carrito = new CarritoCompra(request.CarritoId)
            {
                CarritoId = request.CarritoId,
                Items = request.Items
            };
            var response = await _carritoCompraRepositorio.ActualizarCarritoCompraAsync(carrito);

            return response;
        }

        public async Task<bool> Handle(CarritoComandoEliminar request, CancellationToken cancellationToken)
        {
            bool response = await _carritoCompraRepositorio.EliminarCarritoCompraAsync(request.CarritoCompraId);
          return response;
        }
    }
}
