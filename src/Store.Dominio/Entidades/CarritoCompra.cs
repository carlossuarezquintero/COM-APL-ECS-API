using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Dominio.Entidades
{
    public class CarritoCompra
    {
        public CarritoCompra()
        {

        }
        public  CarritoCompra(string id )
        {
            CarritoId = id;
        }
        public string  CarritoId {get;set;}

        public List<CarritoItem> Items { get; set; } = new List<CarritoItem>();

    }
}
