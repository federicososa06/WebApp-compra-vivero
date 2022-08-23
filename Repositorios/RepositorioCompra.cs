using Dominio.EntidadesNegocio;
using Dominio.EntidadNegocio;
using Dominio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repositorios
{
    public class RepositorioCompra : IRepositorioCompra
    {
        public Context Db { get; set; }

        public RepositorioCompra(Context ct)
        {
            Db = ct;
        }

        public bool Add(Compra obj)
        {
            try
            {
                if (obj == null || !obj.Validar())
                    return false;

                if (obj.Tipo() == "Plaza")
                {
                    CompraPlaza compra = obj as CompraPlaza;
                    compra.TasaIva = Db.Parametros.Where(p => p.Nombre == "Tasa Iva").SingleOrDefault().Valor;

                    compra.CostoTotal = compra.CalcularTotalCompra();
                    compra.Impuestos = compra.CalcularImpuestos();

                    Db.Compras.Add(compra);
                    Db.SaveChanges();
                    return true;
                }

                if (obj.Tipo() == "Importada")
                {
                    CompraImportada compra = obj as CompraImportada;
                    compra.TasaArancelesAmerica = Db.Parametros.Where(p => p.Nombre == "Tasa Aranceles America del Sur").SingleOrDefault().Valor;
                    compra.TasaImportacion = Db.Parametros.Where(p => p.Nombre == "Tasa Importación").SingleOrDefault().Valor;

                    compra.CostoTotal = compra.CalcularTotalCompra();
                    compra.Impuestos = compra.CalcularImpuestos();

                    Db.Compras.Add(compra);
                    Db.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return false;
        }

        public IEnumerable<Compra> FindAll()
        {
            return Db.Compras.ToList();
        }

        public Compra FindById(object id)
        {
            return Db.Compras.Find(id);
        }

        public bool Remove(object id)
        {
            Compra buscada = FindById(id);

            if (buscada == null)
                return false;

            Db.Compras.Remove(buscada);
            Db.SaveChanges();
            return true;
        }

        public bool Update(Compra obj)
        {
            if (obj == null || !obj.Validar())
                return false;

            Db.Compras.Update(obj);
            Db.SaveChanges();
            return true;
        }


        public IEnumerable<Item> ObtenerItemPorTipoPlanta(int idTipo)
        {
            return Db.Items.Where(i => i.Planta.Tipo.Id == idTipo)
                             .Include(li => li.Planta).ThenInclude(p => p.ListaNombreVulgares)
                             .Include(li => li.Planta.FichaCuidados).ThenInclude(fc => fc.Iluminacion)
                             .Include(li => li.Planta.Tipo)
                             .Include(li => li.Compra)
                             .ToList();
        }

    }
}