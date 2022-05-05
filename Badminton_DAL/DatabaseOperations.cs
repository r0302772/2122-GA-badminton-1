﻿using System;
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
        public static List<Speler> GetSpelers()
        {
            using (BadmintonEntities badmintonEntities = new BadmintonEntities())
            {
                return badmintonEntities.Spelers.ToList();
            }
        }

        public static List<Speler> GetSpelersByNaam(string naam)
        {
            using (BadmintonEntities badmintonEntities = new BadmintonEntities())
            {
                return badmintonEntities.Spelers
                    .Where(x => (x.Voornaam == naam) || (x.Familienaam == naam)).ToList();
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
                    .Where(x => (x.Clubnaam == naam)).ToList();
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
    }
}
