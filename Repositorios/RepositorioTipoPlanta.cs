using Dominio.EntidadesNegocio;
using Dominio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Repositorios
{
    public class RepositorioTipoPlanta : IRepositorioTipoPlanta
    {
        public Context Db { get; set; }

        public RepositorioTipoPlanta(Context db)
        {
            Db = db;
        }

        public bool Add(TipoPlanta obj)
        {
            bool ret = false;
            if (obj == null || !obj.Validar())
                return ret;

            //validar que no exista el nombre del tipo de planta
            TipoPlanta existeTP = BuscarPorNombre(obj.Nombre);

            //validar topes de descripción
            decimal min = Db.Parametros.Where(p => p.Nombre == "TipoPlantaTopeDescrMin").FirstOrDefault().Valor;
            decimal max = Db.Parametros.Where(p => p.Nombre == "TipoPlantaTopeDescrMax").FirstOrDefault().Valor;

            if (existeTP == null && obj.ValidarParametrosDescripcion(min, max))
            {
                Db.TiposPlanta.Add(obj);
                Db.SaveChanges();
                ret = true;
            }

            return ret;
        }

        public TipoPlanta BuscarPorNombre(string nom)
        {
            return Db.TiposPlanta.Where(tp => tp.Nombre == nom).SingleOrDefault();
        }

        public IEnumerable<TipoPlanta> FindAll()
        {
            return Db.TiposPlanta.ToList();
        }

        public TipoPlanta FindById(object id)
        {
            return Db.TiposPlanta.Find(id);
        }

        public bool Remove(object id)
        {
            Db.TiposPlanta.Remove(new TipoPlanta { Id = (int)id });
            Db.SaveChanges();
            bool ret = true;

            return ret;
        }

        public bool Update(TipoPlanta obj)
        {
            bool ret = false;

            if (obj == null || !obj.Validar())
                return false;

            decimal min = Db.Parametros.Where(p => p.Nombre == "TipoPlantaTopeDescrMin").FirstOrDefault().Valor;
            decimal max = Db.Parametros.Where(p => p.Nombre == "TipoPlantaTopeDescrMax").FirstOrDefault().Valor;

            if (obj.ValidarParametrosDescripcion(min, max))
            {
                Db.TiposPlanta.Update(obj);
                Db.SaveChanges();
                ret = true;
            }

            return ret;
        }
    }
}