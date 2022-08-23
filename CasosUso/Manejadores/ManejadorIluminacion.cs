using CasosUso.InterfacesManejadores;
using Dominio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Text;
using Dominio.InterfacesRepositorios;

namespace CasosUso.Manejadores
{
    public class ManejadorIluminacion : IManejadorIluminacion
    {

        public IRepositorioTipoIluminacion RepoIluminacion { get; set; }

        public ManejadorIluminacion(IRepositorioTipoIluminacion repo)
        {
            RepoIluminacion = repo;
        }


        public IEnumerable<TipoIluminacion> TraerTodasLasIluminaciones()
        {
           return RepoIluminacion.FindAll();
        }
    }
}
