using AutoMapper;
using Store.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Servicio.Queries.Dto
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Producto, ProductoDto>();
            CreateMap<Direccion, DireccionDto>().ReverseMap();
            CreateMap<Usuario, UsuarioDto>();
            
        }
    }
}
