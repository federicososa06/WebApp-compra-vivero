using Dominio.EntidadesNegocio;
using Dominio.EntidadNegocio;
using Dominio.InterfacesRepositorios;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApiCompra.DTOs;
using WebApiCompra.Mapeo;

namespace WebAppCompra.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompraController : ControllerBase
    {
        //inyectar el repositorio
        public IRepositorioCompra RepoCompra { get; set; }
        public IRepositorioTipoPlanta RepoTipoPlanta { get; set; }

        public CompraController(IRepositorioCompra repo, IRepositorioTipoPlanta repoTipo)
        {
            RepoCompra = repo;
            RepoTipoPlanta = repoTipo;
        }


    

        // POST api/<CompraController>
        [HttpPost]
        public IActionResult Post([FromBody] DTOCompra c)
        {
            try
            {
                if (c == null || c.Tipo == null)
                    return BadRequest();

                Compra compra = MapeoCompra.ToEntityCompra(c);
                                
                bool agregado = RepoCompra.Add(compra);

                if (!agregado)
                    return Conflict();

                return Created("api/compra" + compra.Id, compra); //se envia la ruta y la compra creada
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }


        //GET: api/<CompraController>
        [HttpGet]
        [Route("filtrarPorTipo/{id}")] //api/compra/filtrarportipo/5
        public IActionResult FiltrarPorTipo(int id)
        {
            try
            {
                if (id == 0)
                    return BadRequest();

                IEnumerable<Item> items = RepoCompra.ObtenerItemPorTipoPlanta(id); 

                IEnumerable<DTOCompra> listaDTO = MapeoCompra.ToListaDTOCompras(items); 

                if (listaDTO.Count() == 0)
                    return NotFound();

                return Ok(listaDTO);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }


        [HttpGet]
        [Route("listaTiposPlanta")]  //api/compra/listaTiposPlanta
        public IActionResult TraerListaTipoPlanta()
        {
            try
            {
                IEnumerable<TipoPlanta> lista = RepoTipoPlanta.FindAll();
                return Ok(lista);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

    }
}