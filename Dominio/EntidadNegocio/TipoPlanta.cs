using Dominio.EntidadesNegocio;
using Dominio.OtrasInterfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Dominio.EntidadesNegocio
{
	public class TipoPlanta : IValidable, IValidarDescripcion
	{
		public int Id { get; set; }

        [Required]
        public string Nombre{ get; set; }

		public string Descripcion{ get; set; } //topes se controlan en el repo con los parametros establecidos

        private static int TipoPlantaTopeDescrMin = 10;

        private static int TipoPlantaTopeDescrMax = 200;

        public bool Validar()
        {
            return !string.IsNullOrEmpty(this.Nombre) &&
                !string.IsNullOrEmpty(this.Descripcion);
        }

        public bool ValidarParametrosDescripcion(decimal min, decimal max)
        {
            if (this.Descripcion.Length >= min && this.Descripcion.Length <= max)
                return true;
            else
                return false;

        }


        public override string ToString()
        {
            return $"{this.Nombre} - {this.Descripcion}";
        }
    }

}

