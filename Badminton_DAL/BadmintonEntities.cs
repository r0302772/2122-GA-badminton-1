using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace Badminton_DAL
{
    public class BadmintonEntities : DbContext
    {
        public BadmintonEntities() : base("BadmintonDB")
        {

        }

        public DbSet<Speler> Spelers { get; set; }
    }
}
