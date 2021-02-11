using Microsoft.EntityFrameworkCore;
using MvcCorePeliculaANS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCorePeliculaANS.Data
{
    public class PeliculasDbContext:DbContext
    {

        public PeliculasDbContext(DbContextOptions<PeliculasDbContext> options) : base(options)
        {

        }

        public DbSet<Genero> Generos { get; set; }

        public DbSet<Peliculas> Peliculas { get; set; }

        public DbSet<VistaPeli> VistaPeliculas { get; set; }
    }
}
