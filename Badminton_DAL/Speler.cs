using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Badminton_DAL
{
    [Table("Spelers")]
    public class Speler
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
        [MaxLength(1)]
        public string Geslacht { get; set; }

        [Required]
       
        public DateTime Geboortedatum { get; set; }

        [Required]
        [MaxLength(50)]
        public string Telefoonnummer { get; set; }

        [Required]
        [MaxLength(50)]
        public string Email { get; set; }
    }
}
