
using System.Collections.Generic;

namespace AppMVC.Models
{
    public class ViewModelCompleto
    {
        public IEnumerable<ViewModelTipoPlanta> ListaTiposPlanta { get; set; }
        public int idTipoSeleccionado { get; set; }
        public IEnumerable<ViewModelCompra> ListaCompras { get; set; }

    }
}