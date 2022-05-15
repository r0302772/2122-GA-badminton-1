using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Badminton_DAL
{
    [Table("CategorieWedstrijd")]
    public class CategorieSpelerWedstrijd
    {
        [Key]
        public int Id { get; set; }

        public int SpelerId { get; set; }
        public int Wedstrijd { get; set; }

        public ICollection<Wedstrijd> Wedstrijden { get; set; }

    }
}
