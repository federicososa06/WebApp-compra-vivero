using Dominio.EntidadesNegocio;
using Dominio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Repositorios
{
    public class RepositorioPlanta : IRepositorioPlanta
    {
        public Context Db { get; set; }

        public RepositorioPlanta(Context db)
        {
            Db = db;
        }

        //CRUD
        public bool Add(Planta obj)
        {
            bool ret = false;

            if (obj == null || !obj.Validar())
                return false;

            //validar parametros
            decimal min = Db.Parametros.Where(p => p.Nombre == "PlantaTopeDescrMin").FirstOrDefault().Valor;
            decimal max = Db.Parametros.Where(p => p.Nombre == "PlantaTopeDescrMax").FirstOrDefault().Valor;

            if (obj.ValidarParametrosDescripcion(min, max))
            {
                Db.Plantas.Add(obj);
                Db.SaveChanges();

                ret = true;
            }

            return ret;
        }

        public IEnumerable<Planta> FindAll()
        {
            return Db.Plantas.Include(p => p.FichaCuidados).ThenInclude(f => f.Iluminacion)
                     .Include(p => p.ListaNombreVulgares)
                     .Include(p => p.Tipo)
                     .ToList();
        }

        public Planta FindById(object id)
        {

            return Db.Plantas.Include(p => p.FichaCuidados).ThenInclude(f => f.Iluminacion)
                                .Include(p => p.ListaNombreVulgares)
                                .Include(p => p.Tipo)
                                .Where(p => p.Id == (int)id).FirstOrDefault();

        }

        public bool Remove(object id)
        {
            Planta buscada = Db.Plantas.Find(id);

            if (buscada == null)
                return false;

            Db.Plantas.Remove(buscada);
            Db.SaveChanges();
            return true;
        }

        public bool Update(Planta obj)
        {
            bool ret = false;
            if (obj == null || !obj.Validar())
            {
                return false;
            }

            decimal min = Db.Parametros.Where(p => p.Nombre == "PlantaTopeDescrMin").FirstOrDefault().Valor;
            decimal max = Db.Parametros.Where(p => p.Nombre == "PlantaTopeDescrMax").FirstOrDefault().Valor;

            if (obj.ValidarParametrosDescripcion(min, max))
            {
                Db.Plantas.Update(obj);
                Db.SaveChanges();
                ret = true;
            }

            return ret;
        }

        //CHILD ENTITY
        public TipoIluminacion TraerIluminacion(int idPlanta)
        {
            return (TipoIluminacion)Db.Plantas.Where(p => p.Id == idPlanta).Select(p => p.FichaCuidados.Iluminacion);
        }

        public FichaCuidados TraerFichaCuidados(int idPlanta)
        {
            return (FichaCuidados)Db.Plantas.Where(p => p.Id == idPlanta).Select(p => p.FichaCuidados);
        }

        public Ambiente TraerAmbiente(int idPlanta)
        {
            return Db.Plantas.Where(p => p.Id == idPlanta).Select(p => p.Ambiente).SingleOrDefault();
        }

        //BUSQUEDAS
        public Planta BuscarPlantaPorNombreCientifico(string nom)
        {
            return Db.Plantas.Where(p => p.NombreCientifico == nom)
                             .Include(p => p.FichaCuidados).ThenInclude(fc => fc.Iluminacion)
                             .Include(p => p.ListaNombreVulgares)
                             .FirstOrDefault();
        }

        public IEnumerable<Planta> BuscarPlantasMasAltas(int altura)
        {
            return Db.Plantas.Where(p => p.AlturaMax >= altura)
                            .Include(p => p.FichaCuidados).ThenInclude(fc => fc.Iluminacion)
                            .Include(p => p.ListaNombreVulgares)
                            .ToList();
        }

        public IEnumerable<Planta> BuscarPlantasMasBajas(int altura)
        {
            return Db.Plantas.Where(p => p.AlturaMax <= altura)
                             .Include(p => p.FichaCuidados).ThenInclude(fc => fc.Iluminacion)
                             .Include(p => p.ListaNombreVulgares)
                             .ToList(); ;
        }

        public IEnumerable<Planta> BuscarPorAmbiente(Ambiente amb)
        {
            return Db.Plantas.Where(p => p.Ambiente == amb)
                            .Include(p => p.FichaCuidados).ThenInclude(fc => fc.Iluminacion)
                            .Include(p => p.ListaNombreVulgares)
                            .ToList();
        }

        public IEnumerable<Planta> BuscarPorNombre(string nom)
        {
            return Db.Plantas.Where(p => p.ListaNombreVulgares.Any(nv => nv.Nombre.Contains(nom)))
                             .Concat(Db.Plantas.Where(p => p.NombreCientifico.Contains(nom)))
                             .Include(p => p.FichaCuidados).ThenInclude(fc => fc.Iluminacion)
                             .Include(p => p.ListaNombreVulgares)
                             .ToList();
        }

        public IEnumerable<Planta> BuscarPorTipo(int idTipo)
        {
            return Db.Plantas.Where(p => p.Tipo.Id == idTipo)
                            .Include(p => p.FichaCuidados).ThenInclude(fc => fc.Iluminacion)
                            .Include(p => p.ListaNombreVulgares)
                            .ToList();
        }
    }
}