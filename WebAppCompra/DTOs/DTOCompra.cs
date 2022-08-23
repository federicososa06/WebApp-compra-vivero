using Dominio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCompra.DTOs
{
    public class DTOCompra
    {
        //compra
        public int CompraId { get; set; }
        public string Tipo { get; set; }
        public DateTime Fecha { get; set; }
        public decimal CostoTotal { get; set; }
        public decimal Impuestos { get; set; }

        public bool AmericaDelSur { get; set; } //CompraImprtada
        public string MedidasSanitarias { get; set; } //CompraImprtada
        public decimal TasaImportacion { get; set; }//CompraImprtada
        public decimal TasaArancelesAmerica { get; set; }//CompraImprtada


        public decimal TasaIva { get; set; }//CompraPlaza
        public decimal CostoFlete { get; set; } //CompraPlaza


        //items
        public List<Item> ListaItems{ get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }

        //planta
        public string NombreCientifico { get; set; }
        public int PlantaId { get; set; }
    }
}
