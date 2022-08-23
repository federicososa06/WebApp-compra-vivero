using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppMVC.Models
{
    public class ViewModelCompra
    {
        public int CompraId { get; set; }
        public int Cantidad { get; set; }
        public string NombreCientifico { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal CostoTotal { get; set; }
        public DateTime Fecha { get; set; }
       
    }
}
