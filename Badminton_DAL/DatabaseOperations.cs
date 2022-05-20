using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Badminton_DAL
{
    public class DatabaseOperations
    {
        #region Speler
        public static Speler GetSpelerByPK(int pk)
        {
            using (BadmintonEntities badmintonEntities = new BadmintonEntities())
            {
                return badmintonEntities.Spelers
                    .Include(x => x.Geslacht)
                    .Include(x => x.Club)
                    .Where(x => x.Id == pk).SingleOrDefault();
            }
        }

        public static List<Speler> GetSpelers()
        {
            using (BadmintonEntities badmintonEntities = new BadmintonEntities())
            {
                return badmintonEntities.Spelers.Include(x => x.Geslacht).ToList();
            }
        }

        public static List<Speler> GetSpelersByNaam(string naam)
        {
            using (BadmintonEntities badmintonEntities = new BadmintonEntities())
            {
                return badmintonEntities.Spelers
                    .Where(x => (x.Voornaam.Contains(naam)) || (x.Familienaam.Contains(naam))).ToList();
            }
        }

        public static List<Speler> GetSpelerByClubId(int id)
        {
            using (BadmintonEntities badmintonEntities = new BadmintonEntities())
            {
                return badmintonEntities.Spelers
                    .Where(x => x.Id == id).ToList();
            }
        }
        //Werkt
        public static int SpelerToevoegen(Speler speler)
        {
            try
            {
                using (BadmintonEntities badmintonEntities = new BadmintonEntities())
                {
                    badmintonEntities.Spelers.Add(speler);
                    return badmintonEntities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                FileOperations.FoutLoggen(ex);
                return 0;
            }
        }

        //Werkt
        public static int SpelerAanpassen(Speler speler)
        {
            try
            {
                using (BadmintonEntities badmintonEntities = new BadmintonEntities())
                {

                    badmintonEntities.Entry(speler).State = EntityState.Modified;
                    return badmintonEntities.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                FileOperations.FoutLoggen(ex);
                return 0;
            }
        }

        //Werkt
        public static int SpelerVerwijderen(Speler speler)
        {
            try
            {
                using (BadmintonEntities badmintonEntities = new BadmintonEntities())
                {

                    badmintonEntities.Entry(speler).State = EntityState.Deleted;
                    return badmintonEntities.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                FileOperations.FoutLoggen(ex);
                return 0;
            }
        }
        #endregion

        #region Club
        //testen
        public static List<Club> GetClubs()
        {
            using (BadmintonEntities badmintonEntities = new BadmintonEntities())
            {
                return badmintonEntities.Clubs.ToList();
            }
        }

        //testen
        public static List<Club> GetClubsByNaam(string naam)
        {
            using (BadmintonEntities badmintonEntities = new BadmintonEntities())
            {
                return badmintonEntities.Clubs
                    .Where(x => x.Clubnaam.Contains(naam)).ToList();
            }
        }



        //testen
        public static int ClubToevoegen(Club club)
        {
            try
            {
                using (BadmintonEntities badmintonEntities = new BadmintonEntities())
                {
                    badmintonEntities.Clubs.Add(club);
                    return badmintonEntities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                FileOperations.FoutLoggen(ex);
                return 0;
            }
        }

        //testen
        public static int ClubAanpassen(Club club)
        {
            try
            {
                using (BadmintonEntities badmintonEntities = new BadmintonEntities())
                {

                    badmintonEntities.Entry(club).State = EntityState.Modified;
                    return badmintonEntities.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                FileOperations.FoutLoggen(ex);
                return 0;
            }
        }

        //testen
        public static int ClubVerwijderen(Club club)
        {
            try
            {
                using (BadmintonEntities badmintonEntities = new BadmintonEntities())
                {

                    badmintonEntities.Entry(club).State = EntityState.Deleted;
                    return badmintonEntities.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                FileOperations.FoutLoggen(ex);
                return 0;
            }
        }
        #endregion

        #region Geslacht

        public static List<Geslacht> GetGeslachten()
        {
            using (BadmintonEntities badmintonEntities = new BadmintonEntities())
            {
                return badmintonEntities.Geslachten.ToList();
            }
        }

        public static Geslacht GetGeslachtById(int id)
        {
            using (BadmintonEntities badmintonEntities = new BadmintonEntities())
            {
                return badmintonEntities.Geslachten.Include(x => x.Spelers).Where(g => g.Id == id).SingleOrDefault();

            }
        }
        #endregion

        #region
        public static Gebruiker GetGebruikerById(int id)
        {
            using (BadmintonEntities entities = new BadmintonEntities())
            {
                return entities.Gebruikers.Where(x => x.Id == id).SingleOrDefault();
            }
        }
        #endregion
    }
}
