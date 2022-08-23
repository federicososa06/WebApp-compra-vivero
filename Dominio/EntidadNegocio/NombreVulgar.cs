using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.EntidadesNegocio
{
    public class NombreVulgar
    {
        [Key]
        public int Id { get; set; }

        public string Nombre { get; set; }

        public Planta Planta { get; set; }

        
        public int PlantaId { get; set; }

        public override string ToString()
        {
            return this.Nombre;
        }
    }
}