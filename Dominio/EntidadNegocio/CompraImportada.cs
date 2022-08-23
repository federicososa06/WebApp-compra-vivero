using System.Linq;

namespace Dominio.EntidadesNegocio
{
    public class CompraImportada : Compra
    {
        public bool AmericaDelSur { get; set; }

        public string MedidasSanitarias { get; set; }

        public decimal TasaImportacion { get; set; }

        public decimal TasaArancelesAmerica { get; set; }

        public override string Tipo()
        {
            return "Importada";
        }

        public override decimal CalcularTotalCompra()
        {
            decimal total = 0; 

            foreach (Item item in this.ListaItems)
                total += item.TotalItem();

            if (AmericaDelSur)
                total += (TasaImportacion-TasaArancelesAmerica) * total / 100;
            else
                total += TasaImportacion  * total / 100;

            return total;
        }


        public override decimal CalcularImpuestos()
        {
            decimal total = 0;

            foreach (var item in ListaItems)
                total += item.TotalItem();

            total = CalcularTotalCompra() - total ;

            return total;
        }


        public override bool Validar()
        {
            return !string.IsNullOrEmpty(this.MedidasSanitarias) &&
                    this.Fecha != null
                    && this.ListaItems != null &&
                    this.ListaItems.Count() > 0; //no puede haber compra sin items
        }

        public override string ToString()
        {
            return $"{this.Id} - {this.Tipo()} - {this.AmericaDelSur} - {this.MedidasSanitarias} ";
        }

       
    }
}