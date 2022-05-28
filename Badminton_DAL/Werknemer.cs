using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badminton_DAL
{
    [Table("Personeel")]
    public partial class Werknemer
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
        [MaxLength(50)]
        public string Adres { get; set; }

        [Required]
        [MaxLength(50)]
        public string Gemeente { get; set; }

        [Required]
        [MaxLength(50)]
        public string Telefoonnummer { get; set; }

        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        public int ClubId { get; set; }

        public int FunctieId { get; set; }

        public Functie Functie { get; set; }
        public Club Club { get; set; }

        
    }
}
