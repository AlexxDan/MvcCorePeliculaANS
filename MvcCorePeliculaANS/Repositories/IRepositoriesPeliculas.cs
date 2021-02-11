using MvcCorePeliculaANS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCorePeliculaANS.Repositories
{
    public interface IRepositoriesPeliculas
    {
        List<Genero> GetAllGeneros();

        List<VistaPeli> GetPeliculasByGenero(int idGenero);

        List<VistaPeli> PaginarPelisByGenero(int posicion,int idGenero, ref int registro);

        List<VistaPeli> GetAllPelis();

        Peliculas PeliculaDetails(int idPelicula);
    }
}
