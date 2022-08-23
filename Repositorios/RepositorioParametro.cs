using System;
using System.Collections.Generic;
using System.Text;
using Dominio.InterfacesRepositorios;
using System.Linq;
using Dominio.ParametroConfiguracion;

namespace Repositorios
{
    public class RepositorioParametro : IRepositorioParametro
    {
        public Context Db{ get; set; }
        public RepositorioParametro(Context db)
        {
            Db = db;
        }


        public bool Add(Parametros obj)
        {
            if (obj == null || !obj.Validar())
                return false;

            Db.Parametros.Add(obj);
            Db.SaveChanges();
            bool ret = true;
            return ret;
        }

        public IEnumerable<Parametros> FindAll()
        {
            return Db.Parametros.ToList();
        }

        public Parametros FindById(object id)
        {
            return Db.Parametros.Find(id);
        }

        public bool Remove(object id)
        {
            Db.Parametros.Remove(new Parametros { Id = (int)id });
            Db.SaveChanges();
            bool ret = true;
            return ret;
        }
        public bool Update(Parametros obj)
        {
            if (obj == null || !obj.Validar())
                return false;

            Db.Parametros.Update(obj);
            Db.SaveChanges();
            bool ret = true;
            return ret;
        }

        //Cambia el valor de un parametro existente
        public bool SetValorParametro(string nom, decimal val)
        {
            throw new NotImplementedException();
        }

        //Devuelve el valor de un parametro según su nombre
        public string GetValorParametro(string nom)
        {
            return Db.Parametros.Where(param => param.Nombre == nom).FirstOrDefault().ToString();
            //hay que parsear a decimal al momento de usar
        }

    }
}
