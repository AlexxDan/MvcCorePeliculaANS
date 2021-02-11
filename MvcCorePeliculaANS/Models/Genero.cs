using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCorePeliculaANS.Models
{
    [Table("Generos")]
    public class Genero
    {
        [Key]
        [Column("IdGenero")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdGenero { get; set; }


        [Column("Genero")]
        public String GeneroName { get; set; }
    }
}
