using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badminton_DAL
{
    [Table("Rank")]
    public class Rank
    {
        [Key]
        public int Id { get; set; }

        public int Niveau { get; set; }

        public ICollection<CategorieSpelerRank> CategoriesSpelersRanks { get; set; }
    }
}
