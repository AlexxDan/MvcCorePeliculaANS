using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCorePeliculaANS.Models
{
    [Table("VistaMainPelis")]
    public class VistaPeli
    {
        [Key]
        [Column("IdPelicula")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdPelicula { get; set; }

        [Column("Titulo")]
        public String Titulo { get; set; }
        [Column("Foto")]
        public String Foto { get; set; }

        [Column("Precio")]
        public int Precio { get; set; }
    }
}
