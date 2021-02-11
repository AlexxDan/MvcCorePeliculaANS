using Microsoft.AspNetCore.Mvc;
using MvcCorePeliculaANS.Extension;
using MvcCorePeliculaANS.Models;
using MvcCorePeliculaANS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCorePeliculaANS.Controllers
{
    public class PeliculasController : Controller
    {
        private IRepositoriesPeliculas repo;

        public PeliculasController(IRepositoriesPeliculas repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            List<VistaPeli> pelis = this.repo.GetAllPelis();
            return View(pelis);
        }

        public IActionResult PeliculasGeneros(int idGenero)
        {
           List<VistaPeli> pelicuasByGenero = this.repo.GetPeliculasByGenero(idGenero);

            return View(pelicuasByGenero);
        }

        public IActionResult DetallePelis(int idPelicula)
        {
            List<VistaPeli> pelisSession;
            
            if (HttpContext.Session.GetObject<List<VistaPeli>>("PelisGuardas") == null)
            {
                pelisSession = new List<VistaPeli>();
            }
            else
            {
                pelisSession = HttpContext.Session.GetObject<List<VistaPeli>>("PelisGuardas");
              
            }

            if (pelisSession.Exists(z=>z.IdPelicula==idPelicula) == false)
            {
                Peliculas pelicula = this.repo.PeliculaDetails(idPelicula);
                return View(pelicula);
            }else
            {   
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public IActionResult DetallePelis(int idPelicula, String titulo, int precio, string imagen, int idGenero)
        {
            VistaPeli peliculaguardar = new VistaPeli();
            peliculaguardar.IdPelicula = idPelicula;
            peliculaguardar.Titulo = titulo;
            peliculaguardar.Precio = precio;
            peliculaguardar.Foto = imagen;

            List<VistaPeli> pelisSession;
            int cantidad = 0;
            int total = 0;
            if (HttpContext.Session.GetObject<List<VistaPeli>>("PelisGuardas") == null)
            {
                pelisSession = new List<VistaPeli>();
                cantidad = 0;
            }
            else
            {
                pelisSession = HttpContext.Session.GetObject<List<VistaPeli>>("PelisGuardas");
                cantidad = HttpContext.Session.GetObject<int>("CantidadPelis");
                total = HttpContext.Session.GetObject<int>("Total");
            }

            if (pelisSession.Contains(peliculaguardar) == false)
            {
                pelisSession.Add(peliculaguardar);
                cantidad++;
                total += peliculaguardar.Precio;
                HttpContext.Session.SetObject("CantidadPelis", cantidad);
                HttpContext.Session.SetObject("PelisGuardas", pelisSession);
                HttpContext.Session.SetObject("Total", total);

            }
            return RedirectToAction("PeliculasGeneros", "Peliculas", new { idGenero = idGenero });
        }


        public IActionResult PagarPeliculas()
        {
            List<VistaPeli> pelisSession = HttpContext.Session.GetObject<List<VistaPeli>>("PelisGuardas");

            int suma = HttpContext.Session.GetObject<int>("Total");
           

            ViewData["Total"] = suma;

            return View(pelisSession);
        }
    }
}
