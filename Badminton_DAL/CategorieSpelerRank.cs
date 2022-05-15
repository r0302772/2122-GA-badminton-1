using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badminton_DAL
{
    [Table("CategorieSpelerRank")]
   public class CategorieSpelerRank
    {
        [Key]
        public int Id { get; set; }

        public int CategorieId { get; set; }

        public int SpelerId { get; set; }

        public int RankId { get; set; }

        public Speler Speler { get; set; }
        
       // public ICollection<Speler> Spelers { get; set; }
    }
}
