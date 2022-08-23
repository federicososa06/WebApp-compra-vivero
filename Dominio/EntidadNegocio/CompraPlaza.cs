using Dominio.EntidadesNegocio;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.EntidadesNegocio
{
	public class CompraPlaza : Compra
	{
		public decimal CostoFlete{ get; set; }

		public decimal TasaIva { get; set; }


        public override string Tipo()
        {
            return "Plaza";
        }

        public override decimal CalcularTotalCompra()
        {
            decimal total = 0; 

            foreach (Item item in this.ListaItems)
                total += item.TotalItem();

            total += TasaIva * total / 100;
            total += this.CostoFlete;

            return total;
        }

        public override decimal CalcularImpuestos()
        {
            decimal total = 0;

            foreach (var item in ListaItems)
                total += item.TotalItem();

            total = CalcularTotalCompra() - total - CostoFlete;

            return total;
        }

        public override bool Validar()
        {
            return this.CostoFlete >= 0 &&
                   this.Fecha != null
                   && this.ListaItems != null &&
                   this.ListaItems.Count() > 0; //no puede haber compra sin items
        }

        public override string ToString()
        {
            return $"{this.Id} - {this.Tipo()} - {this.CostoFlete} ";
        }
    }

}

