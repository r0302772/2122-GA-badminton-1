using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badminton_DAL
{
    [Table("Clubs")]
    public partial class Club
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Clubnaam { get; set; }

        [Required]
        [MaxLength(50)]
        public string Adres { get; set; }

        [Required]
        [MaxLength(50)]
        public string Gemeente { get; set; }

        [Required]
        public DateTime DatumOpgericht { get; set; }

        [Required]
        [MaxLength(50)]
        public string Telefoonnummer { get; set; }

        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

    }
}
