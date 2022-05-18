using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badminton_DAL
{
    [Table("Wedstrijd")]
   public class Wedstrijd
    {
        [Key]
       
        public int Id { get; set; }

        //[Required(ErrorMessage ="Score is verplicht")]
        public int Score { get; set; }

        public string Seizoen { get; set; }

        public CategorieSpelerWedstrijd CategorieSpelerWedstrijd { get; set; }
    }
}
