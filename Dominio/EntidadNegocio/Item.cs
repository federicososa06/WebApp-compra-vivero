using Dominio.OtrasInterfaces;
using System;
using System.Collections.Generic;

namespace Dominio.EntidadesNegocio
{
    public class Item : IValidable
    {
        public int Id { get; set; }//para id identity

        public Compra Compra { get; set; }
        public int CompraId { get; set; }//para primary key compuesta


        public Planta Planta{ get; set; }
        public int PlantaId { get; set; }//para primary key compuesta

        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }



        public decimal TotalItem()
        {
            return this.PrecioUnitario * this.Cantidad;
        }

        public bool Validar()
        {
            return Planta != null && Cantidad > 0 && PrecioUnitario > 0;
        }

        public static implicit operator Item(List<Item> v)
        {
            throw new NotImplementedException();
        }

     
    }
}