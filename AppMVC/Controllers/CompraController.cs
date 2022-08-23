using AppMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace AppMVC.Controllers
{
    public class CompraController : Controller
    {
       
        // GET: CompraController
        public ActionResult Index()
        {
            try
            {
                HttpClient cliente = new HttpClient();

                Task<HttpResponseMessage> task = cliente.GetAsync("http://localhost:11960/api/compra/");
                task.Wait();

                if (task.Result.IsSuccessStatusCode)
                {
                    Task<string> task2 = task.Result.Content.ReadAsStringAsync();
                    task2.Wait();

                    string respuestaJson = task2.Result;
                    var compras = JsonConvert.DeserializeObject<ViewModelCompleto>(respuestaJson);

                    return View(compras);
                }
                else
                {
                    ViewBag.Error = "Ocurrio un error";
                    return View();
                }
            }
            catch (Exception e)
            {
                return View();
            }
        }

        // GET: CompraController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                HttpClient cliente = new HttpClient();

                Task<HttpResponseMessage> task1 = cliente.GetAsync("http://localhost:11960/api/compra/" + id);
                task1.Wait();

                if (task1.Result.IsSuccessStatusCode)
                {
                    Task<string> task2 = task1.Result.Content.ReadAsStringAsync();
                    task2.Wait();

                    string respuestaJson = task2.Result;
                    ViewModelCompleto compra = JsonConvert.DeserializeObject<ViewModelCompleto>(respuestaJson);
                    
                    return View(compra);
                }
                else
                {
                    ViewModelCompleto compra = new ViewModelCompleto();
                    ViewBag.Error = "Ocurrio un error";
                    return View(compra);
                }
            }
            catch (Exception e)
            {
                return View();
            }
        }

        // GET: CompraController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CompraController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ViewModelCompleto c)
        {
            try
            {
                if (c == null)
                {
                    ViewBag.Error = "Datos invalidos";
                    return View(c);
                }

                HttpClient cliente = new HttpClient();

                Task<HttpResponseMessage> task1 = cliente.PostAsJsonAsync("http://localhost:11960/api/compra/", c);
                task1.Wait();

                if (task1.Result.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Error = "Datos incorrectos";
                    return View(c);
                }
            }
            catch (Exception e)
            {
                return View();
            }
        }



        // GET: CompraController/BuscarPorTipoPlanta/5
        public ActionResult BuscarPorTipoPlanta()
        {
            ViewModelCompleto vmCompleto = new ViewModelCompleto();
            vmCompleto.ListaTiposPlanta = TraerListaTipoPlantas();
            return View(vmCompleto);
        }

        // POST: CompraController/BuscarPorTipoPlanta/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BuscarPorTipoPlanta(ViewModelCompleto vmRecibido)
        {
            try
            {
                ViewModelCompleto vmCompleto = new ViewModelCompleto();
                vmCompleto.ListaTiposPlanta = TraerListaTipoPlantas();

                if (vmRecibido.idTipoSeleccionado == 0)
                {
                    ViewBag.Error = "Datos invalidos";
                    return View(vmCompleto);
                }

                HttpClient cliente = new HttpClient();

                Task<HttpResponseMessage> task1 = cliente.GetAsync("http://localhost:11960/api/compra/filtrarportipo/" + vmRecibido.idTipoSeleccionado);
                task1.Wait();

                if (task1.Result.IsSuccessStatusCode)
                {
                    Task<string> task2 = task1.Result.Content.ReadAsStringAsync();
                    task2.Wait();

                    string bodyResp = task2.Result;
                    vmCompleto.ListaCompras = JsonConvert.DeserializeObject<List<ViewModelCompra>>(bodyResp); 

                    return View(vmCompleto); 
                }
                else
                {
                    ViewBag.Error = "No se encontraron compras para ese tipo de planta";
                    return View(vmCompleto);
                }
            }
            catch (Exception e)
            {
                ViewBag.Error = "Ocurrio un error interno";
                return View();
            }
        }

        [HttpGet]
        public IEnumerable<ViewModelTipoPlanta> TraerListaTipoPlantas()
        {
            try
            {
                HttpClient cliente = new HttpClient();

                Task<HttpResponseMessage> task = cliente.GetAsync("http://localhost:11960/api/compra/listaTiposPlanta");
                task.Wait();

                if (task.Result.IsSuccessStatusCode)
                {
                    Task<string> task2 = task.Result.Content.ReadAsStringAsync();
                    task2.Wait();

                    string respuestaJson = task2.Result;
                    var listado = JsonConvert.DeserializeObject<List<ViewModelTipoPlanta>>(respuestaJson);

                    return listado;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}