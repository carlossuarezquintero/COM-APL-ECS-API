using MediatR;
using Microsoft.AspNetCore.Identity;
using Store.Servicio.EventHandler.Responses;
using Store.Servicio.Queries.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Servicio.EventHandler.Command
{
    public class UsuarioComandoCrear : IRequest<UsuarioDto>
    {
        [Required(ErrorMessage = "El usuario es requerido")]
        
        public string UserName { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El Apellido es requerido")]
        public string Apellido { get; set; }

        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [Required(ErrorMessage = "El email es requerido")]
        public string Email { get; set; }

        [Required]
        [StringLength(18, ErrorMessage = "El {0} debe tener al menos {2} caracteres.", MinimumLength = 6)]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$", ErrorMessage = "la contraseña debe tener al menos 6 caracteres, no más de 18 caracteres y debe incluir al menos una letra mayúscula, una letra minúscula y un dígito numérico.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
