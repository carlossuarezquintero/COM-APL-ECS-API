using Microsoft.Extensions.Logging;
using Store.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Persistencia.Seed
{
    public class DatosSemilla
    {
        public static async Task CargarData(ApplicationDbContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                // Verificar si la tabla esta vacia 

                var aleatorio = new Random();

                //Crear Marcas
               if (!context.Marcas.Any())
                {
                    var marcas = new List<Marca>();


                    for (var i = 1; i <= 100; i++)
                    {
                        var rta= context.Marcas.Add(new Marca
                        {
                            
                            Nombre = "Marca " +i,
                            Codigo = aleatorio.Next(1, 50000),
                            Descripcion = "Marca " +i + Convert.ToString(Guid.NewGuid()),
                            FechaCreacion = DateTime.Today,
                            FechaActualizacion = null,
                            Estado = 1
                           
                        }); 

                        
                    }

                    await context.SaveChangesAsync();
                }

                // Crear Categorias 

                if (!context.Categorias.Any())
                {
                    var categorias = new List<Categoria>();


                    for (var z = 1; z <= 100; z++)
                    {
                        context.Categorias.Add(new Categoria
                        {
                            
                            Nombre = "Categoria " + z,
                            Codigo = aleatorio.Next(1, 50000),
                            Descripcion = "Categoria " + z + Convert.ToString(Guid.NewGuid()),
                            FechaCreacion = DateTime.Today,
                            FechaActualizacion = null,
                            Estado = 1
                        }); 

                    }

                    await context.SaveChangesAsync();
                }

                // Crear productos

                if (!context.Productos.Any())
                {
                    var productos = new List<Producto>();
                    int c = 100; int m = 1;

                    for (var p = 1; p <= 100; p++)
                    {
                        context.Productos.Add(new Producto
                        {
                            
                            Nombre = "Producto " + p,
                            Codigo = aleatorio.Next(1, 50000),
                            Descripcion = "Producto " + p + Convert.ToString(Guid.NewGuid()),
                            Precio = aleatorio.Next(15000, 50000),
                            Stock = aleatorio.Next(1, 1000),
                            Imagen= "https://source.unsplash.com/random",
                            MarcaId = m,
                            CategoriaId = c-1,
                            FechaCreacion = DateTime.Today,
                            FechaActualizacion = null,
                            Estado = 1
                        }); 

                    }
                    
                    await context.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<ApplicationDbContext>();
                logger.LogError(ex.Message);
            }
        }
    }
}
