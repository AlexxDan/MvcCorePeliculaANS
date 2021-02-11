using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MvcCorePeliculaANS.Data;
using MvcCorePeliculaANS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCorePeliculaANS.Repositories
{
    #region Procedimientos Vistas
    //create view VistaMainPelis
    //as
    //select IdPelicula, Titulo, Foto, Precio,IdGenero
    //from Peliculas
    //go
    //create procedure PeliculasByGenero
    //(@idGenero int)
    //as
    //select IdPelicula, Titulo, Foto, Precio from VistaMainPelis
    //where IdGenero = @idGenero
    //go

    //Procediemiento de Paginar Peliculas Funcional , pero no implementado
    //create Procedure PaginarPeliculas
    //(@posicion int, @registro int out,@idGenero int)
    //as
    //select @registro = count(IdPelicula) from VistaMainPelis
    //where IdGenero = @idGenero
    //select IdPelicula, Titulo, Foto, Precio from
    //(
    //select ROW_NUMBER() over (order by IdPelicula) as Posicion, 
    //IdPelicula, Titulo, Foto, Precio
    //from VistaMainPelis
    //where IdGenero=@idGenero
    //) consulta
    //where Posicion>@posicion and Posicion<(@posicion +4)
    //go


    #endregion
    public class RepositoriesPeliculas:IRepositoriesPeliculas
    {
        private PeliculasDbContext context;
    
        public RepositoriesPeliculas(PeliculasDbContext context) { this.context = context; }

        public List<Genero> GetAllGeneros()
        {

            return this.context.Generos.ToList();
        }
        public List<VistaPeli> GetAllPelis()
        {
            return this.context.VistaPeliculas.ToList();
        }
        public List<VistaPeli> GetPeliculasByGenero(int idGenero)
        {
            String sql = "PeliculasByGenero @idGenero";

            SqlParameter idGeneroParmeter = new SqlParameter("@idGenero", idGenero);
            List<VistaPeli> pelisbyGnero = this.context.VistaPeliculas.FromSqlRaw(sql, idGeneroParmeter).ToList();

            return pelisbyGnero;
        }

        public Peliculas PeliculaDetails(int idPelicula)
        {
            var consulta = from datos in this.context.Peliculas
                           where datos.IdPelicula == idPelicula
                           select datos;

            return consulta.FirstOrDefault();
        }
    }
}
