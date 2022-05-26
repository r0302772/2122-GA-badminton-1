using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Badminton_DAL
{
    [Table("Gebruiker")]
   public class Gebruiker
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Gebruikersnaam { get; set; }
        [Required]
        
        public string Wachtwoord { get; set; }
    }
}
