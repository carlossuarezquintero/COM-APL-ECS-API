using Microsoft.AspNetCore.Identity;
using Store.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Persistencia.Seed
{
    public class SeguridadDatoSemilla
    {
        public static async Task seguridadatosemilla(UserManager<Usuario> userManager)
        {
            if (!userManager.Users.Any())
            {
                var usuario = new Usuario
                {
                    Nombre = "Carlos",
                    Apellido = "Suarez",
                    UserName = "Carlos",
                    Email = "carlossuarezquintero@gmail.com",
                    Direccion = new Direccion
                    {
                        Calle = "Mz 2 casa 35",
                        Ciudad = "Cúcuta",
                        Departamento = "Norte de santander",
                        CodigoPostal = "540003"
                    }
                };

                var result= await userManager.CreateAsync(usuario, "27378859Ca*");

            }
        }
    }
}
