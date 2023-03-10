using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Badminton_DAL
{
    [Table("Spelers")]
    public partial class Speler
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Voornaam { get; set; }

        [Required]
        [MaxLength(50)]
        public string Familienaam { get; set; }

        
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        public DateTime Geboortedatum { get; set; }

        [Required]
        [MaxLength(50)]
        public string Telefoonnummer { get; set; }

        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        public int GeslachtID { get; set; }
        public Geslacht Geslacht { get; set; }

        public int? ClubID { get; set; }
        public Club Club { get; set; }

       

        public string VolledigeNaam
        {
            get { return Voornaam + " " + Familienaam; }
        }

        public ICollection<CategorieSpelerWedstrijd> CategorieSpelerWedstrijden { get; set; }
       
    }
}
