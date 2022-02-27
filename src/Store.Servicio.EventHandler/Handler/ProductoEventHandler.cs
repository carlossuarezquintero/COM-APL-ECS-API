using MediatR;
using Store.Dominio.Entidades;
using Store.Repositorios.Interfaces;
using Store.Servicio.EventHandler.Command.Productos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Store.Servicio.EventHandler.Handler
{
    public class ProductoEventHandler : IRequestHandler<ProductoComandoCrear, int>,
         IRequestHandler<ProductoComandoActualizar, int>
    {
        private readonly IGenericRepositorio<Producto> _genericRepositorio;
        public ProductoEventHandler(IGenericRepositorio<Producto> genericRepositorio)
        {
            _genericRepositorio = genericRepositorio;
        }

        public async Task<int> Handle(ProductoComandoCrear request, CancellationToken cancellationToken)
        {
            var producto = (new Producto
            {
                Stock = request.Stock,
                MarcaId = request.MarcaId,
                CategoriaId = request.CategoriaId,
                Nombre = request.Nombre,
                Descripcion = request.Descripcion,
                Precio = request.Precio ,
                Imagen = request.Imagen,
                Codigo = request.Codigo

              });

            await _genericRepositorio.Agregar(producto);

            return producto.ProductoId;
        }

        public async Task<int> Handle(ProductoComandoActualizar request, CancellationToken cancellationToken)
        {
            var producto = (new Producto
            {
                ProductoId= request.ProductoId,
                Stock = request.Stock,
                MarcaId = request.MarcaId,
                CategoriaId = request.CategoriaId,
                Nombre = request.Nombre,
                Descripcion = request.Descripcion,
                Precio = request.Precio,
                Imagen = request.Imagen,
                Codigo = request.Codigo

            });

           var response =  await _genericRepositorio.Actualizar(producto);

            return response;
        }
    }
}
