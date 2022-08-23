using Dominio.OtrasInterfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Dominio.EntidadesNegocio;


namespace Dominio.EntidadesNegocio
{
    public class Planta : IValidable, IValidarDescripcion
    {
        [Key]
        public int Id { get; set; }

        public TipoPlanta Tipo { get; set; }
        
        [Required]
        public string NombreCientifico { get; set; }
        
        public string Descripcion { get; set; } //topes se controlan en el repo con los parametros establecidos

        //public static int PlantaTopeDescrMin = 10;
        //public static int PlantaTopeDescrMax = 500;
        
        public int AlturaMax { get; set; }
        
        [Required]
        public string UrlFoto { get; set; }
        
        public Ambiente Ambiente { get; set; }
        
        public FichaCuidados FichaCuidados { get; set; }

        public IEnumerable<NombreVulgar> ListaNombreVulgares { get; set; }
        
        public IEnumerable<Item> ListaItems { get; set; }


        public bool Validar()
        {
            return !string.IsNullOrEmpty(this.NombreCientifico);
        }

        public bool ValidarParametrosDescripcion(decimal min, decimal max)
        {
            if (this.Descripcion == null)
                return false;

            if (this.Descripcion.Length >= min && this.Descripcion.Length <= max)
                return true;
            else
                return false;
        }

        public override string ToString()
        {
            return ($"{this.Id} - " +
                    $"{this.NombreCientifico} - {this.Descripcion} - " +
                    $"{this.AlturaMax} - {this.UrlFoto} - " +
                    $"{this.Ambiente}");
        }
    }
}