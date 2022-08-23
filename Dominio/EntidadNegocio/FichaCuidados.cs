using Dominio.EntidadesNegocio;
using Dominio.OtrasInterfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.EntidadesNegocio
{
	public class FichaCuidados : IValidable
	{
		//[Key]
		//public int Id { get; set; }

		public string FrecuenciaRiegoUnidadTiempo { get; set; }

		public int FrecuenciaRiegoCantidad { get; set; }

		public decimal Temperatura { get; set; }

		public TipoIluminacion Iluminacion { get; set; }

		public Planta Planta { get; set; }
        
		[Key, ForeignKey("Planta")]
		public int PlantaId { get; set; }

        public bool Validar()
        {
			return !string.IsNullOrEmpty(FrecuenciaRiegoUnidadTiempo) &&
					this.FrecuenciaRiegoCantidad > 0 &&
					this.Iluminacion != null;
        }

        public override string ToString()
        {
			return $"{this.FrecuenciaRiegoCantidad} x {this.FrecuenciaRiegoUnidadTiempo} - {this.Temperatura} - {this.Iluminacion.ToString()}";

		}
    }

}

