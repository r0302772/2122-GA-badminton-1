using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badminton_DAL
{  
    [Table("Categorie")]
   public class Categorie
    {
        [Key]
        public int Id { get; set; }

        public string Naam { get; set; }
        public ICollection< CategorieSpeler> CategoriesSpelers { get; set; }
    }
}
