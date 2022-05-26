using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Badminton_DAL
{
    [Table("CategorieSpelerWedstrijd")]
    public class CategorieSpelerWedstrijd
    {
        [Key]
        public int Id { get; set; }

        public int SpelerHome1Id { get; set; }
        public int? SpelerHome2Id { get; set; }
        public int SpelerAway1Id { get; set; }
        public int? SpelerAway2Id { get; set; }
        public Speler SpelerHome1 { get; set; }
        public Speler SpelerHome2 { get; set; }
        public Speler SpelerAway1 { get; set; }
        public Speler SpelerAway2 { get; set; }

        public int CategorieId { get; set; }

        public Categorie Categorie { get; set; }

        public int WedstrijdId { get; set; }
        public Wedstrijd Wedstrijd { get; set; }
    }
}
