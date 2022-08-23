using System;
using Dominio.EntidadesNegocio;
using System.Collections.Generic;
using Dominio.OtrasInterfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.EntidadesNegocio
{
	public abstract class Compra:IValidable
	{
		[Key]
		public int Id { get; set; }

		public DateTime Fecha{ get; set; }

		public IEnumerable<Item> ListaItems { get; set; }

        public decimal Impuestos { get; set; }
        public decimal CostoTotal { get; set; } //costo total con impuestos

		public abstract decimal CalcularTotalCompra();
		public abstract decimal CalcularImpuestos();

		public abstract string Tipo(); //devuelve el tipo de compra (plaza o importada)

		public abstract bool Validar();

        //public static implicit operator Compra(Compra v) => throw new NotImplementedException();

    }

}

