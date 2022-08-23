using System;
using System.Collections.Generic;
using System.Text;
using Dominio.EntidadesNegocio;

namespace CasosUso.InterfacesManejadores
{
   public  interface IManejadorIluminacion
    {
        public IEnumerable<TipoIluminacion> TraerTodasLasIluminaciones();
    }
}
