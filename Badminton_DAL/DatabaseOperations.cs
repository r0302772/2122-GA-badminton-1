using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

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
                    .Where(x => x.ClubID == id).ToList();
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

        #region Werknemer
        public static Werknemer GetWerknemerByPK(int pk)
        {
            using (BadmintonEntities badmintonEntities = new BadmintonEntities())
            {
                return badmintonEntities.Personeel
                    .Include(x => x.Functie)
                    .Include(x => x.Club)
                    .Where(x => x.Id == pk).SingleOrDefault();
            }
        }

        public static List<Werknemer> GetWerkenemerByClub(Club club)
        {
            using (BadmintonEntities badmintonEntities = new BadmintonEntities())
            {
                return badmintonEntities.Personeel
                    .Include(x=> x.Club)
                    .Include(x => x.Functie)
                    .Where(x => x.ClubId == club.Id)
                    .ToList();
            }
        }

        public static List<Werknemer> GetWerknemer()
        {
            using (BadmintonEntities badmintonEntities = new BadmintonEntities())
            {
                return badmintonEntities.Personeel
                    .Include(x => x.Functie)
                    .Include(y => y.Club)
                    .ToList();
            }
        }

 

        public static List<Werknemer> GetWerknemerByClubId(int id)
        {
            using (BadmintonEntities badmintonEntities = new BadmintonEntities())
            {
                return badmintonEntities.Personeel
                    .Where(x => x.ClubId == id).ToList();
            }
        }
        //Werkt
        public static int WerknemerToevoegen(Werknemer werknemer)
        {
            try
            {
                using (BadmintonEntities badmintonEntities = new BadmintonEntities())
                {
                    badmintonEntities.Personeel.Add(werknemer);
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
        public static int WerknemerAanpassen(Werknemer werknemer)
        {
            try
            {
                using (BadmintonEntities badmintonEntities = new BadmintonEntities())
                {

                    badmintonEntities.Entry(werknemer).State = EntityState.Modified;
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
        public static int WerknemerVerwijderen(Werknemer werknemer)
        {
            try
            {
                using (BadmintonEntities badmintonEntities = new BadmintonEntities())
                {

                    badmintonEntities.Entry(werknemer).State = EntityState.Deleted;
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

        #region Functie
        public static List<Functie> GetFuncties()
        {
            using (BadmintonEntities badmintonEntities = new BadmintonEntities())
            {
                return badmintonEntities.Functies.ToList();
            }
        }

        public static Functie GetFunctieById(int id)
        {
            using (BadmintonEntities badmintonEntities = new BadmintonEntities())
            {
                return badmintonEntities.Functies.Include(x => x.Werknemers).Where(f => f.Id == id).SingleOrDefault();

            }
        }
        #endregion

        #region gebruiker
        public static Gebruiker GetGebruikerById(int id)
        {
            using (BadmintonEntities entities = new BadmintonEntities())
            {
                return entities.Gebruikers.Where(x => x.Id == id).SingleOrDefault();
            }
        }
        #endregion

        #region CategorieSpelerWedstrijd
        public static List<CategorieSpelerWedstrijd> GetCategorieSpelerWedstrijden()
        {
            using (BadmintonEntities badmintonEntities = new BadmintonEntities())
            {
                return badmintonEntities.CategorienSpelerWedstrijden
                    .Include(x => x.SpelerHome1)
                    .Include(x => x.SpelerHome2)
                    .Include(x => x.SpelerAway1)
                    .Include(x => x.SpelerAway2)
                    .Include(x => x.Wedstrijd)
                    .ToList();
            }
        }
        #endregion
        #region Wedstrijden
        public static List<Wedstrijd> GetWedstrijden()
        {
            using (BadmintonEntities badmintonEntities = new BadmintonEntities())
            {
                return badmintonEntities.Wedstrijden
                    .ToList();
            }
        }
        public static int WedstrijdToevoegen(Wedstrijd wedstrijdRecord)
        {
            try
            {
                using (BadmintonEntities badmintonEntities = new BadmintonEntities())
                {
                    badmintonEntities.Wedstrijden.Add(wedstrijdRecord);
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
        #region Categories

        public static List<Categorie> GetCategories()
        {
            using (BadmintonEntities badmintonEntities = new BadmintonEntities())
            {
                return badmintonEntities.Categorien
                    .ToList();
            }
        }
        #endregion
    }
}
