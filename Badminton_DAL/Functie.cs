using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badminton_DAL
{
    [Table("Functie")]
   public class Functie
    {
        [Key]
        public int Id { get; set; }

        public string Naam { get; set; }

        public ICollection<Werknemer> Werknemers { get; set; }
    }
}
