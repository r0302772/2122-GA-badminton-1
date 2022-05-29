using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Badminton_DAL.BaseModels;

namespace Badminton_DAL
{
    public partial class CategorieSpelerWedstrijd : BasisKlasse
    {
        public override string this[string columnName]
        {
            get
            {
                if (columnName == /*nameof(Voornaam)*/ "SpelerHome1" && SpelerHome1Id<0)
                {
                    return "SpelerHome1 is een verplicht veld!";
                }
                if (columnName == /*nameof(Voornaam)*/ "SpelerHome2" && SpelerHome2Id<0)
                {
                    return "SpelerHome2 is een verplicht veld!";
                }
                if (columnName == /*nameof(Voornaam)*/ "SpelerAway1" && SpelerAway1Id<0)
                {
                    return "SpelerAway1 is een verplicht veld!";
                }
                if (columnName == /*nameof(Voornaam)*/ "SpelerAway2" && SpelerAway2Id<0)
                {
                    return "SpelerAway2 is een verplicht veld!";
                }
                if (columnName == /*nameof(Voornaam)*/ "Categorie" && CategorieId<0)
                {
                    return "Categorie is een verplicht veld!";
                }
                if (columnName == /*nameof(Voornaam)*/ "Wedstrijd" && WedstrijdId<0)
                {
                    return "Wedstrijd is een verplicht veld!";
                }


                return "";
            }
        }

    }
}
