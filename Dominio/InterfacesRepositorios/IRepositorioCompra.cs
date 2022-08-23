using Dominio.EntidadesNegocio;
using Dominio.EntidadNegocio;
using System.Collections.Generic;

namespace Dominio.InterfacesRepositorios
{
	public interface IRepositorioCompra : IRepositorio<Compra>
	{
		public IEnumerable<Item> ObtenerItemPorTipoPlanta(int idTipo);
		
	}

}

