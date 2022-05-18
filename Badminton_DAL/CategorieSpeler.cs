using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Badminton_DAL
{
    [Table("CategorieSpeler")]
    public class CategorieSpeler
    {
        [Key]
        public int Id { get; set; }



        public int SpelerId { get; set; }

        public Speler Speler { get; set; }

        public int CategorieId { get; set; }

        public Categorie Categorie { get; set; }
    }
}
