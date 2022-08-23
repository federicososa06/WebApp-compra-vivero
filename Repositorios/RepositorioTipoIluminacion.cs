using System;
using System.Collections.Generic;
using System.Text;
using Dominio.EntidadesNegocio;
using Dominio.InterfacesRepositorios;
using System.Linq;


namespace Repositorios
{
    public class RepositorioTipoIluminacion : IRepositorioTipoIluminacion
    {

        public Context Db { get; set; }

        public RepositorioTipoIluminacion(Context ct)
        {
            Db = ct;
        }

        public bool Add(TipoIluminacion obj)
        {
            if (obj == null)
                return false;

            Db.TipoIluminacion.Add(obj);
            Db.SaveChanges();
            return true;

        }

        public IEnumerable<TipoIluminacion> FindAll()
        {
            return Db.TipoIluminacion.ToList();
        }

        public TipoIluminacion FindById(object id)
        {
            return Db.TipoIluminacion.Find(id);
        }

        public bool Remove(object id)
        {
            TipoIluminacion buscada = Db.TipoIluminacion.Find(id);
            
            if (buscada == null)
                return false;

            Db.TipoIluminacion.Remove(buscada);
            Db.SaveChanges();

            return true;
        }

        public bool Update(TipoIluminacion obj)
        {
            if (obj == null)
                return false;

            Db.TipoIluminacion.Update(obj);
            Db.SaveChanges();
            return true;
        }
    }
}
