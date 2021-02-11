using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using MvcCorePeliculaANS.Extension;
using MvcCorePeliculaANS.Models;
using MvcCorePeliculaANS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCorePeliculaANS.ViewComponents
{
    public class MenuGeneroViewComponent : ViewComponent
    {
        private IRepositoriesPeliculas repo;
      
        public MenuGeneroViewComponent(IRepositoriesPeliculas repo)
        {
            this.repo = repo;
  
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Genero> generos = this.repo.GetAllGeneros();
           int cantidad= HttpContext.Session.GetObject<int>("CantidadPelis");
            if (HttpContext.Session.GetObject<int>("CantidadPelis") != 0)
            {
                cantidad = HttpContext.Session.GetObject<int>("CantidadPelis");
            }

            ViewData["Cantidad"] = cantidad;
            return View(generos);
        }

    }
}
