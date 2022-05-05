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

        //Werkt nog niet
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

        //Werkt nog niet
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
    }
}
