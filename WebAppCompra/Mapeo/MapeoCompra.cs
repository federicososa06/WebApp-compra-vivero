using Dominio.EntidadesNegocio;
using System.Collections.Generic;
using System.Linq;
using WebApiCompra.DTOs;

namespace WebApiCompra.Mapeo
{
    public class MapeoCompra
    {

        //Convierte un dto en una compra
        public static Compra ToEntityCompra(DTOCompra dto)
        {
            Compra nuevaCompra = null;

            if (dto == null)
                return nuevaCompra;

            string tipo = dto.Tipo.ToLower();

            if (tipo == "plaza")
            {
                nuevaCompra = new CompraPlaza()
                {
                    ListaItems = dto.ListaItems,
                    Fecha = dto.Fecha,
                    CostoFlete = dto.CostoFlete
                };
            }
            else if (tipo == "importada")
            {
                nuevaCompra = new CompraImportada
                {
                    ListaItems = dto.ListaItems,
                    Fecha = dto.Fecha,
                    AmericaDelSur = dto.AmericaDelSur,
                    MedidasSanitarias = dto.MedidasSanitarias,
                };
            }

            return nuevaCompra;
        }

        //Convierte lista de items en lista de dto
        public static IEnumerable<DTOCompra> ToListaDTOCompras(IEnumerable<Item> listaItems)
        {
            if (listaItems == null)
                return null;

            return listaItems.Select(lista => ItemToDTO(lista));
        }

        //Convierte un item en un dto
        public static DTOCompra ItemToDTO(Item i)
        {
            DTOCompra dto = null;

            if (i == null)
                return dto;

            if (i.Compra is CompraPlaza)
            {
                CompraPlaza c = i.Compra as CompraPlaza;
                dto = new DTOCompra()
                {
                    CompraId = c.Id,
                    Tipo = "Plaza",
                    Fecha = c.Fecha,
                    CostoTotal = c.CostoTotal,

                    CostoFlete = c.CostoFlete,
                    TasaIva = c.TasaIva,

                    Cantidad = i.Cantidad,
                    NombreCientifico = i.Planta.NombreCientifico,
                    PlantaId = i.PlantaId,
                    PrecioUnitario = i.PrecioUnitario,
                    Impuestos = c.CostoTotal - (i.PrecioUnitario * i.Cantidad)
                };
            }
            else if (i.Compra is CompraImportada)
            {
                CompraImportada c = i.Compra as CompraImportada;
                dto = new DTOCompra()
                {
                    CompraId = c.Id,
                    Tipo = "Importada",
                    Fecha = c.Fecha,
                    CostoTotal = c.CostoTotal,

                    TasaArancelesAmerica = c.TasaArancelesAmerica,
                    TasaImportacion = c.TasaImportacion,
                    AmericaDelSur = c.AmericaDelSur,
                    MedidasSanitarias = c.MedidasSanitarias,

                    Cantidad = i.Cantidad,
                    NombreCientifico = i.Planta.NombreCientifico,
                    PlantaId = i.PlantaId,
                    PrecioUnitario = i.PrecioUnitario,
                    Impuestos = c.CostoTotal - (i.PrecioUnitario * i.Cantidad)
                };
            }

            return dto;
        }
    }
}