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
        public int ScoreHome { get; set; }
        public int ScoreAway { get; set; }
        public string Seizoen { get; set; }

        public ICollection<CategorieSpelerWedstrijd> CategorieSpelerWedstrijden { get; set; }

        public bool IsGeldig()
        {
            //throw new NotImplementedException();
            return true;
        }
    }
}
