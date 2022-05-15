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
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Werknemer> Personeel { get; set; }
        public DbSet<Geslacht> Geslachten { get; set; }
        public DbSet<Wedstrijd> Wedstrijden { get; set; }
        public DbSet<CategorieSpelerWedstrijd> CategorienSpelersWedstrijden { get; set; }
        public DbSet<CategorieSpeler> CategoriesSpelers { get; set; }
        public DbSet<CategorieSpelerRank> CategoriesSpelersRanks { get; set; }
        public DbSet<Categorie> Categorien { get; set; }
      
        public DbSet<Functie> Functies { get; set; }

        
    }
}
